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
        public async Task<Student> CheckPasswordIsSet(string emptyPassword)
        {
            var allPersons = await GetAllPersons();
            await firebase
              .Child("Students").Child("Password:")
              .OnceAsync<Student>();
            return allPersons.Where(word => word.Password == emptyPassword).FirstOrDefault();
        }
        public async Task<Student> RetrievePassword(string password)
        {
            var allPersons = await GetAllPersons();
            await firebase
              .Child("Students").Child("Password:")
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





            //            var Students = await firebase.Child("Students")
            //            .OnceAsync<Student>();
            //            foreach (var item in Students)
            //            {
            //                if (studentId == item.Key)
            //                {
            //                    StudentFound = true;
            //                }
            //                else
            //                {
            //                    StudentFound = false;
            //                }
            //            }

            //Console.WriteLine($”{ dino.Key} is { dino.Object.Height } m high.”);
            // await DisplayAlert("Success", item.Key, "word");

            //var abc = await firebase
            //  .Child("Students").OnceAsync<Student>();
            //foreach (var item in abc)
            //{
            //    string word = Convert.ToString(item);
            //    await DisplayAlert("Success", word, "word");
            //}


        }
        //public async void removePassword(string studentId)                                    //not working
        //{

        //    var toUpdateStudentPassword = (await firebase

        //          .Child("Students").Child("Password:")

        //          .OnceAsync<Student>()).Where(a => a.Object.StudentId == studentId).FirstOrDefault();



        //    await firebase

        //      .Child("Student")

        //      .Child(toUpdateStudentPassword.Key)

        //      .PutAsync(new Student() { StudentId = studentId, Password = "" });
        //}





    }
}
