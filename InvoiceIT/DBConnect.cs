using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace InvoiceIT
{
    public class DBConnect
    {
        public static SqlConnection CreateCon()
        {
            string str = ConfigurationManager.ConnectionStrings["invoiceitcon"].ConnectionString;
            SqlConnection con = new SqlConnection(str);

            con.Open();

            return con;
        }
        public static void DropConn(SqlConnection con)
        {
            if (con.State == System.Data.ConnectionState.Open)
                con.Close();
                con.Dispose();
        }

        internal class DropCon
        {
        }
    }
}