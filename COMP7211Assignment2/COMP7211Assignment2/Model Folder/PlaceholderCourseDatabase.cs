using System;
using System.Collections.Generic;
using System.Text;

namespace COMP7211Assignment2
{
    class PlaceholderCourseDatabase
    {
        public List<Course> records = new List<Course>();
        public PlaceholderCourseDatabase()
        {
            records.Add(new Course("Routing and Switching", 6201));
            records.Add(new Course("Professional Practice", 6205));
            records.Add(new Course("Advanced GUI", 7211));
            records.Add(new Course("Artificial Intelligence", 7212));
        }
    }
}
