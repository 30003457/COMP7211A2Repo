using COMP7211Assignment2.Controller_Folder;
using COMP7211Assignment2.Model_Folder;
using System;
using System.Collections.Generic;
using System.Text;

//*********************
//Code by Min 30003457
//*********************
namespace COMP7211Assignment2
{
    class CourseDetector
    {
        public List<Course> DetectedCourses { get; set; }
        PageManager pm;
        //PlaceholderUserDatabase userDb;
        public CourseDetector(int id)
        {
            DetectedCourses = new List<Course>();
            pm = new PageManager();
            //userDb = new PlaceholderUserDatabase();
            foreach (var item in PageData.PManager.UserRecords)
            {
                if(item.StudentID == id)
                {
                    DetectedCourses = item.EnrolledCourses;
                    break;
                }
            }
        }
    }
}
