using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFServiceWebRole1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IFieldService" in both code and config file together.
    [ServiceContract]
    public interface IFieldService
    {
        [OperationContract]
        [WebInvoke(
            Method = "POST",
            UriTemplate = "InsertField",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        int InsertField(Field field);

        [OperationContract]
        [WebInvoke(
           Method = "POST",
           UriTemplate = "DeleteField",
           BodyStyle = WebMessageBodyStyle.WrappedRequest,
           ResponseFormat = WebMessageFormat.Json,
           RequestFormat = WebMessageFormat.Json)]
        void DeleteField(int field_id);

        [OperationContract]
        [WebInvoke(
            Method = "GET",
            UriTemplate = "SelectFieldById?field_id={field_id}",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        Field SelectFieldById(int field_id);

        [OperationContract]
        [WebGet(
           UriTemplate = "SelectFields",
           BodyStyle = WebMessageBodyStyle.WrappedRequest,
           ResponseFormat = WebMessageFormat.Json,
           RequestFormat = WebMessageFormat.Json)]
        List<Field> SelectFields();
        
    }

    [DataContract]
    public class Field
    {
        [DataMember(Name = "field_id")]
        public int FieldId { get; set; }
        [DataMember(Name = "name")]
        public String Name { get; set; }
        [DataMember(Name = "altitude")]
        public double Altitude { get; set; }
        [DataMember(Name = "areasize")]
        public double AreaSize { get; set; }
        [DataMember(Name = "areasizemeasure")]
        public String AreaSizeMeasure { get; set; }
        [DataMember(Name = "mapid")]
        public int MapId { get; set; }
        [DataMember(Name = "cropid")]
        public int CropId { get; set; }
    }
}
