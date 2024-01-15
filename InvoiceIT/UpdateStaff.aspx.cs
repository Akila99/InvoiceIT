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
    public partial class UpdateStaff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["ID"] != null && int.TryParse(Request.Params["ID"], out int Staff_Id))
            {
                Staff staff = new Staff();
                _ = new List<string>(7);
                List<string> staffData = staff.GetStaff(Staff_Id);
                bool isEmpty = AppUtilities.IsEmpty(staffData);


                this.updatestaffheader.InnerHtml = "<h3>Update Details for " + staffData[1] + "</h3>";

                if (isEmpty)
                {
                    Response.Write("There was an unexpected error - no staff  details were returned");
                }
                else
                {



                    this.CtrlStaffID.Value = staffData[0].ToString();
                    this.cntrlstafnm.Text = staffData[1];
                    this.cntrlsurnm.Text = staffData[2];
                    this.cntrlstffemail.Text = staffData[3];
                    this.cntrlstfmob.Text = staffData[4];
                    string accesslvl = staffData[5].Replace(" ", String.Empty);



                    string dlstfacclvl;
                    if (accesslvl == "Administrator")
                    {
                        dlstfacclvl = "<select class='tbinput' name='Ctrlacclvl' id='Ctrlacclvl'>";
                        dlstfacclvl += "<option value='Administrator' selected='selected'>Administrator</option>";
                        dlstfacclvl += "<option value='Staff'>Staff</option>";
                        dlstfacclvl += "</select>";
                    }
                    else
                    {
                        dlstfacclvl = "<select class='tbinput' name='Ctrlacclvl' id='Ctrlacclvl'>";
                        dlstfacclvl += "<option value='Administrator'>Administrator</option>";
                        dlstfacclvl += "<option value='Staff' selected='selected'>Staff</option>";
                        dlstfacclvl += "</select>";
                    }

                    acclevlPH.Text = dlstfacclvl;
                    string stfstatus = staffData[6].Replace(" ", String.Empty);



                    string dlstfsts;
                    if (stfstatus == "Active")
                    {
                        dlstfsts = "<select class='tbinput' name='Ctrlstfstatus' id='Ctrlstfstatus'>";
                        dlstfsts += "<option value='Active' selected='selected'>Active</option>";
                        dlstfsts += "<option value='Inactive'>Inactive</option>";
                        dlstfsts += "</select>";
                    }
                    else
                    {
                        dlstfsts = "<select class='tbinput' name='Ctrlstfstatus' id='Ctrlstfstatus'>";
                        dlstfsts += "<option value='Active'>Active</option>";
                        dlstfsts += "<option value='Inactive' selected='selected'>Inactive</option>";
                        dlstfsts += "</select>";
                    }

                    stffstsPH.Text = dlstfsts;



                }
            }
            else
            {
                Response.Write("No ID in url OR couldn't parse url parameter to an int");


            }

        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                NameValueCollection UpdateStaffData = Request.Form;
                Staff UpdateStaff = new Staff();
                string Result = UpdateStaff.UpdateStaff(UpdateStaffData);
                if (Result == "The record has been updated succesfully")
                {
                    this.frmcont.Visible = false;
                    Response.Write("<span class='success'>Staff details updated successfully.</span><br />");
                    Response.Write("<a href='GetStaff.aspx'>Return to Staff List</a>");
                }
                else
                {
                    this.frmcont.Visible = false;
                    Response.Write("<span class='error'>Update failed; staff details have not been changed.</span><br />");
                    Response.Write("<a href='GetStaff.aspx'>Return to Staff List</a>");
                }

            }

        }
    }
}