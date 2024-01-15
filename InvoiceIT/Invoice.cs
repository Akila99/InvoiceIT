using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;

namespace InvoiceIT
{
    public class Invoice
    {
        public int Invoice_ID { get; set; }

        public int Client_ID { get; set; }
        

        public string Start_Date { get; set; }
        public string End_Date { get; set; }
        public string Generated_Date { get; set; }
        public string Sent_Date { get; set; }
        public string Payment_Date { get; set; }
        public string Invoice_Status { get; set; }
        public string Message { get; set; }

        public string AddInvoice(NameValueCollection NewInvoiceData)
        {

            this.Client_ID = Convert.ToInt32(NewInvoiceData["CtrlClientList"]);

            this.Start_Date = NewInvoiceData["CtrlstrDate"];

            this.End_Date = NewInvoiceData["CtrlEndDate"];

            this.Generated_Date = NewInvoiceData["CtrlgenDate"];

            this.Sent_Date = NewInvoiceData["CtrlsentDate"];

            this.Payment_Date = NewInvoiceData["CtrlpayDate"];
            this.Invoice_Status = NewInvoiceData["CtrlinvoStatus"];


            SqlConnection con = DBConnect.CreateCon();

            SqlCommand AddInvoice = new SqlCommand
            {
                CommandText = "INSERT Invoice ( startDate, endDate, generatedDate, sentDate, paymentDue, invoiceStatus, client_Id) VALUES ('" + Start_Date + "', '" + End_Date + "', '" + Generated_Date + "', '" + Sent_Date + "', '" + Payment_Date + "', '" + Invoice_Status + "', '" + Client_ID + "')",

                CommandType = CommandType.Text,
                Connection = con


            };




            if (con.State == ConnectionState.Open)
            {

                int a = AddInvoice.ExecuteNonQuery();
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



        public List<List<string>> GetInvoice() // set retrun type to multidimensional list,string>
        {

            SqlConnection con = DBConnect.CreateCon();

            SqlCommand GetAllInvoice = new SqlCommand
            {
                CommandText = "SELECT * FROM Invoice",
                CommandType = CommandType.Text,
                Connection = con
            };


            List<List<string>> AllInvoice = new List<List<string>>();


            SqlDataReader r = GetAllInvoice.ExecuteReader();


            if (r.HasRows)
            {
                while (r.Read())
                {
                    // Add each record to the list
                    AllInvoice.Add(new List<string> { r["invoice_Id"].ToString(), r["StartDate"].ToString(), r["endDate"].ToString(), r["generatedDate"].ToString(), r["sentDate"].ToString(), r["paymentDue"].ToString(), r["invoiceStatus"].ToString(), r["client_Id"].ToString() });

                }
                r.Close();
            }
            else
            {
                AllInvoice = null; // if no records are returned
            }

            DBConnect.DropConn(con);
            return AllInvoice; // return multidimensional list to caller

        }
        public List<string> GetInvoice(int Invoice_Id)
        {
            this.Invoice_ID = Invoice_Id;
            List<string> details = new List<string>(8);

            // Make connection to the database
            SqlConnection con = DBConnect.CreateCon();

            // SQL sequence to get the specific course the caller wants
            SqlCommand GetInvoiceDetails = new SqlCommand
            {
                CommandText = "SELECT * FROM Invoice WHERE invoice_Id = " + Invoice_Id,
                CommandType = CommandType.Text,
                Connection = con
            };

            SqlDataReader r = GetInvoiceDetails.ExecuteReader();

            if (!r.HasRows)
            {
                details = null;
            }
            else
            {
                while (r.Read())
                {
                    details.Add(r["invoice_Id"].ToString());
                    details.Add(r["startDate"].ToString());
                    details.Add(r["endDate"].ToString());
                    details.Add(r["generatedDate"].ToString());
                    details.Add(r["sentDate"].ToString());
                    details.Add(r["paymentDue"].ToString());
                    details.Add(r["invoiceStatus"].ToString());
                    details.Add(r["client_Id"].ToString());

                }
            }

            DBConnect.DropConn(con);
            return details;

        }
        public string UpdateInvoice(NameValueCollection UpdateInvoiceData)

        {
            this.Invoice_ID = Convert.ToInt32(UpdateInvoiceData["CtrlinvoID"]);
            this.Client_ID = Convert.ToInt32(UpdateInvoiceData["CtrlClientList"]);
            this.Start_Date = UpdateInvoiceData["Ctrlinvodate"];
            this.End_Date = UpdateInvoiceData["txtenddate"];
            this.Generated_Date = UpdateInvoiceData["txtgendate"];
            this.Sent_Date = UpdateInvoiceData["txtsendate"];
            this.Payment_Date = UpdateInvoiceData["txtpaydue"];
            this.Invoice_Status = UpdateInvoiceData["upinvoStatus"];





            SqlConnection con = DBConnect.CreateCon();

            SqlCommand UpdateInvoice = new SqlCommand
            {
                CommandText = "UPDATE Invoice SET startDate ='" + this.Start_Date + "',endDate='" + this.End_Date + "',generatedDate='" + this.Generated_Date + "',sentDate='" + this.Sent_Date + "',paymentDue='" + this.Payment_Date + "',invoiceStatus='" + this.Invoice_Status + "',client_Id='" + this.Client_ID + "'WHERE invoice_Id = " + this.Invoice_ID,
                CommandType = CommandType.Text,
                Connection = con
            };

            if (con.State == ConnectionState.Open)
            {
                int a = UpdateInvoice.ExecuteNonQuery();
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
        public List<string> DeleteInvoice(int Invoice_Id)
        {
            this.Invoice_ID = Invoice_Id;
            List<string> details = new List<string>(8);

            // Make connection to the database
            SqlConnection con = DBConnect.CreateCon();

            // SQL sequence to get the specific course the caller wants
            SqlCommand DeleteInvoiceDetails = new SqlCommand
            {
                CommandText = "Delete FROM Invoice WHERE invoice_Id = " + Invoice_Id,
                CommandType = CommandType.Text,
                Connection = con
            };


            if (con.State == ConnectionState.Open)
            {
                int a = DeleteInvoiceDetails.ExecuteNonQuery();
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

            SqlDataReader r = DeleteInvoiceDetails.ExecuteReader();

            if (!r.HasRows)
            {
                details = null;
            }
            else
            {
                while (r.Read())
                {
                    details.Add(r["invoice_Id"].ToString());
                    details.Add(r["startDate"].ToString());
                    details.Add(r["endDate"].ToString());
                    details.Add(r["generatedDate"].ToString());
                    details.Add(r["sentDate"].ToString());
                    details.Add(r["paymentDue"].ToString());
                    details.Add(r["invoiceStatus"].ToString());
                    details.Add(r["client_Id"].ToString());

                }
            }

            DBConnect.DropConn(con);
            return details;


        }

    }
}