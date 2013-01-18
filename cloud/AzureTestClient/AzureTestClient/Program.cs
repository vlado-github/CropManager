using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AzureTestClient.ServiceReference1;

namespace AzureTestClient
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Service1Client client = null;

            try
            {
                //GetData test
                client = new Service1Client();
                Crop crop = new Crop();
                crop.Name = "Kukuruz";
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

                Console.WriteLine("The WCF service called returned: ");

                //GetDataUsingDataContract test
                //CompositeType compositeType = new CompositeType();
                //compositeType.BoolValue = true;
                //compositeType.StringValue = "test";
                //CompositeType responseComposit = client.GetDataUsingDataContract(compositeType);

                //Console.WriteLine("The WCF service called returned: '{0}' '{1}'",
                //                    responseComposit.BoolValue, responseComposit.StringValue);

                Console.WriteLine("Press any key to close");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception encounter: {0}",
                                   e.Message);
            }
            finally
            {
                if (null != client)
                {
                    client.Close();
                }
            }
        }
    }
}
