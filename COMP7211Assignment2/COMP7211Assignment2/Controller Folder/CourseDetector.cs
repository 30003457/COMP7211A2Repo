using System;
using System.Collections.Generic;
using System.Text;

namespace COMP7211Assignment2
{
    class CourseDetector
    {
        public List<Course> DetectedCourses { get; set; }
        PlaceholderUserDatabase userDb;
        public CourseDetector(int id)
        {
            DetectedCourses = new List<Course>();
            userDb = new PlaceholderUserDatabase();
            foreach (var item in userDb.records)
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
