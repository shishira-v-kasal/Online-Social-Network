using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

namespace OSNProject
{
    public partial class frmUserHome : System.Web.UI.Page
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
                headerrow.BackColor = System.Drawing.Color.DarkSlateGray;

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

                    if (tab.Rows[cnt]["RequestFrom"].ToString().Equals(Session["UserId"].ToString()))
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
                            hypMore.NavigateUrl = string.Format("frmSharedInformation.aspx?postId={0}", tabPostings.Rows[j]["PostId"].ToString());
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

        //function to get friend request (algorithm steps)
        private void GetFriendRequests()
        {
            DataTable tab = new DataTable();
            BLL1 obj1 = new BLL1();

            BLL obj2 = new BLL();

            tab = obj2.GetFriendRequests(Session["UserId"].ToString());

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
                cell6.Text = "<b>Status</b>";
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
                    //profile matching
                    DataTable tabUsers = new DataTable();

                    if (tab.Rows[cnt]["RequestFrom"].ToString().Equals(Session["UserId"].ToString()))
                    {                       
                        tabUsers = obj2.GetUserByEmailId(tab.Rows[cnt]["RequestTo"].ToString());
                    }
                    else
                    {
                        tabUsers = obj2.GetUserByEmailId(tab.Rows[cnt]["RequestFrom"].ToString());
                    }                                                         

                    DataTable tabUsers1 = new DataTable();
                    //email exisits
                    tabUsers1 = obj1.GetUserDetails_OSN1(tabUsers.Rows[0]["EmailId"].ToString());

                    //Cosine Method

                    ArrayList _arrayConstraints = new ArrayList();

                    string _firstName1 = null;
                    string _lastName1 = null;
                    string _DOB1 = null;
                    string _HighSchool1 = null;
                    string _College1 = null;
                    string _Employer1 = null;
                    string _currentCity1 = null;
                    string _homeTown1 = null;
                    string _relStatus1 = null;
                    string _aboutU1 = null;
                    string _languages1 = null;
                    string _religion1 = null;
                    string _zipCode1 = null;

                    _firstName1 = tabUsers1.Rows[0]["FirstName"].ToString();
                    _lastName1 = tabUsers1.Rows[0]["LastName"].ToString();
                    _DOB1 = tabUsers1.Rows[0]["DateOfBirth"].ToString();
                    _HighSchool1 = tabUsers1.Rows[0]["HighSchool"].ToString();
                    _College1 = tabUsers1.Rows[0]["College"].ToString();
                    _Employer1 = tabUsers1.Rows[0]["Employer"].ToString();
                    _currentCity1 = tabUsers1.Rows[0]["CurrentCity"].ToString();
                    _homeTown1 = tabUsers1.Rows[0]["HomeTown"].ToString();
                    _relStatus1 = tabUsers1.Rows[0]["RelationshipStatus"].ToString();
                    _aboutU1 = tabUsers1.Rows[0]["AboutU"].ToString();
                    _languages1 = tabUsers1.Rows[0]["Languages"].ToString();
                    _religion1 = tabUsers1.Rows[0]["Religion"].ToString();
                    _zipCode1 = tabUsers1.Rows[0]["ZipCode"].ToString();

                    string _firstName2 = null;
                    string _lastName2 = null;
                    string _DOB2 = null;
                    string _HighSchool2 = null;
                    string _College2 = null;
                    string _Employer2 = null;
                    string _currentCity2 = null;
                    string _homeTown2 = null;
                    string _relStatus2 = null;
                    string _aboutU2 = null;
                    string _languages2 = null;
                    string _religion2 = null;
                    string _zipCode2 = null;

                    _firstName2 = tabUsers.Rows[0]["FirstName"].ToString();
                    _lastName2 = tabUsers.Rows[0]["LastName"].ToString();
                    _DOB2 = tabUsers.Rows[0]["DateOfBirth"].ToString();
                    _HighSchool2 = tabUsers.Rows[0]["HighSchool"].ToString();
                    _College2 = tabUsers.Rows[0]["College"].ToString();
                    _Employer2 = tabUsers.Rows[0]["Employer"].ToString();
                    _currentCity2 = tabUsers.Rows[0]["CurrentCity"].ToString();
                    _homeTown2 = tabUsers.Rows[0]["HomeTown"].ToString();
                    _relStatus2 = tabUsers.Rows[0]["RelationshipStatus"].ToString();
                    _aboutU2 = tabUsers.Rows[0]["AboutU"].ToString();
                    _languages2 = tabUsers.Rows[0]["Languages"].ToString();
                    _religion2 = tabUsers.Rows[0]["Religion"].ToString();
                    _zipCode2 = tabUsers.Rows[0]["ZipCode"].ToString();

                    //firstName Similarity
                    char[] s1_firstName = new char[_firstName1.Length];

                    for (int i = 0; i < _firstName1.Length; i++)
                    {
                        s1_firstName[i]= _firstName1[i];
                    }

                    char[] s2_firstName = new char[_firstName2.Length];

                    for (int i = 0; i < _firstName2.Length; i++)
                    {
                        s2_firstName[i] = _firstName2[i];
                    }

                    int _cntFirstName = 0;
                    int _machingFirstNameCnt = 0;

                    if (_firstName1.Length < _firstName2.Length)
                    {
                        _cntFirstName = _firstName1.Length;
                    }
                    else
                    {
                        _cntFirstName = _firstName2.Length;
                    }

                    for (int j = 0; j < _cntFirstName; j++)
                    {
                        if (s1_firstName[j].Equals(s2_firstName[j]))
                        {
                            ++_machingFirstNameCnt;
                        }
                    }

                    //similarity
                    double _firstNameSim = 0;
                    _firstNameSim = double.Parse(_machingFirstNameCnt.ToString()) / _cntFirstName;

                    //threshold
                    double _threshold = 0.2;

                    if (_firstNameSim >= _threshold)
                    {
                        _arrayConstraints.Add("FirstName");
                    }

                    //lastName Similarity
                    char[] s1_lastName = new char[_lastName1.Length];

                    for (int i = 0; i < _lastName1.Length; i++)
                    {
                        s1_lastName[i] = _lastName1[i];
                    }

                    char[] s2_lastName = new char[_lastName2.Length];

                    for (int i = 0; i < _lastName2.Length; i++)
                    {
                        s2_lastName[i] = _lastName2[i];
                    }

                    int _cntlastName = 0;
                    int _machinglastCnt = 0;

                    if (_lastName1.Length < _lastName2.Length)
                    {
                        _cntlastName = _lastName1.Length;
                    }
                    else
                    {
                        _cntlastName = _lastName2.Length;
                    }

                    for (int j = 0; j < _cntlastName; j++)
                    {
                        if (s1_lastName[j].Equals(s2_lastName[j]))
                        {
                            ++_machinglastCnt;
                        }
                    }

                    //similarity
                    double _lastNameSim = 0;
                    _lastNameSim = double.Parse(_machinglastCnt.ToString()) / _cntlastName;

                    if (_lastNameSim >= _threshold)
                    {
                        _arrayConstraints.Add("LastName");
                    }


                    //DOB Similarity
                    char[] s1_DOB = new char[_DOB1.Length];

                    for (int i = 0; i < _DOB1.Length; i++)
                    {
                        s1_DOB[i] = _DOB1[i];
                    }

                    char[] s2_DOB = new char[_DOB2.Length];

                    for (int i = 0; i < _DOB2.Length; i++)
                    {
                        s2_DOB[i] = _DOB2[i];
                    }

                    int _cntDOB = 0;
                    int _machingDOBCnt = 0;

                    if (_DOB1.Length < _DOB2.Length)
                    {
                        _cntDOB = _DOB1.Length;
                    }
                    else
                    {
                        _cntDOB = _DOB2.Length;
                    }

                    for (int j = 0; j < _cntDOB; j++)
                    {
                        if (s1_DOB[j].Equals(s2_DOB[j]))
                        {
                            ++_machingDOBCnt;
                        }
                    }

                    //similarity
                    double _DOBSim = 0;
                    _DOBSim = double.Parse(_machingDOBCnt.ToString()) / _cntDOB;

                    if (_DOBSim >= _threshold)
                    {
                        _arrayConstraints.Add("DOB");
                    }

                    //Highschool Similarity
                    char[] s1_HighSchool = new char[_HighSchool1.Length];

                    for (int i = 0; i < _HighSchool1.Length; i++)
                    {
                        s1_HighSchool[i] = _HighSchool1[i];
                    }

                    char[] s2_HighSchool = new char[_HighSchool2.Length];

                    for (int i = 0; i < _HighSchool2.Length; i++)
                    {
                        s2_HighSchool[i] = _HighSchool2[i];
                    }

                    int _cntHighSchool = 0;
                    int _machingHighSchoolCnt = 0;

                    if (_HighSchool1.Length < _HighSchool2.Length)
                    {
                        _cntHighSchool = _HighSchool1.Length;
                    }
                    else
                    {
                        _cntHighSchool = _HighSchool2.Length;
                    }

                    for (int j = 0; j < _cntHighSchool; j++)
                    {
                        if (s1_HighSchool[j].Equals(s2_HighSchool[j]))
                        {
                            ++_machingHighSchoolCnt;
                        }
                    }

                    //similarity
                    double _HighSchoolSim = 0;
                    _HighSchoolSim = double.Parse(_machingHighSchoolCnt.ToString()) / _cntHighSchool;

                    if (_HighSchoolSim >= _threshold)
                    {
                        _arrayConstraints.Add("HighSchool");
                    }

                    //College Similarity
                    char[] s1_College = new char[_College1.Length];

                    for (int i = 0; i < _College1.Length; i++)
                    {
                        s1_College[i] = _College1[i];
                    }

                    char[] s2_College = new char[_College2.Length];

                    for (int i = 0; i < _College2.Length; i++)
                    {
                        s2_College[i] = _College2[i];
                    }

                    int _cntCollege = 0;
                    int _machingCollegeCnt = 0;

                    if (_College1.Length < _College2.Length)
                    {
                        _cntCollege = _College1.Length;
                    }
                    else
                    {
                        _cntCollege = _College2.Length;
                    }

                    for (int j = 0; j < _cntCollege; j++)
                    {
                        if (s1_College[j].Equals(s2_College[j]))
                        {
                            ++_machingCollegeCnt;
                        }
                    }

                    //similarity
                    double _CollegeSim = 0;
                    _CollegeSim = double.Parse(_machingCollegeCnt.ToString()) / _cntCollege;

                    if (_CollegeSim >= _threshold)
                    {
                        _arrayConstraints.Add("College");
                    }

                    //Employer Similarity
                    char[] s1_Employer = new char[_Employer1.Length];

                    for (int i = 0; i < _Employer1.Length; i++)
                    {
                        s1_Employer[i] = _Employer1[i];
                    }

                    char[] s2_Employer = new char[_Employer2.Length];

                    for (int i = 0; i < _Employer2.Length; i++)
                    {
                        s2_Employer[i] = _Employer2[i];
                    }

                    int _cntEmployer = 0;
                    int _machingEmployerCnt = 0;

                    if (_Employer1.Length < _Employer2.Length)
                    {
                        _cntEmployer = _Employer1.Length;
                    }
                    else
                    {
                        _cntEmployer = _Employer2.Length;
                    }

                    for (int j = 0; j < _cntEmployer; j++)
                    {
                        if (s1_Employer[j].Equals(s2_Employer[j]))
                        {
                            ++_machingEmployerCnt;
                        }
                    }

                    //similarity
                    double _EmployerSim = 0;
                    _EmployerSim = double.Parse(_machingEmployerCnt.ToString()) / _cntEmployer;

                    if (_EmployerSim >= _threshold)
                    {
                        _arrayConstraints.Add("Employer");
                    }

                    //CurrentCity Similarity
                    char[] s1_CurrentCity = new char[_currentCity1.Length];

                    for (int i = 0; i < _currentCity1.Length; i++)
                    {
                        s1_CurrentCity[i] = _currentCity1[i];
                    }

                    char[] s2_CurrentCity = new char[_currentCity2.Length];

                    for (int i = 0; i < _currentCity2.Length; i++)
                    {
                        s2_CurrentCity[i] = _currentCity2[i];
                    }

                    int _cntcurrentcity = 0;
                    int _machingcurrentCityCnt = 0;

                    if (_currentCity1.Length < _currentCity2.Length)
                    {
                        _cntcurrentcity = _currentCity1.Length;
                    }
                    else
                    {
                        _cntcurrentcity = _currentCity2.Length;
                    }

                    for (int j = 0; j < _cntcurrentcity; j++)
                    {
                        if (s1_CurrentCity[j].Equals(s2_CurrentCity[j]))
                        {
                            ++_machingcurrentCityCnt;
                        }
                    }

                    //similarity
                    double _CurrentcitySim = 0;
                    _CurrentcitySim = double.Parse(_machingcurrentCityCnt.ToString()) / _cntcurrentcity;

                    if (_CurrentcitySim >= _threshold)
                    {
                        _arrayConstraints.Add("CurrentCity");
                    }

                    //HomeTown Similarity
                    char[] s1_Hometown = new char[_homeTown1.Length];

                    for (int i = 0; i < _homeTown1.Length; i++)
                    {
                        s1_Hometown[i] = _homeTown1[i];
                    }

                    char[] s2_Hometown = new char[_homeTown2.Length];

                    for (int i = 0; i < _homeTown2.Length; i++)
                    {
                        s2_Hometown[i] = _homeTown2[i];
                    }

                    int _cntHometown= 0;
                    int _machingHometownCnt = 0;

                    if (_homeTown1.Length < _homeTown2.Length)
                    {
                        _cntHometown = _homeTown1.Length;
                    }
                    else
                    {
                        _cntHometown = _homeTown2.Length;
                    }

                    for (int j = 0; j < _cntHometown; j++)
                    {
                        if (s1_Hometown[j].Equals(s2_Hometown[j]))
                        {
                            ++_machingHometownCnt;
                        }
                    }

                    //similarity
                    double _HometownSim = 0;
                    _HometownSim = double.Parse(_machingHometownCnt.ToString()) / _cntHometown;

                    if (_HometownSim >= _threshold)
                    {
                        _arrayConstraints.Add("Hometown");
                    }

                    //Relationship Status Similarity
                    char[] s1_relStatus = new char[_relStatus1.Length];

                    for (int i = 0; i < _relStatus1.Length; i++)
                    {
                        s1_relStatus[i] = _relStatus1[i];
                    }

                    char[] s2_relStatus = new char[_relStatus2.Length];

                    for (int i = 0; i < _relStatus2.Length; i++)
                    {
                        s2_relStatus[i] = _relStatus2[i];
                    }

                    int _cntrelStatus = 0;
                    int _machingrelStatusCnt = 0;

                    if (_relStatus1.Length < _relStatus2.Length)
                    {
                        _cntrelStatus = _relStatus1.Length;
                    }
                    else
                    {
                        _cntrelStatus = _relStatus2.Length;
                    }

                    for (int j = 0; j < _cntrelStatus; j++)
                    {
                        if (s1_relStatus[j].Equals(s2_relStatus[j]))
                        {
                            ++_machingrelStatusCnt;
                        }
                    }

                    //similarity
                    double _relStatusSim = 0;
                    _relStatusSim = double.Parse(_machingrelStatusCnt.ToString()) / _cntrelStatus;

                    if (_relStatusSim >= _threshold)
                    {
                        _arrayConstraints.Add("RelationshipStatus");
                    }


                    //About U Similarity
                    char[] s1_aboutU = new char[_aboutU1.Length];

                    for (int i = 0; i < _aboutU1.Length; i++)
                    {
                        s1_aboutU[i] = _aboutU1[i];
                    }

                    char[] s2_aboutU = new char[_aboutU2.Length];

                    for (int i = 0; i < _aboutU2.Length; i++)
                    {
                        s2_aboutU[i] = _aboutU2[i];
                    }

                    int _cntaboutU = 0;
                    int _machingaboutUCnt = 0;

                    if (_aboutU1.Length < _aboutU2.Length)
                    {
                        _cntaboutU = _aboutU1.Length;
                    }
                    else
                    {
                        _cntaboutU = _aboutU2.Length;
                    }

                    for (int j = 0; j < _cntaboutU; j++)
                    {
                        if (s1_aboutU[j].Equals(s2_aboutU[j]))
                        {
                            ++_machingaboutUCnt;
                        }
                    }

                    //similarity
                    double _aboutUSim = 0;
                    _aboutUSim = double.Parse(_machingaboutUCnt.ToString()) / _cntaboutU;

                    if (_aboutUSim >= _threshold)
                    {
                        _arrayConstraints.Add("AboutU");
                    }


                    //Lanaguages Similarity
                    char[] s1_Languages = new char[_languages1.Length];

                    for (int i = 0; i < _languages1.Length; i++)
                    {
                        s1_Languages[i] = _languages1[i];
                    }

                    char[] s2_Languages = new char[_languages2.Length];

                    for (int i = 0; i < _languages2.Length; i++)
                    {
                        s2_Languages[i] = _languages2[i];
                    }

                    int _cntlanguages = 0;
                    int _machinglanguagesCnt = 0;

                    if (_languages1.Length < _languages2.Length)
                    {
                        _cntlanguages = _languages1.Length;
                    }
                    else
                    {
                        _cntlanguages = _languages2.Length;
                    }

                    for (int j = 0; j < _cntlanguages; j++)
                    {
                        if (s1_Languages[j].Equals(s2_Languages[j]))
                        {
                            ++_machinglanguagesCnt;
                        }
                    }

                    //similarity
                    double _languagesSim = 0;
                    _languagesSim = double.Parse(_machinglanguagesCnt.ToString()) / _cntlanguages;

                    if (_languagesSim >= _threshold)
                    {
                        _arrayConstraints.Add("Languages");
                    }

                    //Religion Similarity
                    char[] s1_Religion = new char[_religion1.Length];

                    for (int i = 0; i < _religion1.Length; i++)
                    {
                        s1_Religion[i] = _religion1[i];
                    }

                    char[] s2_Religion = new char[_religion2.Length];

                    for (int i = 0; i < _religion2.Length; i++)
                    {
                        s2_Religion[i] = _religion2[i];
                    }

                    int _cntreligion = 0;
                    int _machingreligionCnt = 0;

                    if (_religion1.Length < _religion2.Length)
                    {
                        _cntreligion = _religion1.Length;
                    }
                    else
                    {
                        _cntreligion = _religion2.Length;
                    }

                    for (int j = 0; j < _cntreligion; j++)
                    {
                        if (s1_Religion[j].Equals(s2_Religion[j]))
                        {
                            ++_machingreligionCnt;
                        }
                    }

                    //similarity
                    double _religionSim = 0;
                    _religionSim = double.Parse(_machingreligionCnt.ToString()) / _cntreligion;

                    if (_religionSim >= _threshold)
                    {
                        _arrayConstraints.Add("Religion");
                    }


                    //ZipCode Similarity
                    char[] s1_Zipcode = new char[_zipCode1.Length];

                    for (int i = 0; i < _zipCode1.Length; i++)
                    {
                        s1_Zipcode[i] = _zipCode1[i];
                    }

                    char[] s2_ZipCode = new char[_zipCode2.Length];

                    for (int i = 0; i < _zipCode2.Length; i++)
                    {
                        s2_ZipCode[i] = _zipCode2[i];
                    }

                    int _cntzipcode = 0;
                    int _machingzipcodeCnt = 0;

                    if (_zipCode1.Length < _zipCode2.Length)
                    {
                        _cntzipcode = _zipCode1.Length;
                    }
                    else
                    {
                        _cntzipcode = _zipCode2.Length;
                    }

                    for (int j = 0; j < _cntzipcode; j++)
                    {
                        if (s1_Zipcode[j].Equals(s2_ZipCode[j]))
                        {
                            ++_machingzipcodeCnt;
                        }
                    }

                    //similarity
                    double _zipcodeSim = 0;
                    _zipcodeSim = double.Parse(_machingzipcodeCnt.ToString()) / _cntzipcode;

                    if (_zipcodeSim >= _threshold)
                    {
                        _arrayConstraints.Add("Zipcode");
                    }                                       
                                                                               
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

                    //Get User AOI, Activities
                    string _A1 = LoadUserA1(tabUsers.Rows[0]["EmailId"].ToString());

                    string[] SA1 = null;

                    if (_A1 == null)
                    {

                    }
                    else
                    {
                        SA1 = _A1.Split(',');
                    }

                    string _A2 = LoadUserA2(tabUsers.Rows[0]["EmailId"].ToString());

                    string[] SA2 = null;

                    if (_A2 == null)
                    {

                    }
                    else
                    {
                        SA2 = _A2.Split(',');
                    }

                    TableCell cellStatus = new TableCell();
                    cellStatus.Width = 100;

                    //number of constraints to match
                    int _consThreshold = 8;

                    if (_consThreshold < int.Parse(_arrayConstraints.Count.ToString()))
                    {
                        if (_A1 == null || _A2 == null)
                        {
                            cellStatus.ForeColor = System.Drawing.Color.Red;
                            cellStatus.Text = "Fake" + "<br/>" + "[OSN1:" + _A1 + "<br/>" + "OSN2:" + _A2 + "]";
                        }
                        else
                        {
                            if (_A1.Equals(_A2))
                            {
                                cellStatus.ForeColor = System.Drawing.Color.Green;
                                cellStatus.Text = "Genuine" + "<br/>" + "[OSN1:" + _A1 + "<br/>" + "OSN2:" + _A2 + "]";
                            }
                            else
                            {
                                cellStatus.ForeColor = System.Drawing.Color.Red;
                                cellStatus.Text = "Fake" + "<br/>" + "[OSN1:" + _A1 + "<br/>" + "OSN2:" + _A2 + "]";
                            }
                        }
                    }
                    else
                    {
                        if (int.Parse(_arrayConstraints.Count.ToString()) >= 6)
                        {
                            if (_A1 == null || _A2 == null)
                            {
                                cellStatus.ForeColor = System.Drawing.Color.Red;
                                cellStatus.Text = "Fake" + "<br/>" + "[OSN1:" + _A1 + "<br/>" + "OSN2:" + _A2 + "]";
                            }
                            else
                            {
                                if (_A1.Equals(_A2))
                                {
                                    cellStatus.ForeColor = System.Drawing.Color.Green;
                                    cellStatus.Text = "Genuine" + "<br/>" + "[OSN1:" + _A1 + "<br/>" + "OSN2:" + _A2 + "]";
                                }
                                else
                                {
                                    cellStatus.ForeColor = System.Drawing.Color.Red;
                                    cellStatus.Text = "Fake" + "<br/>" + "[OSN1:" + _A1 + "<br/>" + "OSN2:" + _A2 + "]";
                                }
                            }
                        }
                        else
                        {
                            cellStatus.ForeColor = System.Drawing.Color.Red;
                            cellStatus.Text = "Fake" + "<br/>" + "[OSN1:" + _A1 + "<br/>" + "OSN2:" + _A2 + "]";
                        }
                    }                        

                    row.Controls.Add(cellStatus);

                    TableCell cellMore = new TableCell();

                    HyperLink hypMore = new HyperLink();
                    hypMore.Text = "MoreDetails";
                    hypMore.ID = "More~" + tabUsers.Rows[0]["EmailId"].ToString();
                    hypMore.CssClass = "fancybox fancybox.iframe";
                    hypMore.NavigateUrl = string.Format("frmUserDetails.aspx?UserId={0}", tabUsers.Rows[0]["EmailId"].ToString());
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

        //function to load user's area of interest
        private string LoadUserA1(string emailId)
        {
            BLL1 obj = new BLL1();
            DataTable tab = new DataTable();
            string UserAOI = null;

            //Preprocessing: Includes Training of the system. 
            tab = obj.GetContentTypes_OSN1();//select *from tblContentTypes [retrives the community types]

            if (tab.Rows.Count > 0)
            {
                ArrayList ArrayCnt = new ArrayList();
                ArrayList ArrayContentType = new ArrayList();
                ArrayList ArrayTemp = new ArrayList();
                ArrayList arrayExists = new ArrayList();

                for (int j = 0; j < tab.Rows.Count; j++)
                {
                    // Extraction: Includes Data extraction from OSN [Necessary data for mining]                    
                    int cnt = obj.GetPostingsByEmailIdandTypes_OSN1(emailId, tab.Rows[j]["ContentType"].ToString());

                    if (cnt != 0)
                    {
                        //threshold value for identifying the user's AOI
                        if (cnt > 2)
                        {
                            ArrayCnt.Add(cnt);
                            ArrayContentType.Add(tab.Rows[j]["ContentType"].ToString());
                        }
                    }
                }

                if (ArrayCnt.Count > 0)
                {
                    for (int z = 0; z < ArrayCnt.Count; z++)
                    {
                        //put count into one temp array
                        ArrayTemp.Add(ArrayCnt[z]);
                    }

                    ArrayTemp.Sort();
                    ArrayTemp.Reverse();
                    //after array reverse arrayTemp[0] contains the highest count

                    string _U1_Patterns = null;

                    if (ArrayTemp.Count > 3)
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            int d = 0;

                            for (int h = 0; h < ArrayTemp.Count; h++)
                            {
                                if (ArrayCnt[h].Equals(ArrayTemp[k]))
                                {
                                    if (d == 0 && !arrayExists.Contains(ArrayContentType[h]))
                                    {
                                        //storing the user AOI using string
                                        _U1_Patterns += ArrayContentType[h].ToString() + ",";

                                        arrayExists.Add(ArrayContentType[h]);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int k = 0; k < ArrayTemp.Count; k++)
                        {
                            int d = 0;

                            for (int h = 0; h < ArrayTemp.Count; h++)
                            {
                                if (ArrayCnt[h].Equals(ArrayTemp[k]))
                                {
                                    if (d == 0 && !arrayExists.Contains(ArrayContentType[h]))
                                    {
                                        //storing the user AOI using string
                                        _U1_Patterns += ArrayContentType[h].ToString() + ",";

                                        arrayExists.Add(ArrayContentType[h]);
                                    }
                                }
                            }
                        }
                    }

                    UserAOI = _U1_Patterns.Substring(0, _U1_Patterns.Length - 1);
                }
                else
                {

                }
            }

            return UserAOI;
        }

        //function to load user's area of interest
        private string LoadUserA2(string emailId)
        {
            BLL obj = new BLL();
            DataTable tab = new DataTable();
            string UserAOI = null;

            //Preprocessing: Includes Training of the system. 
            tab = obj.GetContentTypes();//select *from tblContentTypes [retrives the community types]

            if (tab.Rows.Count > 0)
            {
                ArrayList ArrayCnt = new ArrayList();
                ArrayList ArrayContentType = new ArrayList();
                ArrayList ArrayTemp = new ArrayList();
                ArrayList arrayExists = new ArrayList();

                for (int j = 0; j < tab.Rows.Count; j++)
                {
                    // Extraction: Includes Data extraction from OSN [Necessary data for mining]                    
                    int cnt = obj.GetPostingsByEmailIdandType(emailId, tab.Rows[j]["ContentType"].ToString());

                    if (cnt != 0)
                    {
                        //threshold value for identifying the user's AOI
                        if (cnt > 2)
                        {
                            ArrayCnt.Add(cnt);
                            ArrayContentType.Add(tab.Rows[j]["ContentType"].ToString());
                        }
                    }
                }

                if (ArrayCnt.Count > 0)
                {
                    for (int z = 0; z < ArrayCnt.Count; z++)
                    {
                        //put count into one temp array
                        ArrayTemp.Add(ArrayCnt[z]);
                    }

                    ArrayTemp.Sort();
                    ArrayTemp.Reverse();
                    //after array reverse arrayTemp[0] contains the highest count

                    string _U1_Patterns = null;

                    if (ArrayTemp.Count > 3)
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            int d = 0;

                            for (int h = 0; h < ArrayTemp.Count; h++)
                            {
                                if (ArrayCnt[h].Equals(ArrayTemp[k]))
                                {
                                    if (d == 0 && !arrayExists.Contains(ArrayContentType[h]))
                                    {
                                        //storing the user AOI using string
                                        _U1_Patterns += ArrayContentType[h].ToString() + ",";

                                        arrayExists.Add(ArrayContentType[h]);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int k = 0; k < ArrayTemp.Count; k++)
                        {
                            int d = 0;

                            for (int h = 0; h < ArrayTemp.Count; h++)
                            {
                                if (ArrayCnt[h].Equals(ArrayTemp[k]))
                                {
                                    if (d == 0 && !arrayExists.Contains(ArrayContentType[h]))
                                    {
                                        //storing the user AOI using string
                                        _U1_Patterns += ArrayContentType[h].ToString() + ",";

                                        arrayExists.Add(ArrayContentType[h]);
                                    }
                                }
                            }
                        }
                    }

                    UserAOI = _U1_Patterns.Substring(0, _U1_Patterns.Length - 1);
                }
                else
                {

                }
            }

            return UserAOI;
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