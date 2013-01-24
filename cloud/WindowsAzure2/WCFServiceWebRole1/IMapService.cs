using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFServiceWebRole1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMapService" in both code and config file together.
    [ServiceContract]
    public interface IMapService
    {
        [OperationContract]
        [WebInvoke(
            Method = "POST",
            UriTemplate = "InsertMap",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        int InsertMap(Map map);

        [OperationContract]
        [WebInvoke(
          Method = "POST",
          UriTemplate = "DeleteMap",
          BodyStyle = WebMessageBodyStyle.WrappedRequest,
          ResponseFormat = WebMessageFormat.Json,
          RequestFormat = WebMessageFormat.Json)]
        void DeleteMap(int map_id);

        [OperationContract]
        [WebInvoke(
            Method = "GET",
            UriTemplate = "SelectMapById?map_id={map_id}",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        Map SelectMapById(int map_id);

        [OperationContract]
        [WebGet(
          UriTemplate = "SelectMaps",
          BodyStyle = WebMessageBodyStyle.WrappedRequest,
          ResponseFormat = WebMessageFormat.Json,
          RequestFormat = WebMessageFormat.Json)]
        List<Map> SelectMaps();
    }

    [DataContract]
    public class Map
    {
        [DataMember(Name = "mapid")]
        public int MapId { get; set; }
        [DataMember(Name = "longitude")]
        public double Longitude { get; set; }
        [DataMember(Name = "latitude")]
        public double Latitude { get; set; }
        [DataMember(Name = "field_fk")]
        public int FieldId { get; set; }
    }
}
