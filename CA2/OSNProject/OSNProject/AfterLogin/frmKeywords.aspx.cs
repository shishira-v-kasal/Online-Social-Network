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
    public partial class frmKeywords : System.Web.UI.Page
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
                    if (!this.IsPostBack)
                    {
                        LoadTypes();
                    }

                    GetKeywords();
                }
            }
            catch
            {

            }
        }

        //function to load all types into dropdown list - dropdownlistTypes
        private void LoadTypes()
        {
            DataTable tab = new DataTable();
            BLL obj = new BLL();

            tab = obj.GetContentTypes();

            if (tab.Rows.Count > 0)
            {
                DropDownListTypes.Items.Clear();
                DropDownListTypes.DataSource = tab;
                DropDownListTypes.DataTextField = "ContentType";
                DropDownListTypes.DataValueField = "ContentTypeId";

                DropDownListTypes.DataBind();

                DropDownListTypes.Items.Insert(0, "- All -");

            }
            else
            {
                DropDownListTypes.Items.Insert(0, "- Input ContentTypes First-");

            }

        }

        //function to get all words
        private void GetKeywords()
        {
            int serialNo = 1;

            DataTable tab = new DataTable();
            BLL obj = new BLL();

            if (DropDownListTypes.SelectedIndex > 0)
            {
                tab = obj.GetKeywordsByContentType(int.Parse(DropDownListTypes.SelectedValue.ToString()));
            }
            else
            {
                tab = obj.GetAllKeywords();
            }

            if (tab.Rows.Count > 0)
            {
                tblKeywords.Rows.Clear();

                tblKeywords.BorderStyle = BorderStyle.Double;
                tblKeywords.GridLines = GridLines.Both;
                tblKeywords.BorderColor = System.Drawing.Color.DarkGray;

                TableRow headerrow = new TableRow();
                headerrow.Height = 30;
                headerrow.ForeColor = System.Drawing.Color.WhiteSmoke;
                headerrow.BackColor = System.Drawing.Color.DarkSlateGray;

                TableCell cell1 = new TableCell();
                cell1.Text = "<b>SLNo</b>";
                headerrow.Controls.Add(cell1);

                TableCell cell2 = new TableCell();
                cell2.Text = "<b>ContentType</b>";
                headerrow.Controls.Add(cell2);

                TableCell cell3 = new TableCell();
                cell3.Text = "<b>Word</b>";
                headerrow.Controls.Add(cell3);

                if (DropDownListTypes.SelectedIndex > 0)
                {
                    TableCell cell41 = new TableCell();
                    cell41.Text = "<b>Edit</b>";
                    headerrow.Controls.Add(cell41);

                    TableCell cell4 = new TableCell();
                    cell4.Text = "<b>Delete</b>";
                    headerrow.Controls.Add(cell4);
                }

                tblKeywords.Controls.Add(headerrow);

                for (int cnt = 0; cnt < tab.Rows.Count; cnt++)
                {
                    TableRow row = new TableRow();

                    TableCell cellSerialNo = new TableCell();
                    cellSerialNo.Width = 10;
                    cellSerialNo.Font.Size = 10;
                    cellSerialNo.Text = serialNo + cnt + ".";
                    row.Controls.Add(cellSerialNo);

                    TableCell cellContent = new TableCell();
                    cellContent.Width = 150;

                    DataTable tabContent = new DataTable();
                    tabContent = obj.GetContenttypeById(int.Parse(tab.Rows[cnt]["ContentTypeId"].ToString()));

                    cellContent.Text = tabContent.Rows[0]["ContentType"].ToString();
                    row.Controls.Add(cellContent);

                    TableCell cellKeyword = new TableCell();
                    cellKeyword.Width = 150;
                    cellKeyword.Text = tab.Rows[cnt]["Keyword"].ToString();
                    row.Controls.Add(cellKeyword);

                    if (DropDownListTypes.SelectedIndex > 0)
                    {
                        TableCell cell_edit = new TableCell();
                        LinkButton lbtn_edit = new LinkButton();
                        lbtn_edit.ForeColor = System.Drawing.Color.Red;
                        lbtn_edit.Font.Bold = true;
                        lbtn_edit.Text = "Edit";
                        lbtn_edit.ID = "Edit~" + tab.Rows[cnt]["KeyId"].ToString();
                        lbtn_edit.Click += new EventHandler(lbtn_edit_Click);
                        cell_edit.Controls.Add(lbtn_edit);
                        row.Controls.Add(cell_edit);

                        TableCell cellDelete = new TableCell();

                        ImageButton btnDelete = new ImageButton();
                        btnDelete.Width = 15;
                        btnDelete.Height = 15;
                        btnDelete.ImageUrl = "~/images/deletebtn.jpg";
                        btnDelete.ToolTip = "Click here to Delete the Word";
                        btnDelete.ID = "Keyword~" + tab.Rows[cnt]["KeyId"].ToString();
                        btnDelete.OnClientClick = "return confirm('Are you sure do you want to Delete')";
                        btnDelete.Click += new ImageClickEventHandler(btnDelete_Click);

                        cellDelete.Controls.Add(btnDelete);
                        row.Controls.Add(cellDelete);
                    }
                    else
                    {

                    }

                    tblKeywords.Controls.Add(row);

                }

            }
            else
            {
                tblKeywords.Rows.Clear();
                tblKeywords.BorderStyle = BorderStyle.None;

                TableHeaderRow row = new TableHeaderRow();
                TableHeaderCell cell = new TableHeaderCell();
                cell.ColumnSpan = 5;
                cell.Font.Bold = true;
                cell.ForeColor = System.Drawing.Color.Red;

                if (DropDownListTypes.SelectedIndex > 0)
                {
                    cell.Text = "No Words Found for the ContentType - " + DropDownListTypes.SelectedItem.Text;
                }
                else
                {
                    cell.Text = "No Words Found";
                }

                row.Controls.Add(cell);
                tblKeywords.Controls.Add(row);

            }

        }

        void btnDelete_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton btn = (ImageButton)sender;
                string[] s = btn.ID.Split('~');

                BLL obj = new BLL();
                obj.DeleteKeyword(int.Parse(s[1].ToString()));

                //lblSuccess.Font.Bold = true;
                //lblError.Text = " ";
                //lblSuccess.ForeColor = System.Drawing.Color.Green;
                //lblSuccess.Text = "<b>Success:</b>Word Deleted Successfully!!!";

                ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Word Deleted Successfully!!!')</script>");
                GetKeywords();

            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Deletion Error!!!')</script>");
            }
        }

        //function to clear the textboxes
        private void ClearPlaceTextboxes()
        {
            txtKeyword.Text = string.Empty;
            //DropDownListTypes.SelectedIndex = 0;
        }

        protected void DropDownListTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetKeywords();
        }

        protected void btnKeyword_Click(object sender, EventArgs e)
        {
            try
            {
                BLL obj = new BLL();

                if (DropDownListTypes.SelectedIndex > 0)
                {
                    if (btnKeyword.Text == "Add")
                    {
                        if (txtKeyword.Text.Contains(','))
                        {
                            int cnt = 0;

                            string[] s = txtKeyword.Text.Split(',');

                            for (int i = 0; i < s.Length; i++)
                            {
                                if (obj.CheckKeyword(int.Parse(DropDownListTypes.SelectedValue.ToString()), s[i]))
                                {
                                    obj.InsertKeyword(int.Parse(DropDownListTypes.SelectedValue.ToString()), s[i]);                                   
                                }
                                else
                                {
                                    ++cnt;
                                }
                            }

                            if (cnt > 0)
                            {
                                ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Few Words Exists!!!')</script>");
                                ClearPlaceTextboxes();
                                DropDownListTypes_SelectedIndexChanged(sender, e);
                            }
                            else
                            {
                                //lblSuccess.Font.Bold = true;
                                //lblError.Text = " ";
                                //lblSuccess.ForeColor = System.Drawing.Color.Green;
                                //lblSuccess.Text = " <b>Success:</b>Words Added Successfully!!!";
                                ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Words Added Successfully')</script>");
                                ClearPlaceTextboxes();
                                DropDownListTypes_SelectedIndexChanged(sender, e);
                            }

                        }
                        else
                        {
                            if (obj.CheckKeyword(int.Parse(DropDownListTypes.SelectedValue.ToString()), txtKeyword.Text))
                            {
                                obj.InsertKeyword(int.Parse(DropDownListTypes.SelectedValue.ToString()), txtKeyword.Text);
                                //lblSuccess.Font.Bold = true;
                                //lblError.Text = " ";
                                //lblSuccess.ForeColor = System.Drawing.Color.Green;
                                //lblSuccess.Text = " <b>Success:</b>Word Added Successfully!!!";
                                ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Word Added Successfully')</script>");
                                ClearPlaceTextboxes();
                                DropDownListTypes_SelectedIndexChanged(sender, e);
                            }
                            else
                            {
                                //lblSuccess.Text = " ";
                                //lblError.ForeColor = System.Drawing.Color.Red;
                                //lblError.Text = " <b>Error:</b> Word Already Exists!!!";
                                ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Word Exists!!!')</script>");
                            }
                        }
                    }
                    else if (btnKeyword.Text == "Update")
                    {
                        if (txtKeyword.Text.Contains(','))
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Up!!!')</script>");
                        }
                        else
                        {
                            obj.UpdateKeyword(int.Parse(DropDownListTypes.SelectedValue), txtKeyword.Text, int.Parse(Session["KeyId"].ToString()));
                            txtKeyword.Text = string.Empty;
                            ClearPlaceTextboxes();
                            DropDownListTypes_SelectedIndexChanged(sender, e);
                            btnKeyword.Text = "Add";
                            ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Keyword Updated Successfully!!!')</script>");

                        }                        

                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Select ContentType!!!')</script>");
                }

            }
            catch
            {

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

                tabProduct = obj.GetKeywordById(int.Parse(s[1].ToString()));

                txtKeyword.Text = tabProduct.Rows[0]["Keyword"].ToString();


                int CTId = int.Parse(tabProduct.Rows[0]["KeyId"].ToString());

                Session["KeyId"] = null;
                Session["KeyId"] = CTId;

                btnKeyword.Text = "Update";
            }
            catch
            {
                ClientScript.RegisterStartupScript(GetType(), "key", "<script>alert('Server Error - Check the Database Connectivity!!!')</script>");
            }
        }


    }
}