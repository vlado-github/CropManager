using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFServiceWebRole1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IJournalService" in both code and config file together.
    [ServiceContract]
    public interface IJournalService
    {
        [OperationContract]
        [WebInvoke(
            Method = "POST",
            UriTemplate = "InsertJournal",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        int InsertJournal(Journal journal);

        [OperationContract]
        [WebInvoke(
           Method = "GET",
           UriTemplate = "SelectJournalByCropId?crop_id={crop_id}",
           BodyStyle = WebMessageBodyStyle.WrappedRequest,
           ResponseFormat = WebMessageFormat.Json,
           RequestFormat = WebMessageFormat.Json)]
        List<Journal> SelectJournalByCropId(int crop_id);
    }

    [DataContract]
    public class Journal
    {
        [DataMember(Name = "journalid")]
        public int JournalId { get; set; }
        [DataMember(Name = "dateentered")]
        public DateTime DateEntered { get; set; }
        [DataMember(Name = "description")]
        public String Description { get; set; }
        [DataMember(Name = "journalimage")]
        public byte[] JournalImage { get; set; }
        [DataMember(Name = "cropid")]
        public int CropId { get; set; } 
    }
}
