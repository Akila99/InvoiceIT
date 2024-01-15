using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace InvoiceIT
{
    public partial class UpdateClient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["ID"] != null && int.TryParse(Request.Params["ID"], out int Client_Id))
            {
                Client client = new Client(); // Create a client object from the Client class
                _ = new List<string>(12); // Create a new List object of type string
                List<string> ClientData = client.GetClient(Client_Id); // Place data returned by Getclient(int) method into a list named ClientData
                bool isEmpty = AppUtilities.IsEmpty(ClientData); // Check whether or not the ClientData list is empty or not

                // Write customised header above form
                this.updateclientheader.InnerHtml = "<h3>Update Details for " + ClientData[1] + "</h3>";

                if (isEmpty)
                {
                    Response.Write("There was an unexpected error - no client details were returned"); // If ClientData list is null or empty, inform user
                }
                else
                {  // If ClientData list contains data, place into the appropriate form locations

                    // USER DATA LEGEND
                    // Client ID: ClientData[0]
                    // Comp Add1: ClientData[1]
                    // Comp add2c: ClientData[2]
                    // Comp add 2: ClientData[3]

                    // Write user details to matching target controls in form
                    this.CtrlClientID.Value = ClientData[0].ToString();
                    this.cntrlcomname.Text = ClientData[1];
                    this.cntrlcompadd1.Text = ClientData[2];
                    this.cntrlcompadd2.Text = ClientData[3];
                    this.cntrlcomploc.Text = ClientData[4];
                    this.cntrlcompcod.Text = ClientData[5];
                    this.cntrlconfnam.Text = ClientData[6];
                    this.cntrlconlnam.Text = ClientData[7];
                    this.cntrlconemail.Text = ClientData[8];
                    this.cntrlconmob.Text = ClientData[9];
                    

                    string billto = ClientData[10].Replace(" ", String.Empty);
                    string dlclientbillto;
                    if (billto == "Client")
                    {
                        dlclientbillto = "<select class='tbinput' name='cntrlbillto' id='cntrlbillto'>";
                        dlclientbillto += "<option value='Client' selected='selected'>Client</option>";
                        dlclientbillto += "<option value='Company'>Company </option>";
                        dlclientbillto += "</select>";
                    }
                    else
                    {
                        dlclientbillto = "<select class='tbinput' name='cntrlbillto' id='cntrlbillto'>";
                        dlclientbillto += "<option value='Client'>Client</option>";
                        dlclientbillto += "<option value='Company' selected='selected'>Company</option>";
                        dlclientbillto += "</select>";
                    }
                    Clientbillto.Text = dlclientbillto;

                    string status = ClientData[11].Replace(" ", String.Empty);
                    // Response.Write("The contents of status is " + status + "<br />");
                    // Response.Write("The length of status is " + status.Length + "<br />");

                    string dlclientstatus;
                    if (status == "Good")
                    {
                        dlclientstatus = "<select class='tbinput' name='cntrlclientstats' id='cntrlclientstats'>";
                        dlclientstatus += "<option value='Good' selected='selected'>Good</option>";
                        dlclientstatus += "<option value='In Arrears'>In Arrears</option>";
                        dlclientstatus += "<option value='Discontinued'>Discontinued</option>";
                        dlclientstatus += "</select>";
                    }
                    
                    else if (status == "In Arrears")
                    {
                        dlclientstatus = "<select class='tbinput' name='cntrlclientstats' id='cntrlclientstats'>";
                        dlclientstatus += "<option value='Good '>Good</option>";
                        dlclientstatus += "<option value='Discontinued'>Discontinued</option>";
                        dlclientstatus += "<option value='In Arrears' selected='selected'>In Arrears</option>";
                        dlclientstatus += "</select>";
                    }
                    else
                    {
                        dlclientstatus = "<select class='tbinput' name='cntrlclientstats' id='cntrlclientstats'>";
                        dlclientstatus += "<option value='Discontinued' selected='selected'>Discontinued</option>";
                        dlclientstatus += "<option value='Good '>Good</option>";
                        dlclientstatus += "<option value='In Arrears'>In Arrears</option>";
                    }
                    
                    ClientStatusPH.Text = dlclientstatus;

                }
            }
            else
            {
                Response.Write("No ID in url OR couldn't parse url parameter to an int");
            }

        }

        protected void btnupdateclientDetails_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                System.Collections.Specialized.NameValueCollection UpdateClientData = Request.Form;
                Client UpdateClient = new Client();
                string Result = UpdateClient.UpdateClient(UpdateClientData);
                if (Result == "The record has been updated succesfully")
                {
                    this.frmcont.Visible = false;
                    Response.Write("<span class='success'>Client details updated successfully.</span><br />");
                    Response.Write("<a href='GetClient.aspx'>Return to Client List</a>");
                }
                else
                {
                    this.frmcont.Visible = false;
                    Response.Write("<span class='error'>Update failed; client details have not been changed.</span><br />");
                    Response.Write("<a href='GetClient.aspx'>Return to Client List</a>");
                }

            }

        }
    }
}