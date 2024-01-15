using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace InvoiceIT
{
    public partial class ViewClientDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["ID"] != null && int.TryParse(Request.Params["ID"], out int Client_Id))
            {
                Client client = new Client();
                _ = new List<string>(12);
                List<string> ClientData = client.GetClient(Client_Id);
                bool isEmpty = AppUtilities.IsEmpty(ClientData);
                if (isEmpty)
                {
                    Response.Write("There was an unexpected error - no client details were returned.");
                }
                else
                {
                    Response.Write("Client ID: " + ClientData[0] + "<br />");
                    Response.Write("Company Name: " + ClientData[1] + "<br />");
                    Response.Write("Company Address 1: " + ClientData[2] + "<br />");
                    Response.Write("Company Address 2: " + ClientData[3] + "<br />");
                    Response.Write("Company Code: " + ClientData[4] + "<br />");
                    Response.Write("Company Location: " + ClientData[5] + "<br />");
                    Response.Write("Contact First name : " + ClientData[6] + "<br />");
                    Response.Write("Contact Last Name: " + ClientData[7] + "<br />");
                    Response.Write("Contact Email: " + ClientData[8] + "<br />");
                    Response.Write("Contact Mobile: " + ClientData[9] + "<br />");
                    Response.Write("Bill To: " + ClientData[10] + "<br />");
                    Response.Write("Client Status: " + ClientData[11] + "<br />");
                    Response.Write("<br />");
                    Response.Write("<a href='UpdateClient.aspx?ID=" + ClientData[0] + "'>Update Client Details</a>");
                    Response.Write("<br />");
                    Response.Write("<a href='DeleteClient.aspx?ID=" + ClientData[0] + "'>Delete Client Details</a>");
                }

            }
            else
            {
                Response.Write("No ID in url or couldn't parse to an int");
            }

        }
    }
}