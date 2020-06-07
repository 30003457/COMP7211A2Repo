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
        public LogInPage()
        {
            InitializeComponent();
            vd = new Validator();
            Validator = new ValidateLoginData();

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

            //Validator.ValidateID(StudentIDEntry.Text);
            //Validator.ValidatePassword(PasswordEntry.Text);
           // Validator.ValidatePasswordStatus("");          //not working

            //if (Validator.PasswordIsSet)          //not working
            //{
                //if (Validator.passwordMatches || Validator.idMatches || vd.ValidateLogin(StudentIDEntry.Text, PasswordEntry.Text))
                //{
                //    await DisplayAlert("Success", "You are Logged In", "OK");
                //    await Navigation.PushAsync(new CoursesViewPage());
                //    StudentIDEntry.Text = null;
                //    PasswordEntry.Text = null;
                //}
                //else
                //{
                //    await DisplayAlert("Invalid", vd.errorMsg, "OK");
                //}

            //}
            //else
            //{
            //    await DisplayAlert("Warning", "You have not set up your account, please set up your password to continue: ", "OK");
            //}

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
        }




    }
}
