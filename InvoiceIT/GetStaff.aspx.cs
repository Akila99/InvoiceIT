using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace InvoiceIT
{ 
    public partial class GetStaff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Staff AllStaff = new Staff();


                // Assign returned results to multidimensional string list
                List<List<string>> allstaff = AllStaff.GetStaff();

            if (allstaff == null)
            {
                Response.Write("No records found");
            }
            else
            {
                int results = allstaff.Count;

                // A bit of preamble
                Response.Write("<h3> Current Staff List</h3>");
                Response.Write("<p>" + results + " Staff Available</p>");

                Response.Write("<div class='stafflistingcont'>");
                // construct display of Staff
                for (int i = 0; i <= results - 1; i++)
                {
                    Response.Write("<div class='stafflistingrow'>");
                    Response.Write("<div class='staffId'>" + allstaff[i][0] + " </div>");
                    Response.Write("<div class='staffName'>" + allstaff[i][1] + "</div>");
                    Response.Write("<div class='staffSurname'>" + allstaff[i][2] + "</div>");
                    Response.Write("<div class='staffviewdetails' ' ><a href='ViewStaffDetails.aspx?ID=" + allstaff[i][0] + "'>View</a></div>");
                    Response.Write("</div>");
                }

                Response.Write("</div>");
            }

        }
    }
}