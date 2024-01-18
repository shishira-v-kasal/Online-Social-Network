using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Collections;

namespace OSNProject
{
    public partial class frmProfileUpdation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
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
            catch
            {

            }
        }

        //function to load user profile
        private void LoadUserProfile()
        {
            DataTable tab = new DataTable();
            BLL obj = new BLL();

            tab = obj.GetUserByEmailId(Session["UserId"].ToString());

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
            fileuploadPhoto.Enabled = false;
            RequiredFieldValidator9.Enabled = false;
            RegularExpressionValidator2.Enabled = false;
            DropDownListReplationship.Enabled = false;
            lbtnChangephoto.Enabled = false;
            //GridView1.Enabled = false;
            RegularExpressionValidator3.Enabled = false;
        }

        //function to enable controls
        private void EnableControls()
        {
            txtAboutU.Enabled = true;
            txtAddress.Enabled = true;
            txtCollege.Enabled = true;
            txtCurrentCity.Enabled = true;
            txtEmployer.Enabled = true;
            txtHighSchool.Enabled = true;
            txtHomeTown.Enabled = true;
            txtLanguages.Enabled = true;
            txtMobile.Enabled = true;
            txtOtherPhone.Enabled = true;
            txtReligion.Enabled = true;
            txtZipCode.Enabled = true;
            DropDownListReplationship.Enabled = true;
            lbtnChangephoto.Enabled = true;
            //GridView1.Enabled = true;
            RegularExpressionValidator3.Enabled = true;

        }

        //click event to update User profile details
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                BLL obj = new BLL();

                if (btnUpdate.Text.Equals("Edit Profile"))
                {
                    EnableControls();
                    btnUpdate.Text = "Update";
                }
                else if (btnUpdate.Text.Equals("Update"))
                {
                    if (fileuploadPhoto.Enabled)
                    {
                        if (Session["Oldpath"].Equals(""))
                        {

                        }
                        else
                        {
                            File.Delete(Server.MapPath(Session["Oldpath"].ToString()));
                        }

                        string photoName = System.IO.Path.GetFileName(fileuploadPhoto.PostedFile.FileName);

                        int index = photoName.LastIndexOf('.');
                        string ext = photoName.Substring(index + 1);

                        string phtotPath = Server.MapPath("/AfterLogin/UsersPhoto/" + Session["UserId"].ToString() + "." + ext);
                        fileuploadPhoto.PostedFile.SaveAs(phtotPath);

                        string dbPath = "~/AfterLogin/UsersPhoto/" + Session["UserId"].ToString() + "." + ext;

                        obj.UpdateProfile(txtHighSchool.Text, txtCollege.Text, txtEmployer.Text, txtCurrentCity.Text, txtHomeTown.Text, dbPath, DropDownListReplationship.SelectedValue,
                      txtAboutU.Text, txtLanguages.Text, txtReligion.Text, txtMobile.Text, txtOtherPhone.Text, txtAddress.Text, txtZipCode.Text, null, Session["UserId"].ToString());

                        ClientScript.RegisterStartupScript(this.GetType(), "Key", "<script>alert('Profile Updated Successfully with Photo')</script>");
                        btnUpdate.Text = "Edit Profile";

                        LoadUserProfile();
                        DisableControls();

                    }
                    else
                    {

                        obj.UpdateProfile(txtHighSchool.Text, txtCollege.Text, txtEmployer.Text, txtCurrentCity.Text, txtHomeTown.Text, Session["Oldpath"].ToString(), DropDownListReplationship.SelectedValue,
                      txtAboutU.Text, txtLanguages.Text, txtReligion.Text, txtMobile.Text, txtOtherPhone.Text, txtAddress.Text, txtZipCode.Text, null, Session["UserId"].ToString());



                        ClientScript.RegisterStartupScript(this.GetType(), "Key", "<script>alert('Profile Updated Successfully')</script>");
                        btnUpdate.Text = "Edit Profile";

                        LoadUserProfile();
                        DisableControls();

                    }
                }
            }
            catch
            {

            }
        }

        //click event to enable fileupload component
        protected void lbtnChangephoto_Click(object sender, EventArgs e)
        {
            fileuploadPhoto.Enabled = true;
            RequiredFieldValidator9.Enabled = true;
            RegularExpressionValidator2.Enabled = true;
        }
        
    }
}