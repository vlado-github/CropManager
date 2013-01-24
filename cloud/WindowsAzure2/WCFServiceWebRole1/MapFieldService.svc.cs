using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFServiceWebRole1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MapFieldService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MapFieldService.svc or MapFieldService.svc.cs at the Solution Explorer and start debugging.
    public class MapFieldService : IMapFieldService
    {
        public int InsertMapField(MapField mapField)
        {
            int id = 0;
            using (SqlConnection con = DBConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("InsertMapField", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@field_id_fk", mapField.FieldId));
                cmd.Parameters.Add(new SqlParameter("@map_id_fk", mapField.MapId));
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

        public void DeleteMapField(int field_id)
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("DeleteMapField", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@field_id", field_id));
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public List<int> SelectMapRecordsByFieldId(int field_id)
        {
            List<int> mapRecords = new List<int>();
            using (SqlConnection con = DBConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("SelectMapRecordsByFieldId", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@field_id", field_id));
                con.Open();
                //cmd.ExecuteNonQuery();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                DataTable result = ds.Tables[0];
                foreach (DataRow row in result.Rows)
                {
                    int id = Int16.Parse(row[0].ToString());
                    mapRecords.Add(id);
                }
                con.Close();
            }
            return mapRecords;
        }
    }
}
