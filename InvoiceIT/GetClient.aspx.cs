using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace InvoiceIT
{
    public partial class GetClient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Client AllClient = new Client();
          

               // Assign returned results to multidimensional string list
               List <List<string>> allclient = AllClient.GetClient();

            if (allclient == null)
            {
                Response.Write("No records found");
            }
            else
            {
                int results = allclient.Count;

                // A bit of preamble
                Response.Write("<h3> Current Client List</h3>");
                Response.Write("<p>" + results + " Client Available</p>");

                Response.Write("<div class='clientlistingcont'>");
                // construct display of client
                for (int i = 0; i <= results - 1; i++)
                {
                    Response.Write("<div class='clientlistingrow'>");
                    Response.Write("<div class='clientid'>" + allclient[i][0] + " </div>");
                    Response.Write("<div class='compName'>" + allclient[i][1] + "</div>");
                    Response.Write("<div class='clientfname'>" + allclient[i][5] + "</div>");
                    Response.Write("<div class='clientviewdetails' ' ><a href='ViewClientDetails.aspx?ID=" + allclient[i][0] + "'>View</a Class ='button' ></div>");
                    Response.Write("</div>");
                }

                Response.Write("</div>");
            }

        }
    }
}