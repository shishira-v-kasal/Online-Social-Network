using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data; 

namespace SocialNetworking.Visitor
{
    public partial class Register : System.Web.UI.Page
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

                SocialNetworking.JQueryUtils.RegisterTextBoxForDatePicker(Page, txtDOB);
            }
            catch
            {

            }
        }

        //click event to get register to the application
        protected void imagebtnRegister_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                BLL obj = new BLL();

                if (obj.CheckUserId(txtEmailId.Text))
                {
                    string[] s = txtDOB.Text.Split('-');
                    obj.InsertUser(txtEmailId.Text, txtPassword.Text, txtFirstName.Text, txtLastName.Text, dropdownlistGender.SelectedValue, s[2], DateTime.Now.ToShortDateString());

                    lblError.Text = " ";
                    lblSuccess.Font.Bold = true;
                    lblError.Text = " ";
                    lblSuccess.ForeColor = System.Drawing.Color.Green;
                    lblSuccess.Text = "User Registration is Successfull";
                    ClearTextBoxes();

                    ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('User Registration is Successfull')</script>");
                    DisableControls();
                }
                else
                {
                    lblSuccess.Text = " ";
                    lblError.Font.Bold = true;
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = "EmailId Already Exists";
                    DisableControls();
                }
            }
            catch
            {

            }

        }

        //function to clear the textboxes contents
        private void ClearTextBoxes()
        {
            txtEmailId.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
        }

        protected void txtEmailId_TextChanged(object sender, EventArgs e)
        {
            try
            {
                BLL obj = new BLL();

                if (txtEmailId.Text.Contains('@') && txtEmailId.Text.Contains(".com"))
                {
                    if (obj.CheckUserId(txtEmailId.Text))
                    {
                        txtPassword.Focus();
                        EnableControls();
                        lblSuccess.Text = " ";
                        lblError.Text = " ";
                    }
                    else
                    {
                        lblSuccess.Text = " ";
                        lblError.Font.Bold = true;
                        lblError.ForeColor = System.Drawing.Color.Red;
                        lblError.Text = "EmailId Already Exists";
                        ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('EmailId Already Exists')</script>");
                        DisableControls();
                    }

                }
                else
                {
                    lblSuccess.Text = " ";
                    lblError.Font.Bold = true;
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = "Invalid EmailId";
                    ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Invalid EmailId')</script>");
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
            txtConfirm.Enabled = false;
            txtFirstName.Enabled = false;
            txtLastName.Enabled = false;
            txtPassword.Enabled = false;
            txtDOB.Enabled = false;
            imagebtnRegister.Enabled = false;
            dropdownlistGender.SelectedIndex = 0;
            dropdownlistGender.Enabled = false;
        }

        //enable controls
        private void EnableControls()
        {
            txtConfirm.Enabled = true;
            txtFirstName.Enabled = true;
            txtLastName.Enabled = true;
            txtPassword.Enabled = true;
            txtDOB.Enabled = true;
            imagebtnRegister.Enabled = true;
            dropdownlistGender.SelectedIndex = 0;
            dropdownlistGender.Enabled = true;
        }

    }
}