using COMP7211Assignment2.Model_Folder;
using System.Collections.Generic;
using Firebase.Database;
using Firebase.Database.Query;
using Google.Cloud.Firestore.V1;

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
        public CourseDetector CDetector { get; set; }
        public PostDetector PDetector { get; set; }
        public FireBaseHelperv2 FBHelper { get; set; }
        public ResponsiveController Responsive { get; set; }
        //private readonly PlaceholderUserDatabase userDb;
        //private readonly PlaceholderPostDatabase postDb;

        public int SortSettings { get; set; }
        public PageManager()
        {
            //userDb = new PlaceholderUserDatabase();
            //postDb = new PlaceholderPostDatabase();

            //UserRecords = userDb.records;
            //PostRecords = postDb.records;
            Responsive = new ResponsiveController();

            SortSettings = 1; //default to votes

            FBHelper = new FireBaseHelperv2();
            //UserRecords = FBHelper.GetAllUsers().Result;
            //PostRecords = FBHelper.GetAllPosts().Result;
        }

        public string UpdateStatusText()
        {
            return $"Logged in as {LoginSystem.LoggedInUser.FName} {LoginSystem.LoggedInUser.StudentID.ToString("00000000")}";
        }
        public void DetectPosts()
        {
            DetectedPostRecords = PDetector.DetectedPosts;
        }

        public void BackToHomePage(int currentPageIndex)
        {
            //for (var counter = 1; counter < BackCount; counter++)
            //{
            //    Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
            //}
            //await Navigation.PopAsync();
        }
    }
}
