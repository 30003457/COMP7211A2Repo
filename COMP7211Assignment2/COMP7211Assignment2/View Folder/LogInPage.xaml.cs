using COMP7211Assignment2.Controller_Folder;
using COMP7211Assignment2.Model_Folder;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace COMP7211Assignment2
{
    //Code by Lewis Evans 27033957

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogInPage : ContentPage
    {
        Validator vd;
        ValidateLoginData Validator;
        StudentLoginFirebaseRetriever retriever;
        public LogInPage()
        {
            InitializeComponent();
            vd = new Validator();
            Validator = new ValidateLoginData();
            retriever = new StudentLoginFirebaseRetriever();

            PageData.PManager = new PageManager(); //initiate page manager
        }
        private async void ForgotClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ResetPassword());
        }
        private async void CreateClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FirstLoginPage());
        }
        private async void RetrieveDataClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DataRetriveController());
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
            RetrieveID();

        }
        public async void RetrieveID()
        {
            await retriever.GetStudent(StudentIDEntry.Text);
            var student = await retriever.GetStudent(StudentIDEntry.Text);
            if (student != null)
            {

                //txtId.Text = person.StudentId.ToString();
                await DisplayAlert("Success", "Person Retrive Successfully", "OK");


            }
            else
            {
                await DisplayAlert("Success", "No Person Available", "OK");
            }

        }



    }
}
