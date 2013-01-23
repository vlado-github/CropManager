using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFServiceWebRole1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICropService" in both code and config file together.
    [ServiceContract]
    public interface ICropService
    {
        [OperationContract]
        void InsertCropData(Crop crop);

        [OperationContract]
        void DeleteCropData(int crop_id);
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
