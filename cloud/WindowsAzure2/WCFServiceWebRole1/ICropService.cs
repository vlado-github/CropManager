using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFServiceWebRole1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICropService" in both code and config file together.
    [ServiceContract]
    public interface ICropService
    {
        [OperationContract]
        [WebInvoke(
            Method = "POST",
            UriTemplate = "InsertCropData",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        int InsertCropData(Crop crop);

        [OperationContract]
        [WebInvoke(
            Method = "POST",
            UriTemplate = "DeleteCropData",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        void DeleteCropData(int crop_id);

        [OperationContract]
        [WebInvoke(
            Method="GET",
            UriTemplate = "SelectCropById?crop_id={crop_id}",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        Crop SelectCropById(int crop_id);

        [OperationContract]
        [WebGet(
            UriTemplate = "SelectCrops",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        List<Crop> SelectCrops();
    }

    [DataContract]
    public class Crop
    {
        [DataMember(Name="cropid")]
        public int CropId { get; set; }
        [DataMember(Name="name")]
        public string Name { get; set; }
        [DataMember(Name="croptype")]
        public string CropType { get; set; }
        [DataMember(Name="timeofplanting")]
        public DateTime timeOfPlanting { get; set; }
        [DataMember(Name = "avatarimage")]
        public byte[] AvatarImage { get; set; }
        [DataMember(Name = "wateringfrequency")]
        public int WateringFrequency { get; set; }
        [DataMember(Name = "wateringperiod")]
        public string WateringPeriod { get; set; }
        [DataMember(Name = "harvesttime")]
        public DateTime HarvestTime { get; set; }
        [DataMember(Name = "hillingtime")]
        public DateTime HillingTime { get; set; }
        [DataMember(Name = "fertilizingtime")]
        public DateTime FertilizingTime { get; set; }
        [DataMember(Name = "fieldcoverage")]
        public double FieldCoverage { get; set; }
    }
}
