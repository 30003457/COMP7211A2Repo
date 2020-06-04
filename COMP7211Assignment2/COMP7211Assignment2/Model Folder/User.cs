using System;
using System.Collections.Generic;
using System.Text;

//*********************
//Code by Min 30003457
//*********************
namespace COMP7211Assignment2
{
    class User
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public int StudentID { get; set; }
        public List<Course> EnrolledCourses { get; set; }
        protected string Password { get; set; }
        public bool IsRep { get; set; }
        public List<int> VotedPosts { get; set; } //add post id to this list and check this list of id's before voting so users can only vote once on same post
        PlaceholderCourseDatabase cdb;

        //All students enrolled in same courses for now...
        public User(string fn, string ln, int studentId, string password, bool isRep)
        {
            cdb = new PlaceholderCourseDatabase();
            FName = fn;
            LName = ln;
            StudentID = studentId;
            Password = password;
            EnrolledCourses = cdb.records;
            IsRep = isRep;
        }
    }
}
