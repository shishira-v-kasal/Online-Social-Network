using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

namespace OSNProject.AfterLogin
{
    public partial class frmMembers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["AdminId"] == null)
                {
                    Session.Abandon();
                    Response.Redirect("~/BeforeLogin/frmLogin.aspx");
                }
                else
                {
                    GetMembers();
                }
            }
            catch
            {

            }
          
        }

        //function to get registered members
        private void GetMembers()
        {
            int serialNo = 1;
            DataTable tab = new DataTable();
            BLL obj = new BLL();

            tab = obj.GetMembers();

            if (tab.Rows.Count > 0)
            {
                tableMembers.Rows.Clear();

                tableMembers.BorderStyle = BorderStyle.Double;
                tableMembers.GridLines = GridLines.Both;
                tableMembers.BorderColor = System.Drawing.Color.DarkGray;

                TableRow headerrow = new TableRow();
                headerrow.Height = 30;
                headerrow.ForeColor = System.Drawing.Color.WhiteSmoke;
                //#bbd142
                headerrow.BackColor = System.Drawing.Color.DarkSlateGray;

                TableCell cell1 = new TableCell();
                cell1.Text = "<b>SLNo</b>";
                headerrow.Controls.Add(cell1);

                TableCell cell2 = new TableCell();
                cell2.Text = "<b>Photo</b>";
                headerrow.Controls.Add(cell2);

                TableCell cell3 = new TableCell();
                cell3.Text = "<b>FName</b>";
                headerrow.Controls.Add(cell3);

                TableCell cell4 = new TableCell();
                cell4.Text = "<b>LName</b>";
                headerrow.Controls.Add(cell4);

                TableCell cell5 = new TableCell();
                cell5.Text = "<b>Mobile</b>";
                headerrow.Controls.Add(cell5);

                TableCell cell6 = new TableCell();
                cell6.Text = "<b>EmailId</b>";
                headerrow.Controls.Add(cell6);

                TableCell cell7 = new TableCell();
                cell7.Text = "<b>More Details</b>";
                headerrow.Controls.Add(cell7);

                TableCell cell8 = new TableCell();
                cell8.Text = "<b>Delete</b>";
                headerrow.Controls.Add(cell8);

                tableMembers.Controls.Add(headerrow);

                for (int cnt = 0; cnt < tab.Rows.Count; cnt++)
                {
                    TableRow row = new TableRow();

                    TableCell cellSerialNo = new TableCell();
                    cellSerialNo.Text = cnt + serialNo + ".";
                    row.Controls.Add(cellSerialNo);

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

                    TableCell cellFName = new TableCell();
                    cellFName.Width = 200;
                    cellFName.Text = tab.Rows[cnt]["FirstName"].ToString();
                    row.Controls.Add(cellFName);

                    TableCell cellLName = new TableCell();
                    cellLName.Width = 100;
                    cellLName.Text = tab.Rows[cnt]["LastName"].ToString();
                    row.Controls.Add(cellLName);

                    TableCell cellMobile = new TableCell();
                    cellMobile.Width = 150;
                    cellMobile.Text = tab.Rows[cnt]["Mobile"].ToString();
                    row.Controls.Add(cellMobile);

                    TableCell cellEmailId = new TableCell();
                    cellEmailId.Width = 200;
                    cellEmailId.Text = tab.Rows[cnt]["EmailId"].ToString();
                    row.Controls.Add(cellEmailId);

                    TableCell cellMore = new TableCell();
                    cellMore.Width = 150;

                    HyperLink hypMore = new HyperLink();
                    hypMore.Text = "MoreDetails";
                    hypMore.ID = "More~" + tab.Rows[cnt]["EmailId"].ToString();
                    hypMore.CssClass = "fancybox fancybox.iframe";
                    hypMore.NavigateUrl = string.Format("frmUserDetails.aspx?UserId={0}", tab.Rows[cnt]["EmailId"].ToString());
                    cellMore.Controls.Add(hypMore);

                    row.Controls.Add(cellMore);

                    TableCell cellDelete = new TableCell();

                    Button btnDelete = new Button();
                    btnDelete.ID = "del~" + tab.Rows[cnt]["EmailId"].ToString();
                    btnDelete.Text = "Delete";
                    btnDelete.ToolTip = "Click here to delete member";
                    btnDelete.OnClientClick = "return confirm('Are you sure do you want to delete?')";
                    btnDelete.Click += new EventHandler(btnDelete_Click);
                    cellDelete.Controls.Add(btnDelete);
                    row.Controls.Add(cellDelete);

                    tableMembers.Controls.Add(row);

                }
            }
            else
            {
                tableMembers.Rows.Clear();
                tableMembers.GridLines = GridLines.None;
                tableMembers.BorderStyle = BorderStyle.None;

                TableRow row = new TableRow();

                TableCell cell = new TableCell();
                cell.ColumnSpan = 10;
                cell.ForeColor = System.Drawing.Color.Red;
                cell.Font.Size = 10;
                cell.Text = "<b>No Members Found</b>";
                cell.HorizontalAlign = HorizontalAlign.Center;
                row.Controls.Add(cell);
                tableMembers.Controls.Add(row);

            }

        }

        void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                BLL obj = new BLL();

                Button btn = (Button)sender;
                string[] emailId = btn.ID.Split('~');

              

                //delete the user postings
                DataTable tabPostings = new DataTable();
                tabPostings = obj.GetPostingsByEmailId(emailId[1]);

                if (tabPostings.Rows.Count > 0)
                {
                    for (int i = 0; i < tabPostings.Rows.Count; i++)
                    {
                        if (tabPostings.Rows[i]["PostType"].Equals("Text"))
                        {
                            obj.DeleteTextByPostId(int.Parse(tabPostings.Rows[i]["PostId"].ToString()));
                        }
                        else if (tabPostings.Rows[i]["PostType"].Equals("Photo"))
                        {
                            DataTable tabPhotos = new DataTable();
                            tabPhotos = obj.GetPhotosByPostId(int.Parse(tabPostings.Rows[i]["PostId"].ToString()));

                            if (tabPhotos.Rows.Count > 0)
                            {
                                for (int j = 0; j < tabPhotos.Rows.Count; j++)
                                {
                                    string attachedfile = tabPhotos.Rows[j]["Photo"].ToString();

                                    if ((attachedfile == null) || (attachedfile == ""))
                                    {

                                    }
                                    else
                                    {
                                        File.Delete(Server.MapPath(tabPhotos.Rows[j]["Photo"].ToString()));
                                    }
                
                                }
                            }

                            obj.DeletePhotosByPostId(int.Parse(tabPostings.Rows[i]["PostId"].ToString()));

                        }
                        else if (tabPostings.Rows[i]["PostType"].Equals("Video"))
                        {
                            obj.DeleteVideosByPostId(int.Parse(tabPostings.Rows[i]["PostId"].ToString()));
                        }
                    }

                    obj.DeletePostingsByUser(emailId[1]);
                }

                DataTable tabMyFriends = new DataTable();
                tabMyFriends = obj.GetMyFriends(emailId[1], emailId[1]);

                if (tabMyFriends.Rows.Count > 0)
                {
                    obj.DeleteMyFriends(emailId[1]);
                }
              
                DataTable tabUser = new DataTable();
                tabUser = obj.GetUserByEmailId(emailId[1]);

                string attachedfile1 = tabUser.Rows[0]["Photo"].ToString();

                if ((attachedfile1 == null) || (attachedfile1 == ""))
                {

                }
                else
                {
                    File.Delete(Server.MapPath(tabUser.Rows[0]["Photo"].ToString()));
                }

               

                obj.DeleteMember(emailId[1]);

                ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('User deleted Successfully')</script>");
                tableMembers.Rows.Clear();
                GetMembers();
            }
            catch
            {

            }
        }

    }
}