using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SocialNetworking.Member
{
    public partial class Account : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                Session.Abandon();
                Response.Redirect("~/Index.aspx");
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

            tab = obj.GetUserByEmailId(Session["UserId"].ToString());
            string oldPassword = tab.Rows[0]["Password"].ToString();

            if (txtOldpassword.Text.Equals(oldPassword))
            {
                try
                {
                    obj.UpdatePassword(txtNewpassword.Text, Session["UserId"].ToString());

                    lblPasswordSuccess.Font.Bold = true;
                    lblPasswordError.Text = " ";
                    lblPasswordSuccess.ForeColor = System.Drawing.Color.Green;
                    lblPasswordSuccess.Text = "<b>Error:</b>User Password changed successfully!!!";
                    ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('User Password changed successfully')</script>");
                }
                catch
                {
                    lblPasswordError.Font.Bold = true;
                    lblPasswordSuccess.Text = " ";
                    lblPasswordError.ForeColor = System.Drawing.Color.Red;
                    lblPasswordError.Text = "<b>Error:</b> Server Error!!!";
                    ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Server Error!')</script>");
                }
            }
            else
            {
                lblPasswordError.Font.Bold = true;
                lblPasswordSuccess.Text = " ";
                lblPasswordError.ForeColor = System.Drawing.Color.Red;
                lblPasswordError.Text = "<b>Error:</b> User Old password incorrect!!!";
                ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('User Old password incorrect')</script>");
            }
        }


    }
}