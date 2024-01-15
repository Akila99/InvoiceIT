using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;

namespace InvoiceIT
{
    public partial class UpdateInvoice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.Params["ID"] != null && int.TryParse(Request.Params["ID"], out int Invoice_Id))
            {
                Invoice invoice = new Invoice();
                _ = new List<string>(8);
                List<string> invoiceData = invoice.GetInvoice(Invoice_Id);
                bool isEmpty = AppUtilities.IsEmpty(invoiceData);


                this.updateinvoheader.InnerHtml = "<h3>Update Details for " + invoiceData[7] + "</h3>";

                if (isEmpty)
                {
                    Response.Write("There was an unexpected error - no Invoice  details were returned");
                }
                else
                {



                    this.CtrlinvoID.Value = invoiceData[0].ToString();
                    
                    this.Ctrlinvodate.Text = invoiceData[1];
                    this.txtenddate.Text = invoiceData[2];
                    this.txtgendate.Text = invoiceData[3];
                    this.txtsendate.Text = invoiceData[4];
                    this.txtpaydue.Text = invoiceData[5];
                    this.ClientListPH.Text = invoiceData[7];


                    string invoicestatus = invoiceData[6].Replace(" ", String.Empty);



                    string dlinvosts;
                    if (invoicestatus == "Generated")
                    {
                        dlinvosts = "<select class='tbinput' name='upinvoStatus' id='upinvoStatus'>";
                        dlinvosts += "<option value='Generated' selected='selected'>Generated</option>";
                        dlinvosts += "<option value='Sent'>Sent</option>";
                        dlinvosts += "<option value='Overdue'>Overdue</option>";
                        dlinvosts += "<option value='Paid'>Paid</option>";
                        dlinvosts += "<option value='Withdrawn'>Withdrawn</option>";
                        dlinvosts += "</select>";
                    }
                    else if (invoicestatus == "Sent")
                    {
                        dlinvosts = "<select class='tbinput' name='upinvoStatus' id='upinvoStatus'>";
                        dlinvosts += "<option value='Generated'>Generated</option>";
                        dlinvosts += "<option value='Overdue'>Overdue</option>";
                        dlinvosts += "<option value='Paid'>Paid</option>";
                        dlinvosts += "<option value='Sent' selected='selected'>Sent</option>";
                        dlinvosts += "<option value='Withdrawn'>Withdrawn</option>";
                        dlinvosts += "</select>";
                    }
                    else if (invoicestatus == "Overdue")
                    {
                        dlinvosts = "<select class='tbinput' name='upinvoStatus' id='upinvoStatus'>";
                        dlinvosts += "<option value='Generated'>Generated</option>";
                        dlinvosts += "<option value='Sent'>Sent</option>";
                        dlinvosts += "<option value='Paid'>Paid</option>";
                        dlinvosts += "<option value='Withdrawn'>Withdrawn</option>";
                        dlinvosts += "<option value='Overdue' selected='selected'>Overdue</option>";
                        dlinvosts += "</select>";
                    }
                    else if (invoicestatus == "Paid")
                    {
                        dlinvosts = "<select class='tbinput' name='upinvoStatus' id='upinvoStatus'>";
                        dlinvosts += "<option value='Generated'>Generated</option>";
                        dlinvosts += "<option value='Sent'>Sent</option>";
                        dlinvosts += "<option value='Overdue'>Overdue</option>";
                        dlinvosts += "<option value='Withdrawn'>Withdrawn</option>";
                        dlinvosts += "<option value='Paid' selected='selected'>Paid</option>";
                        dlinvosts += "</select>";
                    }
                    else
                    {
                        dlinvosts = "<select class='tbinput' name='upinvoStatus' id='upinvoStatus '>";
                        dlinvosts += "<option value='Generated'>Generated</option>";
                        dlinvosts += "<option value='Sent'>Sent</option>";
                        dlinvosts += "<option value='Overdue'>Overdue</option>";
                        dlinvosts += "<option value='Paid'>Paid</option>";
                        dlinvosts += "<option value='Withdrawn' selected='selected'>Withdrawn</option>";
                        dlinvosts += "</select>";
                    }


                    invoStatusPH.Text = dlinvosts;

                    


                }
            }

            else
            {
                Response.Write("No ID in url OR couldn't parse url parameter to an int");


            }


            // Create a string variable to hold the generated dropbox html
            string dlclient;


            Client AllClient = new Client();


            List<List<string>> allclient = AllClient.GetClient();

            if (allclient == null)
            {

                ClientListPH.Text = "Error - no courses returned";
            }
            else
            {

                int clientcnt = allclient.Count;


                dlclient = "<span id='LblClientList' Readonly='true'class='frmlabel'>Select a Client Company Name</span><br />";
                dlclient += "<select class='dllist' name='CtrlClientList'>";
                


                for (int i = 0; i <= clientcnt - 1; i++)
                {
                    dlclient += "<option value='" + allclient[i][0] + "'>" + allclient[i][1] + "</option>";
                }

                dlclient += "</select>";
                ClientListPH.Text = dlclient;

            }

        }

        protected void btnupinvo_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                NameValueCollection UpdateInvoiceData = Request.Form;
                Invoice UpdateInvoice = new Invoice();
                string Result = UpdateInvoice.UpdateInvoice(UpdateInvoiceData);
                if (Result == "The record has been updated succesfully")
                {
                    this.frmcont.Visible = false;
                    Response.Write("<span class='success'>Invoice details updated successfully.</span><br />");
                    Response.Write("<a href='GetInvoice.aspx'>Return to Invoice List</a>");
                }
                else
                {
                    this.frmcont.Visible = false;
                    Response.Write("<span class='error'>Update failed; Invoice details have not been changed.</span><br />");
                    Response.Write("<a href='GetInvoice.aspx'>Return to Invoice List</a>");
                }

            }

        }
    }
}