using System;
using Firebase.Database;
using Firebase.Database.Query;
using System.Collections.Generic;
using System.Text;
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
        public string StudentIsFound { get; set; }
        public bool PasswordMatch { get; set; }
        public bool NotSet { get; set; }

        private FirebaseClient firebase = new FirebaseClient("https://student-rep-app.firebaseio.com/");

        //public async Task<List<Person>> GetAllPersons()
        //{

        //    return (await firebase
        //      //.Child("Students")
        //      .Child("Students")
        //            .Child("EnrolledCourses")
        //      .OnceAsync<Person>()).Select(item => new Person
        //      {
        //          StudentId = item.Object.StudentId
        //      }).ToList();



        //}
        public async void  GetPerson(string studentId)
        {
            var Students = await firebase.Child("Students")
             .OrderByKey()
             .OnceAsync<Student>();
            
            foreach (var item in Students)
            {
                if ("00000001" == item.Key)
                {
                    StudentFound = true;
                    StudentIsFound = "Yessir";
                }
                //else
                //{
                //    StudentFound = false;
                //}
                
            }
            
            //Console.WriteLine($”{ dino.Key} is { dino.Object.Height } m high.”);
            // await DisplayAlert("Success", item.Key, "word");

            //var abc = await firebase
            //  .Child("Students").OnceAsync<Student>();
            //foreach (var item in abc)
            //{
            //    string word = Convert.ToString(item);
            //    await DisplayAlert("Success", word, "word");
            //}



            //var allPersons = await GetAllPersons();
            //await firebase
            //  .Child("Students")
            //  .OnceAsync<Person>();
            //return allPersons.Where(word => word.StudentId == studentId).FirstOrDefault();



            //await firebase.Child("bucketa/bucketb/bucketc").OnceAsync<Dictiona‌​ry<string, RealCl‌​ass>>();


        }


        private async void BtnRetrive_Clicked(object sender, EventArgs e)
        {
           // GetPerson(txtId.Text);
            //var person = await GetPerson(txtId.Text);
            //if (person != null)
            //{

            //    txtId.Text = person.StudentId.ToString();            
            //     string Id = Convert.ToString(person.StudentId);
            //    await DisplayAlert("Success", "Person Retrive Successfully ", Id);

            //}
            //else
            //{
            //    await DisplayAlert("Success", "No Person Available", "OK");
            //}

        }






        //protected async override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    var allPersons = await GetAllPersons();
        //    lstPersons.ItemsSource = allPersons;
        //}
        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {

            // await firebaseHelper.AddPerson(Convert.ToInt32(txtId.Text), txtName.Text);
            //txtId.Text = string.Empty;
            //txtName.Text = string.Empty;
            //await DisplayAlert("Success", "Person Added Successfully", "OK");
            // var allPersons = await firebaseHelper.GetAllPersons();
            //  lstPersons.ItemsSource = allPersons;
        }


        private async void BtnUpdate_Clicked(object sender, EventArgs e)
        {
            //await firebaseHelper.UpdatePerson(Convert.ToInt32(txtId.Text), txtName.Text);
            //txtId.Text = string.Empty;
            //txtName.Text = string.Empty;
            //await DisplayAlert("Success", "Person Updated Successfully", "OK");
            // var allPersons = await firebaseHelper.GetAllPersons();
            // lstPersons.ItemsSource = allPersons;
        }

        private async void BtnDelete_Clicked(object sender, EventArgs e)
        {
            //  await firebaseHelper.DeletePerson(Convert.ToInt32(txtId.Text));
            //await DisplayAlert("Success", "Person Deleted Successfully", "OK");
            //var allPersons = await GetAllPersons();
            //lstPersons.ItemsSource = allPersons;
        }

    }
}
