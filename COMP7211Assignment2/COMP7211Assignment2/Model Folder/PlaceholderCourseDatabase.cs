using System.Collections.Generic;
using COMP7211Assignment2.Model_Folder;
using Firebase.Database;
using Firebase.Database.Query;

//*********************
//Code by Min 30003457
//*********************
namespace COMP7211Assignment2
{
    internal class PlaceholderCourseDatabase
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
