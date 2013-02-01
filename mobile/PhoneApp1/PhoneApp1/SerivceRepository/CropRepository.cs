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
using System.Collections.Generic;

namespace PhoneApp1.ServiceRepository
{
    public class CropRepository
    {
        Crop crop = null;
        CropModel cropModel = null;
        Func<int, int> insertCropCallback = null;
        Action<List<CropModel>> getAllCropsCallback = null;

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

        public void getAllCrops(Action<List<CropModel>> callback)
        {
            CropServiceClient cropSvc = new CropServiceClient();
            getAllCropsCallback = callback;
            cropSvc.SelectCropsAsync();
            cropSvc.SelectCropsCompleted += new EventHandler
            <SelectCropsCompletedEventArgs>(cropSvc_GetAllCrops);
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

        private void cropSvc_GetAllCrops(object sender, SelectCropsCompletedEventArgs e)
        {
            IEnumerable<Crop> crops = (IEnumerable<Crop>) e.Result;
            List<Crop> cropList = new List<Crop>(crops);
            List<CropModel> cropModelList = new List<CropModel>();
            foreach (Crop c in cropList)
            {
                CropModel cm = mapCropToCropModel(c);
                cropModelList.Add(cm);
            }
            getAllCropsCallback(cropModelList);
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

        // Maps DataContract from service to ViewModel
        private CropModel mapCropToCropModel(Crop cm)
        {
            CropModel crop = new CropModel();
            crop.Name = cm.name;
            crop.Type = cm.croptype;
            crop.TimeOfPlanting = cm.timeofplanting;
            crop.AvatarImage = cm.avatarimage;
            crop.CoverageValue = cm.fieldcoverage;
            crop.WateringFrequency = cm.wateringfrequency;
            crop.WateringPeriod = cm.wateringperiod;
            crop.HarvestTime = cm.harvesttime;
            crop.HillingTime = cm.hillingtime;
            crop.FertilizingTime = cm.fertilizingtime;
            crop.FieldId = cm.fieldid;

            return crop;
        }
    }
}
