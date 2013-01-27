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

namespace PhoneApp1.Models
{
    public class CropModel
    {
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

        public void Save()
        {
            try
            {
                CropRepository cropRep = new CropRepository();
                cropRep.saveCropData(this);
            }
            catch (Exception e)
            {
                Console.WriteLine("Crop save: " + e.StackTrace);
            }
        }

        public int SaveCompleted(int id)
        {
            return id;
        }
    }
}
