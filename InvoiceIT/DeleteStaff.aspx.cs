using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InvoiceIT
{
    public partial class DeleteStaff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["ID"] != null && int.TryParse(Request.Params["ID"], out int Staff_Id))
            {
                Staff staff = new Staff();
                _ = new List<string>(4);
                List<string> StaffData = staff.GetStaff(Staff_Id);
                List<string> StaffDa = staff.DeleteStaff(Convert.ToInt32(StaffData[0]));
                bool isEmpty = AppUtilities.IsEmpty(StaffData);
                if (isEmpty)
                {
                    Response.Write("There was an unexpected error - no staff details were returned.");
                }
                else
                {
                    Response.Write("Staff ID: " + StaffData[0] + "<br />");
                    Response.Write("Staff Name: " + StaffData[1] + "<br />");
                    Response.Write("Staff Surname: " + StaffData[2] + "<br />");
                    Response.Write("Staff Email: " + StaffData[3] + "<br />");
                    Response.Write("Staff Mobile: " + StaffData[4] + "<br />");
                    Response.Write("Staff Access Level: " + StaffData[5] + "<br />");
                    Response.Write("Staff Status : " + StaffData[6] + "<br />");
                    Response.Write("<br />");
                    Response.Write("<a href='GetStaff.aspx?ID=" + StaffData[0] + "'>Delete Client Details</a>");


                }

            }
            else
            {
                Response.Write("No ID in url or couldn't parse to an int");
            }

        }

    }
}