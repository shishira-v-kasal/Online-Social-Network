using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

namespace OSNProject.BeforeLogin
{
    public partial class frmAdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)

                txtAdminId.Focus();
        }

        //click event to check admin login
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            BLL obj = new BLL();

            if (obj.CheckAdminLogin(txtAdminId.Text, txtPassword.Text))
            {
                Session["AdminId"] = txtAdminId.Text;
                Response.Redirect("~/AfterLogin/frmMembers.aspx");
            }
            else
            {
                //lblError.Font.Bold = true;
                //lblError.ForeColor = System.Drawing.Color.Red;
                //lblError.Text = "Invalid AdminId/Password";
                ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Invalid AdminId/Password')</script>");
            }
        }
    }
}