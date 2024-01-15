using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InvoiceIT
{
    public partial class GetworkItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WorkItem AllWorkitm = new WorkItem();


            // Assign returned results to multidimensional string list
            List<List<string>> allworkitm = AllWorkitm.GetWorkitm();

            if (allworkitm == null)
            {
                Response.Write("No records found");
            }
            else
            {
                int results = allworkitm.Count;

                // A bit of preamble
                Response.Write("<h3> Current Work Item List</h3>");
                Response.Write("<p>" + results + " Work item Available</p>");

                Response.Write("<div class='wrkitmlistingcont'>");

                for (int i = 0; i <= results - 1; i++)
                {
                    Response.Write("<div  class='wrkitmlistingrow'>");
                    Response.Write("<div class='wrkitmid'>" + allworkitm[i][0] + " </div>");
                    Response.Write("<div class='date'>" + allworkitm[i][1] + "</div>");
                    Response.Write("<div class='startTime'>" + allworkitm[i][2] + "</div>");
                    Response.Write("<div class='endTime'>" + allworkitm[i][3] + "</div>");
                    Response.Write("<div class='work_ItemStatus'>" + allworkitm[i][4] + "</div>");

                    Response.Write("<div class='wrkitmviewdetails' ' ><a href='ViewWorkitemDetails.aspx?ID=" + allworkitm[i][0] + "'>View</a></div>");
                    Response.Write("</div>");
                }

                Response.Write("</div>");
            }

        }
    }
}