using MedicalSystemApp.InputModels;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows;
using System.Windows.Controls;

namespace MedicalSystemApp.DiseaseWindows.Hepatitis
{
    /// <summary>
    /// Логика взаимодействия для HepatitisFailurePredictWindow.xaml
    /// </summary>
    public partial class HepatitisFailurePredictWindow : Window
    {
        static HttpClient httpClient = new HttpClient();

        private string Age { get; set; }
        private string Sex { get; set; }
        private string Alb { get; set; }
        private string Alp { get; set; }
        private string Alt { get; set; }
        private string Ast { get; set; }
        private string Bil { get; set; }
        private string Che { get; set; }
        private string Chol { get; set; }
        private string Crea { get; set; }
        private string Ggt { get; set; }
        private string Prot { get; set; }

        public HepatitisFailurePredictWindow()
        {
            InitializeComponent();
        }

        private void Age_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            Age = Convert.ToString(textBox.Text);
            Age = Age.Replace('.', ',');
        }

        private void Sex_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            Sex = Convert.ToString(textBox.Text);
            if (Sex.Equals("Муж"))
            {
                Sex = "m";
            }
            else if (Sex.Equals("Жен"))
            {
                Sex = "f";
            }
        }

        private void Alb_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            Alb = Convert.ToString(textBox.Text);
            Alb = Alb.Replace(".", ",");
        }

        private void Alp_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            Alp = Convert.ToString(textBox.Text);
            Alp = Alp.Replace(".", ",");
        }

        private void Alt_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            Alt = Convert.ToString(textBox.Text);
            Alt = Alt.Replace(".", ",");
        }

        private void Ast_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            Ast = Convert.ToString(textBox.Text);
            Ast = Ast.Replace(".", ",");
        }

        private void Bil_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            Bil = Convert.ToString(textBox.Text);
            Bil = Bil.Replace(".", ",");
        }

        private void Che_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            Che = Convert.ToString(textBox.Text);
            Che = Che.Replace(".", ",");
        }

        private void Chol_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            Chol = Convert.ToString(textBox.Text);
            Chol = Chol.Replace(".", ",");
        }

        private void Crea_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            Crea = Convert.ToString(textBox.Text);
            Crea = Crea.Replace(".", ",");
        }

        private void Ggt_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            Ggt = Convert.ToString(textBox.Text);
            Ggt = Ggt.Replace(".", ",");
        }

        private void Prot_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            Prot = Convert.ToString(textBox.Text);
            Prot = Prot.Replace(".", ",");
        }

        private async void PredictHepatitisFailureButton_OnClick(object sender, RoutedEventArgs E)
        {
            //var result = HepatitisPredictModel.Predict(new HepatitisPredictModel.ModelInput
            //{
            //    Age = float.Parse(Age),
            //    Sex = Sex,
            //    ALB = float.Parse(Alb),
            //    ALP = float.Parse(Alp),
            //    ALT = float.Parse(Alt),
            //    AST = float.Parse(Ast),
            //    BIL = float.Parse(Bil),
            //    CHE = float.Parse(Che),
            //    CHOL = float.Parse(Chol),
            //    CREA = float.Parse(Crea),
            //    GGT = float.Parse(Ggt),
            //    PROT = float.Parse(Prot),
            //});

            //ResultText.Text = $"{result.PredictedLabel} - {result.Score.Max():p0}";
            HepatitisModelInput hepatitisModelInput = new HepatitisModelInput() {
                Age = float.Parse(Age),
                Sex = Sex,
                ALB = float.Parse(Alb),
                ALP = float.Parse(Alp),
                ALT = float.Parse(Alt),
                AST = float.Parse(Ast),
                BIL = float.Parse(Bil),
                CHE = float.Parse(Che),
                CHOL = float.Parse(Chol),
                CREA = float.Parse(Crea),
                GGT = float.Parse(Ggt),
                PROT = float.Parse(Prot),
            };
            using var response = await httpClient.PostAsJsonAsync("https://localhost:44311/hepatitis", hepatitisModelInput);
            string? result = await response.Content.ReadFromJsonAsync<string>();
            //ResultText.Text = $"{result.PredictedLabel} - {result.Score.Max():p0}";
            ResultText.Text = result;
        }
    }
}
