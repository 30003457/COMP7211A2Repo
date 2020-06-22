using COMP7211Assignment2.Model_Folder;
using System.Collections.Generic;

//*********************
//Code by Min 30003457
//*********************
namespace COMP7211Assignment2.Controller_Folder
{
    internal class PageManager
    {
        public string CurrentTitle { get; set; }
        public string CurrentSubtext { get; set; }
        public int CurrentCourseID { get; set; }
        public List<User> UserRecords { get; set; } //Have to have lists here from the DB's for bindings
        public List<Post> PostRecords { get; set; }
        public List<Post> DetectedPostRecords { get; set; }
        public List<PostReply> DetectedPostReplyRecords { get; set; }
        public CourseDetector CDetector { get; set; }
        public PostDetector PDetector { get; set; }
        public PostReplyDetector PRDetector { get; set; }
        public FireBaseHelperv2 FBHelper { get; set; }
        public ResponsiveController Responsive { get; set; }

        public int SortSettings { get; set; }
        public PageManager()
        {
            Responsive = new ResponsiveController();

            SortSettings = 1; //default to votes

            FBHelper = new FireBaseHelperv2();
            RetrieveUsersFromDB();
            RetrievePostsFromDB();
        }

        private async void RetrieveUsersFromDB()
        {
            UserRecords = await FBHelper.GetAllUsers();
        }

        private async void RetrievePostsFromDB()
        {
            PostRecords = await FBHelper.GetAllPosts();
        }

        public string UpdateStatusText()
        {
            return $"Logged in as {LoginSystem.LoggedInUser.FName} {LoginSystem.LoggedInUser.StudentID.ToString("00000000")}";
        }
        public void DetectPosts()
        {
            DetectedPostRecords = PDetector.DetectedPosts;
        }

        public void DetectPostReplies()
        {
            DetectedPostReplyRecords = PRDetector.DetectedPostReplies;
        }

    }
}
