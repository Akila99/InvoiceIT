﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InvoiceIT
{
    public partial class ViewInvoiceDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["ID"] != null && int.TryParse(Request.Params["ID"], out int Invoice_Id))
            {
                Invoice invoice = new Invoice();
                _ = new List<string>(4);
                List<string> InvoiceData = invoice.GetInvoice(Invoice_Id);
                bool isEmpty = AppUtilities.IsEmpty(InvoiceData);
                if (isEmpty)
                {
                    Response.Write("There was an unexpected error - no staff details were returned.");
                }
                else
                {
                    Response.Write("Invoice ID: " + InvoiceData[0] + "<br />");
                    Response.Write("Start Date : " + InvoiceData[1] + "<br />");
                    Response.Write("End Date: " + InvoiceData[2] + "<br />");
                    Response.Write("Generated Date: " + InvoiceData[3] + "<br />");
                    Response.Write("Sent Date: " + InvoiceData[4] + "<br />");
                    Response.Write("Payment Due: " + InvoiceData[5] + "<br />");
                    Response.Write("Invoice Status : " + InvoiceData[6] + "<br />");
                    Response.Write("Client ID : " + InvoiceData[7] + "<br />");
                    Response.Write("<br />");
                    Response.Write("<a href='UpdateInvoice.aspx?ID=" + InvoiceData[0] + "'>Update Invoice Details</a>");
                    Response.Write("<br />");
                    Response.Write("<a href='DeleteInvoice.aspx?ID=" + InvoiceData[0] + "'>Delete Invoice Details</a>");
                }

            }
            else
            {
                Response.Write("No ID in url or couldn't parse to an int");
            }


        }
    }
}