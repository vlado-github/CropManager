using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFServiceWebRole1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CropService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CropService.svc or CropService.svc.cs at the Solution Explorer and start debugging.
    public class CropService : ICropService
    {
        public void InsertCropData(Crop crop)
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("InsertCrop", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@name", crop.Name));
                cmd.Parameters.Add(new SqlParameter("@crop_type", crop.CropType));
                cmd.Parameters.Add(new SqlParameter("@time_of_planting", crop.timeOfPlanting));
                cmd.Parameters.Add(new SqlParameter("@avatar_image", @"C:\asdfasd.jpg"));
                cmd.Parameters.Add(new SqlParameter("@watering_frequency", crop.WateringFrequency));
                cmd.Parameters.Add(new SqlParameter("@watering_period", crop.WateringPeriod));
                cmd.Parameters.Add(new SqlParameter("@harvest_time", crop.HarvestTime));
                cmd.Parameters.Add(new SqlParameter("@hilling_time", crop.HillingTime));
                cmd.Parameters.Add(new SqlParameter("@fertillizing_time", crop.FertilizingTime));
                cmd.Parameters.Add(new SqlParameter("@illness_foreign_key", crop.IllnessFK));
                cmd.Parameters.Add(new SqlParameter("@field_foreign_key", crop.FieldFK));
                cmd.Parameters.Add(new SqlParameter("@journal_foreign_key", crop.JournalFK));
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
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
    }
}
