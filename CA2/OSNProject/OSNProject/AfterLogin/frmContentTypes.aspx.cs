using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Web.UI.HtmlControls;

namespace OSNProject.AfterLogin
{
    public partial class frmContentTypes : System.Web.UI.Page
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
                    GetContentTypes();
                }
            }
            catch
            {

            }
        }

        protected void btnContentType_Click(object sender, EventArgs e)
        {
            try
            {
                BLL obj = new BLL();

                if (btnContentType.Text == "Add")
                {
                    if (obj.CheckContentType(txtContentType.Text))
                    {
                        //System.Drawing.Image imgFile = System.Drawing.Image.FromStream(fileuploadPhoto.PostedFile.InputStream);
                        //string photoName = System.IO.Path.GetFileName(fileuploadPhoto.PostedFile.FileName);

                        //int index = photoName.LastIndexOf('.');
                        //string ext = photoName.Substring(index + 1);

                        //string photoPath = Server.MapPath("/AfterLogin/ContentTypes/" + txtContentType.Text + "." + ext);
                        //fileuploadPhoto.PostedFile.SaveAs(photoPath);

                        //string dbPath = "/AfterLogin/ContentTypes/" + txtContentType.Text + "." + ext;
                        string dbPath = null;

                        obj.InsertContentType(txtContentType.Text, dbPath);
                        //lblContentSuccess.Font.Bold = true;
                        //lblContentError.Text = " ";
                        //lblContentSuccess.ForeColor = System.Drawing.Color.Green;
                        //lblContentSuccess.Text = " <b>Success:</b>Area of Interest Added Successfully!!!";
                        ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Area of Interest Added Successfully')</script>");
                        ClearPlaceTextboxes();
                        GetContentTypes();

                    }
                    else
                    {
                        //lblContentSuccess.Text = " ";
                        //lblContentError.ForeColor = System.Drawing.Color.Red;
                        //lblContentError.Text = " <b>Error:</b>Area of Interest Already Exists!!!";
                        ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Area of Interest Exists!!!')</script>");
                    }

                }
                else if (btnContentType.Text == "Update")
                {
                    obj.UpdateCT(txtContentType.Text, int.Parse(Session["CTID"].ToString()));
                    txtContentType.Text = string.Empty;
                    GetContentTypes();
                    ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Area of Interest Updated Successfully!!!')</script>");
                    btnContentType.Text = "Add";
                }

            }
            catch
            {

            }
        }

        //function to get all contenttypes
        private void GetContentTypes()
        {
            int serialNo = 1;

            DataTable tab = new DataTable();
            BLL obj = new BLL();

            tab = obj.GetContentTypes();

            if (tab.Rows.Count > 0)
            {
                tblContentTypes.Rows.Clear();

                tblContentTypes.BorderStyle = BorderStyle.Double;
                tblContentTypes.GridLines = GridLines.Both;
                tblContentTypes.BorderColor = System.Drawing.Color.DarkGray;

                TableRow headerrow = new TableRow();
                headerrow.Height = 30;
                headerrow.ForeColor = System.Drawing.Color.WhiteSmoke;
                headerrow.BackColor = System.Drawing.Color.DarkSlateGray;

                TableCell cell1 = new TableCell();
                cell1.Text = "<b>SLNo</b>";
                headerrow.Controls.Add(cell1);

                TableCell cell3 = new TableCell();
                cell3.Text = "<b>Area of Interest</b>";
                headerrow.Controls.Add(cell3);

                TableCell cell41 = new TableCell();
                cell41.Text = "<b>Edit</b>";
                headerrow.Controls.Add(cell41);

                TableCell cell4 = new TableCell();
                cell4.Text = "<b>Delete</b>";
                headerrow.Controls.Add(cell4);


                tblContentTypes.Controls.Add(headerrow);

                for (int cnt = 0; cnt < tab.Rows.Count; cnt++)
                {
                    TableRow row = new TableRow();

                    TableCell cellSerialNo = new TableCell();
                    cellSerialNo.Width = 10;
                    cellSerialNo.Font.Size = 10;
                    cellSerialNo.Text = serialNo + cnt + ".";
                    row.Controls.Add(cellSerialNo);

                    TableCell cellContentType = new TableCell();
                    cellContentType.Width = 150;
                    cellContentType.Text = tab.Rows[cnt]["ContentType"].ToString();
                    row.Controls.Add(cellContentType);

                    TableCell cell_edit = new TableCell();
                    LinkButton lbtn_edit = new LinkButton();
                    lbtn_edit.ForeColor = System.Drawing.Color.Red;
                    lbtn_edit.Font.Bold = true;
                    lbtn_edit.Text = "Edit";
                    lbtn_edit.ID = "Edit~" + tab.Rows[cnt]["ContentTypeId"].ToString();
                    lbtn_edit.Click += new EventHandler(lbtn_edit_Click);
                    cell_edit.Controls.Add(lbtn_edit);
                    row.Controls.Add(cell_edit);

                    TableCell cellDelete = new TableCell();

                    ImageButton btnDelete = new ImageButton();
                    btnDelete.Width = 15;
                    btnDelete.Height = 15;
                    btnDelete.ImageUrl = "~/images/deletebtn.jpg";
                    btnDelete.ToolTip = "Click here to Delete the Place";
                    btnDelete.ID = "Delete~" + tab.Rows[cnt]["ContentTypeId"].ToString();
                    btnDelete.OnClientClick = "return confirm('Are you sure do you want to Delete')";
                    btnDelete.Click += new ImageClickEventHandler(btnDelete_Click);

                    cellDelete.Controls.Add(btnDelete);
                    row.Controls.Add(cellDelete);

                    tblContentTypes.Controls.Add(row);

                }

            }
            else
            {
                tblContentTypes.Rows.Clear();
                tblContentTypes.BorderStyle = BorderStyle.None;

                TableHeaderRow row = new TableHeaderRow();
                TableHeaderCell cell = new TableHeaderCell();
                cell.ColumnSpan = 5;
                cell.Font.Bold = true;
                cell.ForeColor = System.Drawing.Color.Red;
                cell.Text = "No ContentTypes Found";
                row.Controls.Add(cell);

                tblContentTypes.Controls.Add(row);

            }

        }

        void lbtn_edit_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = (LinkButton)sender;
                string[] s = btn.ID.Split('~');

                DataTable tabProduct = new DataTable();
                BLL obj = new BLL();

                tabProduct = obj.GetContenttypeById(int.Parse(s[1].ToString()));

                txtContentType.Text = tabProduct.Rows[0]["ContentType"].ToString();


                int CTId = int.Parse(tabProduct.Rows[0]["ContentTypeId"].ToString());

                Session["CTID"] = null;
                Session["CTID"] = CTId;

                btnContentType.Text = "Update";
            }
            catch
            {
                ClientScript.RegisterStartupScript(GetType(), "key", "<script>alert('Server Error - Check the Database Connectivity!!!')</script>");
            }
        }

        void btnDelete_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton btn = (ImageButton)sender;
                string[] s = btn.ID.Split('~');

                BLL obj = new BLL();
                //obj.DeleteKeywordsByContentType(int.Parse(s[1].ToString()));
                obj.DeleteContentType(int.Parse(s[1].ToString()));

                //lblContentSuccess.Font.Bold = true;
                //lblContentError.Text = " ";
                //lblContentSuccess.ForeColor = System.Drawing.Color.Green;
                //lblContentSuccess.Text = "<b>Success:</b>Area of Interest Deleted Successfully!!!";

                ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Area of Interest Deleted Successfully!!!')</script>");
                GetContentTypes();
                btnContentType.Text = "Add";
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Deletion Error!!!(Server Error!!!)')</script>");
            }
        }

        //function to clear the place textboxes
        private void ClearPlaceTextboxes()
        {
            txtContentType.Text = string.Empty;
        }

    }
}