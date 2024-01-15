using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace InvoiceIT
{
    public partial class GetTask : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Task AllTask = new Task();


            // Assign returned results to multidimensional string list
            List<List<string>> alltask = AllTask.GetTask();

            if (alltask == null)
            {
                Response.Write("No records found");
            }
            else
            {
                int results = alltask.Count;

                // A bit of preamble
                Response.Write("<h3> Current Task List</h3>");
                Response.Write("<p>" + results + " Task Available</p>");

                Response.Write("<div class='tasklistingcont'>");
                // construct display of Task
                for (int i = 0; i <= results - 1; i++)
                {
                    Response.Write("<div class='tasklistingrow'>");
                    Response.Write("<div class='taskId '>" + alltask[i][0] + " </div>");
                    Response.Write("<div class='coltitle '>" + alltask[i][1] + "</div>");
                    Response.Write("<div class='taskviewdetails' ' ><a href='ViewTaskDetails.aspx?ID=" + alltask[i][0] + "'>View</a></div>");
                    Response.Write("</div>");
                }

                Response.Write("</div>");

            }
        }
    }
}