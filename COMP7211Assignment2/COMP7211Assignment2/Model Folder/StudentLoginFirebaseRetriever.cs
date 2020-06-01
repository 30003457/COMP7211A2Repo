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

        public bool StudentFound { get; set; }
        public string StudentIsFound; 
        public bool PasswordMatch { get; set; }
        public bool NotSet { get; set; }

        private FirebaseClient firebase = new FirebaseClient("https://student-rep-app.firebaseio.com/");

        public async Task<List<Student>> GetAllPersons()
        {

            return (await firebase
              //.Child("Students")
              .Child("Students")
                    
              .OnceAsync<Student>()).Select(item => new Student
              {
                  StudentId = item.Object.StudentId
              }).ToList();



        }
        public async Task<Student> GetPassword(string studentId)
        {
            var allPersons = await GetAllPersons();
            await firebase
              .Child("Students")
              .OnceAsync<Student>();
            return allPersons.Where(word => word.StudentId == studentId).FirstOrDefault();
        }
       public async Task<Student> GetStudent(string studentId)
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


        public async void RetrieveID (string StudentID)
        {
            await GetStudent(StudentID);
            var student = await GetStudent(StudentID);
            if (student != null)
            {

                //txtId.Text = person.StudentId.ToString();
                StudentIsFound = student.StudentId;
                

            }
            else
            {
                StudentIsFound = "not found";
            }

        }


    }
}
