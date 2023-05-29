using Microsoft.ML;
using WebApiServer.InputModels;
using WebApiServer.OutputModels;

MLContext heartMlContext = new MLContext();
MLContext lungMlContext = new MLContext();
MLContext hepatitisMlContext = new MLContext();

// Load Trained Model
DataViewSchema heartPredictionPipelineSchema;
ITransformer heartPredictionPipeline = heartMlContext.Model.Load("D:\\Guap\\Diplom\\MedicalSystemApp\\WebApiServer\\HeartFailureModel.zip", out heartPredictionPipelineSchema);
DataViewSchema lungPredictionPipelineSchema;
ITransformer lungPredictionPipeline = lungMlContext.Model.Load("D:\\Guap\\Diplom\\MedicalSystemApp\\WebApiServer\\XRayChestModel.zip", out lungPredictionPipelineSchema);
DataViewSchema hepatitisPredictionPipelineSchema;
ITransformer hepatitisPredictionPipeline = hepatitisMlContext.Model.Load("D:\\Guap\\Diplom\\MedicalSystemApp\\WebApiServer\\HepatitisPredictModel.zip", out hepatitisPredictionPipelineSchema);

PredictionEngine<HeartModelInput, HeartModelOutput> heartPredictionEngine = heartMlContext.Model.CreatePredictionEngine<HeartModelInput, HeartModelOutput>(heartPredictionPipeline);
PredictionEngine<LungModelInput, LungModelOutput> lungPredictionEngine = lungMlContext.Model.CreatePredictionEngine<LungModelInput, LungModelOutput>(lungPredictionPipeline);
PredictionEngine<HepatitisModelInput, HepatitisModelOutput> hepatitisPredictionEngine = hepatitisMlContext.Model.CreatePredictionEngine<HepatitisModelInput, HepatitisModelOutput>(hepatitisPredictionPipeline);

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (context) =>
{
    var response = context.Response;
    var request = context.Request;
    var path = request.Path;
    
    if (path == "/heart" && request.Method == "POST")
    {
        await GetHeartFailurePredict(response, request);
    }
    else if (path == "/lung" && request.Method == "POST")
    {
        await GetLungFailurePredict(response, request);
    }
    else if (path == "/hepatitis" && request.Method == "POST")
    {
        await GetHepatitisFailurePredict(response, request);
    }
});

app.Run();

async Task GetHeartFailurePredict(HttpResponse response, HttpRequest request)
{
    HeartModelInput? heartModelInputData = await request.ReadFromJsonAsync<HeartModelInput>();

    if (heartModelInputData != null)
    {
        var predictionResult = heartPredictionEngine.Predict(heartModelInputData);

        if (predictionResult.PredictedLabel == 0)
        {
            await response.WriteAsJsonAsync($"Состояние в норме - {predictionResult.Score.Max():p0}");
        }
        else if (predictionResult.PredictedLabel == 1)
        {
            await response.WriteAsJsonAsync($"Есть риск заболевания - {predictionResult.Score.Max():p0}");
        }
    }
}

async Task GetLungFailurePredict(HttpResponse response, HttpRequest request)
{
    LungModelInput? lungModelInputData = await request.ReadFromJsonAsync<LungModelInput>();

    if (lungModelInputData != null)
    {
        var predictionResult = lungPredictionEngine.Predict(lungModelInputData);
        await response.WriteAsJsonAsync($"{predictionResult.PredictedLabel} - {predictionResult.Score.Max():p0}");
    }
}

async Task GetHepatitisFailurePredict(HttpResponse response, HttpRequest request)
{
    HepatitisModelInput? hepatitisModelInputData = await request.ReadFromJsonAsync<HepatitisModelInput>();

    if (hepatitisModelInputData != null)
    {
        var predictionResult = hepatitisPredictionEngine.Predict(hepatitisModelInputData);

        if (predictionResult.PredictedLabel.Equals("0=Blood Donor"))
        {
            await response.WriteAsJsonAsync($"Состояние в норме - {predictionResult.Score.Max():p0}");
        }
        else if (predictionResult.PredictedLabel.Equals("0s=suspect Blood Donor"))
        {
            await response.WriteAsJsonAsync($"Есть предпосылки к\nразвитию заболеваний - {predictionResult.Score.Max():p0}");
        }
        else if (predictionResult.PredictedLabel.Equals("1=Hepatitis"))
        {
            await response.WriteAsJsonAsync($"Гепатит - {predictionResult.Score.Max():p0}");
        }
        else if (predictionResult.PredictedLabel.Equals("2=Fibrosis"))
        {
            await response.WriteAsJsonAsync($"Фиброз - {predictionResult.Score.Max():p0}");
        }
        else if (predictionResult.PredictedLabel.Equals("3=Cirrhosis"))
        {
            await response.WriteAsJsonAsync($"Цирроз - {predictionResult.Score.Max():p0}");
        }
    }
}
