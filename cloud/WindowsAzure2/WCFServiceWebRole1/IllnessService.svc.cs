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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "IllnessService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select IllnessService.svc or IllnessService.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class IllnessService : IIllnessService
    {
        public int InsertIllness(Illness illness)
        {
            int id = 0;
            using (SqlConnection con = DBConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("InsertJournal", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@name", illness.Name));
                cmd.Parameters.Add(new SqlParameter("@type", illness.Type));
                cmd.Parameters.Add(new SqlParameter("@date_from", illness.DateFrom));
                cmd.Parameters.Add(new SqlParameter("@date_to", illness.DateTo));
                cmd.Parameters.Add(new SqlParameter("@percentage_effected", illness.PercetageInfected));
                cmd.Parameters.Add(new SqlParameter("@image", @"c:\asdf.jpg"));
                cmd.Parameters.Add(new SqlParameter("@diagnose", illness.Diagnose));
                cmd.Parameters.Add(new SqlParameter("@crop_id_fk", illness.CropId));
                cmd.Parameters.Add(new SqlParameter("@journal_id_fk", illness.JournalId));

                con.Open();
                //cmd.ExecuteNonQuery();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                DataTable result = ds.Tables[0];
                foreach (DataRow row in result.Rows)
                {
                    id = Int16.Parse(row[0].ToString());
                }
                con.Close();
            }
            return id;
        }

        public List<Illness> SelectIllnessesByCropId(int crop_id)
        {
            List<Illness> illnesses = new List<Illness>();
            try
            {
                using (SqlConnection con = DBConnection.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("SelectIllnessByCropId", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@crop_id", crop_id));
                    con.Open();

                    SqlDataAdapter ad = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    ad.Fill(ds);
                    DataTable maps = ds.Tables[0];
                    if (maps == null)
                    {
                        return null;
                    }
                    else
                    {
                        foreach (DataRow row in maps.Rows)
                        {
                            Illness illness = new Illness();
                            illness.IllnessId = Int16.Parse(row[0].ToString());
                            illness.Name = row[1].ToString();
                            illness.Type = row[2].ToString();
                            illness.DateFrom = DateTime.Parse(row[3].ToString());
                            illness.DateTo = DateTime.Parse(row[4].ToString());
                            illness.PercetageInfected = Double.Parse(row[5].ToString());
                            //illness.image
                            illness.Diagnose = row[6].ToString();
                            illness.CropId = Int16.Parse(row[7].ToString());
                            illness.JournalId = Int16.Parse(row[8].ToString());
                            illnesses.Add(illness);
                        }
                    }
                    con.Close();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            return illnesses;
        }
    }
}
