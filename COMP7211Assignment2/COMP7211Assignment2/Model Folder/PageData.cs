using COMP7211Assignment2.Controller_Folder;
using System;
using System.Collections.Generic;
using System.Text;

namespace COMP7211Assignment2.Model_Folder
{
    class PageData
    {
        public static string CurrentTitle { get; set; }
        public static int CurrentCourseID { get; set; }
        public static List<User> UserRecords { get; set; }
        public static List<Post> PostRecords { get; set; }
       // public static List<Post> DetectedPostRecords { get; set; }
        public static CourseDetector CDetector { get; set; }
        public static PostDetector PDetector { get; set; }
    }
}
