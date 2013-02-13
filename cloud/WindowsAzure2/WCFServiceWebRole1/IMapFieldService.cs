using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFServiceWebRole1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMapFieldService" in both code and config file together.
    [ServiceContract]
    public interface IMapFieldService
    {
        [OperationContract]
        [WebInvoke(
            Method = "POST",
            UriTemplate = "InsertMapField",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        int InsertMapField(MapField mapField);

        [OperationContract]
        [WebInvoke(
            Method = "POST",
            UriTemplate = "DeleteMapField",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        void DeleteMapField(int field_id);

        [OperationContract]
        [WebInvoke(
            Method = "GET",
            UriTemplate = "SelectMapRecordsByFieldId?field_id={field_id}",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        List<int> SelectMapRecordsByFieldId(int field_id);

    }

    [DataContract]
    public class MapField
    {
        [DataMember(Name = "mapfieldid")]
        public int MapFieldId { get; set; }
        [DataMember(Name = "fieldid")]
        public int FieldId { get; set; }
        [DataMember(Name = "mapid")]
        public int MapId { get; set; }
    }
}
