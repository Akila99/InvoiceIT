using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Collections.Specialized;

namespace InvoiceIT
{
    public partial class AddTask : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = DBConnect.CreateCon();

            if (con.State == System.Data.ConnectionState.Open)
            {
                Response.Write("DB Connection successfull. ");

            }
            else
            {
                Response.Write("Oops, the database connection failed. ");
            }

        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                NameValueCollection NewTaskData = Request.Form;
                Task NewTask = new Task();
                string Result = NewTask.AddTask(NewTaskData);
                Response.Write(Result);
                AppUtilities.ClearForm(Form.Controls);
            }

        }
    }
}