using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;

namespace WCFServiceWebRole1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CropService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CropService.svc or CropService.svc.cs at the Solution Explorer and start debugging.
   [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class CropService : ICropService
    {
        public int InsertCropData(Crop crop)
        {
            int id = 0;
            using (SqlConnection con = DBConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("InsertCrop", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@name", crop.Name));
                cmd.Parameters.Add(new SqlParameter("@crop_type", crop.CropType));
                cmd.Parameters.Add(new SqlParameter("@time_of_planting", crop.timeOfPlanting));
                cmd.Parameters.Add(new SqlParameter("@avatar_image", crop.AvatarImage));
                cmd.Parameters.Add(new SqlParameter("@watering_frequency", crop.WateringFrequency));
                cmd.Parameters.Add(new SqlParameter("@watering_period", crop.WateringPeriod));
                cmd.Parameters.Add(new SqlParameter("@harvest_time", crop.HarvestTime));
                cmd.Parameters.Add(new SqlParameter("@hilling_time", crop.HillingTime));
                cmd.Parameters.Add(new SqlParameter("@fertillizing_time", crop.FertilizingTime));
                cmd.Parameters.Add(new SqlParameter("@field_coverage", crop.FieldCoverage));
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

        public void DeleteCropData(int crop_id)
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("DeleteCrop", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@crop_id", crop_id));
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public Crop SelectCropById(int crop_id)
        {
            Crop crop = new Crop();
            try
            {
                using (SqlConnection con = DBConnection.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("SelectCropById", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id_crop", crop_id));
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
                            crop.CropId = Int16.Parse(row[0].ToString());
                            crop.Name = row[1].ToString();
                            crop.CropType = row[2].ToString();
                            crop.timeOfPlanting = DateTime.Parse(row[3].ToString());
                            crop.AvatarImage = row[4] as byte[];
                            crop.WateringFrequency = Int16.Parse(row[5].ToString());
                            crop.WateringPeriod = row[6].ToString();
                            crop.HarvestTime = DateTime.Parse(row[7].ToString());
                            crop.HillingTime = DateTime.Parse(row[8].ToString());
                            crop.FertilizingTime = DateTime.Parse(row[9].ToString());
                            crop.FieldCoverage = Double.Parse(row[10].ToString());
                        }
                    }
                    con.Close();
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            
            return crop;
        }

        public List<Crop> SelectCrops()
        {
            List<Crop> crops = new List<Crop>();
            using (SqlConnection con = DBConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("SelectCrops", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
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
                        Crop crop = new Crop();
                        crop.CropId = Int16.Parse(row[0].ToString());
                        crop.Name = row[1].ToString();
                        crop.CropType = row[2].ToString();                  
                        crops.Add(crop);
                    }
                }
                con.Close();
            }
            
            return crops;
        }
    }
}
