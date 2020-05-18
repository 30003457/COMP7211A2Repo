using COMP7211Assignment2.Model_Folder;
using System;
using System.Collections.Generic;
using System.Text;

namespace COMP7211Assignment2.Controller_Folder
{
    class PageManager
    {
        public string CurrentTitle { get; set; }
        public int CurrentCourseID { get; set; }
        public List<User> UserRecords { get; set; }
        public List<Post> PostRecords { get; set; }
        public List<Post> DetectedPostRecords { get; set; }
        public CourseDetector CDetector { get; set; }
        //public PostDetector PDetector { get; set; }
        PlaceholderUserDatabase userDb;
        PlaceholderPostDatabase postDb;
        public PageManager()
        {
            userDb = new PlaceholderUserDatabase();
            postDb = new PlaceholderPostDatabase();

            UserRecords = PageData.UserRecords = userDb.records;
            PostRecords = PageData.PostRecords = postDb.records;
            CurrentCourseID = PageData.CurrentCourseID;
            //DetectedPostRecords = PageData.PDetector.DetectedPosts;
            CDetector = PageData.CDetector;
            CurrentTitle = GetTitle();
        }
        public void DetectPosts()
        {
            DetectedPostRecords = PageData.PDetector.DetectedPosts;
        }
        public string GetTitle()
        {
            return PageData.CurrentTitle;
        }

        public void SetTitle(string title)
        {
            PageData.CurrentTitle = title;
        }
    }
}
