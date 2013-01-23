using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestProject.CropServiceReference;

namespace UnitTestProject
{
    [TestClass]
    public class CropUnitTest
    {
        [TestMethod]
        public void CropInsertTest()
        {
             CropServiceClient client = null;

             try
             {
                 //GetData test
                 client = new CropServiceClient();
                 Crop crop = new Crop();
                 crop.Name = "Psenica";
                 crop.CropType = "MN98";
                 crop.FertilizingTime = new DateTime(2013, 04, 16);
                 crop.FieldFK = 2;
                 crop.HarvestTime = new DateTime(2013, 05, 05);
                 crop.HillingTime = new DateTime(2013, 03, 03);
                 crop.IllnessFK = 1;
                 crop.JournalFK = 1;
                 crop.timeOfPlanting = new DateTime(2013, 02, 20);
                 crop.WateringFrequency = 2;
                 crop.WateringPeriod = "mjesec";

                 client.InsertCropData(crop);



             }catch(Exception e){
                    Console.WriteLine("Exception encounter: {0}", e.Message);
             }

        }
    }
}
