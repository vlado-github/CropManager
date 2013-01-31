using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;

namespace WCFServiceWebRole1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TimePeriodsService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select TimePeriodsService.svc or TimePeriodsService.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class TimePeriodsService : ITimePeriodsService
    {
        public List<TimePeriod> SelectAllTimePeriods()
        {
            List<TimePeriod> timePeriods = new List<TimePeriod>();
            using (SqlConnection con = DBConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("SelectAllTimePeriods", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();

                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                DataTable timePeriodsTable = ds.Tables[0];

                if (timePeriodsTable == null)
                {
                    return null;
                }
                else
                {
                    foreach (DataRow row in timePeriodsTable.Rows)
                    {
                        TimePeriod timePeriod = new TimePeriod();
                        timePeriod.TimePeriodId = Int16.Parse(row[0].ToString());
                        timePeriod.Type = row[1].ToString();

                        timePeriods.Add(timePeriod);
                    }
                }
                con.Close();
            }
            return timePeriods;
        }
    }
}
