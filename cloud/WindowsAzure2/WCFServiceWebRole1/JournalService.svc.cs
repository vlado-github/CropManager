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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "JournalService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select JournalService.svc or JournalService.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class JournalService : IJournalService
    {
        public int InsertJournal(Journal journal)
        {
            int id = 0;
            using (SqlConnection con = DBConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("InsertJournal", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@date_entered", journal.DateEntered));
                cmd.Parameters.Add(new SqlParameter("@description", journal.Description));
                cmd.Parameters.Add(new SqlParameter("@image", @"C:\asdfasd.jpg"));
                cmd.Parameters.Add(new SqlParameter("@crop_id_fk", journal.CropId));
                
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

        public Journal SelectJournalByCropId(int crop_id)
        {
            Journal journal = new Journal();
            try
            {
                using (SqlConnection con = DBConnection.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("SelectJournalByCropId", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@crop_id", crop_id));
                    con.Open();

                    SqlDataAdapter ad = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    ad.Fill(ds);
                    DataTable cropsTable = ds.Tables[0];
                    if (cropsTable == null)
                    {
                        return null;
                    }
                    else
                    {
                        foreach (DataRow row in cropsTable.Rows)
                        {
                            journal.JournalId = Int16.Parse(row[0].ToString());
                            journal.DateEntered = DateTime.Parse(row[1].ToString());
                            journal.Description = row[2].ToString();
                            //TODO journal.JournalImage = row[3];
                            journal.CropId = Int16.Parse(row[4].ToString());
                        }
                    }
                    con.Close();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            return journal;
        }
    }
}
