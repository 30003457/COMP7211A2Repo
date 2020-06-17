
using Firebase.Database;
using Firebase.Database.Query;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;
namespace COMP7211Assignment2
{
    public class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
    }

    public class FirebaseHelper
    {
        FirebaseClient firebase = new FirebaseClient("https://student-rep-app.firebaseio.com/");

        public async Task<List<Person>> GetAllUsers()
        {

            return (await firebase
              .Child("StudentID")
              .OnceAsync<Person>()).Select(item => new Person
              {
                  Name = item.Object.Name,
                  PersonId = item.Object.PersonId
              }).ToList();
        }

        //public async Task AddPerson(int personId, string name)
        //{

        //    await firebase
        //      .Child("Persons")
        //      .PostAsync(new Person() { PersonId = personId, Name = name });
        //}

        public async Task<Person> GetPerson(int personId)
        {
            var allPersons = await GetAllUsers();
            await firebase
              .Child("User")
              .OnceAsync<Person>();
            return allPersons.Where(a => a.PersonId == personId).FirstOrDefault();
        }

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




