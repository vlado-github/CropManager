using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using PhoneApp1.CropServiceReference;
using PhoneApp1.Models;

namespace PhoneApp1.ServiceRepository
{
    public class CropRepository
    {
        Crop crop = null;
        CropModel cropModel = null;
        Func<int, int> insertCropCallback = null;

        // Save crop data
        public void saveCropData(Func<int,int> callback, CropModel cropModel)
        {
            this.cropModel = cropModel;
            insertCropCallback = callback;
            Crop c = mapCropModelToCrop(cropModel);
            CropServiceClient cropSvc = new CropServiceClient();
            cropSvc.InsertCropDataAsync(c);
            cropSvc.InsertCropDataCompleted += new EventHandler
                <InsertCropDataCompletedEventArgs>(cropSvc_InsertCropDataCompleted);
        }

        // Return crop data by id
        public void getCropDataById(int id)
        {
            CropServiceClient cropSvc = new CropServiceClient();
            cropSvc.SelectCropByIdAsync(id);
            cropSvc.SelectCropByIdCompleted += new EventHandler
            <SelectCropByIdCompletedEventArgs>(cropSvc_SelectCropByIdCompleted);
        }

        private void cropSvc_SelectCropByIdCompleted(object sender, SelectCropByIdCompletedEventArgs e)
        {
            crop = e.Result;
        }

        private void cropSvc_InsertCropDataCompleted(object sender, InsertCropDataCompletedEventArgs e)
        {
            int id = e.Result;
            //cropModel.SaveCompleted(id);
            insertCropCallback(id);
        }

        // Maps ViewModel with service DataContract
        private Crop mapCropModelToCrop(CropModel cm)
        {
            Crop crop = new Crop();
            crop.name = cm.Name;
            crop.croptype = cm.Type;
            crop.timeofplanting = cm.TimeOfPlanting;
            crop.avatarimage = cm.AvatarImage;
            crop.fieldcoverage = cm.CoverageValue;
            crop.wateringfrequency = cm.WateringFrequency;
            crop.wateringperiod = cm.WateringPeriod;
            crop.harvesttime = cm.HarvestTime;
            crop.hillingtime = cm.HillingTime;
            crop.fertilizingtime = cm.FertilizingTime;
            crop.fieldid = cm.FieldId;

            return crop;
        }
    }
}
