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
using System.IO;
using System.Windows.Media.Imaging;

namespace PhoneApp1.Views
{
    public partial class CropDetailsPage : PhoneApplicationPage
    {
        public delegate void GetCropByIdCompleted(CropModel cm);
        public delegate void GetFieldByIdCompleted(FieldModel fm);

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
            GetFieldByIdCompleted fieldDataHandler = new GetFieldByIdCompleted(LoadFieldById);
            FieldModel fieldModel = new FieldModel();
            fieldModel.GetFieldById(new Action<FieldModel>(fieldDataHandler), cm.FieldId);
       
            byte[] avatarImageByte = cm.AvatarImage;

            if (avatarImageByte != null)
            {
                MemoryStream ms = new MemoryStream(avatarImageByte);
                BitmapImage avatar = new BitmapImage();
                avatar.SetSource(ms);
                AvatarImg.Source = avatar;
            }

            NameTxt.Text = cm.Name;
            TypeTxt.Text = cm.Type;
            TimeOfPlantingTxt.Text = cm.TimeOfPlanting.ToString("yyyy-MM-dd");
            AreaCoverageTxt.Text = cm.CoverageValue.ToString();
            WateringTxt.Text = cm.WateringFrequency + " X " + cm.WateringPeriod;
            HillingTxt.Text = cm.HillingTime.ToString("yyyy-MM-dd");
            HarvestingTxt.Text = cm.HarvestTime.ToString("yyyy-MM-dd");
            FertilizingTimeTxt.Text = cm.FertilizingTime.ToString("yyyy-MM-dd");
        }

        public void LoadFieldById(FieldModel fm)
        {
            FieldNameTxt.Text = fm.Name;
            AltitudeTxt.Text = fm.Altitude.ToString();
            AreaSizeTxt.Text = fm.AreaSize.ToString() + " [" + fm.AreaSizeMeasure + "]";
        }
    }
}