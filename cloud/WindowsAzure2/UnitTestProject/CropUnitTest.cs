using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestProject.CropServiceReference;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class CropUnitTest
    {
        [TestInitialize]
        public void init()
        {
            //Insert Test data
            CropServiceClient client = new CropServiceClient();
            List<Crop> testCrops = new List<Crop>();

            Crop crop1 = new Crop();
            crop1.name = "Repica";
            crop1.croptype = "MN98";
            crop1.fertilizingtime = new DateTime(2013, 04, 16);
            crop1.fieldfk = 2;
            crop1.harvesttime = new DateTime(2013, 05, 05);
            crop1.hillingtime = new DateTime(2013, 03, 03);
            crop1.illnessfk = 1;
            crop1.journalfk = 1;
            crop1.timeofplanting = new DateTime(2013, 02, 20);
            crop1.wateringfrequency = 2;
            crop1.wateringperiod = "mjesec";

            Crop crop2 = new Crop();
            crop2.name = "Lubenica";
            crop2.croptype = "MN98";
            crop2.fertilizingtime = new DateTime(2013, 04, 16);
            crop2.fieldfk = 2;
            crop2.harvesttime = new DateTime(2013, 05, 05);
            crop2.hillingtime = new DateTime(2013, 03, 03);
            crop2.illnessfk = 1;
            crop2.journalfk = 1;
            crop2.timeofplanting = new DateTime(2013, 02, 20);
            crop2.wateringfrequency = 2;
            crop2.wateringperiod = "mjesec";

            testCrops.Add(crop1);
            testCrops.Add(crop2);

            foreach (Crop c in testCrops)
            {
                client.InsertCropData(c);
            }
        }

        [TestMethod]
        public void CropInsertTest()
        {
             CropServiceClient client = null;

             try
             {
                 //GetData test
                 client = new CropServiceClient();
                 Crop expected = new Crop();
                 expected.name = "Psenica";
                 expected.croptype = "MN98";
                 expected.fertilizingtime = new DateTime(2013, 04, 16);
                 expected.fieldfk = 2;
                 expected.harvesttime = new DateTime(2013, 05, 05);
                 expected.hillingtime = new DateTime(2013, 03, 03);
                 expected.illnessfk = 1;
                 expected.journalfk = 1;
                 expected.timeofplanting = new DateTime(2013, 02, 20);
                 expected.wateringfrequency = 2;
                 expected.wateringperiod = "mjesec";

                 int expectedid = client.InsertCropData(expected);

                 Crop actual = client.SelectCropById(expectedid);

                 Assert.AreEqual(expectedid, actual.cropid);
             }catch(Exception e){
                    Console.WriteLine("Exception encounter: {0}", e.Message);
             }

        }
    }
}
