using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InvoiceIT
{
    public partial class ViewTaskDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["ID"] != null && int.TryParse(Request.Params["ID"], out int Task_Id))
            {
                Task task = new Task();
                _ = new List<string>(4);
                List<string> TaskData = task.GetTask(Task_Id);
                bool isEmpty = AppUtilities.IsEmpty(TaskData);
                if (isEmpty)
                {
                    Response.Write("There was an unexpected error - no task details were returned.");
                }
                else
                {
                    Response.Write("Task ID           : " + TaskData[0] + "<br />");
                    Response.Write("Task Tittle       : " + TaskData[1] + "<br />");
                    Response.Write("Task Description  : " + TaskData[2] + "<br />");
                    Response.Write("Task Rate         : " + TaskData[3] + "<br />");
                    Response.Write("<br />");
                    Response.Write("<a href='UpdateTask.aspx?ID=" + TaskData[0] + "'>Update Task Details</a>");
                    Response.Write("<br />");
                    Response.Write("<a href='DeleteTask.aspx?ID=" + TaskData[0] + "'>Delete Task Details</a>");
                }

            }
            else
            {
                Response.Write("No ID in url or couldn't parse to an int");
            }

        }
    }
}