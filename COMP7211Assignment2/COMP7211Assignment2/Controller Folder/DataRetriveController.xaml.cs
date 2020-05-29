using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using Google.Cloud.Firestore;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace COMP7211Assignment2.Controller_Folder
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    //public class Person
    //{
    //    public string StudentId { get; set; }
        
    //}
    public class Student
    {
        public string StudentId { get; set; }
        public string Password { get; set; }


    }
    public partial class DataRetriveController : ContentPage
    {
        private FirebaseClient firebase = new FirebaseClient("https://student-rep-app.firebaseio.com/");
        public DataRetriveController()
        {
            
            InitializeComponent();
        }
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
        public async void GetPerson(string studentId)
        {
            var Students = await firebase.Child("Students")
             .OrderByKey()
             .OnceAsync<Student>();
            foreach (var item in Students)
            {
                //Console.WriteLine($”{ dino.Key} is { dino.Object.Height } m high.”);
                await DisplayAlert("Success", item.Key, "word");
            }

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
            GetPerson(txtId.Text);
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
