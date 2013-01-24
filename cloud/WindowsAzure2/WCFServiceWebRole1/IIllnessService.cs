using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFServiceWebRole1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IIllnessService" in both code and config file together.
    [ServiceContract]
    public interface IIllnessService
    {
        [OperationContract]
        [WebInvoke(
            Method = "POST",
            UriTemplate = "InsertIllness",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        int InsertIllness(Illness illness);

        [OperationContract]
        [WebInvoke(
          Method = "GET",
          UriTemplate = "SelectIllnessesByCropId?crop_id={crop_id}",
          BodyStyle = WebMessageBodyStyle.WrappedRequest,
          ResponseFormat = WebMessageFormat.Json,
          RequestFormat = WebMessageFormat.Json)]
        List<Illness> SelectIllnessesByCropId(int crop_id);
    }

    [DataContract]
    public class Illness
    {
        [DataMember(Name="illnessid")]
        public int IllnessId { get; set; }
        [DataMember(Name = "name")]
        public String Name { get; set; }
        [DataMember(Name = "type")]
        public String Type { get; set; }
        [DataMember(Name = "datefrom")]
        public DateTime DateFrom { get; set; }
        [DataMember(Name = "dateto")]
        public DateTime DateTo { get; set; }
        [DataMember(Name = "percentageinfected")]
        public double PercetageInfected { get; set; }
        [DataMember(Name = "illnessimage")]
        public byte[] IllnessImage { get; set; }
        [DataMember(Name = "diagnose")]
        public String Diagnose { get; set; }
        [DataMember(Name = "cropid")]
        public int CropId { get; set; }
        [DataMember(Name = "journalid")]
        public int JournalId { get; set; }
    }
}
