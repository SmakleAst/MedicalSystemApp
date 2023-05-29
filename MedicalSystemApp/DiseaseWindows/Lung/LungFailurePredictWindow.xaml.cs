using MedicalSystemApp.InputModels;
using Microsoft.Win32;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows;
using System.Windows.Media.Imaging;

namespace MedicalSystemApp.DiseaseWindows.Lung
{
    /// <summary>
    /// Логика взаимодействия для LungFailurePredictWindow.xaml
    /// </summary>
    public partial class LungFailurePredictWindow : Window
    {
        static HttpClient httpClient = new HttpClient();

        public LungFailurePredictWindow()
        {
            InitializeComponent();
        }

        private async void OpenImageButton_OnClick(object sender, RoutedEventArgs E)
        {
            var dialog = new OpenFileDialog
            {
                Title = "Выбор картинки",
                Filter = "Картинки|*.jpg;*.jpeg;*.png;*.bmp|Все файлы (*.*)|*.*",
                CheckFileExists = true,
            };

            if (dialog.ShowDialog(this) != true) return;

            var file = dialog.FileName;
            var imageBytes = File.ReadAllBytes(dialog.FileName);

            ImageView.Source = new BitmapImage(new Uri(file));

            //var result = XRayChestModel.Predict(new XRayChestModel.ModelInput
            //{
            //    ImageSource = imageBytes
            //});

            LungModelInput lungModelInput = new LungModelInput() { ImageSource = imageBytes };
            using var response = await httpClient.PostAsJsonAsync("https://localhost:44311/lung", lungModelInput);
            string? result = await response.Content.ReadFromJsonAsync<string>();
            //ResultText.Text = $"{result.PredictedLabel} - {result.Score.Max():p0}";
            ResultText.Text = result;
        }
    }
}
