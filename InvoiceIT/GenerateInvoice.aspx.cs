using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;

namespace InvoiceIT
{
    public partial class GenerateInvoice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Create a string variable to hold the generated dropbox html
            string dlclient;

            // Instantiate a new Course object from the Course class
            Client AllClient = new Client();

            // Assign the returned results of the Course.GetCourse method to a multidimensional list<string>
            List<List<string>> allclient = AllClient.GetClient();

            if (allclient == null)
            {
                // if no results returned by the Course.GetCourse method, inform the user
                clientidPh.Text = "Error - no courses returned";
            }
            else
            {
                // get a count of the records returned for display construction
                int clientcnt = allclient.Count;

                // Create the courses droplist
                dlclient = "<span id='LblClientList' class='frmlabel'>Select a Client Company Name</span><br />";
                dlclient += "<select class='dllist' name='CtrlClientList'>";
                dlclient += "<option value='0'>--Please make a selection--</option>";

                // Add all courses to the courses droplist
                for (int i = 0; i <= clientcnt - 1; i++)
                {
                    dlclient += "<option value='" + allclient[i][0] + "'>" + allclient[i][1] + "</option>";
                }

                dlclient += "</select>";
                clientidPh.Text = dlclient; // Assign the course droplist to its placeholder in web form

            }

        }

        protected void geninvo_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                NameValueCollection NewInvoiceData = Request.Form;
                Invoice NewInvoice = new Invoice();
                string Result = NewInvoice.AddInvoice(NewInvoiceData);
                Response.Write(Result);
                AppUtilities.ClearForm(Form.Controls); 
            }

        }
    }
}