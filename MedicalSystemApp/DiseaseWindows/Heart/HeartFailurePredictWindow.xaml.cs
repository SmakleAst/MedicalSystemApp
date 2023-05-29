using MedicalSystemApp.InputModels;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows;
using System.Windows.Controls;

namespace MedicalSystemApp.DiseaseWindows.Heart
{
    /// <summary>
    /// Логика взаимодействия для HeartFailurePredictWindow.xaml
    /// </summary>

    public partial class HeartFailurePredictWindow : Window
    {
        static HttpClient httpClient = new HttpClient();

        private string Age { get; set; }
        private string Sex { get; set; }
        private string Cp { get; set; }
        private string Trestbps { get; set; }
        private string Chol { get; set; }
        private string Fbs { get; set; }
        private string Restecg { get; set; }
        private string Thalach { get; set; }
        private string Exang { get; set; }
        private string Oldpeak { get; set; }
        private string Slope { get; set; }
        private string Ca { get; set; }
        private string Thal { get; set; }

        public HeartFailurePredictWindow()
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
                Sex = "1";
            }
            else if (Sex.Equals("Жен"))
            {
                Sex = "0";
            }
        }

        private void Cp_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            Cp = Convert.ToString(textBox.Text);
            Cp = Cp.Replace(".", ",");
        }

        private void Trestbps_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            Trestbps = Convert.ToString(textBox.Text);
            Trestbps = Trestbps.Replace('.', ',');
        }

        private void Chol_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            Chol = Convert.ToString(textBox.Text);
            Chol = Chol.Replace('.', ',');
        }

        private void Fbs_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            Fbs = Convert.ToString(textBox.Text);
            Fbs = Fbs.Replace('.', ',');
        }

        private void Restecg_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            Restecg = Convert.ToString(textBox.Text);
            Restecg = Restecg.Replace('.', ',');
        }

        private void Thalach_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            Thalach = Convert.ToString(textBox.Text);
            Thalach = Thalach.Replace('.', ',');
        }

        private void Exang_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            Exang = Convert.ToString(textBox.Text);
            Exang = Exang.Replace('.', ',');
        }

        private void Oldpeak_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            Oldpeak = Convert.ToString(textBox.Text);
            Oldpeak = Oldpeak.Replace('.', ',');
        }

        private void Slope_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            Slope = Convert.ToString(textBox.Text);
            Slope = Slope.Replace('.', ',');
        }

        private void Ca_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            Ca = Convert.ToString(textBox.Text);
            Ca = Ca.Replace(".", ",");
        }

        private void Thal_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            Thal = Convert.ToString(textBox.Text);
            Thal = Thal.Replace(".", ",");
        }

        private async void PredictHeartFailureButton_OnClick(object sender, RoutedEventArgs E)
        {
            HeartModelInput heartModelInput = new HeartModelInput()
            {
                Age = float.Parse(Age),
                Sex = float.Parse(Sex),
                Cp = float.Parse(Cp),
                Trestbps = float.Parse(Trestbps),
                Chol = float.Parse(Chol),
                Fbs = float.Parse(Fbs),
                Restecg = float.Parse(Restecg),
                Thalach = float.Parse(Thalach),
                Exang = float.Parse(Exang),
                Oldpeak = float.Parse(Oldpeak),
                Slope = float.Parse(Slope),
                Ca = float.Parse(Ca),
            };

            using var response = await httpClient.PostAsJsonAsync("https://localhost:44311/heart", heartModelInput);
            string? result = await response.Content.ReadFromJsonAsync<string>();

            ResultText.Text = result;
        }
    }
}
