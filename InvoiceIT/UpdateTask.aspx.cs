using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using System.Data.SqlClient;

namespace InvoiceIT
{
    public partial class UpdateTask : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["ID"] != null && int.TryParse(Request.Params["ID"], out int Task_Id))
            {
                Task task = new Task();
                _ = new List<string>(4);
                List<string> taskData = task.GetTask(Task_Id);
                bool isEmpty = AppUtilities.IsEmpty(taskData);


                this.updatetaskheader.InnerHtml = "<h3>Update Details for " + taskData[1] + "</h3>";

                if (isEmpty)
                {
                    Response.Write("There was an unexpected error - no task  details were returned");
                }
                else
                {



                    this.CtrlTaskID.Value = taskData[0].ToString();
                    this.cntrltasktitle.Text = taskData[1];
                    this.cntrltskdes.Text = taskData[2];
                    this.cntrltskrate.Text = taskData[3];


                }
            }
            else
            {
                Response.Write("No ID in url OR couldn't parse url parameter to an int");


            }

        }



        protected void btnupdatetaskdetails_click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                NameValueCollection UpdateTaskfData = Request.Form;
                Task UpdateTask = new Task();
                string Result = UpdateTask.UpdateTask(UpdateTaskfData);
                if (Result == "The record has been updated succesfully")
                {
                    this.frmcont.Visible = false;
                    Response.Write("<span class='success'>Task details updated successfully.</span><br />");
                    Response.Write("<a href='GetTask.aspx'>Return to Task List</a>");
                }
                else
                {
                    this.frmcont.Visible = false;
                    Response.Write("<span class='error'>Update failed; task details have not been changed.</span><br />");
                    Response.Write("<a href='GetTask.aspx'>Return to Task List</a>");
                }

            }

        }
    }
}