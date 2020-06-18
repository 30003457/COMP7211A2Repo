using System;
using Firebase.Database;
using Firebase.Database.Query;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Xamarin.Forms;
using System.Threading.Tasks;
// Code by Lewis Evans 27033957
namespace COMP7211Assignment2.Model_Folder
{
    public class Student
    {
        public string StudentId { get; set; }
        public string Password { get; set; }

    }
    class StudentLoginFirebaseRetriever
    {

        private FirebaseClient firebase = new FirebaseClient("https://student-rep-app.firebaseio.com/");

        public async Task<List<Student>> GetAllPersons()
        {

            return (await firebase
              .Child("Students")

              .OnceAsync<Student>()).Select(item => new Student
              {
                  StudentId = item.Object.StudentId,
                  Password = item.Object.Password
              }).ToList();
        }
        public async Task<Student> CheckPasswordIsSet(string emptyPassword, string studentID)
        {
            var allPersons = await GetAllPersons();
            await firebase
             .Child("Students").Child(studentID).Child("Password:")
              .OnceAsync<Student>();
            return allPersons.Where(word => word.Password == emptyPassword &&  word.StudentId == studentID).FirstOrDefault();
        }
        public async Task<Student> RetrievePassword(string password, string studentID)
        {
            var allPersons = await GetAllPersons();
            await firebase
                .Child("Students")
              .Child(studentID).Child("Password:")
              .OnceAsync<Student>();
            return allPersons.Where(word => word.Password == password).FirstOrDefault();
        }
        public async Task<Student> RetrieveStudentID(string studentId)
        {
            var allPersons = await GetAllPersons();
            await firebase
              .Child("Students")
              .OnceAsync<Student>();
            return allPersons.Where(word => word.StudentId == studentId).FirstOrDefault();
        }
    }
}
