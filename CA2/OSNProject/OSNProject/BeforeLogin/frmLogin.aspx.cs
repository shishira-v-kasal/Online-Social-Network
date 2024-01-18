using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OSNProject.BeforeLogin
{
    public partial class frmLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!this.IsPostBack)
                {
                    txtEmailId.Focus();

                    HttpCookie h = Request.Cookies["ID"];

                    if (h != null)
                    {
                        txtPassword.Focus();
                        lblCookieUserId.Visible = true;
                        lblCookieUserId.ForeColor = System.Drawing.Color.SteelBlue;
                        lblCookieUserId.Text = "Welcome" + h.Value;
                        txtEmailId.Text = h.Value;
                        checkboxRememberme.Checked = true;
                    }

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

                    if (checkboxRememberme.Checked)
                    {
                        HttpCookie h = new HttpCookie("ID");
                        h.Value = txtEmailId.Text;
                        h.Expires = DateTime.Now.AddDays(2);
                        Response.Cookies.Add(h);
                    }
                    else
                    {
                        HttpCookie h = new HttpCookie("ID");
                        h.Value = null;
                        h.Expires = DateTime.Now.AddDays(0);
                        Response.Cookies.Add(h);
                    }

                    Response.Redirect("~/AfterLogin/frmUserHome.aspx");
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
                        //lblError.Font.Bold = true;
                        //lblError.ForeColor = System.Drawing.Color.Red;
                        //lblError.Text = "Invalid EmailId";
                        ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Invalid EmailId')</script>");
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
                    //lblError.Font.Bold = true;
                    //lblError.ForeColor = System.Drawing.Color.Red;
                    //lblError.Text = "Invalid EmailId Format";
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