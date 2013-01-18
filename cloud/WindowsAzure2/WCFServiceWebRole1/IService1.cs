using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFServiceWebRole1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        void InsertCropData(Crop crop);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }

    [DataContract]
    public class Crop
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string CropType { get; set; }
        [DataMember]
        public DateTime timeOfPlanting { get; set; }
        [DataMember]
        public int WateringFrequency { get; set; }
        [DataMember]
        public string WateringPeriod { get; set; }
        [DataMember]
        public DateTime HarvestTime { get; set; }
        [DataMember]
        public DateTime HillingTime { get; set; }
        [DataMember]
        public DateTime FertilizingTime { get; set; }
        [DataMember]
        public int IllnessFK { get; set; }
        [DataMember]
        public int FieldFK { get; set; }
        [DataMember]
        public int JournalFK { get; set; }
    }
}
