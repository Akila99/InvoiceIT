using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
namespace InvoiceIT
{
    public partial class AddWorkItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string dltask;

            
            Task AllTask = new Task();

            // Assign the returned results of the task.Gettask method to a multidimensional list<string>
            List<List<string>> alltask = AllTask.GetTask();

            if (alltask == null)
            {
                // if no results returned by the Task.Gettask method, inform the user
                TaskListPH.Text = "Error - no task returned";
            }
            else
            {
                // get a count of the records returned for display construction
                int tskcnt = alltask.Count;

                // Create the Task droplist
                dltask = "<span id='LblTaskList' class='frmlabel'>Select a Task</span><br />";
                dltask += "<select class='dllist' name='CtrlTaskList'>";
                dltask += "<option value='0'>--Please make a selection--</option>";

                // Add all Task to the Task droplist
                for (int i = 0; i <= tskcnt - 1; i++)
                {
                    dltask += "<option value='" + alltask[i][0] + "'>" + alltask[i][1] + " " + alltask[i][2] + "</option>";
                }

                dltask += "</select>";
                TaskListPH.Text = dltask;

            }



                string dlclient;

            // Instantiate a new Client object from the Client class
            Client AllClient = new Client();

            // Assign the returned results of the Client.GetClient method to a multidimensional list<string>
            List<List<string>> allclient = AllClient.GetClient();

            if (allclient == null)
            {
                // if no results returned by the Client.GetClient method, inform the user
                ClientListPH.Text = "Error - no client details returned";
            }
            else
            {
                // get a count of the records returned for display construction
                int clientcnt = allclient.Count;

                // Create the client droplist
                dlclient = "<span id='LblClientList' class='frmlabel'>Select a Client</span><br />";
                dlclient += "<select class='dllist' name='CtrlClientList'>";
                dlclient += "<option value='0'>--Please make a selection--</option>";

                // Add all client to the client droplist
                for (int i = 0; i <= clientcnt - 1; i++)
                {
                    dlclient += "<option value='" + allclient[i][0] + "'>" + allclient[i][1] + "</option>";
                }

                dlclient += "</select>";
                ClientListPH.Text = dlclient;

                string dlstaff;


                Staff AllStaff = new Staff();


                List<List<string>> allstaff = AllStaff.GetStaff();

                if (allstaff == null)
                {

                    Response.Write("Error - no Staff details returned");
                }
                else
                {

                    int staffcnt = allstaff.Count;

                    dlstaff = "<span id='LblStaffList' class='frmlabel'>Select a Staff</span><br />";
                    dlstaff += "<select class='dllist' name='CtrlStaffList'>";
                    dlstaff += "<option value='0'>--Please make a selection--</option>";


                    for (int i = 0; i <= staffcnt - 1; i++)
                    {
                        dlstaff += "<option value='" + allstaff[i][0] + "'>" + allstaff[i][1] + "  "  + allstaff[i][2] + " </ option>";
                       
                    }

                    dlstaff += "</select>";
                    staffListPH.Text = dlstaff;

                }

            }
        }

        protected void btnwrkitm_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {

                NameValueCollection NewWorkItemData = Request.Form;
                WorkItem NewWorkItem = new WorkItem();
                string Result = NewWorkItem.AddWorkItem(NewWorkItemData);
                Response.Write(Result);
                AppUtilities.ClearForm(Form.Controls);

            }
        }
    }
}