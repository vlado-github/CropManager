using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using PhoneApp1.Models;

namespace PhoneApp1.Views
{
    public partial class Journal : PhoneApplicationPage
    {
        public delegate void GetAllCropsCallback(List<CropModel> cropModels);

        public Journal()
        {
            InitializeComponent();

            CropModel cropModel = new CropModel();
            GetAllCropsCallback handler = new GetAllCropsCallback(GetAllCropsCompleted);
            cropModel.GetAllCrops(new Action<List<CropModel>>(handler));
        }

        public void GetAllCropsCompleted(List<CropModel> crops)
        {
            cropPicker.ItemsSource = crops;
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            int selectedCropId = ((CropModel)cropPicker.SelectedItem).Id;
            NavigationService.Navigate(new Uri("/Views/AddJournal.xaml?parameter=" + selectedCropId, UriKind.Relative));
        }

        private void readBtn_Click(object sender, RoutedEventArgs e)
        {
            int selectedCropId = ((CropModel)cropPicker.SelectedItem).Id;
            NavigationService.Navigate(new Uri("/Views/JournalDetails.xaml?parameter=" + selectedCropId, UriKind.Relative));
        }
    }
}