using System.Windows;
using MedicalSystemApp.DiseaseWindows.Heart;
using MedicalSystemApp.DiseaseWindows.Lung;
using MedicalSystemApp.DiseaseWindows.Hepatitis;

namespace MedicalSystemApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LungButton_Click(object sender, RoutedEventArgs e)
        {
            LungFailurePredictWindow lungFailurePredictWindow = new LungFailurePredictWindow();
            lungFailurePredictWindow.Show();
        }

        private void HeartButton_Click(object sender, RoutedEventArgs e)
        {
            HeartFailurePredictWindow heartFailurePredictWindow = new HeartFailurePredictWindow();
            heartFailurePredictWindow.Show();
        }

        private void HepatitisButton_Click(object sender, RoutedEventArgs e)
        {
            HepatitisFailurePredictWindow hepatitisFailurePredictWindow = new HepatitisFailurePredictWindow();
            hepatitisFailurePredictWindow.Show();
        }
    }
}
