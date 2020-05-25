using COMP7211Assignment2.Controller_Folder;
using COMP7211Assignment2.Model_Folder;
using System.Collections.Generic;

//*********************
//Code by Min 30003457
//*********************
namespace COMP7211Assignment2
{
    internal class CourseDetector
    {
        public List<Course> DetectedCourses { get; set; }

        private readonly PageManager pm;
        //PlaceholderUserDatabase userDb;
        public CourseDetector(int id)
        {
            DetectedCourses = new List<Course>();
            pm = new PageManager();
            //userDb = new PlaceholderUserDatabase();
            foreach (User item in PageData.PManager.UserRecords)
            {
                if (item.StudentID == id)
                {
                    DetectedCourses = item.EnrolledCourses;
                    break;
                }
            }
        }
    }
}
