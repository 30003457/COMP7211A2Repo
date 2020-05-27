using COMP7211Assignment2.Controller_Folder;
using COMP7211Assignment2.Model_Folder;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace COMP7211Assignment2
{
    //Code by Lewis 27033957 and Min 30003457

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogInPage : ContentPage
    {
        FireBaseHelper firebaseHelper = new FireBaseHelper();

        Validator vd;
        public LogInPage()
        {
            InitializeComponent();
            vd = new Validator();
            PageData.PManager = new PageManager(); //initiate page manager
        }





        //protected async override void OnAppearing()
        //{

        //    base.OnAppearing();
        //    var allPersons = await firebaseHelper.GetAllUsers();
        //   // string persons = Convert.ToString(allPersons);

        //    //await DisplayAlert("Success", persons, "OK");

        //    foreach (var item in allPersons)
        //    {
        //        String User = Convert.ToString(item);
        //        await DisplayAlert("Success", User, "OK");
        //    }

        //    //lstPersons.ItemsSource = allPersons;
        //}

        //private async void BtnAdd_Clicked(object sender, EventArgs e)
        //{
        //    await firebaseHelper.AddPerson(Convert.ToInt32(txtId.Text), txtName.Text);
        //    txtId.Text = string.Empty;
        //    txtName.Text = string.Empty;
        //    await DisplayAlert("Success", "Person Added Successfully", "OK");
        //    var allPersons = await firebaseHelper.GetAllPersons();
        //    lstPersons.ItemsSource = allPersons;
        //}

        //private async void BtnRetrive_Clicked(object sender, EventArgs e)
        //{
        //    var person = await firebaseHelper.GetPerson(Convert.ToInt32(StudentIDEntry.Text));
        //    if (person != null)
        //    {
        //        StudentIDEntry.Text = person.PersonId.ToString();
        //        string StudentID = person.Name;
        //        await DisplayAlert("Success", StudentID, "OK");

        //    }
        //    else
        //    {
        //        await DisplayAlert("Success", "No Person Available", "OK");
        //    }



        //}






        private async void ForgotClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ResetPassword());
        }
        private async void CreateClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FirstLoginPage());
        }
        
        private async void SignInClicked(object sender, EventArgs e)
        {
            if (vd.ValidateLogin(StudentIDEntry.Text, PasswordEntry.Text) == true)
            {
                StudentIDEntry.Text = null;
                PasswordEntry.Text = null;
                await Navigation.PushAsync(new CoursesViewPage());
            }
            else
            {
                await DisplayAlert("Invalid", vd.errorMsg, "OK");
            }

            //var person = await firebaseHelper.GetPerson(Convert.ToInt32(StudentIDEntry.Text));
            //if (person != null)
            //{
            //    StudentIDEntry.Text = person.PersonId.ToString();
            //    string StudentID = person.Name;
            //    await DisplayAlert("Success", StudentID, "OK");

            //}
            //else
            //{
            //    await DisplayAlert("Success", "No Person Available", "OK");
            //}
        }

    }
  }
