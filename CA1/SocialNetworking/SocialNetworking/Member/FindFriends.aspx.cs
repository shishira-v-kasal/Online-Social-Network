using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SocialNetworking.Member
{
    public partial class FindFriends : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!this.IsPostBack)
                {
                    RadioButton2.Checked = true;
                    txtSearch.Focus();
                }

                GetUsers();
            }
            catch
            {

            }
        }

        //function to display users
        private void GetUsers()
        {
            lblUser.Text = "Users with : " + txtSearch.Text;

            DataTable tab = new DataTable();
            BLL obj = new BLL();

            if (RadioButton1.Checked)
            {
                tab = obj.GetUsersByName("%" + txtSearch.Text + "%");
            }
            else if (RadioButton2.Checked)
            {
                tab = obj.GetUserByEmailId(txtSearch.Text);
            }

            if (tab.Rows.Count > 0)
            {
                tblUsers.Rows.Clear();

                tblUsers.BorderStyle = BorderStyle.Double;
                tblUsers.GridLines = GridLines.Both;
                tblUsers.BorderColor = System.Drawing.Color.DarkGray;

                TableRow headerrow = new TableRow();
                headerrow.Height = 30;
                headerrow.ForeColor = System.Drawing.Color.WhiteSmoke;
                //#bbd142
                headerrow.BackColor = System.Drawing.Color.ForestGreen;

                TableCell cell1 = new TableCell();
                cell1.Text = "<b>Photo</b>";
                headerrow.Controls.Add(cell1);

                TableCell cell2 = new TableCell();
                cell2.Text = "<b>User Id</b>";
                headerrow.Controls.Add(cell2);

                TableCell cell3 = new TableCell();
                cell3.Text = "<b>First Name</b>";
                headerrow.Controls.Add(cell3);

                TableCell cell4 = new TableCell();
                cell4.Text = "<b>Gender</b>";
                headerrow.Controls.Add(cell4);

                TableCell cell5 = new TableCell();
                cell5.Text = "<b>Mobile</b>";
                headerrow.Controls.Add(cell5);

                TableCell cell7 = new TableCell();
                cell7.Text = "<b>MoreDetails</b>";
                headerrow.Controls.Add(cell7);

                TableCell cell8 = new TableCell();
                cell8.Text = "<b>SendRequest</b>";
                headerrow.Controls.Add(cell8);

                tblUsers.Controls.Add(headerrow);

                for (int cnt = 0; cnt < tab.Rows.Count; cnt++)
                {
                    TableRow row = new TableRow();

                    TableCell cellPhoto = new TableCell();
                    cellPhoto.VerticalAlign = VerticalAlign.Top;
                    cellPhoto.Width = 50;
                    cellPhoto.Height = 50;
                    HyperLink hypLink = new HyperLink();
                    hypLink.CssClass = "fancybox";
                    Image imgPhoto = new Image();
                    imgPhoto.Width = 50;
                    imgPhoto.Height = 50;
                    imgPhoto.ImageUrl = tab.Rows[cnt]["Photo"].ToString();
                    hypLink.Controls.Add(imgPhoto);
                    hypLink.NavigateUrl = tab.Rows[cnt]["Photo"].ToString();
                    cellPhoto.Controls.Add(hypLink);
                    row.Controls.Add(cellPhoto);

                    TableCell cellTouristId = new TableCell();
                    cellTouristId.Width = 100;
                    cellTouristId.Text = "<a href='#'>" + tab.Rows[cnt]["EmailId"].ToString() + "<span>Name : " + tab.Rows[cnt]["FirstName"].ToString() + ".</br>Address : " + tab.Rows[cnt]["Address"].ToString() + ".</br>Email ID : " + tab.Rows[cnt]["EmailId"].ToString() + "</span></a>";
                    row.Controls.Add(cellTouristId);

                    TableCell cellFirstName = new TableCell();
                    cellFirstName.Width = 250;
                    cellFirstName.Text = tab.Rows[cnt]["FirstName"].ToString();
                    row.Controls.Add(cellFirstName);

                    TableCell cellGender = new TableCell();
                    cellGender.Width = 100;
                    cellGender.Text = tab.Rows[cnt]["Gender"].ToString();
                    row.Controls.Add(cellGender);

                    TableCell cellPhone = new TableCell();
                    cellPhone.Width = 200;
                    cellPhone.Text = tab.Rows[cnt]["Mobile"].ToString();
                    row.Controls.Add(cellPhone);

                    TableCell cellMore = new TableCell();

                    HyperLink hypMore = new HyperLink();
                    hypMore.Text = "MoreDetails";
                    hypMore.ID = "More~" + tab.Rows[cnt]["EmailId"].ToString();
                    hypMore.CssClass = "fancybox fancybox.iframe";
                    hypMore.NavigateUrl = string.Format("UserDetails.aspx?UserId={0}", tab.Rows[cnt]["EmailId"].ToString());
                    cellMore.Controls.Add(hypMore);
                    row.Controls.Add(cellMore);

                    TableCell cellSend = new TableCell();
                    Button btnSend = new Button();
                    btnSend.ID = tab.Rows[cnt]["EmailId"].ToString();
                    btnSend.Text = "Send Request";
                    btnSend.ToolTip = "Click here to send friend request";
                    btnSend.OnClientClick = "return confirm('Are you sure do you want to send request')";
                    btnSend.Click += new EventHandler(btnSend_Click);
                    cellSend.Controls.Add(btnSend);
                    row.Controls.Add(cellSend);

                    tblUsers.Controls.Add(row);

                }
            }
            else
            {
                tblUsers.Rows.Clear();
                tblUsers.GridLines = GridLines.None;

                TableRow row = new TableRow();

                TableCell cell = new TableCell();
                cell.ColumnSpan = 10;
                cell.ForeColor = System.Drawing.Color.Red;
                cell.Font.Size = 10;
                cell.Text = "<b>No Users Found</b>";
                cell.HorizontalAlign = HorizontalAlign.Center;
                row.Controls.Add(cell);
                tblUsers.Controls.Add(row);

            }

        }

        void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                BLL obj = new BLL();

                if (obj.CheckFriendRequest(Session["UserId"].ToString(), btn.ID) && btn.ID != Session["UserId"].ToString() && obj.CheckFriendRequest(btn.ID, Session["UserId"].ToString()))
                {
                    DataTable tabPosting = new DataTable();
                    tabPosting = obj.GetPostingsByEmailId(Session["UserId"].ToString());

                    DataTable tabProfile = new DataTable();
                    tabProfile = obj.GetUserByEmailId(Session["UserId"].ToString());

                    if (tabPosting.Rows.Count > 0 && tabProfile.Rows[0]["CurrentCity"] != null && tabProfile.Rows[0]["Address"] != null && tabProfile.Rows[0]["HomeTown"] != null && tabProfile.Rows[0]["Mobile"] != null && tabProfile.Rows[0]["Religion"] != null)
                    {
                        obj.SendFriendRequest(Session["UserId"].ToString(), btn.ID, DateTime.Now.ToShortDateString(), "Pending");
                        GetUsers();
                        ClientScript.RegisterStartupScript(this.GetType(), "Key", "<script>alert('Friend Request Sent Successfully!')</script>");
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Key", "<script>alert('Update Your Profile and Activities!!!')</script>");
                    }
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

        protected void imgbtnSearch_Click(object sender, ImageClickEventArgs e)
        {
            if (RadioButton1.Checked)
            {
                GetUsers();
            }
            else if (RadioButton2.Checked)
            {
                if (txtSearch.Text.Contains('@') && txtSearch.Text.Contains(".com"))
                {
                    GetUsers();
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Key", "<script>alert('Invalid EmailId!')</script>");
                }
            }


        }
              
    }
}