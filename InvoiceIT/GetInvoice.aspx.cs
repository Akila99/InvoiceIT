using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InvoiceIT
{
    public partial class GetInvoice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Invoice AllInvoice = new Invoice();


            // Assign returned results to multidimensional string list
            List<List<string>> allinvoice = AllInvoice.GetInvoice();

            if (allinvoice == null)
            {
                Response.Write("No records found");
            }
            else
            {
                int results = allinvoice.Count;

                // A bit of preamble
                Response.Write("<h3> Current Invoice List</h3>");
                Response.Write("<p>" + results + " Invoice Available</p>");

                Response.Write("<div class='clientlistingcont'>");
                // construct display of client
                for (int i = 0; i <= results - 1; i++)
                {
                    Response.Write("<div class='clientlistingrow'>");
                    Response.Write("<div class='clientid'>" + allinvoice[i][0] + " </div>");
                    Response.Write("<div class='compName'>" + allinvoice[i][1] + "</div>");
                    Response.Write("<div class='clientfname'>" + allinvoice[i][2] + "</div>");
                    Response.Write("<div class='clientviewdetails' ' ><a href='ViewInvoiceDetails.aspx?ID=" + allinvoice[i][0] + "'>View</a Class ='button' ></div>");
                    Response.Write("</div>");
                }

                Response.Write("</div>");
            }

        }
    }
}