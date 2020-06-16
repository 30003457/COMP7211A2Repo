
using Firebase.Database;
using Firebase.Database.Query;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using COMP7211Assignment2.Model_Folder;
using Newtonsoft.Json.Linq;
using System.Reactive.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Api.Gax.Rest;

namespace COMP7211Assignment2
{
    //Code by Lewis and Min 30003457
    public class FireBaseHelperv2
    {
        public FirebaseClient firebase = new FirebaseClient($"https://student-rep-app.firebaseio.com/");

        public async void SetPassword(int studentId, string pw)
        {
            var users = await GetAllUsers();
            await firebase
              .Child("Students")
              .OnceAsync<User>();
            users.Where(a => a.StudentID == studentId).FirstOrDefault().Password = pw;

            await firebase.Child("Students").PutAsync(users);
        }

        public async Task<List<User>> GetAllUsers()
        {
            //return (await firebase
            //    .Child("Students")
            //    .OnceAsync<User>()).Select(item => new User(item.Object.FName, item.Object.LName, item.Object.StudentID, item.Object.Password, item.Object.IsRep, item.Object.EnrolledCourses)).ToList();
            return await firebase.Child("Students").OnceSingleAsync<List<User>>();
        }

        public async Task<User> GetUser(int studentId)
        {
            var users = await GetAllUsers();
            await firebase
              .Child("Students")
              .OnceAsync<User>();
            return users.Where(a => a.StudentID == studentId).FirstOrDefault();
        }

        public async Task<List<Post>> GetAllPosts()
        {
            return (await firebase
                .Child("Posts")
                .OnceSingleAsync<List<Post>>());
        }

        public async Task<Post> GetPost(int postId)
        {
            var posts = await GetAllPosts();
            await firebase
              .Child("Posts")
              .OnceAsync<Post>();
            return posts.Where(a => a.Id == postId).FirstOrDefault();
        }

        public async Task<List<PostReply>> GetAllReplies()
        {
            return (await firebase
                .Child("PostReply")
                .OnceSingleAsync<List<PostReply>>());
        }

        public async Task<List<Course>> GetAllCourses()
        {
            return (await firebase
                .Child("Courses").OnceSingleAsync<List<Course>>());
                //.OnceAsync<Course>()).Select(item => new Course(item.Object.Name, item.Object.ID)).ToList();
        }

        public async Task AddPassword(int studentId, string password)
        {
            var users = await GetAllUsers();
            var toUpdatePerson = (await firebase
              .Child("Students")
              .OnceAsync<User>()).Where(a => a.Object.StudentID == studentId).FirstOrDefault();

            await firebase
              .Child("Students")
              .Child(toUpdatePerson.Key)
              .PutAsync(new Student() {Password = password });


            //await firebase
            //  .Child("Students").Child(studentId)
            //  .PostAsync(new User(){ Password = password });
        }



        //public async Task AddPerson(int personId, string name)
        //{

        //    await firebase
        //      .Child("Persons")
        //      .PostAsync(new Person() { PersonId = personId, Name = name });
        //}

        //public async Task<Person> GetPerson(int personId)
        //{
        //    var allPersons = await GetAllUsers();
        //    await firebase
        //      .Child("User")
        //      .OnceAsync<Person>();
        //    return allPersons.Where(a => a.PersonId == personId).FirstOrDefault();
        //}

        //public async Task UpdatePerson(int personId, string name)
        //{
        //    var toUpdatePerson = (await firebase
        //      .Child("Persons")
        //      .OnceAsync<Person>()).Where(a => a.Object.PersonId == personId).FirstOrDefault();

        //    await firebase
        //      .Child("Persons")
        //      .Child(toUpdatePerson.Key)
        //      .PutAsync(new Person() { PersonId = personId, Name = name });
        //}

        //public async Task DeletePerson(int personId)
        //{
        //    var toDeletePerson = (await firebase
        //      .Child("Persons")
        //      .OnceAsync<Person>()).Where(a => a.Object.PersonId == personId).FirstOrDefault();
        //    await firebase.Child("Persons").Child(toDeletePerson.Key).DeleteAsync();

        //}
    }

}




