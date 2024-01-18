using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace OSNProject.AfterLogin
{
    public partial class frmAdminAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminId"] == null)
            {
                Session.Abandon();
                Response.Redirect("frmLogin.aspx");
            }
            else
            {
                txtOldpassword.Focus();
            }

        }


        //click event to change administrator password
        protected void imgbtnChangepwd_Click(object sender, ImageClickEventArgs e)
        {
            DataTable tab = new DataTable();
            BLL obj = new BLL();
            tab.Rows.Clear();

            tab = obj.GetAdminDetails(Session["AdminId"].ToString());
            string oldPassword = tab.Rows[0]["Password"].ToString();

            if (txtOldpassword.Text.Equals(oldPassword))
            {
                obj.UpdateAdminPassword(txtNewpassword.Text, Session["AdminId"].ToString());

                //lblPasswordSuccess.Font.Bold = true;
                //lblPasswordError.Text = " ";
                //lblPasswordSuccess.ForeColor = System.Drawing.Color.Green;
                //lblPasswordSuccess.Text = "<b>Error:</b>Admin Password changed successfully!!!";
                ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Admin Password changed successfully')</script>");
            }
            else
            {
                //lblPasswordError.Font.Bold = true;
                //lblPasswordSuccess.Text = " ";
                //lblPasswordError.ForeColor = System.Drawing.Color.Red;
                //lblPasswordError.Text = "<b>Error:</b> Admin Old password incorrect!!!";
                ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Admin Old password incorrect')</script>");
            }
        }


    }
}