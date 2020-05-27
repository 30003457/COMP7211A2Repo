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
        public CourseDetector CDetector { get; set; }
        public PostDetector PDetector { get; set; }
        public ResponsiveController Responsive { get; set; }

        private readonly PlaceholderUserDatabase userDb;
        private readonly PlaceholderPostDatabase postDb;
        public int SortSettings { get; set; }
        public PageManager()
        {
            Responsive = new ResponsiveController();
            userDb = new PlaceholderUserDatabase();
            postDb = new PlaceholderPostDatabase();

            UserRecords = userDb.records;
            PostRecords = postDb.records;

            SortSettings = 1; //default to votes
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
