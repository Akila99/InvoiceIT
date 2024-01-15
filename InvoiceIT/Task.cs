using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;

namespace InvoiceIT
{
    public class Task

    {
        public int Task_Id { get; set; }

        public string TaskTitle { get; set; }

        public string TaskDescription { get; set; }

        public string TaskRate { get; set; }

        public string Message { get; set; }

        // Add a new Task
        public string AddTask(NameValueCollection NewTaskData)
        {
            this.TaskTitle = NewTaskData["txttasktitle"];
            this.TaskDescription = NewTaskData["txttskdes"];
            this.TaskRate = NewTaskData["txttskrate"];

            SqlConnection con = DBConnect.CreateCon();

            SqlCommand AddTask = new SqlCommand
            {
                CommandText = "INSERt INTO Task(taskTitle,taskDescription,taskRate) VALUES('" + TaskTitle + "',  '" + TaskDescription + "', '" + TaskRate + "') ",
                CommandType = CommandType.Text,
                Connection = con
            };

            if (con.State == ConnectionState.Open)
            {
                int a = AddTask.ExecuteNonQuery();
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
        // Get All task Details

        public List<List<string>> GetTask() // set retrun type to multidimensional list,string>
        {

            SqlConnection con = DBConnect.CreateCon();

            SqlCommand GetAllTask = new SqlCommand
            {
                CommandText = "SELECT * FROM Task",
                CommandType = CommandType.Text,
                Connection = con
            };


            List<List<string>> AllTask = new List<List<string>>();


            SqlDataReader r = GetAllTask.ExecuteReader();

            if (r.HasRows) // If records found then do what follows
            {
                while (r.Read())
                {
                    // Add each record to the list
                    AllTask.Add(new List<string> { r["task_Id"].ToString(), r["taskTitle"].ToString(), r["taskDescription"].ToString(), r["taskRate"].ToString() });


                }
                r.Close();
            }
            else
            {
                AllTask = null; // if no records are returned
            }

            DBConnect.DropConn(con);
            return AllTask; // return multidimensional list to caller

        }

        // Display details of a specific workitm
        public List<string> GetTask(int Task_Id)
        {
            this.Task_Id = Task_Id;
            List<string> details = new List<string>(4);

            // Make connection to the database
            SqlConnection con = DBConnect.CreateCon();

           
            SqlCommand GetTaskDetails = new SqlCommand
            {
                CommandText = "SELECT * FROM Task WHERE task_Id = " + Task_Id,
                CommandType = CommandType.Text,
                Connection = con
            };

            SqlDataReader r = GetTaskDetails.ExecuteReader();

            if (!r.HasRows)
            {
                details = null;
            }
            else
            {
                while (r.Read())
                {
                    details.Add(r["task_Id"].ToString());
                    details.Add(r["taskTitle"].ToString());
                    details.Add(r["taskDescription"].ToString());
                    details.Add(r["taskRate"].ToString());
                    

                }
            }

            DBConnect.DropConn(con);
            return details;
        }
        public string UpdateTask(NameValueCollection updateTaskData)

        {
            this.Task_Id = Convert.ToInt32(updateTaskData["CtrlTaskID"]);
            this.TaskTitle= updateTaskData["cntrltasktitle"];
            this.TaskDescription= updateTaskData["cntrltskdes"];
            this.TaskRate = updateTaskData["cntrltskrate"];
            

            SqlConnection con = DBConnect.CreateCon();

            SqlCommand UpdateTask = new SqlCommand
            {
                CommandText = "UPDATE Task SET taskTitle ='" + this.TaskTitle + "',taskDescription='" + this.TaskDescription + "',taskRate='"+this.TaskRate + "' WHERE Task_Id = " + this.Task_Id,
                CommandType = CommandType.Text,
                Connection = con
            };

            if (con.State == ConnectionState.Open)
            {
                int a = UpdateTask.ExecuteNonQuery();
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

        // Display details of a specific workitm
        public List<string> DeleteTask(int Task_Id)
        {
            this.Task_Id = Task_Id;
            List<string> details = new List<string>(4);

            // Make connection to the database
            SqlConnection con = DBConnect.CreateCon();


            SqlCommand DeleteTaskDetails = new SqlCommand
            {
                CommandText = "Delete FROM Task WHERE task_Id = " + Task_Id,
                CommandType = CommandType.Text,
                Connection = con
            };

            if (con.State == ConnectionState.Open)
            {
                int a = DeleteTaskDetails.ExecuteNonQuery();
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




            SqlDataReader r = DeleteTaskDetails.ExecuteReader();

            if (!r.HasRows)
            {
                details = null;
            }
            else
            {
                while (r.Read())
                {
                    details.Add(r["task_Id"].ToString());
                    details.Add(r["taskTitle"].ToString());
                    details.Add(r["taskDescription"].ToString());
                    details.Add(r["taskRate"].ToString());


                }
            }

            DBConnect.DropConn(con);
            return details;
        }

    }
}