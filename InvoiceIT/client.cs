using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;

namespace InvoiceIT
{
    public class Client
    {
        public int Client_Id { get; set; }

        public string CompName { get; set; }

        public string CompAdd1 { get; set; }

        public string CompAdd2 { get; set; }

        public string CompLocation { get; set; }

        public string CompCode { get; set; }

        public string ContactFname { get; set; }

        public string ContactLname { get; set; }

        public string ContactEmail { get; set; }

        public string ContactMobile { get; set; }

        public string BillTo { get; set; }

        public string ClientStatus { get; set; }

        public string Message { get; set; }

        // Add a new client

        public string AddClient(NameValueCollection NewClientData)
        {
            this.CompName = NewClientData["txtclicompname"];
            

            this.CompAdd2 = NewClientData["txtcopadd2"];
            this.CompCode = NewClientData["txtcompcod"];
            this.CompLocation = NewClientData["txtcomploc"];
            this.ContactFname = NewClientData["txtconfnam"];
            this.ContactLname = NewClientData["txtconlnam"];
            this.ContactEmail = NewClientData["txtconemail"];
            this.ContactMobile = NewClientData["txtconmob"];
            this.BillTo = NewClientData["drpbillto"];
            this.ClientStatus = NewClientData["drpsts"];

            SqlConnection con = DBConnect.CreateCon();

            SqlCommand AddClient = new SqlCommand
            {
                CommandText = "INSERT INTO Client(compName,compAdd1,compAdd2,compCode,compLocation,contactFname, " +
                "contactLname,contactEmail,contactMobile,billTo,clientStatus) VALUES('" + CompName + "',  '" + CompAdd1 + "', '" + CompAdd2 + "','" + CompCode + "','" + CompLocation + "','" + ContactFname + "','" + ContactLname + "','" + ContactEmail + "','" + ContactMobile + "','" + BillTo + "','" + ClientStatus + "') ",
                CommandType = CommandType.Text,
                Connection = con
            };

            if (con.State == ConnectionState.Open)
            {
                int a = AddClient.ExecuteNonQuery();
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

        // Get All Clients Details

        public List<List<string>> GetClient() // set retrun type to multidimensional list,string>
        {
            
            SqlConnection con = DBConnect.CreateCon();

            SqlCommand GetAllClient = new SqlCommand
            {
                CommandText = "SELECT * FROM Client",
                CommandType = CommandType.Text,
                Connection = con
            };

            
            List<List<string>> AllClient = new List<List<string>>();

           
            SqlDataReader r = GetAllClient.ExecuteReader();

            if (r.HasRows)
            {
                while (r.Read())
                {
                    // Add each record to the list
                    AllClient.Add(new List<string> { r["client_id"].ToString(), r["compName"].ToString(), r["compAdd1"].ToString(), r["CompAdd2"].ToString(), r["compLocation"].ToString(), r["compCode"].ToString(), r["contactFname"].ToString(), r["contactLname"].ToString(), r["contactEmail"].ToString(), r["contactMobile"].ToString(), r["billTo"].ToString(), r["clientStatus"].ToString() });

                }
                r.Close();
            }
            else
            {
                AllClient = null; // if no records are returned
            }

            DBConnect.DropConn(con);
            return AllClient; // return multidimensional list to caller

        }

        // Display details of a specific client

        public List<string> GetClient(int Client_Id)
        {
            this.Client_Id = Client_Id;
            List<string> details = new List<string>(12);

            // Make connection to the database
            SqlConnection con = DBConnect.CreateCon();

            // SQL sequence to get the specific course the caller wants
            SqlCommand GetClientDetails = new SqlCommand
            {
                CommandText = "SELECT * FROM Client WHERE client_Id = " + Client_Id,
                CommandType = CommandType.Text,
                Connection = con
            };

            SqlDataReader r = GetClientDetails.ExecuteReader();

            if (!r.HasRows)
            {
                details = null;
            }
            else
            {
                while (r.Read())
                {
                    details.Add(r["client_Id"].ToString()); 
                    details.Add(r["compName"].ToString()); 
                    details.Add(r["compAdd1"].ToString()); 
                    details.Add(r["CompAdd2"].ToString());
                    details.Add(r["compLocation"].ToString());
                    details.Add(r["compCode"].ToString());
                    details.Add(r["contactFname"].ToString());
                    details.Add(r["contactLname"].ToString());
                    details.Add(r["contactEmail"].ToString());
                    details.Add(r["contactMobile"].ToString());
                    details.Add(r["billTo"].ToString());
                    details.Add(r["clientStatus"].ToString());


                
                }
            }

            DBConnect.DropConn(con);
            return details;

        }

        // update  client
        public string UpdateClient(NameValueCollection UpdateClientsData)
        {
            this.Client_Id = Convert.ToInt32(UpdateClientsData["CtrlClientID"]);
            this.CompName = UpdateClientsData["cntrlcomname"];
            this.CompAdd1 = UpdateClientsData["cntrlcompadd1"];
            this.CompAdd2 = UpdateClientsData["cntrlcompadd2"];
            this.CompCode = UpdateClientsData["cntrlcompcod"];
            this.CompLocation = UpdateClientsData["cntrlcomploc"];
            this.ContactFname = UpdateClientsData["cntrlconfnam"];
            this.ContactLname = UpdateClientsData["cntrlconlnam"];
            this.ContactEmail = UpdateClientsData["cntrlconemail"];
            this.ContactMobile = UpdateClientsData["cntrlconmob"];
            this.BillTo = UpdateClientsData["cntrlbillto"];
            this.ClientStatus = UpdateClientsData["cntrlclientstats"];

            SqlConnection con = DBConnect.CreateCon();

            SqlCommand UpdateClient = new SqlCommand
            {
                CommandText = "UPDATE CLIENT SET compName ='" + this.CompName+ "',compAdd1 ='" + this.CompAdd1 + "',compAdd2 = '" + this.CompAdd2 + "',compCode = '" + this.CompCode + "',compLocation = '" + this.CompLocation + "',contactFname = '" + this.ContactFname + "', contactLname = '" + this.ContactLname + "',contactEmail = '" + this.ContactEmail + "' ,contactMobile = '" + this.ContactMobile + "',billTo = '" + BillTo + "',clientStatus = '" + this.ClientStatus + "' WHERE Client_Id = " + this.Client_Id,
                CommandType = CommandType.Text,
                Connection = con  
            };

            if (con.State == ConnectionState.Open)
            {
                int a = UpdateClient.ExecuteNonQuery();
                if (a == 0)
                {
                    this.Message = " SQL Query Failed";
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

        public List<string> DeleteClient(int Client_Id)
        {
            this.Client_Id = Client_Id;
            List<string> details = new List<string>(12);

            SqlConnection con = DBConnect.CreateCon();

            // SQL sequence to get the specific course the caller wants
            SqlCommand DeleteClientDetails = new SqlCommand
            {
                CommandText = "Delete FROM Client WHERE client_Id = " + Client_Id,
                CommandType = CommandType.Text,
                Connection = con
            };

            

            if (con.State == ConnectionState.Open)
            {
                int a = DeleteClientDetails.ExecuteNonQuery();
                if (a == 0)
                {
                    this.Message = " SQL Query Failed";
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

            SqlDataReader r = DeleteClientDetails.ExecuteReader();

            if (!r.HasRows)
            {
                details = null;
            }
            else
            {
                while (r.Read())
                {
                    details.Add(r["client_Id"].ToString());
                    details.Add(r["compName"].ToString());
                    details.Add(r["compAdd1"].ToString());
                    details.Add(r["CompAdd2"].ToString());
                    details.Add(r["compLocation"].ToString());
                    details.Add(r["compCode"].ToString());
                    details.Add(r["contactFname"].ToString());
                    details.Add(r["contactLname"].ToString());
                    details.Add(r["contactEmail"].ToString());
                    details.Add(r["contactMobile"].ToString());
                    details.Add(r["billTo"].ToString());
                    details.Add(r["clientStatus"].ToString());



                }
            }

            DBConnect.DropConn(con);
            return details;
           





        }


    }
}


