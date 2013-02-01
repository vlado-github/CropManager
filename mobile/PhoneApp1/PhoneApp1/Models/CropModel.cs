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
using PhoneApp1.ServiceRepository;
using System.Collections.Generic;

namespace PhoneApp1.Models
{
    public class CropModel
    {
        Action<int> ViewCallback = null;
        Action<List<CropModel>> ViewGetAllCropsCallback = null;
        public delegate int CropSaveCallback(int id);
        public delegate void CropGetAllCallback(List<CropModel> crops);

        public String Name { get; set; }
        public String Type { get; set; }
        public DateTime TimeOfPlanting { get; set; }
        public byte[] AvatarImage { get; set; }
        public int FieldId { get; set; }
        public double CoverageValue { get; set; }
        public int WateringFrequency { get; set; }
        public String WateringPeriod { get; set; }
        public DateTime HarvestTime { get; set; }
        public DateTime HillingTime { get; set; }
        public DateTime FertilizingTime { get; set; }
        public int IllnessId { get; set; }

        public void Save(Action<int> callback)
        {
            try
            {
                CropSaveCallback handler = new CropSaveCallback(SaveCompleted);
                CropRepository cropRep = new CropRepository();
                ViewCallback = callback;
                
                cropRep.saveCropData(new Func<int,int>(handler), this);
            }
            catch (Exception e)
            {
                Console.WriteLine("Crop save: " + e.StackTrace);
            }
        }

        public void GetAllCrops(Action<List<CropModel>> callback)
        {
            try
            {
                CropGetAllCallback handler = new CropGetAllCallback(GetAllCropsCompleted);
                CropRepository cropRep = new CropRepository();
                ViewGetAllCropsCallback = callback;

                cropRep.getAllCrops(new Action<List<CropModel>>(handler));
            }
            catch (Exception e)
            {
                Console.WriteLine("Crop save: " + e.StackTrace);
            }
        }

        public int SaveCompleted(int id)
        {
            ViewCallback(id);
            return id;
        }

        public void GetAllCropsCompleted(List<CropModel> cropList)
        {
            ViewGetAllCropsCallback(cropList);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
