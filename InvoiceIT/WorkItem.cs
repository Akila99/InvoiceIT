using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;

namespace InvoiceIT
{
    public class WorkItem
    {
        public int work_item_Id { get; set; }

        public string Date { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public string WorkitmStatus { get; set; }

        public string Comment { get; set; }

        public int Client_Id { get; set; }

        public int Task_Id { get; set; }

        public int Staff_Id { get; set; }


        public string Message { get; set; }

        // Add a new work item
        public string AddWorkItem(NameValueCollection NewWorkItemData)
        {
            this.Client_Id = Convert.ToInt32(NewWorkItemData["CtrlClientList"]);
            this.Task_Id = Convert.ToInt32(NewWorkItemData["CtrlTaskList"]);
            this.Staff_Id = Convert.ToInt32(NewWorkItemData["CtrlStaffList"]);
            
            this.Date = NewWorkItemData["CtrlwrlitmDate"];
            this.StartTime = NewWorkItemData["CtrlwrkitmStartTime"];
            this.EndTime = NewWorkItemData["CtrlwrkitmEndTime"];
            this.WorkitmStatus = NewWorkItemData["CtrlwrkitmStatus"];
            this.Comment = NewWorkItemData["txtcmnt"];



            SqlConnection con = DBConnect.CreateCon();

            SqlCommand AddWorkItem = new SqlCommand
            {
                CommandText = "INSERT INTO Work_Item(date,startTime,endTime,work_ItemStatus,comment,client_Id, task_Id,staff_Id ) VALUES('" + Date + "',  '" + StartTime + "', '" + EndTime + "','" + WorkitmStatus + "','" + Comment + "','" + Client_Id + "','" + Task_Id + "','" + Staff_Id + "') ",
                CommandType = CommandType.Text,
                Connection = con
            };

            if (con.State == ConnectionState.Open)
            {
                int a = AddWorkItem.ExecuteNonQuery();
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
        // Get All  Details

        public List<List<string>> GetWorkitm() // set retrun type to multidimensional list,string>
        {

            SqlConnection con = DBConnect.CreateCon();

            SqlCommand GetAllWorkitm = new SqlCommand
            {
                CommandText = "SELECT * FROM Work_Item",
                CommandType = CommandType.Text,
                Connection = con
            };


            List<List<string>> AllWorkitm = new List<List<string>>();


            SqlDataReader r = GetAllWorkitm.ExecuteReader();

            if (r.HasRows) // If records found then do what follows
            {
                while (r.Read())
                {
                    // Add each record to the list
                    AllWorkitm.Add(new List<string> { r["work_Item_Id"].ToString(), r["date"].ToString(), r["startTime"].ToString(), r["endTime"].ToString(), r["work_itemStatus"].ToString(), r["comment"].ToString(), r["client_Id"].ToString(), r["task_Id"].ToString(), r["staff_Id"].ToString() });


                }
                r.Close();
            }
            else
            {
                AllWorkitm = null; // if no records are returned
            }

            DBConnect.DropConn(con);
            return AllWorkitm; // return multidimensional list to caller

        }

        // Display details of a specific workItem
        public List<string> GetWorkitm(int Work_Item_Id)
        {
            this.work_item_Id = Work_Item_Id;
            List<string> details = new List<string>(9);

            // Make connection to the database
            SqlConnection con = DBConnect.CreateCon();

            // SQL sequence to get the specific staff the caller wants
            SqlCommand GetWorkitmDetails = new SqlCommand
            {
                CommandText = "SELECT * FROM Work_Item WHERE work_Item_Id = " + work_item_Id,
                CommandType = CommandType.Text,
                Connection = con
            };

            SqlDataReader r = GetWorkitmDetails.ExecuteReader();

            if (!r.HasRows)
            {
                details = null;
            }
            else
            {
                while (r.Read())
                {
                    details.Add(r["work_Item_Id"].ToString());
                    details.Add(r["date"].ToString());
                    details.Add(r["startTime"].ToString());
                    details.Add(r["endTime"].ToString());
                    details.Add(r["work_ItemStatus"].ToString());
                    details.Add(r["comment"].ToString());
                    details.Add(r["client_Id"].ToString());
                    details.Add(r["task_Id"].ToString());
                    details.Add(r["staff_Id"].ToString());




                }
            }

            DBConnect.DropConn(con);
            return details;
        }
        public string UpdateWorkItem(NameValueCollection UpdateWorkItemData)

        {
            this.work_item_Id = Convert.ToInt32(UpdateWorkItemData["CtrlworkitemID"]);
            this.Client_Id = Convert.ToInt32(UpdateWorkItemData["CtrlClientList"]);
            this.Task_Id = Convert.ToInt32(UpdateWorkItemData["CtrlTaskList"]);
            this.Staff_Id = Convert.ToInt32(UpdateWorkItemData["CtrlStaffList"]);
            this.Date = UpdateWorkItemData["cntrldate"];
            this.StartTime = UpdateWorkItemData["cntrlstrtime"];
            this.EndTime = UpdateWorkItemData["cntrlendtime"];
            this.WorkitmStatus = UpdateWorkItemData["Ctrlwrkitemtatus"];
            this.Comment = UpdateWorkItemData["cntrlcmnt"];





            SqlConnection con = DBConnect.CreateCon();

            SqlCommand UpdateWorkItem = new SqlCommand
            {
                CommandText = "UPDATE Work_Item SET date ='" + this.Date + "',startTime='" + this.StartTime + "',endTime='" + this.EndTime + "',work_ItemStatus='" + this.WorkitmStatus + "',comment='" + this.Comment + "',client_Id='" + this.Client_Id + "',task_Id='" + this.Task_Id + "',staff_Id='" + this.Staff_Id + "'WHERE work_Item_Id = " + this.work_item_Id,
                CommandType = CommandType.Text,
                Connection = con
            };

            if (con.State == ConnectionState.Open)
            {
                int a = UpdateWorkItem.ExecuteNonQuery();
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



        public List<string> Deletewrkitm(int Work_Item_Id)
        {
            this.work_item_Id = Work_Item_Id;
            List<string> details = new List<string>(9);

            // Make connection to the database
            SqlConnection con = DBConnect.CreateCon();

            // SQL sequence to get the specific staff the caller wants
            SqlCommand DeleteWorkitmDetails = new SqlCommand
            {
                CommandText = "Delete FROM Work_Item WHERE work_Item_Id = " + work_item_Id,
                CommandType = CommandType.Text,
                Connection = con
            };

            if (con.State == ConnectionState.Open)
            {
                int a = DeleteWorkitmDetails.ExecuteNonQuery();
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

            SqlDataReader r = DeleteWorkitmDetails.ExecuteReader();

            if (!r.HasRows)
            {
                details = null;
            }
            else
            {
                while (r.Read())
                {
                    details.Add(r["work_Item_Id"].ToString());
                    details.Add(r["date"].ToString());
                    details.Add(r["startTime"].ToString());
                    details.Add(r["endTime"].ToString());
                    details.Add(r["work_ItemStatus"].ToString());
                    details.Add(r["comment"].ToString());
                    details.Add(r["client_Id"].ToString());
                    details.Add(r["task_Id"].ToString());
                    details.Add(r["staff_Id"].ToString());




                }
            }

            DBConnect.DropConn(con);
            return details;







        }
        }
}