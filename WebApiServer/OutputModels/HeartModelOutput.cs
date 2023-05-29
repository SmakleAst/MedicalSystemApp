using Microsoft.ML.Data;

namespace WebApiServer.OutputModels
{
    internal class HeartModelOutput
    {
        [ColumnName(@"age")]
        public float Age { get; set; }

        [ColumnName(@"sex")]
        public float Sex { get; set; }

        [ColumnName(@"cp")]
        public float Cp { get; set; }

        [ColumnName(@"trestbps")]
        public float Trestbps { get; set; }

        [ColumnName(@"chol")]
        public float Chol { get; set; }

        [ColumnName(@"fbs")]
        public float Fbs { get; set; }

        [ColumnName(@"restecg")]
        public float Restecg { get; set; }

        [ColumnName(@"thalach")]
        public float Thalach { get; set; }

        [ColumnName(@"exang")]
        public float Exang { get; set; }

        [ColumnName(@"oldpeak")]
        public float Oldpeak { get; set; }

        [ColumnName(@"slope")]
        public float Slope { get; set; }

        [ColumnName(@"ca")]
        public float Ca { get; set; }

        [ColumnName(@"thal")]
        public float Thal { get; set; }

        [ColumnName(@"target")]
        public uint Target { get; set; }

        [ColumnName(@"Features")]
        public float[] Features { get; set; }

        [ColumnName(@"PredictedLabel")]
        public float PredictedLabel { get; set; }

        [ColumnName(@"Score")]
        public float[] Score { get; set; }
    }
}
