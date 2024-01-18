using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Collections;

namespace OSNProject.AfterLogin
{
    public partial class frmSendRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                Session.Abandon();
                Response.Redirect("../BeforeLogin/Index.aspx");
            }
            else
            {
                if (!this.IsPostBack)
                {
                    LoadUserProfile();
                }
            }
        }

        //function to load user profile
        private void LoadUserProfile()
        {
            DataTable tab = new DataTable();
            BLL obj = new BLL();

            tab = obj.GetUserByEmailId(Request.QueryString["UserId"].ToString());

            //basic Details
            lblEmailId.Text = tab.Rows[0]["EmailId"].ToString();
            lblFirstName.Text = tab.Rows[0]["FirstName"].ToString();
            lblLastName.Text = tab.Rows[0]["LastName"].ToString();
            lblGender.Text = tab.Rows[0]["Gender"].ToString();
            lblDOB.Text = tab.Rows[0]["DateOfBirth"].ToString();
            imgPhoto.ImageUrl = tab.Rows[0]["Photo"].ToString();

            Session["Oldpath"] = null;
            Session["Oldpath"] = tab.Rows[0]["Photo"].ToString();
            lblRegisteredDate.Text = tab.Rows[0]["RegisteredDate"].ToString();

            //Educational Details
            txtHighSchool.Text = tab.Rows[0]["HighSchool"].ToString();
            txtCollege.Text = tab.Rows[0]["College"].ToString();

            //Employer Details
            txtEmployer.Text = tab.Rows[0]["Employer"].ToString();

            //Contact Details
            txtAddress.Text = tab.Rows[0]["Address"].ToString();
            txtCurrentCity.Text = tab.Rows[0]["CurrentCity"].ToString();
            txtHomeTown.Text = tab.Rows[0]["HomeTown"].ToString();
            txtMobile.Text = tab.Rows[0]["Mobile"].ToString();
            txtOtherPhone.Text = tab.Rows[0]["OtherPhones"].ToString();
            txtZipCode.Text = tab.Rows[0]["ZipCode"].ToString();

            //Others
            txtReligion.Text = tab.Rows[0]["Religion"].ToString();
            txtLanguages.Text = tab.Rows[0]["Languages"].ToString();
            txtAboutU.Text = tab.Rows[0]["AboutU"].ToString();

            if (tab.Rows[0]["RelationshipStatus"].ToString().Equals(""))
            {

            }
            else
            {
                string dataTextField = DropDownListReplationship.Items.FindByValue(tab.Rows[0]["RelationshipStatus"].ToString()).ToString();

                ListItem item = new ListItem(dataTextField, tab.Rows[0]["RelationshipStatus"].ToString());
                int index = DropDownListReplationship.Items.IndexOf(item);

                if (index != -1)

                    DropDownListReplationship.SelectedIndex = index;

            }

            DisableControls();

        }

        //function to disable controls
        private void DisableControls()
        {
            txtAboutU.Enabled = false;
            txtAddress.Enabled = false;
            txtCollege.Enabled = false;
            txtCurrentCity.Enabled = false;
            txtEmployer.Enabled = false;
            txtHighSchool.Enabled = false;
            txtHomeTown.Enabled = false;
            txtLanguages.Enabled = false;
            txtMobile.Enabled = false;
            txtOtherPhone.Enabled = false;
            txtReligion.Enabled = false;
            txtZipCode.Enabled = false;
            DropDownListReplationship.Enabled = false;

        }

        protected void btnRequest_Click(object sender, EventArgs e)
        {

            try
            {
                Button btn = (Button)sender;
                BLL obj = new BLL();

                if (obj.CheckFriendRequest(Session["UserId"].ToString(), btn.ID) && btn.ID != Session["UserId"].ToString() && obj.CheckFriendRequest(btn.ID, Session["UserId"].ToString()))
                {
                    obj.SendFriendRequest(Session["UserId"].ToString(), btn.ID, DateTime.Now, "Pending");
                    //GetUsers();
                    ClientScript.RegisterStartupScript(this.GetType(), "Key", "<script>alert('Friend Request Sent Successfully!')</script>");
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Key", "<script>alert('Already Requested/self Request!')</script>");
                }
            }
            catch
            {

            }
        }
              
    }
}