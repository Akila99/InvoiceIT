using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InvoiceIT
{
    public partial class DeleteWorkItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["ID"] != null && int.TryParse(Request.Params["ID"], out int Work_Item_Id))
            {
                WorkItem work_Item = new WorkItem();
                _ = new List<string>(4);
                List<string> WorkitmData = work_Item.GetWorkitm(Work_Item_Id);
                List<string> WorkItmDa = work_Item.Deletewrkitm(Convert.ToInt32(WorkitmData[0]));
                bool isEmpty = AppUtilities.IsEmpty(WorkitmData);
                if (isEmpty)
                {
                    Response.Write("There was an unexpected error - no work item details were returned.");
                }
                else
                {
                    Response.Write("Work item ID: " + WorkitmData[0] + "<br />");
                    Response.Write("date: " + WorkitmData[1] + "<br />");
                    Response.Write("Start Time: " + WorkitmData[2] + "<br />");
                    Response.Write("End Time: " + WorkitmData[3] + "<br />");
                    Response.Write("Work Item Status: " + WorkitmData[4] + "<br />");
                    Response.Write("Comment: " + WorkitmData[5] + "<br />");
                    Response.Write("Client Id : " + WorkitmData[6] + "<br />");
                    Response.Write("Task Id : " + WorkitmData[7] + "<br />");
                    Response.Write("Staff Id : " + WorkitmData[8] + "<br />");
                    Response.Write("<br />");
                    Response.Write("<a href='GetworkItem.aspx?ID=" + WorkitmData[0] + "'>Get WorkItem List</a>");
                }

            }
            else
            {
                Response.Write("No ID in url or couldn't parse to an int");
            }

        }
    }
}