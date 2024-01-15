using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InvoiceIT
{
    public partial class UpdateWorkItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["ID"] != null && int.TryParse(Request.Params["ID"], out int work_item_Id))
            {
                WorkItem workItem = new WorkItem();
                _ = new List<string>(8);
                List<string> workitemData = workItem.GetWorkitm(work_item_Id);
                bool isEmpty = AppUtilities.IsEmpty(workitemData);


                this.updateworkitemheader.InnerHtml = "<h3>Update Work Item Details for " + workitemData[7] + "</h3>";

                if (isEmpty)
                {
                    Response.Write("There was an unexpected error - no work item details were returned");
                }
                else
                {



                    this.CtrlworkitemID.Value = workitemData[0].ToString();
                    this.cntrldate.Text = workitemData[1];
                    this.upwrkitmStartTime.Text = workitemData[2];
                    this.upwrkitmEndTime.Text = workitemData[3];
                    this.txtcmnt.Text = workitemData[5];
                    this.ClientListPH.Text = workitemData[6];
                    this.taskListPh.Text = workitemData[7];
                    this.StaffListPh.Text = workitemData[8];

                    string workitemtatus = workitemData[4].Replace(" ", String.Empty);



                    string dlwrkitmsts;
                    if (workitemtatus == "Paused")
                    {
                        dlwrkitmsts = "<select class='tbinput' name='upwrkitmStatus' id='upwrkitmStatus'>";
                        dlwrkitmsts += "<option value='Paused' selected='selected'>Paused</option>";
                        dlwrkitmsts += "<option value='Completed'>Completed</option>";
                        dlwrkitmsts += "<option value='Ongoing'>Ongoing</option>";
                        dlwrkitmsts += "<option value='Discontinued'>Discontinued</option>";
                        dlwrkitmsts += "</select>";
                    }
                    else if(workitemtatus == "Ongoing")
                    {
                        dlwrkitmsts = "<select class='tbinput' name='upwrkitmStatus' id='upwrkitmStatus'>";
                        dlwrkitmsts += "<option value='Paused'>Paused</option>";
                        dlwrkitmsts += "<option value='Completed'>Completed</option>";
                        dlwrkitmsts += "<option value='Discontinued'>Discontinued</option>";
                        dlwrkitmsts += "<option value='Ongoing' selected='selected'>Ongoing</option>";
                        dlwrkitmsts += "</select>";
                    }
                    else if (workitemtatus == "Completed")
                    {
                        dlwrkitmsts = "<select class='tbinput' name='upwrkitmStatus' id='upwrkitmStatus'>";
                        dlwrkitmsts += "<option value='Paused'>Paused</option>";
                        dlwrkitmsts += "<option value='Ongoing'>Ongoing</option>";
                        dlwrkitmsts += "<option value='Discontinued'>Discontinued</option>";
                        dlwrkitmsts += "<option value='Completed' selected='selected'>Completed</option>";
                        dlwrkitmsts += "</select>";
                    }
                    else 
                    {
                        dlwrkitmsts = "<select class='tbinput' name='upwrkitmStatus' id='upwrkitmStatus'>";
                        dlwrkitmsts += "<option value='Paused'>Paused</option>";
                        dlwrkitmsts += "<option value='Ongoing'>Ongoing</option>";
                        dlwrkitmsts += "<option value='Completed'>Completed</option>";
                        dlwrkitmsts += "<option value='Discontinued' selected='selected'>Discontinued</option>";
                        dlwrkitmsts += "</select>";
                    }


                    wrkitmStatusPH.Text = dlwrkitmsts;





                }
            }
            else
            {
                Response.Write("No ID in url OR couldn't parse url parameter to an int");
            }

            string dltask;
            Task AllTask = new Task();

            // Assign the returned results of the task.Gettask method to a multidimensional list<string>
            List<List<string>> alltask = AllTask.GetTask();

            if (alltask == null)
            {
                // if no results returned by the Task.Gettask method, inform the user
                taskListPh.Text = "Error - no task returned";
            }
            else
            {

                int tskcnt = alltask.Count;


                dltask = "<span id='LblTaskList' class='frmlabel'>Select a Task</span><br />";
                dltask += "<select class='dllist' name='CtrlTaskList'>";
                dltask += "<option value='0'>--Please make a selection--</option>";


                for (int i = 0; i <= tskcnt - 1; i++)
                {
                    dltask += "<option value='" + alltask[i][0] + "'>" + alltask[i][1] + " " + alltask[i][2] + "</option>";
                }

                dltask += "</select>";
                taskListPh.Text = dltask;

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
                        dlstaff += "<option value='" + allstaff[i][0] + "'>" + allstaff[i][1] + "  " + allstaff[i][2] + " </ option>";

                    }

                    dlstaff += "</select>";
                    StaffListPh.Text = dlstaff;

                }

            }


        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                NameValueCollection UpdateWorkItemData = Request.Form;
                WorkItem UpdateWorkitem = new WorkItem();
                string Result = UpdateWorkitem.UpdateWorkItem(UpdateWorkItemData);
                if (Result == "The record has been updated succesfully")
                {
                    this.frmcont.Visible = false;
                    Response.Write("<span class='success'>Work item details updated successfully.</span><br />");
                    Response.Write("<a href='GetworkItem.aspx'>Return to WorkItem List</a>");
                }
                else
                {
                    this.frmcont.Visible = false;
                    Response.Write("<span class='error'>Update failed; work Item details have not been changed.</span><br />");
                    Response.Write("<a href='GetworkItemt.aspx'>Return to Work Item List</a>");
                }

            }

        }
    }
}