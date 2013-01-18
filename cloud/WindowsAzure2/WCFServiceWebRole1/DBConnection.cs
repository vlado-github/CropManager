using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WCFServiceWebRole1
{
    public class DBConnection
    {
        private static String connectionString = "user id=cropdbuser;" +
                                      @"password=nbsx65NB;server=GARFIELD\MSSQLENT;" +
                                       "Trusted_Connection=yes;" +
                                       "database=CropManager; " +
                                       "connection timeout=30";
        private static SqlConnection con = null;

        public static SqlConnection GetConnection()
        {
            if (con == null)
                con = new SqlConnection(connectionString);
            return con;
        }

        public static void CloseConnection()
        {   
            if(con!=null)
                con.Close();
        }

        public static void OpenConnection()
        {
            if (con != null)
                con.Open();
        }
    }
}