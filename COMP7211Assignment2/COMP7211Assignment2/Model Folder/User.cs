using System.Collections.Generic;

//*********************
//Code by Min 30003457
//*********************
namespace COMP7211Assignment2
{
    public class User
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public int StudentID { get; set; }
        public List<Course> EnrolledCourses { get; set; }
        public string Password { get; set; }
        public bool IsRep { get; set; }
        public List<int> VotedPosts { get; set; } //add post id to this list and check this list of id's before voting so users can only vote once on same post

        public User(string fn, string ln, int studentId, string password, bool isRep, List<Course> enrolledCourses)
        {
            FName = fn;
            LName = ln;
            StudentID = studentId;
            Password = password;
            EnrolledCourses = enrolledCourses;
            IsRep = isRep;
        }
    }
}
