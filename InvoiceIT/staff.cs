using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;

namespace InvoiceIT
{
    public class Staff
    {
        public int Staff_Id { get; set; }

        public string StaffName { get; set; }

        public string StaffSurname { get; set; }

        public string StaffEmail { get; set; }

        public string StaffMobile { get; set; }

        public string StaffAccessLevel { get; set; }

        public string StaffStatus { get; set; }

        public string Message { get; set; }



        // Add a new Staff
        public string AddStaff(NameValueCollection NewStaffData)
        {
            this.StaffName = NewStaffData["txtstafnm"];
            this.StaffSurname = NewStaffData["txtsurnm"];
            this.StaffEmail = NewStaffData["txtstffemail"];
            this.StaffMobile = NewStaffData["txtstfmob"];
            this.StaffAccessLevel = NewStaffData["dpdwnacclvl"];
            this.StaffStatus = NewStaffData["dodwnsts"];


            SqlConnection con = DBConnect.CreateCon();

            SqlCommand AddStaff = new SqlCommand
            {
                CommandText = "INSERT INTO Staff(staffName,staffSurname,staffEmail,staffMobile,staffAccessLevel,staffStatus) VALUES('" + StaffName + "',  '" + StaffSurname + "', '" + StaffEmail + "','" + StaffMobile + "','" + StaffAccessLevel + "','" + StaffStatus + "') ",
                CommandType = CommandType.Text,
                Connection = con
            };

            if (con.State == ConnectionState.Open)
            {
                int a = AddStaff.ExecuteNonQuery();
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
        // Get All Staff Details

        public List<List<string>> GetStaff() // set retrun type to multidimensional list,string>
        {

            SqlConnection con = DBConnect.CreateCon();

            SqlCommand GetAllStaff = new SqlCommand
            {
                CommandText = "SELECT * FROM Staff",
                CommandType = CommandType.Text,
                Connection = con
            };


            List<List<string>> AllStaff = new List<List<string>>();


            SqlDataReader r = GetAllStaff.ExecuteReader();

            if (r.HasRows) // If records found then do what follows
            {
                while (r.Read())
                {
                    // Add each record to the list

                    AllStaff.Add(new List<string> { r["staff_Id"].ToString(), r["staffName"].ToString(), r["staffSurname"].ToString(), r["staffEmail"].ToString(), r["staffMobile"].ToString(), r["staffAccessLevel"].ToString(), r["staffStatus"].ToString() });

                }
                r.Close();
            }
            else
            {
                AllStaff = null; // if no records are returned
            }

            DBConnect.DropConn(con);
            return AllStaff; // return multidimensional list to caller

        }
        public List<string> GetStaff(int Staff_Id)
        {
            this.Staff_Id = Staff_Id;
            List<string> details = new List<string>(4);

            // Make connection to the database
            SqlConnection con = DBConnect.CreateCon();

            // SQL sequence to get the specific staff the caller wants
            SqlCommand GetStaffDetails = new SqlCommand
            {
                CommandText = "SELECT * FROM Staff WHERE staff_Id = " + Staff_Id,
                CommandType = CommandType.Text,
                Connection = con
            };

            SqlDataReader r = GetStaffDetails.ExecuteReader();

            if (!r.HasRows)
            {
                details = null;
            }
            else
            {
                while (r.Read())
                {
                    details.Add(r["staff_Id"].ToString());
                    details.Add(r["staffName"].ToString());
                    details.Add(r["staffSurname"].ToString());
                    details.Add(r["staffEmail"].ToString());
                    details.Add(r["staffMobile"].ToString());
                    details.Add(r["staffAccessLevel"].ToString());
                    details.Add(r["staffStatus"].ToString());




                }
            }

            DBConnect.DropConn(con);
            return details;


        }
        public string UpdateStaff(NameValueCollection updateStaffData)

        {
            this.Staff_Id = Convert.ToInt32(updateStaffData["CtrlStaffID"]);
            this.StaffName = updateStaffData["cntrlstafnm"];
            this.StaffSurname = updateStaffData["cntrlsurnm"];
            this.StaffEmail = updateStaffData["cntrlstffemail"];
            this.StaffMobile = updateStaffData["cntrlstfmob"];
            this.StaffAccessLevel = updateStaffData["Ctrlacclvl"];
            this.StaffStatus = updateStaffData["Ctrlstfstatus"];
            



            SqlConnection con = DBConnect.CreateCon();

            SqlCommand UpdateStaff = new SqlCommand
            {
                CommandText = "UPDATE Staff SET staffName ='" + this.StaffName + "',staffSurname='" + this.StaffSurname + "',staffEmail='" + this.StaffEmail + "',staffMobile='" + this.StaffMobile + "',staffAccessLevel='" + this.StaffAccessLevel + "',staffStatus='" + this.StaffStatus + "' WHERE Staff_Id = " + this.Staff_Id,
                CommandType = CommandType.Text,
                Connection = con
            };

            if (con.State == ConnectionState.Open)
            {
                int a = UpdateStaff.ExecuteNonQuery();
                if (a == 0)
                {
                    this.Message = "Query Failed";
                }
                else
                {
                    this.Message = "The record has been updated succesfully";
                }
            }
            else
            {
                this.Message = "SQL DB Connect Failed";
            }

            DBConnect.DropConn(con);
            return Message;
        }


        public List<string> DeleteStaff(int Staff_Id)
        {
            this.Staff_Id = Staff_Id;
            List<string> details = new List<string>(4);

            // Make connection to the database
            SqlConnection con = DBConnect.CreateCon();

            // SQL sequence to get the specific staff the caller wants
            SqlCommand DeleteStaffDetails = new SqlCommand
            {
                CommandText = "Delete FROM Staff WHERE staff_Id = " + Staff_Id,
                CommandType = CommandType.Text,
                Connection = con
            };

            if (con.State == ConnectionState.Open)
            {
                int a = DeleteStaffDetails.ExecuteNonQuery();
                if (a == 0)
                {
                    this.Message = "Query Failed";
                }
                else
                {
                    this.Message = "The record has been updated succesfully";
                }
            }
            else
            {
                this.Message = "SQL DB Connect Failed";
            }

            


            SqlDataReader r = DeleteStaffDetails.ExecuteReader();

            if (!r.HasRows)
            {
                details = null;
            }
            else
            {
                while (r.Read())
                {
                    details.Add(r["staff_Id"].ToString());
                    details.Add(r["staffName"].ToString());
                    details.Add(r["staffSurname"].ToString());
                    details.Add(r["staffEmail"].ToString());
                    details.Add(r["staffMobile"].ToString());
                    details.Add(r["staffAccessLevel"].ToString());
                    details.Add(r["staffStatus"].ToString());




                }
            }

            DBConnect.DropConn(con);
            return details;


        }



    }
}

          