using COMP7211Assignment2.Model_Folder;
using System;
using System.Collections.Generic;
using System.Text;

namespace COMP7211Assignment2.Controller_Folder
{
    class PageManager
    {
        public string CurrentTitle { get; set; }
        public string CurrentSubtext { get; set; }
        public int CurrentCourseID { get; set; }
        public List<User> UserRecords { get; set; } //Have to have lists here from the DB's for bindings
        public List<Post> PostRecords { get; set; }
        public List<Post> DetectedPostRecords { get; set; }
        public CourseDetector CDetector { get; set; }
        public PostDetector PDetector { get; set; }
        PlaceholderUserDatabase userDb;
        PlaceholderPostDatabase postDb;
        public int SortSettings { get; set; }
        public PageManager()
        {
            userDb = new PlaceholderUserDatabase();
            postDb = new PlaceholderPostDatabase();

            UserRecords = userDb.records;
            PostRecords = postDb.records;

            SortSettings = 1; //default to votes

            //CurrentCourseID = PageData.CurrentCourseID;
            //DetectedPostRecords = PDetector.DetectedPosts;
            //CDetector = PageData.CDetector;
            //CurrentTitle = PageData.CurrentTitle;
            //CurrentSubtext = PageData.CurrentSubtext;
        }

        public string UpdateStatusText()
        {
            return $"Logged in as {LoginSystem.LoggedInUser.FName} {LoginSystem.LoggedInUser.StudentID.ToString("00000000")}";
        }
        public void DetectPosts()
        {
            //DetectedPostRecords = PageData.PDetector.DetectedPosts;
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

        //public void SetTitle(string title)
        //{
        //    PageData.CurrentTitle = title;
        //}
    }
}
