using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

namespace SocialNetworking.Member
{
    public partial class MemberHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                rbtnSharedInformation.Checked = true;
                PanelInformation.Visible = true;
                PanelFriendRequests.Visible = false;
            }

            if (rbtnSharedInformation.Checked)

                GetSharedInformation();

            else if (rbtnFriendRequests.Checked)

                GetFriendRequests();
        }

        //function to retrive the messages 
        private void GetSharedInformation()
        {
            DataTable tab = new DataTable();
            BLL obj = new BLL();

            tab = obj.GetMyFriends(Session["UserId"].ToString(), Session["UserId"].ToString());

            if (tab.Rows.Count > 0)
            {
                Table1.Rows.Clear();

                Table1.BorderStyle = BorderStyle.Double;
                Table1.GridLines = GridLines.Both;
                Table1.BorderColor = System.Drawing.Color.DarkGray;

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
                cell4.Text = "<b>PostType</b>";
                headerrow.Controls.Add(cell4);

                TableCell cell6 = new TableCell();
                cell6.Text = "<b>Title</b>";
                headerrow.Controls.Add(cell6);

                TableCell cell7 = new TableCell();
                cell7.Text = "<b>PostedDate</b>";
                headerrow.Controls.Add(cell7);

                Table1.Controls.Add(headerrow);

                for (int cnt = 0; cnt < tab.Rows.Count; cnt++)
                {
                    DataTable tabUsers = new DataTable();
                    string RF = tab.Rows[cnt]["RequestFrom"].ToString();


                    if (tab.Rows[cnt]["RequestFrom"].ToString().Equals(Session["UserId"].ToString(), StringComparison.InvariantCultureIgnoreCase))
                    {
                        tabUsers = obj.GetUserByEmailId(tab.Rows[cnt]["RequestTo"].ToString());
                    }
                    else
                    {
                        tabUsers = obj.GetUserByEmailId(tab.Rows[cnt]["RequestFrom"].ToString());
                    }

                    DataTable tabPostings = new DataTable();
                    tabPostings = obj.GetPostingsByEmailId(tabUsers.Rows[0]["EmailId"].ToString());

                    if (tabPostings.Rows.Count > 0)
                    {
                        for (int j = 0; j < tabPostings.Rows.Count; j++)
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
                            imgPhoto.ImageUrl = tabUsers.Rows[0]["Photo"].ToString();
                            hypLink.Controls.Add(imgPhoto);
                            hypLink.NavigateUrl = tabUsers.Rows[0]["Photo"].ToString();
                            cellPhoto.Controls.Add(hypLink);
                            row.Controls.Add(cellPhoto);

                            TableCell cellUserId = new TableCell();
                            cellUserId.Width = 100;
                            cellUserId.Text = "<a href='#'>" + tabUsers.Rows[0]["EmailId"].ToString() + "<span>Name : " + tabUsers.Rows[0]["FirstName"].ToString() + ".</br>Address : " + tabUsers.Rows[0]["Address"].ToString() + ".</br>Email ID : " + tabUsers.Rows[0]["EmailId"].ToString() + "</span></a>";
                            row.Controls.Add(cellUserId);

                            TableCell cellFirstName = new TableCell();
                            cellFirstName.Width = 250;
                            cellFirstName.Text = tabUsers.Rows[0]["FirstName"].ToString();
                            row.Controls.Add(cellFirstName);

                            TableCell cellPostType = new TableCell();
                            cellPostType.Width = 100;
                            cellPostType.Text = tabPostings.Rows[j]["PostType"].ToString();
                            row.Controls.Add(cellPostType);

                            DataTable tabTitle = new DataTable();

                            if (tabPostings.Rows[j]["PostType"].Equals("Text"))
                            {
                                tabTitle = obj.GetTextsByPostId(int.Parse(tabPostings.Rows[j]["PostId"].ToString()));
                            }
                            else if (tabPostings.Rows[j]["PostType"].Equals("Photo"))
                            {
                                tabTitle = obj.GetPhotosByPostId(int.Parse(tabPostings.Rows[j]["PostId"].ToString()));
                            }
                            else if (tabPostings.Rows[j]["PostType"].Equals("Video"))
                            {
                                tabTitle = obj.GetVideosByPostId(int.Parse(tabPostings.Rows[j]["PostId"].ToString()));
                            }

                            TableCell cellMore = new TableCell();
                            cellMore.Width = 550;

                            HyperLink hypMore = new HyperLink();
                            hypMore.Text = tabTitle.Rows[0]["Title"].ToString();
                            hypMore.ID = "More~" + tabPostings.Rows[j]["PostId"].ToString();
                            hypMore.CssClass = "fancybox fancybox.iframe";
                            hypMore.NavigateUrl = string.Format("SharedInfo.aspx?postId={0}", tabPostings.Rows[j]["PostId"].ToString());
                            cellMore.Controls.Add(hypMore);

                            row.Controls.Add(cellMore);

                            TableCell cellPostedDate = new TableCell();
                            cellPostedDate.Width = 100;
                            cellPostedDate.Text = tabPostings.Rows[j]["PostedDate"].ToString();
                            row.Controls.Add(cellPostedDate);

                            Table1.Controls.Add(row);
                        }
                    }
                    else
                    {

                    }
                }
            }
            else
            {
                Table1.Rows.Clear();
                Table1.BorderStyle = BorderStyle.None;
                Table1.GridLines = GridLines.None;

                TableRow row = new TableRow();

                TableCell cell = new TableCell();
                cell.ColumnSpan = 10;
                cell.ForeColor = System.Drawing.Color.Red;
                cell.Font.Size = 10;
                cell.Text = "<b>No Shared Information Found</b>";
                cell.HorizontalAlign = HorizontalAlign.Center;
                row.Controls.Add(cell);
                Table1.Controls.Add(row);
            }

            if (Table1.Rows.Count == 1)
            {
                Table1.Rows.Clear();
                Table1.BorderStyle = BorderStyle.None;
                Table1.GridLines = GridLines.None;

                TableRow row = new TableRow();

                TableCell cell = new TableCell();
                cell.ColumnSpan = 10;
                cell.ForeColor = System.Drawing.Color.Red;
                cell.Font.Size = 10;
                cell.Text = "<b>No Shared Information Found</b>";
                cell.HorizontalAlign = HorizontalAlign.Center;
                row.Controls.Add(cell);
                Table1.Controls.Add(row);
            }

        }

        protected void rbtnSharedInformation_CheckedChanged(object sender, EventArgs e)
        {
            PanelInformation.Visible = true;
            PanelFriendRequests.Visible = false;

            GetSharedInformation();
        }

        protected void rbtnFriendRequests_CheckedChanged(object sender, EventArgs e)
        {
            PanelInformation.Visible = false;
            PanelFriendRequests.Visible = true;

            GetFriendRequests();
        }

        //function to get friend request 
        private void GetFriendRequests()
        {
            DataTable tab = new DataTable();
            BLL obj = new BLL();

            tab = obj.GetFriendRequests(Session["UserId"].ToString());

            if (tab.Rows.Count > 0)
            {
                Table2.Rows.Clear();

                Table2.BorderStyle = BorderStyle.Double;
                Table2.GridLines = GridLines.Both;
                Table2.BorderColor = System.Drawing.Color.DarkGray;

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
                cell3.Text = "<b>FirstName</b>";
                headerrow.Controls.Add(cell3);

                TableCell cell4 = new TableCell();
                cell4.Text = "<b>Gender</b>";
                headerrow.Controls.Add(cell4);

                TableCell cell5 = new TableCell();
                cell5.Text = "<b>Mobile</b>";
                headerrow.Controls.Add(cell5);

                TableCell cell6 = new TableCell();
                cell6.Text = "<b>RegisteredDate</b>";
                headerrow.Controls.Add(cell6);

                TableCell cell7 = new TableCell();
                cell7.Text = "<b>MoreDetails</b>";
                headerrow.Controls.Add(cell7);

                TableCell cell8 = new TableCell();
                cell8.Text = "<b>Accept</b>";
                headerrow.Controls.Add(cell8);

                TableCell cell9 = new TableCell();
                cell9.Text = "<b>Reject</b>";
                headerrow.Controls.Add(cell9);

                Table2.Controls.Add(headerrow);

                for (int cnt = 0; cnt < tab.Rows.Count; cnt++)
                {
                    DataTable tabUsers = new DataTable();
                    tabUsers = obj.GetUserByEmailId(tab.Rows[cnt]["RequestFrom"].ToString());

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
                    imgPhoto.ImageUrl = tabUsers.Rows[0]["Photo"].ToString();
                    hypLink.Controls.Add(imgPhoto);
                    hypLink.NavigateUrl = tabUsers.Rows[0]["Photo"].ToString();
                    cellPhoto.Controls.Add(hypLink);
                    row.Controls.Add(cellPhoto);

                    TableCell cellTouristId = new TableCell();
                    cellTouristId.Width = 100;
                    cellTouristId.Text = "<a href='#'>" + tabUsers.Rows[0]["EmailId"].ToString() + "<span>Name : " + tabUsers.Rows[0]["FirstName"].ToString() + ".</br>Address : " + tabUsers.Rows[0]["Address"].ToString() + ".</br>Email ID : " + tabUsers.Rows[0]["EmailId"].ToString() + "</span></a>";
                    row.Controls.Add(cellTouristId);

                    TableCell cellFirstName = new TableCell();
                    cellFirstName.Width = 250;
                    cellFirstName.Text = tabUsers.Rows[0]["FirstName"].ToString();
                    row.Controls.Add(cellFirstName);

                    TableCell cellGender = new TableCell();
                    cellGender.Width = 100;
                    cellGender.Text = tabUsers.Rows[0]["Gender"].ToString();
                    row.Controls.Add(cellGender);

                    TableCell cellPhone = new TableCell();
                    cellPhone.Width = 200;
                    cellPhone.Text = tabUsers.Rows[0]["Mobile"].ToString();
                    row.Controls.Add(cellPhone);

                    TableCell cellRegisteredDate = new TableCell();
                    cellRegisteredDate.Width = 100;
                    cellRegisteredDate.Text = tabUsers.Rows[0]["RegisteredDate"].ToString();
                    row.Controls.Add(cellRegisteredDate);

                    TableCell cellMore = new TableCell();

                    HyperLink hypMore = new HyperLink();
                    hypMore.Text = "MoreDetails";
                    hypMore.ID = "More~" + tabUsers.Rows[0]["EmailId"].ToString();
                    hypMore.CssClass = "fancybox fancybox.iframe";
                    hypMore.NavigateUrl = string.Format("UserDetails.aspx?UserId={0}", tabUsers.Rows[0]["EmailId"].ToString());
                    cellMore.Controls.Add(hypMore);
                    row.Controls.Add(cellMore);

                    TableCell cellApprove = new TableCell();
                    Button btnApprove = new Button();
                    btnApprove.ID = "accept~" + tab.Rows[cnt]["RequestId"].ToString();
                    btnApprove.Text = "Approve";
                    btnApprove.ToolTip = "Click here to approve friend request";
                    btnApprove.OnClientClick = "return confirm('Are you sure do you want to accept request')";
                    btnApprove.Click += new EventHandler(btnApprove_Click);
                    cellApprove.Controls.Add(btnApprove);
                    row.Controls.Add(cellApprove);

                    TableCell cellReject = new TableCell();
                    Button btnReject = new Button();
                    btnReject.ID = "reject~" + tab.Rows[cnt]["RequestId"].ToString();
                    btnReject.Text = "Reject";
                    btnReject.ToolTip = "Click here to reject friend request";
                    btnReject.OnClientClick = "return confirm('Are you sure do you want to reject request')";
                    btnReject.Click += new EventHandler(btnReject_Click);
                    cellReject.Controls.Add(btnReject);
                    row.Controls.Add(cellReject);

                    Table2.Controls.Add(row);

                }
            }
            else
            {
                Table2.Rows.Clear();
                Table2.GridLines = GridLines.None;

                TableRow row = new TableRow();

                TableCell cell = new TableCell();
                cell.ColumnSpan = 10;
                cell.ForeColor = System.Drawing.Color.Red;
                cell.Font.Size = 10;
                cell.Text = "<b>No Friends Requests Found</b>";
                cell.HorizontalAlign = HorizontalAlign.Center;
                row.Controls.Add(cell);
                Table2.Controls.Add(row);
            }

        }

        void btnReject_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string[] s = btn.ID.Split('~');

            BLL obj = new BLL();
            obj.DeleteFriendRequest(int.Parse(s[1].ToString()));
            ClientScript.RegisterStartupScript(this.GetType(), "Key", "<script>alert('Friend Request Deleted Successfully!')</script>");

            rbtnFriendRequests_CheckedChanged(sender, e);

        }

        void btnApprove_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string[] s = btn.ID.Split('~');

            BLL obj = new BLL();

            obj.UpdateStatus("Accepted", DateTime.Now.ToShortDateString(), int.Parse(s[1].ToString()));
            ClientScript.RegisterStartupScript(this.GetType(), "Key", "<script>alert('Friend Request Accepted Successfully!')</script>");

            rbtnFriendRequests_CheckedChanged(sender, e);
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (rbtnSharedInformation.Checked)

                    GetSharedInformation();

                else if (rbtnFriendRequests.Checked)

                    GetFriendRequests();
            }
            catch
            {

            }
        }
               
      
        
    }
}