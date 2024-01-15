using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;

namespace InvoiceIT
{
    public class User
    {
        

        public string User_Fname { get; set; }

        public string User_sysrole { get; set; }

        public string User_Email { get; set; }

        public string User_Passwrd { get; set; }

        public string  Message { get; set; }


        public string AddUser(NameValueCollection NewUserData)
        {
            this.User_Fname = NewUserData["txtusrnam"];
            this.User_sysrole = NewUserData["drsysrol"];
            this.User_Email = NewUserData["txtemail"];
            this.User_Passwrd = NewUserData["txtpasswrd"];
            


            SqlConnection con = DBConnect.CreateCon();

            SqlCommand Adduser = new SqlCommand
            {
                CommandText = "INSERT INTO [user](User_Fname,User_SysRole,User_Pword,User_Email) VALUES('" + User_Fname + "', '" + User_sysrole + "', '" + User_Passwrd + "','" + User_Email + "') ",
                CommandType = CommandType.Text,
                Connection = con
            };

            if (con.State == ConnectionState.Open)
            {
                int a = Adduser.ExecuteNonQuery();
                if (a == 0)
                {
                    this.Message = "Query Failed";
                }
                else
                {
                    this.Message = "Query Succeeded";
                }
            }
            else
            {
                this.Message = "SQL DB Connect Failed";
            }

            DBConnect.DropConn(con);
            return Message;

        }

        public List<string> GetUser(string User_Email, string User_Password)
        {
            this.User_Email = User_Email;
            this.User_Passwrd = User_Password;

            List<string> details = new List<string>(2);

           
            SqlConnection con = DBConnect.CreateCon();

            
            SqlCommand GetUserDetails = new SqlCommand
            {
                CommandText = "SELECT User_Fname, User_SysRole FROM [user] WHERE User_Email = '" + User_Email + "' AND User_Pword = '" + User_Passwrd + "'",
                CommandType = CommandType.Text,
                Connection = con
            };

            SqlDataReader r = GetUserDetails.ExecuteReader();

            if (!r.HasRows)
            {
                details = null;
            }
            else
            {
                while (r.Read())
                {
                    details.Add(r["User_Fname"].ToString()); // Add User_Fname to list index position 0
                    details.Add(r["User_SysRole"].ToString()); // Add User_SysRole to list index position 1
                }
            }

            DBConnect.DropConn(con);
            return details;
        }

        
    }
}