
using Firebase.Database;
using Firebase.Database.Query;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using COMP7211Assignment2.Model_Folder;

namespace COMP7211Assignment2
{
    public class FireBaseHelperv2
    {
        FirebaseClient firebase = new FirebaseClient("https://student-rep-app.firebaseio.com/");

        public async Task<List<User>> GetAllUsers()
        {

            return (await firebase
              .Child("Students")
              .OnceAsync<User>()).Select(item => new User(item.Object.FName, item.Object.LName, item.Object.StudentID, item.Object.Password, item.Object.IsRep)).ToList();
        }

        public async Task<List<Post>> GetAllPosts()
        {
            return (await firebase.Child("Posts").OnceAsync<Post>()).Select(item => new Post(item.Object.Id, item.Object.CourseId, item.Object.Time, item.Object.Title, item.Object.Content)).ToList();
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




