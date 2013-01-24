using AzureTestClient.CropServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureTestClient
{
    class Program
    {
        static void Main(string[] args)
        {
           
            CropServiceClient client = null;

            try
            {
                //GetData test
                client = new CropServiceClient();
                Crop c = client.SelectCropById(1);
                Console.WriteLine("Result: ");
                Console.WriteLine("name = {0}", c.name);

                Crop crop = new Crop();
                crop.name = "Hmelj";
                crop.croptype = "MN98";
                crop.fertilizingtime = new DateTime(2013, 04, 16);
                crop.fieldfk = 2;
                crop.harvesttime = new DateTime(2013, 05, 05);
                crop.hillingtime = new DateTime(2013, 03, 03);
                crop.illnessfk = 1;
                crop.journalfk = 1;
                crop.timeofplanting = new DateTime(2013, 02, 20);
                crop.wateringfrequency = 2;
                crop.wateringperiod = "mjesec";

                int id = client.InsertCropData(crop);

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
                Console.WriteLine("Press any key to close");
                Console.ReadKey();
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
