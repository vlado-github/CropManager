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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "FieldMeasureService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select FieldMeasureService.svc or FieldMeasureService.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class FieldMeasureService : IFieldMeasureService
    {
        public List<Measure> GetAllMeasures()
        {
            List<Measure> measures = new List<Measure>();
            using (SqlConnection con = DBConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("SelectAllMeasures", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();

                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                DataTable measuresTable = ds.Tables[0];

                if (measuresTable == null)
                {
                    return null;
                }
                else
                {
                    foreach (DataRow row in measuresTable.Rows)
                    {
                        Measure measure = new Measure();
                        measure.MeasureId = Int16.Parse(row[0].ToString());
                        measure.Type = row[1].ToString();

                        measures.Add(measure);
                    }
                }
                con.Close();
            }
            return measures;
        }
    }
}
