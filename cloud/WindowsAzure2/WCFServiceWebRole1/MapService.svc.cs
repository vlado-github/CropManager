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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MapService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MapService.svc or MapService.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class MapService : IMapService
    {
        public int InsertMap(Map map)
        {
            int id = 0;
            using (SqlConnection con = DBConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("InsertMap", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@name", map.Longitude));
                cmd.Parameters.Add(new SqlParameter("@altitude", map.Latitude));
                cmd.Parameters.Add(new SqlParameter("@area_size", map.FieldId));

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

        public void DeleteMap(int map_id)
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("DeleteMap", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@map_id", map_id));
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public Map SelectMapById(int map_id)
        {
            Map map = new Map();
            try
            {
                using (SqlConnection con = DBConnection.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("SelectMapById", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@map_id", map_id));
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
                            map.MapId = Int16.Parse(row[0].ToString());
                            map.Longitude = Double.Parse(row[1].ToString());
                            map.Latitude = Double.Parse(row[2].ToString());
                            if(row[3] != DBNull.Value)
                                map.FieldId = Int16.Parse(row[3].ToString());
                        }
                    }
                    con.Close();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            return map;
        }

        public List<Map> SelectMaps()
        {
            List<Map> maps = new List<Map>();
            using (SqlConnection con = DBConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("SelectMaps", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();

                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                DataTable mapsTable = ds.Tables[0];

                if (mapsTable == null)
                {
                    return null;
                }
                else
                {
                    foreach (DataRow row in mapsTable.Rows)
                    {
                        Map map = new Map();
                        map.MapId = Int16.Parse(row[0].ToString());
                        map.Longitude = Double.Parse(row[1].ToString());
                        map.Latitude = Double.Parse(row[2].ToString());
                        map.FieldId = Int16.Parse(row[3].ToString());
                        maps.Add(map);
                    }
                }
                con.Close();
            }

            return maps;
        }
    }
}
