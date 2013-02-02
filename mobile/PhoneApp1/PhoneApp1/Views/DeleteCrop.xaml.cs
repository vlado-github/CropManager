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
    public partial class DeleteCrop : PhoneApplicationPage
    {
        public delegate void GetAllCropsCompleted(List<CropModel> crops);
        CropModel cropModel = null;
        GetAllCropsCompleted handler = null;

        public DeleteCrop()
        {
            InitializeComponent();
            cropModel = new CropModel();
            handler = new GetAllCropsCompleted(LoadCropList);
            cropModel.GetAllCrops(new Action<List<CropModel>>(handler));
        }

        public void LoadCropList(List<CropModel> allCrops)
        {
            cropPicker.ItemsSource = allCrops;
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Delete Item", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                CropModel cropModel = new CropModel();
                int id = ((CropModel)cropPicker.SelectedItem).Id;
                cropModel.DeleteCropById(id);

                cropModel.GetAllCrops(new Action<List<CropModel>>(handler));
            }
        }
    }
}