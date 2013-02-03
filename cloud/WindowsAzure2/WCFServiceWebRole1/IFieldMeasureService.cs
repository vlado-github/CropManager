using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFServiceWebRole1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IFieldMeasureService" in both code and config file together.
    [ServiceContract]
    public interface IFieldMeasureService
    {
        [OperationContract]
        [WebGet(
            UriTemplate = "GetAllMeasures",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        List<Measure> GetAllMeasures();
    }

    [DataContract]
    public class Measure{
        [DataMember(Name = "measureid")]
        public int MeasureId { get; set; }
        [DataMember(Name = "type")]
        public String Type { get; set; }
    }
}
