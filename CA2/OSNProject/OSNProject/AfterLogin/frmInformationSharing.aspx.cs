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
    public partial class frmInformationSharing : System.Web.UI.Page
    {
        static HttpFileCollection hfcFiles = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!this.IsPostBack)
                {
                    rbtnText.Checked = true;
                    PanelText.Visible = true;
                    LoadNumbers();
                }

               GetSharedInformationByEmailId();
            }
            catch
            {

            }
                                   
        }

        //function to load numbers
        private void LoadNumbers()
        {
            DropDownListPhotoNumber.Items.Clear();
          
            for (int i = 1; i <= 10; i++)
            {
                DropDownListPhotoNumber.Items.Add(i.ToString());
            }

            DropDownListPhotoNumber.Items.Insert(0, "Select");
        }

        //function to load textboxes in to gridview
        private void LoadGridview()
        {
            DataTable tabVideo = new DataTable();

            tabVideo.Columns.Add("SerialNo");

            for (int i = 1; i <= 10; i++)
            {
                DataRow row = tabVideo.NewRow();

                row["SerialNo"] = "Video" + i + ":";
                tabVideo.Rows.Add(row);
            }

            GridView1.DataSource = tabVideo;
            GridView1.DataBind();
        }

        #region ---- Text Messages ----

        //click event to share text essage
        protected void btnText_Click(object sender, EventArgs e)
        {
            BLL obj = new BLL();

            string Type = CheckType();

            if (Type != null)
            {
                obj.InsertPosting(Session["UserId"].ToString(), "Text", Type, DateTime.Now.ToShortDateString());

                int maxPostId = obj.GetMaxPostId();

                obj.InsertText(maxPostId, txtTextTitle.Text, txtTextDescription.Text);

                ClientScript.RegisterStartupScript(this.GetType(), "Key", "<script>alert('Information Shared Successfully!!!')</script>");
                ClearTextboxContents();
                GetSharedInformationByEmailId();

            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Key", "<script>alert('This Message does not belongs to any type!!!')</script>");

            }
        }
               
        //function to clear the textbox contents
        private void ClearTextboxContents()
        {
            txtTextTitle.Text = string.Empty;
            txtTextDescription.Text = string.Empty;
            txtPhotoDescription.Text = string.Empty;
            txtPhotoTitle.Text = string.Empty;
            txtVideoDescription.Text = string.Empty;
            txtVideoTitle.Text = string.Empty;
            LoadGridview();
        }

        #endregion

        #region ---- Photos ----

        protected void btnUploadPhotos_Click(object sender, EventArgs e)
        {
            string fullpath = null;

            BLL obj = new BLL();

            if (DropDownListPhotoNumber.SelectedIndex > 0)
            {
                string Type = CheckType();

                if (Type != null)
                {

                    if (CheckPhotos())
                    {
                        if (Directory.Exists(Server.MapPath("~/AfterLogin/MyPhotos/" + Session["UserId"].ToString() + "/")))
                        {
                            obj.InsertPosting(Session["UserId"].ToString(), "Photo", Type, DateTime.Now.ToShortDateString());

                            int maxPostId = obj.GetMaxPostId();

                            hfcFiles = Request.Files;
                            Directory.CreateDirectory(Server.MapPath("~/AfterLogin/MyPhotos/" + Session["UserId"].ToString() + "/" + maxPostId));

                            for (int i = 0; i < hfcFiles.Count; i++)
                            {
                                HttpPostedFile file = hfcFiles[i];
                                string strExtension = Path.GetExtension(file.FileName);
                                file.SaveAs(Server.MapPath("~/AfterLogin/MyPhotos/" + Session["UserId"].ToString() + "/" + maxPostId + "/Photo" + i + strExtension));

                                fullpath = "~/AfterLogin/MyPhotos/" + Session["UserId"].ToString() + "/" + maxPostId + "/Photo" + i + strExtension;

                                obj.InsertPhoto(maxPostId, txtPhotoTitle.Text, txtPhotoDescription.Text, fullpath);
                            }

                        }
                        else
                        {
                            obj.InsertPosting(Session["UserId"].ToString(), "Photo",Type, DateTime.Now.ToShortDateString());

                            int maxPostId = obj.GetMaxPostId();

                            hfcFiles = Request.Files;
                            Directory.CreateDirectory(Server.MapPath("~/AfterLogin/MyPhotos/" + Session["UserId"].ToString() + "/" + maxPostId));

                            for (int i = 0; i < hfcFiles.Count; i++)
                            {
                                HttpPostedFile file = hfcFiles[i];
                                string strExtension = Path.GetExtension(file.FileName);
                                file.SaveAs(Server.MapPath("~/AfterLogin/MyPhotos/" + Session["UserId"].ToString() + "/" + maxPostId + "/Photo" + i + strExtension));

                                fullpath = "~/AfterLogin/MyPhotos/" + Session["UserId"].ToString() + "/" + maxPostId + "/Photo" + i + strExtension;

                                obj.InsertPhoto(maxPostId, txtPhotoTitle.Text, txtPhotoDescription.Text, fullpath);
                            }
                        }

                        ClearTextboxContents();
                        LoadNumbers();
                        GetSharedInformationByEmailId();
                        Table1.Rows.Clear();
                        ClientScript.RegisterStartupScript(this.GetType(), "Key", "<script>alert('Photos Uploaded Successfully!!!')</script>");
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Key", "<script>alert('Upload Photos')</script>");
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Key", "<script>alert('This Message does not belongs to any type!!!')</script>");

                }

            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Key", "<script>alert('Please Select Content Type and Number of Photos to Upload!!!')</script>");
            }

        }

        private bool CheckPhotos()
        {
            hfcFiles = Request.Files;

            for (int j = 0; j < hfcFiles.Count; j++)
            {
                HttpPostedFile file = hfcFiles[j];

                if (file.FileName.Equals(""))
                {
                    return false;
                }
            }
            return true;
        }

        protected void DropDownListPhotoNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            int serialNo = 1;

            if (DropDownListPhotoNumber.SelectedIndex > 0)
            {
                Table1.Rows.Clear();

                Table1.BorderStyle = BorderStyle.Double;
                Table1.GridLines = GridLines.Both;
                Table1.BorderColor = System.Drawing.Color.DarkGray;

                TableRow headerrow = new TableRow();
                headerrow.Height = 30;
                headerrow.ForeColor = System.Drawing.Color.WhiteSmoke;
                //#bbd142
                headerrow.BackColor = System.Drawing.Color.Gray;

                TableCell cell1 = new TableCell();
                cell1.Text = "<b>SL No</b>";
                headerrow.Controls.Add(cell1);

                TableCell cell2 = new TableCell();
                cell2.Text = "<b>Upload Photo</b>";
                headerrow.Controls.Add(cell2);

                Table1.Controls.Add(headerrow);
                
                for (int i = 0; i < int.Parse(DropDownListPhotoNumber.SelectedValue.ToString()); i++)
                {
                    TableRow row = new TableRow();
                    
                    TableCell row1_cell1 = new TableCell();
                    row1_cell1.Font.Size = 10;
                    int slNo = i + serialNo;
                    row1_cell1.Text = "Photo " + slNo + ".";
                    row.Controls.Add(row1_cell1);
                                       
                    FileUpload file_up = new FileUpload();
                    file_up.ID = i.ToString();
                    file_up.Width = 175;

                    RequiredFieldValidator req = new RequiredFieldValidator();
                    req.ID = i.ToString();
                    req.ControlToValidate = file_up.ID;
                    req.ErrorMessage = "*";
                    req.ValidationGroup = "upload";

                    TableCell cellPhoto = new TableCell();
                    cellPhoto.Controls.Add(file_up);
                    row.Controls.Add(cellPhoto);

                    Table1.Controls.Add(row);

                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Key", "<script>alert('Select Number!!!')</script>");
            }
        }
        
        #endregion

        #region ---- Video ----

        private bool CheckVideos()
        {
            int i = 0;

            foreach (GridViewRow row in GridView1.Rows)
            {
                CheckBox ch = (CheckBox)row.FindControl("CheckBox1");
                TextBox txt = (TextBox)row.FindControl("TextBox1");

                if (ch.Checked)
                {
                    if (txt.Text.Equals(""))

                        return false;

                    ++i;
                }
              
            }

            if (i == 0)

                return false;

            return true;
        }

        protected void btnUploadVideos_Click(object sender, EventArgs e)
        {
            BLL obj = new BLL();

            string Type = CheckType();

            if (Type != null)
            {

                if (CheckVideos())
                {
                    obj.InsertPosting(Session["UserId"].ToString(), "Video",Type, DateTime.Now.ToShortDateString());

                    int maxPostId = obj.GetMaxPostId();

                    foreach (GridViewRow row in GridView1.Rows)
                    {
                        CheckBox ch = (CheckBox)row.FindControl("CheckBox1");
                        TextBox txt = (TextBox)row.FindControl("TextBox1");

                        if (ch.Checked)
                        {
                            obj.InsertVideo(maxPostId, txtVideoTitle.Text, txtVideoDescription.Text, txt.Text);
                        }

                    }

                    LoadNumbers();
                    ClearTextboxContents();
                    GetSharedInformationByEmailId();
                    ClientScript.RegisterStartupScript(this.GetType(), "Key", "<script>alert('Videos Shared Successfully!!!')</script>");
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Key", "<script>alert('Upload Videos')</script>");
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Key", "<script>alert('This Message does not belongs to any type!!!')</script>");

            }
        }
              
        #endregion

        #region ---- Shared Information ------

        //function to retrive the messages based on emailId
        private void GetSharedInformationByEmailId()
        {
            int serialNo = 1;
            DataTable tab = new DataTable();
            BLL obj = new BLL();

            tab = obj.GetPostingsByEmailId(Session["UserId"].ToString());

            if (tab.Rows.Count > 0)
            {
                Table3.Rows.Clear();

                Table3.BorderStyle = BorderStyle.Double;
                Table3.GridLines = GridLines.Both;
                Table3.BorderColor = System.Drawing.Color.DarkGray;

                TableRow headerrow = new TableRow();
                headerrow.Height = 30;
                headerrow.ForeColor = System.Drawing.Color.WhiteSmoke;
                //#bbd142
                headerrow.BackColor = System.Drawing.Color.DarkSlateGray;

                TableCell cell1 = new TableCell();
                cell1.Text = "<b>SLNo</b>";
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

                TableCell Cell5 = new TableCell();
                Cell5.Text = "<b>ContentType</b>";
                headerrow.Controls.Add(Cell5);
                
                TableCell cell6 = new TableCell();
                cell6.Text = "<b>Title</b>";
                headerrow.Controls.Add(cell6);

                TableCell cell7 = new TableCell();
                cell7.Text = "<b>PostedDate</b>";
                headerrow.Controls.Add(cell7);

                Table3.Controls.Add(headerrow);

                for (int cnt = 0; cnt < tab.Rows.Count; cnt++)
                {
                    DataTable tabUsers = new DataTable();
                    tabUsers = obj.GetUserByEmailId(tab.Rows[cnt]["EmailId"].ToString());

                    DataTable tabTitle = new DataTable();

                    if (tab.Rows[cnt]["PostType"].Equals("Text"))
                    {
                        tabTitle = obj.GetTextsByPostId(int.Parse(tab.Rows[cnt]["PostId"].ToString()));
                    }
                    else if (tab.Rows[cnt]["PostType"].Equals("Photo"))
                    {
                        tabTitle = obj.GetPhotosByPostId(int.Parse(tab.Rows[cnt]["PostId"].ToString()));
                    }
                    else if (tab.Rows[cnt]["PostType"].Equals("Video"))
                    {
                        tabTitle = obj.GetVideosByPostId(int.Parse(tab.Rows[cnt]["PostId"].ToString()));
                    }

                    if (tabTitle.Rows.Count > 0)
                    {
                        TableRow row = new TableRow();

                        TableCell rowCell1 = new TableCell();
                        rowCell1.Font.Size = 10;
                        rowCell1.Text = cnt + serialNo + ".";
                        row.Controls.Add(rowCell1);

                        TableCell cellUserId = new TableCell();
                        cellUserId.Width = 100;
                        cellUserId.Text = "<a href='#'>" + tabUsers.Rows[0]["EmailId"].ToString() + "<span>Name : " + tabUsers.Rows[0]["FirstName"].ToString() + ".</br>Address : " + tabUsers.Rows[0]["Address"].ToString() + ".</br>Email ID : " + tabUsers.Rows[0]["EmailId"].ToString() + "</span></a>";
                        row.Controls.Add(cellUserId);

                        TableCell cellFirstName = new TableCell();
                        cellFirstName.Width = 150;
                        cellFirstName.Text = tabUsers.Rows[0]["FirstName"].ToString();
                        row.Controls.Add(cellFirstName);

                        TableCell cellPostType = new TableCell();
                        cellPostType.Width = 100;
                        cellPostType.Text = tab.Rows[cnt]["PostType"].ToString();
                        row.Controls.Add(cellPostType);

                        TableCell cellCT = new TableCell();
                        cellCT.Width = 100;
                        cellCT.Text = tab.Rows[cnt]["ContentType"].ToString();
                        row.Controls.Add(cellCT);

                        TableCell cellMore = new TableCell();
                        cellMore.Width = 550;

                        HyperLink hypMore = new HyperLink();
                        hypMore.Text = tabTitle.Rows[0]["Title"].ToString();
                        hypMore.ID = "More~" + tab.Rows[cnt]["PostId"].ToString();
                        hypMore.CssClass = "fancybox fancybox.iframe";
                        hypMore.NavigateUrl = string.Format("frmSharedInformation.aspx?postId={0}", tab.Rows[cnt]["PostId"].ToString());
                        cellMore.Controls.Add(hypMore);

                        row.Controls.Add(cellMore);

                        TableCell cellPostedDate = new TableCell();
                        cellPostedDate.Width = 100;
                        cellPostedDate.Text = tab.Rows[cnt]["PostedDate"].ToString();
                        row.Controls.Add(cellPostedDate);

                        Table3.Controls.Add(row);
                    }
                }
            }
            else
            {
                Table3.Rows.Clear();
                Table3.GridLines = GridLines.None;

                TableRow row = new TableRow();

                TableCell cell = new TableCell();
                cell.ColumnSpan = 10;
                cell.ForeColor = System.Drawing.Color.Red;
                cell.Font.Size = 10;
                cell.Text = "<b>No Shared Information Found</b>";
                cell.HorizontalAlign = HorizontalAlign.Center;
                row.Controls.Add(cell);
                Table3.Controls.Add(row);
                
            }

        }
        
        #endregion

        protected void rbtnText_CheckedChanged(object sender, EventArgs e)
        {
            PanelText.Visible = true;
            PanelPhotos.Visible = false;
            PanelVideos.Visible = false;
        }

        protected void rbtnPhotos_CheckedChanged(object sender, EventArgs e)
        {
            PanelText.Visible = false;
            PanelPhotos.Visible = true;
            PanelVideos.Visible = false;
        }

        protected void rbtnVideos_CheckedChanged(object sender, EventArgs e)
        {
            PanelText.Visible = false;
            PanelPhotos.Visible = false;
            PanelVideos.Visible = true;
            LoadGridview();
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                CheckBox ch = (CheckBox)row.FindControl("CheckBox1");
                TextBox txt = (TextBox)row.FindControl("TextBox1");

                if (ch.Checked)
                {
                    txt.Visible = true;
                }
                else
                {
                    txt.Visible = false;
                }
            }

        }

        //function to check the input with the predefined keywords
        private string CheckType()
        {
            BLL obj = new BLL();
            string contentType = null;

            //code to remove the stop words [preprocessing of data]
            string[] stopwords = { "a", "about", "above", "above", "across", "after", "afterwards", "again", "against", "all", "almost", "alone", "along", "already", "also", "although", "always", "am", "among", "amongst", "amoungst", "amount", "an", "and", "another", "any", "anyhow", "anyone", "anything", "anyway", "anywhere", "are", "around", "as", "at", "back", "be", "became", "because", "become", "becomes", "becoming", "been", "before", "beforehand", "behind", "being", "below", "beside", "besides", "between", "beyond", "bill", "both", "bottom", "but", "by", "call", "can", "cannot", "cant", "co", "con", "could", "couldnt", "cry", "de", "describe", "detail", "do", "done", "down", "due", "during", "each", "eg", "eight", "either", "eleven", "else", "elsewhere", "empty", "enough", "etc", "even", "ever", "every", "everyone", "everything", "everywhere", "except", "few", "fifteen", "fify", "fill", "find", "fire", "first", "five", "for", "former", "formerly", "forty", "found", "four", "from", "front", "full", "further", "get", "give", "go", "had", "has", "hasnt", "have", "he", "hence", "her", "here", "hereafter", "hereby", "herein", "hereupon", "hers", "herself", "him", "himself", "his", "how", "however", "hundred", "ie", "if", "in", "inc", "indeed", "interest", "into", "is", "it", "its", "itself", "keep", "last", "latter", "latterly", "least", "less", "ltd", "made", "many", "may", "me", "meanwhile", "might", "mill", "mine", "more", "moreover", "most", "mostly", "move", "much", "must", "my", "myself", "name", "namely", "neither", "never", "nevertheless", "next", "nine", "no", "nobody", "none", "noone", "nor", "not", "nothing", "now", "nowhere", "of", "off", "often", "on", "once", "one", "only", "onto", "or", "other", "others", "otherwise", "our", "ours", "ourselves", "out", "over", "own", "part", "per", "perhaps", "please", "put", "rather", "re", "same", "see", "seem", "seemed", "seeming", "seems", "serious", "several", "she", "should", "show", "side", "since", "sincere", "six", "sixty", "so", "some", "somehow", "someone", "something", "sometime", "sometimes", "somewhere", "still", "such", "system", "take", "ten", "than", "that", "the", "their", "them", "themselves", "then", "thence", "there", "thereafter", "thereby", "therefore", "therein", "thereupon", "these", "they", "thickv", "thin", "third", "this", "those", "though", "three", "through", "throughout", "thru", "thus", "to", "together", "too", "top", "toward", "towards", "twelve", "twenty", "two", "un", "under", "until", "up", "upon", "us", "very", "via", "was", "we", "well", "were", "what", "whatever", "when", "whence", "whenever", "where", "whereafter", "whereas", "whereby", "wherein", "whereupon", "wherever", "whether", "which", "while", "whither", "who", "whoever", "whole", "whom", "whose", "why", "will", "with", "within", "without", "would", "yet", "you", "your", "yours", "yourself", "yourselves", "the" };

            string[] title = null;

            if (rbtnText.Checked)
            {
                title = txtTextTitle.Text.Split(' ');
            }
            else if (rbtnPhotos.Checked)
            {
                title = txtPhotoTitle.Text.Split(' ');
            }
            else if (rbtnVideos.Checked)
            {
                title = txtVideoTitle.Text.Split(' ');
            }

            List<string> specialWords = new List<string>();

            for (int i = 0; i < title.Length; i++)
            {
                if (!stopwords.Contains(title[i], StringComparer.InvariantCultureIgnoreCase))
                {
                    specialWords.Add(title[i]);
                }
            }

            string[] terms = specialWords.ToArray();

            DataTable tabContentTypes = new DataTable();
            tabContentTypes = obj.GetContentTypes();

            ArrayList arrayCount = new ArrayList();
            ArrayList arrayContentType = new ArrayList();

            if (tabContentTypes.Rows.Count > 0)
            {
                for (int i = 0; i < tabContentTypes.Rows.Count; i++)
                {
                    DataTable tabWords = new DataTable();
                    tabWords = obj.GetKeywordsByContentType(int.Parse(tabContentTypes.Rows[i]["ContentTypeId"].ToString()));

                    int cnt = 0;

                    for (int j = 0; j < tabWords.Rows.Count; j++)
                    {
                        if (terms.Contains(tabWords.Rows[j]["Keyword"].ToString(), StringComparer.InvariantCultureIgnoreCase))
                        {
                            ++cnt;
                        }
                    }

                    if (cnt > 0)
                    {
                        arrayCount.Add(cnt);
                        arrayContentType.Add(tabContentTypes.Rows[i]["ContentType"].ToString());
                    }
                }

                ArrayList arrayTemp = new ArrayList();

                if (arrayCount.Count > 0)
                {
                    for (int i = 0; i < arrayCount.Count; i++)
                    {
                        arrayTemp.Add(arrayCount[i]);
                    }

                    arrayTemp.Sort();
                    arrayTemp.Reverse();

                    for (int h = 0; h < arrayTemp.Count; h++)
                    {
                        if (arrayCount[h].Equals(arrayTemp[0]))
                        {
                            contentType = arrayContentType[h].ToString();
                            break;
                        }
                    }
                }

            }

            return contentType;
        }
             
    }
}