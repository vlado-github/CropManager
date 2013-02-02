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
    public partial class CropDetails : PhoneApplicationPage
    {
        public delegate void GetAllCropsCompleted(List<CropModel> crops);
        public CropDetails()
        {
            InitializeComponent();
            CropModel cropModel = new CropModel();
            GetAllCropsCompleted handler = new GetAllCropsCompleted(LoadCropList);
            cropModel.GetAllCrops(new Action<List<CropModel>>(handler));
        }

        public void LoadCropList(List<CropModel> allCrops)
        {
            cropPicker.ItemsSource = allCrops;
        }

        // Show details button
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            int selectedCropId = ((CropModel)cropPicker.SelectedItem).Id;
            NavigationService.Navigate(new Uri("/CropDetailsPage.xaml?parameter="+selectedCropId, UriKind.Relative));
        }
    }
}