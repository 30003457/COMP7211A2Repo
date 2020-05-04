using System;
using System.Collections.Generic;
using System.Text;

namespace COMP7211Assignment2
{
    class CourseDetector
    {
        List<Course> DetectedCourses = new List<Course>();
        public CourseDetector(int id)
        {
            foreach (var item in PlaceholderUserDatabase.Records)
            {
                if(item.StudentID == id)
                {
                    DetectedCourses = item.EnrolledCourses;
                    break;
                }
            }
        }

        public List<Course> ReturnCourses()
        {
            return DetectedCourses;
        }
    }
}
