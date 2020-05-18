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
        public PageManager()
        {
            userDb = new PlaceholderUserDatabase();
            postDb = new PlaceholderPostDatabase();

            UserRecords = UserRecords = userDb.records;
            PostRecords = PostRecords = postDb.records;

            //CurrentCourseID = PageData.CurrentCourseID;
            //DetectedPostRecords = PDetector.DetectedPosts;
            //CDetector = PageData.CDetector;
            //CurrentTitle = PageData.CurrentTitle;
            //CurrentSubtext = PageData.CurrentSubtext;
        }
        public void DetectPosts()
        {
            //DetectedPostRecords = PageData.PDetector.DetectedPosts;
            DetectedPostRecords = PDetector.DetectedPosts;
        }

        //public void SetTitle(string title)
        //{
        //    PageData.CurrentTitle = title;
        //}
    }
}
