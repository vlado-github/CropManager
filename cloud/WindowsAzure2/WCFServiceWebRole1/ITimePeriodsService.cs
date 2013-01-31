using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFServiceWebRole1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITimePeriodsService" in both code and config file together.
    [ServiceContract]
    public interface ITimePeriodsService
    {
        [OperationContract]
        [WebGet(
            UriTemplate = "SelectAllTimePeriods",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        List<TimePeriod> SelectAllTimePeriods();
    }

    [DataContract]
    public class TimePeriod
    {
        [DataMember(Name = "timeperiodid")]
        public int TimePeriodId { get; set; }
        [DataMember(Name = "type")]
        public String Type { get; set; }
    }
}
