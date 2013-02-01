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
using Microsoft.Phone.Tasks;
using System.IO;

namespace PhoneApp1.Views
{
    public partial class AddCrop : PhoneApplicationPage
    {
        byte[] avatarImage = null;
        public delegate void GetAllFieldsCallback(List<FieldModel> fields);
        public delegate void GetAllTimePeriodsCallback(List<TimePeriodModel> tpms);
        public delegate void SaveCropCallback(int cropId);

        public AddCrop()
        {
            InitializeComponent();
            GetAllFieldsCallback handlerFields = new GetAllFieldsCallback(LoadFieldList);
            FieldModel fm = new FieldModel();
            fm.GetAllFields(new Action<List<FieldModel>>(handlerFields));

            GetAllTimePeriodsCallback handlerTpms = new GetAllTimePeriodsCallback(LoadTimePeriodList);
            TimePeriodModel tpm = new TimePeriodModel();
            tpm.GetAllTimePeriods(new Action<List<TimePeriodModel>>(handlerTpms));
        }

        public void LoadFieldList(List<FieldModel> fields)
        {
            fieldPicker.ItemsSource = fields;
        }

        public void LoadTimePeriodList(List<TimePeriodModel> tpms)
        {
            timeSortPicker.ItemsSource = tpms;
        }

        public void DisplaySaveCropToastMsg(int id)
        {
            MessageBox.Show("Saved successfully.");
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            CropModel cropModel = new CropModel();
            cropModel.Name = nameField.Text;
            cropModel.Type = typeField.Text;
            cropModel.TimeOfPlanting = timeOfPlatning.Value == null ? new DateTime() : (DateTime)timeOfPlatning.Value;
            cropModel.AvatarImage = avatarImage;
            cropModel.FieldId = fieldPicker.SelectedItem == null ? 0 : ((FieldModel)fieldPicker.SelectedItem).Id;
            cropModel.CoverageValue = Double.Parse(coverageValue.Text);
            cropModel.WateringFrequency = Int16.Parse(waterFreqPicker.SelectedItem.ToString());
            cropModel.WateringPeriod = timeSortPicker.SelectedIndex.ToString();
            cropModel.HarvestTime = timeOfHarvest.Value == null ? new DateTime() : (DateTime)timeOfHarvest.Value;
            cropModel.HillingTime = timeOfHilling.Value == null ? new DateTime() : (DateTime)timeOfHilling.Value;
            cropModel.FertilizingTime = timeOfFertilizing.Value == null ? new DateTime() : (DateTime)timeOfFertilizing.Value;
            cropModel.IllnessId = 0;//Int16.Parse(illnessField.Text);
           
            SaveCropCallback handlerCrop = new SaveCropCallback(DisplaySaveCropToastMsg);

            cropModel.Save(new Action<int>(handlerCrop));
        }

        private void photoBtn_Click(object sender, RoutedEventArgs e)
        {
            var task = new CameraCaptureTask();
            task.Completed += new EventHandler<PhotoResult>(photo_ChooserTaskCompleted);
            task.Show();
        }
        private void photo_ChooserTaskCompleted(object sender, PhotoResult e)
        {
            Stream photoStream = e.ChosenPhoto;
            photoName.Text = e.OriginalFileName;
            var memoryStream = new MemoryStream();
            photoStream.CopyTo(memoryStream);
            avatarImage = memoryStream.ToArray();
        }
    }
}