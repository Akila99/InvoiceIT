using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InvoiceIT
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }
        protected void btnlogin_Click(object sender, EventArgs e)
        {
            User user = new User();
            _ = new List<string>(2);
            List<string> UserDetails = user.GetUser(Request.Form["cntrlusrnm"], Request.Form["cntrlusrpasswrd"]);
            bool isEmpty = AppUtilities.IsEmpty(UserDetails);
            if (isEmpty)
            {
                Response.Write("No user found with these credentials. Return to <a href='login.aspx'>Login Page</a>");
            }
            else
            {
                // Response.Write("User Fname: " + UserDetails[0] + "<br />");
                // Response.Write("User_SysRole: " + UserDetails[1] + "<br />");
                System.Collections.ArrayList SessUser = new System.Collections.ArrayList
                            {
                                UserDetails[0], // User First Name
                                UserDetails[1] // User Access Level
                            };
                Session["CurrUser"] = SessUser;

               

                int.TryParse((string)SessUser[1], out int RoleID);
                

                switch (RoleID)
                {
                    case 0:
                        // Client User
                        Response.Redirect("ClientPanel.aspx");
                        break;
                    case 1:
                        // Staff
                        Response.Redirect("StaffPanel.aspx");
                        break;
                    case 2:
                        // Administrator
                        Response.Redirect("AdminPanel.aspx");
                        break;
                    
                }
            }

        }
    }
}