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
    public partial class CropDetailsPage : PhoneApplicationPage
    {
        public delegate void GetCropByIdCompleted(CropModel cm);
        public CropDetailsPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            string cropIdValue = NavigationContext.QueryString["parameter"];
            int cropId = Int16.Parse(cropIdValue);

            GetCropByIdCompleted handler = new GetCropByIdCompleted(LoadCropById);
            CropModel cropModel = new CropModel();
            cropModel.GetCropById(new Action<CropModel>(handler), cropId);
        }

        public void LoadCropById(CropModel cm)
        {

        }
    }
}