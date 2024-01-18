using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SocialNetworking.Visitor
{
    public partial class MemberLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!this.IsPostBack)
                {
                    txtEmailId.Focus();



                    DisableControls();
                }
            }
            catch
            {

            }
              
        }

        //click event to check the user login (user email id & password)
        protected void btnLogin_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                BLL obj = new BLL();

                if (obj.CheckUserLogin(txtEmailId.Text, txtPassword.Text))
                {
                    Session["UserId"] = txtEmailId.Text;



                    Response.Redirect("~/Member/MemberHome.aspx");
                }
                else
                {
                    //lblError.Font.Bold = true;
                    //lblError.ForeColor = System.Drawing.Color.Red;
                    //lblError.Text = "Invalid Password";
                    ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Invalid Password')</script>");
                }

            }
            catch
            {

            }
        }

        protected void txtEmailId_TextChanged(object sender, EventArgs e)
        {
            try
            {
                BLL obj = new BLL();

                if (txtEmailId.Text.Contains('@') && txtEmailId.Text.Contains('.'))
                {
                    if (obj.CheckUserId(txtEmailId.Text))
                    {
                        lblError.Font.Bold = true;
                        lblError.ForeColor = System.Drawing.Color.Red;
                        lblError.Text = "EmailId Does'nt Exists";
                        ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('EmailId Doesnt Exists')</script>");
                        DisableControls();
                    }
                    else
                    {
                        txtPassword.Focus();
                        EnableControls();
                        lblError.Text = " ";
                    }
                }
                else
                {
                    lblError.Font.Bold = true;
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = "Invalid EmailId Format";
                    ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Invalid EmailId Format')</script>");
                    DisableControls();

                }

            }
            catch
            {

            }
        }

        //disable controls
        private void DisableControls()
        {
            txtPassword.Enabled = false;
            btnLogin.Enabled = false;
        }

        //enable controls
        private void EnableControls()
        {
            txtPassword.Enabled = true;
            btnLogin.Enabled = true;
        }
    }
}