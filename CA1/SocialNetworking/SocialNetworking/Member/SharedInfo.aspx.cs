using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SocialNetworking.Member
{
    public partial class SharedInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                GetPostTypeByPostId();
            }
        }

        //function to get posttype by postId
        private void GetPostTypeByPostId()
        {
            DataTable tab = new DataTable();
            BLL obj = new BLL();

            tab = obj.GetPostingByPostId(int.Parse(Request.QueryString["postId"].ToString()));

            if (tab.Rows[0]["PostType"].Equals("Text"))
            {
                panelText.Visible = true;
                panelPhotos.Visible = false;
                panelVideos.Visible = false;

                lblPostType.Font.Bold = true;
                lblPostType.Font.Size = 14;
                lblPostType.Text = "Post Type: Text";
                GetTextByPostId();
            }
            else if (tab.Rows[0]["PostType"].Equals("Photo"))
            {
                panelText.Visible = false;
                panelPhotos.Visible = true;
                panelVideos.Visible = false;

                lblPostType.Font.Bold = true;
                lblPostType.Font.Size = 14;
                lblPostType.Text = "Post Type: Photo";
                GetPhotosByPostId();
            }
            else if (tab.Rows[0]["PostType"].Equals("Video"))
            {
                panelText.Visible = false;
                panelPhotos.Visible = false;
                panelVideos.Visible = true;

                lblPostType.Font.Bold = true;
                lblPostType.Font.Size = 14;
                lblPostType.Text = "Post Type: Video";
                GetVideosByPostId();
            }

        }

        //function to get texts by postId
        private void GetTextByPostId()
        {
            DataTable tab = new DataTable();
            BLL obj = new BLL();

            tab = obj.GetTextsByPostId(int.Parse(Request.QueryString["postId"].ToString()));

            lblTextTitle.Text = tab.Rows[0]["Title"].ToString();
            lblTextDescription.Text = tab.Rows[0]["Description"].ToString();

        }

        //function to get photos by postid
        private void GetPhotosByPostId()
        {
            DataTable tab = new DataTable();
            BLL obj = new BLL();

            tab = obj.GetPhotosByPostId(int.Parse(Request.QueryString["postId"].ToString()));

            if (tab.Rows.Count > 0)
            {
                TableRow row1 = new TableRow();

                TableCell cellPhotoName = new TableCell();
                cellPhotoName.Width = 750;
                cellPhotoName.Text = "<b>Title : " + tab.Rows[0]["Title"].ToString() + "</b>";
                row1.Controls.Add(cellPhotoName);

                TableRow row2 = new TableRow();

                TableCell row2cell1 = new TableCell();
                row2cell1.Width = 750;
                row2cell1.Text = "<br/>" + "Description : " + tab.Rows[0]["Description"].ToString() + "<br/>";
                row2.Controls.Add(row2cell1);

                Table1.Controls.Add(row1);
                Table1.Controls.Add(row2);

                for (int i = 0; i < tab.Rows.Count; i++)
                {
                    TableRow row3 = new TableRow();

                    TableCell cellPhoto = new TableCell();
                    cellPhoto.VerticalAlign = VerticalAlign.Top;
                    cellPhoto.Width = 50;
                    cellPhoto.Height = 50;
                    HyperLink hypLink = new HyperLink();
                    hypLink.CssClass = "fancybox";
                    Image imgPhoto = new Image();
                    imgPhoto.Width = 150;
                    imgPhoto.Height = 150;
                    imgPhoto.ImageUrl = tab.Rows[i]["Photo"].ToString();
                    hypLink.Controls.Add(imgPhoto);
                    hypLink.NavigateUrl = tab.Rows[i]["Photo"].ToString();
                    cellPhoto.Controls.Add(hypLink);
                    row3.Controls.Add(cellPhoto);

                    Table1.Controls.Add(row3);
                }
            }

        }

        //function to get videos by postid
        private void GetVideosByPostId()
        {
            DataTable tab = new DataTable();
            BLL obj = new BLL();

            tab = obj.GetVideosByPostId(int.Parse(Request.QueryString["postId"].ToString()));

            if (tab.Rows.Count > 0)
            {
                TableRow row1 = new TableRow();

                TableCell cell_videoname = new TableCell();
                cell_videoname.Width = 750;
                cell_videoname.Text = "<b>Title : " + tab.Rows[0]["Title"].ToString() + "</b>";
                row1.Controls.Add(cell_videoname);

                TableRow row2 = new TableRow();

                TableCell row2cell1 = new TableCell();
                row2cell1.Width = 750;
                row2cell1.Text = "<br/>" + "Description : " + tab.Rows[0]["Description"].ToString() + "<br/>";
                row2.Controls.Add(row2cell1);

                Table2.Controls.Add(row1);
                Table2.Controls.Add(row2);

                for (int i = 0; i < tab.Rows.Count; i++)
                {
                    TableRow row3 = new TableRow();

                    TableCell cell_link = new TableCell();
                    cell_link.Text = "<br/>  <iframe width=420 height=315 src=" + tab.Rows[i]["Video"].ToString() + "></iframe><br/><br/><hr/>";
                    row3.Controls.Add(cell_link);

                    Table2.Controls.Add(row3);
                }
            }

        }
      
    }
}