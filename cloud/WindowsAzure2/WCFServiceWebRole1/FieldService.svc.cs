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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "FieldService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select FieldService.svc or FieldService.svc.cs at the Solution Explorer and start debugging.
   [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class FieldService : IFieldService
    {
        public int InsertField(Field field)
        {
            int id = 0;
            using (SqlConnection con = DBConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("InsertField", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@name", field.Name));
                cmd.Parameters.Add(new SqlParameter("@altitude", field.Altitude));
                cmd.Parameters.Add(new SqlParameter("@area_size", field.AreaSize));
                cmd.Parameters.Add(new SqlParameter("@area_size_measure", field.AreaSizeMeasure));
                //cmd.Parameters.Add(new SqlParameter("@map_id_fk", field.MapId));
                //cmd.Parameters.Add(new SqlParameter("@crop_id_fk", field.CropId));
                
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

        public void DeleteField(int field_id)
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("DeleteField", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@field_id", field_id));
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public Field SelectFieldById(int field_id)
        {
            Field field = new Field();
            try
            {
                using (SqlConnection con = DBConnection.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("SelectFieldById", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@field_id", field_id));
                    con.Open();

                    SqlDataAdapter ad = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    ad.Fill(ds);
                    DataTable fieldsTable = ds.Tables[0];
                    if (fieldsTable == null)
                    {
                        return null;
                    }
                    else
                    {
                        foreach (DataRow row in fieldsTable.Rows)
                        {
                            field.FieldId = Int16.Parse(row[0].ToString());
                            field.Name = row[1].ToString();
                            field.Altitude = Double.Parse(row[2].ToString());
                            field.AreaSize = Double.Parse(row[3].ToString());
                            field.AreaSizeMeasure = row[4].ToString();
                            if(row[5] != DBNull.Value)
                                field.MapId = Int16.Parse(row[5].ToString());
                            if (row[6] != DBNull.Value)
                                field.CropId = Int16.Parse(row[6].ToString());
                          
                        }
                    }
                    con.Close();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            return field;
        }

        public List<Field> SelectFields()
        {
            List<Field> fields = new List<Field>();
            using (SqlConnection con = DBConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("SelectFields", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();

                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                DataTable fieldsTable = ds.Tables[0];

                if (fieldsTable == null)
                {
                    return null;
                }
                else
                {
                    foreach (DataRow row in fieldsTable.Rows)
                    {
                        Field field = new Field();
                        field.FieldId = Int16.Parse(row[0].ToString());
                        field.Name = row[1].ToString();
                        fields.Add(field);
                    }
                }
                con.Close();
            }

            return fields;
        }
    }
}
