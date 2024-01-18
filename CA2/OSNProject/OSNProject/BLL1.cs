using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using OSNProject.DataSet1TableAdapters;
using System.IO;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace OSNProject
{
    //this is the common class which contains class members and member functions related to OSN

    public class BLL1
    {
        //class members related to online social networking                
        tblContentTypeTableAdapter contenttypeObj = new tblContentTypeTableAdapter();
        tblAdminTableAdapter adminObj = new tblAdminTableAdapter();
        tblUsersTableAdapter userObj = new tblUsersTableAdapter();       
        tblFriendRequestsTableAdapter friendrequestObj = new tblFriendRequestsTableAdapter();
        tblPostingsTableAdapter postObj = new tblPostingsTableAdapter();
        tblTextsTableAdapter textObj = new tblTextsTableAdapter();
        tblPhotosTableAdapter photoObj = new tblPhotosTableAdapter();
        tblVideosTableAdapter videoObj = new tblVideosTableAdapter();
        tblKeywordsTableAdapter keywordObj = new tblKeywordsTableAdapter();

        tblActualDatasetTableAdapter actualObj = new tblActualDatasetTableAdapter();

        #region ----- User Account -----

        //function to get registered to the application
        public void InsertUser(string emailId, string password, string fName, string lName, string gender, string dob, string date)
        {
            userObj.InsertUser(emailId, password, fName, lName, gender, dob, date);
        }

        //function to check user id
        public bool CheckUserId(string emailId)
        {
            //return userObj.CheckUserId(emailId) == 0;
            int cnt = int.Parse(userObj.CheckUserId(emailId).ToString());

            if (cnt == 1)

                return false;

            return true;
        }

        //function to check user login
        public bool CheckUserLogin(string emailId, string password)
        {
            int cnt = int.Parse(userObj.CheckUserLogin(emailId, password).ToString());

            if (cnt == 1)

                return true;

            return false;
        }

        //function to get user details based on emailid
        public DataTable GetUserByEmailId(string emailId)
        {
            return userObj.GetUserByEmailId(emailId);
        }

        //function to get users by name
        public DataTable GetUsersByName(string parameter)
        {
            return userObj.GetUsersByName(parameter);
        }

        //function to change the user password
        public void UpdatePassword(string password, string emailId)
        {
            userObj.UpdatePassword(password, emailId);
        }

        //function to update the profile details
        public void UpdateProfile(string highSchool, string college, string employer, string currentCity, string hometown,
            string photo, string relationship, string aboutU, string languages, string religion, string mobile, string otherPhones, string address, string zipCode,
            string contentType, string userId)
        {
            userObj.UpdateUserProfile(highSchool, college, employer, currentCity, hometown, photo, relationship, aboutU, languages, religion, mobile, otherPhones, address, zipCode, contentType, userId);
        }

        //function to check admin login
        public bool CheckAdminLogin(string adminId, string password)
        {
            int cnt = int.Parse(adminObj.CheckAdminLogin(adminId, password).ToString());

            if (cnt == 1)

                return true;

            return false;
        }

        //function to get all registered users
        public DataTable GetUsers()
        {
            return userObj.GetData();
        }

        //function to get all registered users
        public DataTable GetOtherUsers(string emailId)
        {
            return userObj.GetOtherUsers(emailId);
        }

        //function to delete the comments by user
        

        //function to delete the postings by user
        public void DeletePostingsByUser(string emailId)
        {
            postObj.DeletePostingsByEmailId(emailId);
        }

        //function to delete the text based on postId
        public void DeleteTextByPostId(int postId)
        {
            textObj.DeleteTextsByPostId(postId);
        }

        //function to delete the photos based on postid
        public void DeletePhotosByPostId(int postId)
        {
            photoObj.DeletePhotosByPostId(postId);
        }

        //function to delete the videos based on postId
        public void DeleteVideosByPostId(int postId)
        {
            videoObj.DeleteVideosByPostId(postId);
        }

        //function to delete the friends based on user
        public void DeleteMyFriends(string emailId)
        {
            friendrequestObj.DeleteMyFriends(emailId, emailId);
        }

        //function to delete the member
        public void DeleteMember(string emailId)
        {
            userObj.DeleteMember(emailId);
        }

        //function to get the admin details
        public DataTable GetAdminDetails(string adminId)
        {
            return adminObj.GetAdminDetails(adminId);
        }

        //function to update the admin password
        public void UpdateAdminPassword(string newPassword, string adminId)
        {
            adminObj.UpdateAdminPassword(newPassword, adminId);
        }

        //function to retrive all members
        public DataTable GetMembers()
        {
            return userObj.GetData();
        }

        //function to retrive the users based on DOB
        public DataTable GetUsersByDOB(string emailId, string starYear, string endYear)
        {
            return userObj.GetUserByDateOfBirth(emailId, starYear, endYear);
        }

        //function to retrive the users based on city
        public DataTable GetUsersByCity(string city, string emailId)
        {
            return userObj.GetUsersByCity(city, emailId);
        }

        //function to retrive the users based on area of interest
        public DataTable GetUsersByArea(string area, string emailId)
        {
            return userObj.GetUsersByArea(area, emailId);
        }

        #endregion             

        #region ------ Content Types -----

        //function to get all content types
        public DataTable GetContentTypes()
        {
            return contenttypeObj.GetData();
        }

        //function to insert content types
        public void InsertContentType(string contentType, string image)
        {
            contenttypeObj.InsertContentType(contentType, image);
        }

        //function to delete the contenttype
        public void DeleteContentType(int contentTypeId)
        {
            contenttypeObj.DeleteContentType(contentTypeId);
        }

        //check contenttype name
        public bool CheckContentType(string contentType)
        {
            int cnt = int.Parse(contenttypeObj.CheckContentType(contentType).ToString());

            if (cnt == 1)

                return false;

            return true;

        }

        //function to get the contenttype by id
        public DataTable GetContenttypeById(int typeId)
        {
            return contenttypeObj.GetContentTypeById(typeId);
        }

        #endregion               

        #region ---- Friend Requests -----

        //function to send friend request
        public void SendFriendRequest(string from, string to, string date, string status)
        {
            friendrequestObj.SendFriendRequest(from, to, date, status);
        }

        //function to check friend request
        public bool CheckFriendRequest(string from, string to)
        {
            int cnt = int.Parse(friendrequestObj.CheckFriendRequest(from, to).ToString());

            if (cnt == 1)

                return false;

            else

                return true;
        }

        //function to get the friend requests
        public DataTable GetFriendRequests(string requestTo)
        {
            return friendrequestObj.GetFriendRequests(requestTo);
        }

        //function to update the status
        public void UpdateStatus(string status, string date, int requestId)
        {
            friendrequestObj.UpdateFriendRequest(date, status, requestId);
        }

        //function to delete the friend request
        public void DeleteFriendRequest(int requestId)
        {
            friendrequestObj.DeleteFriendRequest(requestId);
        }

        //function to get my friends
        public DataTable GetMyFriends(string requestFrom, string requestTo)
        {
            return friendrequestObj.GetMyFriends(requestFrom, requestTo);
        }

        #endregion

        #region ---- Information Sharing -----

        //function to insert new posting
        public void InsertPosting(string emailId, string postType, string contentType, string postedDate)
        {
            postObj.InsertPostings(emailId, postType, contentType, postedDate);
        }

        //function to get max post id
        public int GetMaxPostId()
        {
            int cnt = int.Parse(postObj.GetMaxPostId().ToString());

            return cnt;
        }

        //function to insert photos
        public void InsertPhoto(int postId, string title, string description, string photo)
        {
            photoObj.InsertPhoto(postId, title, description, photo);
        }

        //function to insert video
        public void InsertVideo(int postId, string title, string description, string video)
        {
            videoObj.InsertVideo(postId, title, description, video);
        }

        //function to insert text message
        public void InsertText(int postId, string title, string description)
        {
            textObj.InsertText(postId, title, description);
        }

        //function to get postings by emailId
        public DataTable GetPostingsByEmailId(string emailId)
        {
            return postObj.GetPostingsByEmailId(emailId);
        }

        //function to get texts by postId
        public DataTable GetTextsByPostId(int postId)
        {
            return textObj.GetTextsByPostId(postId);
        }

        //function to get photos by postId
        public DataTable GetPhotosByPostId(int postId)
        {
            return photoObj.GetPhotosByPostId(postId);
        }

        //function to get videos by postId
        public DataTable GetVideosByPostId(int postId)
        {
            return videoObj.GetVideosByPostId(postId);
        }

        //function to get posting by post id
        public DataTable GetPostingByPostId(int postId)
        {
            return postObj.GetPostingByPostId(postId);
        }

        //function to get posting by emailId and type
        public int GetPostingsByEmailIdandType(string emailId, string type)
        {
            return (int)postObj.GetPostingByEmailIdandType(emailId, type);
        }

        #endregion            

        #region --- Set Keywords ---

        //function to check keyword based on type
        public bool CheckKeyword(int typeId, string keyword)
        {
            int cnt = int.Parse(keywordObj.CheckKeyword(typeId, keyword).ToString());

            if (cnt == 1)

                return false;

            return true;

        }

        //function to insert keyword
        public void InsertKeyword(int typeId, string keyword)
        {
            keywordObj.InsertKeyword(typeId, keyword);
        }

        //function to delete keyword
        public void DeleteKeyword(int keyId)
        {
            keywordObj.DeleteKeyword(keyId);
        }

        //function to get all keywords
        public DataTable GetAllKeywords()
        {
            return keywordObj.GetData();
        }

        //function to get keywords based on typeId
        public DataTable GetKeywordsByContentType(int typeId)
        {
            return keywordObj.GetKeywordsByType(typeId);
        }

        //function to delete keywords by type
        public void DeleteKeywordsByContentType(int typeId)
        {
            keywordObj.DeleteKeywordsByType(typeId);
        }

        //function to get keyword by id
        public DataTable GetKeywordById(int keyId)
        {
            return keywordObj.GetKeywordById(keyId);
        }


        #endregion

        public DataTable GetActualByEmailId(string emailId)
        {
            return actualObj.GetActualByEmailId(emailId);
        }

        public int GetActualCnt()
        {
            return (int)actualObj.GetActualCnt();
        }


        string ConnectionString = ConfigurationManager.ConnectionStrings["cloneAttacksConnectionString"].ConnectionString;

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader buffer;
        SqlDataAdapter adap;
        DataTable dt;
        DataSet ds;

        //Get user details based emailId
        public DataTable GetUserDetails_OSN1(string emailId)
        {
            string SQL_Search = string.Format("Select *from tblUsers where EmailId='{0}'", emailId);
            DataTable Tab_Student_Info = RetriveDetails(SQL_Search);
            return Tab_Student_Info;
        }

        public DataTable GetContentTypes_OSN1()
        {
            string SQL_Search = string.Format("Select *from tblContentType");
            DataTable Tab_Student_Info = RetriveDetails(SQL_Search);
            return Tab_Student_Info;
        }

        public int GetPostingsByEmailIdandTypes_OSN1(string emailId, string type)
        {
            string SQL_Search = string.Format("Select count(*) from tblPostings where EmailId='{0}' and ContentType='{1}'", emailId, type);
            int result = int.Parse(SQLStatement_ExecuteAggregate(SQL_Search).ToString());
            return result;
        }

        #region ---------------- DB Operations ------------------

        //Write Error message to Text File
        void WriteLog(string message)
        {
            string ErrorLogPath = System.Configuration.ConfigurationSettings.AppSettings["ErrorLogPath"].ToString() + "Error.txt";

            try
            {
                FileStream fs = new FileStream(ErrorLogPath, FileMode.Append);
                StreamWriter writer = new StreamWriter(fs);
                writer.WriteLine(message);
                writer.Close();
            }
            catch (Exception error)
            {
            }
        }

        //This function is common for insert,delete and update Queries 
        private int SQLStatement_Execute(string SQL)
        {
            int Result = 0;
            con = new SqlConnection(ConnectionString);
            cmd = new SqlCommand(SQL, con);
            //try
            //{
            con.Open();
            Result = cmd.ExecuteNonQuery();
            //}
            //catch (Exception error)
            //{
            //    WriteLog(error.ToString());
            //}
            //finally
            //{
            //    if (con.State.ToString().ToLower() == "open")
            //    {
            //        con.Close();
            //    }
            //}
            return Result;
        }

        //function to execute  SQL queries involving aggregate functions
        private object SQLStatement_ExecuteAggregate(string SQL)
        {
            object Result = 0;
            con = new SqlConnection(ConnectionString);
            cmd = new SqlCommand(SQL, con);
            try
            {
                con.Open();
                Result = cmd.ExecuteScalar();
            }
            catch (Exception error)
            {
                WriteLog(error.ToString());
            }
            finally
            {
                if (con.State.ToString().ToLower() == "open")
                {
                    con.Close();
                }
            }
            return Result;
        }

        //Retrive the detail[s] of the specified table[s]
        public DataTable RetriveDetails(string SQL)
        {
            DataTable Table_Retrive = new DataTable("Details");
            SqlDataAdapter adap = new SqlDataAdapter(SQL, ConnectionString);
            //try
            //{
            adap.Fill(Table_Retrive);
            //}
            //catch (Exception error)
            //{
            //    WriteLog(error.ToString());
            //}

            return Table_Retrive;
        }


        #endregion

        
    }
}