using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

namespace OSNProject.AfterLogin
{
    public partial class frmMyFriends : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           

            MyFriends();

           
        }

        //function to get my friends  
        private void MyFriends()
        {
            int serialNo = 1;
            DataTable tab = new DataTable();
            BLL obj = new BLL();

            tab = obj.GetMyFriends(Session["UserId"].ToString(), Session["UserId"].ToString());

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
                headerrow.BackColor = System.Drawing.Color.DarkSlateGray;

                TableCell cell1 = new TableCell();
                cell1.Text = "<b>SLNo</b>";
                headerrow.Controls.Add(cell1);

                TableCell cell12 = new TableCell();
                cell12.Text = "<b>Photo</b>";
                headerrow.Controls.Add(cell12);

                TableCell cell2 = new TableCell();
                cell2.Text = "<b>Name</b>";
                headerrow.Controls.Add(cell2);

                TableCell cell3 = new TableCell();
                cell3.Text = "<b>More Details</b>";
                headerrow.Controls.Add(cell3);

                Table2.Controls.Add(headerrow);

                for (int cnt = 0; cnt < tab.Rows.Count; cnt++)
                {
                    DataTable tabUsers = new DataTable();

                    if (tab.Rows[cnt]["RequestFrom"].ToString().Equals(Session["UserId"].ToString()))
                    {
                        tabUsers = obj.GetUserByEmailId(tab.Rows[cnt]["RequestTo"].ToString());
                    }
                    else
                    {
                        tabUsers = obj.GetUserByEmailId(tab.Rows[cnt]["RequestFrom"].ToString());
                    }

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
                    imgPhoto.ImageUrl = tabUsers.Rows[0]["Photo"].ToString();
                    hypLink.Controls.Add(imgPhoto);
                    hypLink.NavigateUrl = tabUsers.Rows[0]["Photo"].ToString();
                    cellPhoto.Controls.Add(hypLink);
                    row.Controls.Add(cellPhoto);

                    TableCell cellName = new TableCell();
                    cellName.Width = 250;
                    cellName.Text = tabUsers.Rows[0]["FirstName"].ToString();
                    row.Controls.Add(cellName);

                    TableCell cellMore = new TableCell();

                    HyperLink hypMore = new HyperLink();
                    hypMore.Text = "MoreDetails";
                    hypMore.ID = "More~" + tabUsers.Rows[0]["EmailId"].ToString();
                    hypMore.CssClass = "fancybox fancybox.iframe";
                    hypMore.NavigateUrl = string.Format("frmUserBasicDetails.aspx?UserId={0}", tabUsers.Rows[0]["EmailId"].ToString());
                    cellMore.Controls.Add(hypMore);

                    row.Controls.Add(cellMore);

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
                cell.Text = "<b>No Friends Found</b>";
                cell.HorizontalAlign = HorizontalAlign.Center;
                row.Controls.Add(cell);
                Table2.Controls.Add(row);

            }

        }

       

    }
}