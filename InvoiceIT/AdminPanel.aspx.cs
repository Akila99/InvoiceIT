using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
namespace InvoiceIT
{
    public partial class AdminPanel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (System.Web.HttpContext.Current.Session["CurrUser"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                _ = new ArrayList();
                ArrayList userdet = (ArrayList)Session["CurrUser"];
                int.TryParse((string)userdet[1], out int RoleID);
                // Response.Write("The Role ID is " + RoleID);

                switch (RoleID)
                {
                    case 0:
                        // Client User
                        Response.Redirect("StaffPanel.aspx");
                        break;
                    case 1:
                        // Presenter
                        Response.Redirect("AdminPanel.aspx");
                        break;
                    case 2 :
                        // Events Manager or Administrator
                        Response.Write("Hello " + userdet[0] + " | <a href='Logout.aspx'>Log out</a>");
                        break;


                }
            }

        }
    }
}