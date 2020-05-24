using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace COMP7211Assignment2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FirstLoginPage : ContentPage
    {
        public FirstLoginPage()
        {
            InitializeComponent();
        }

        private void SignInClicked(object sender, EventArgs e)
        {


            if (StudentIDEntry.Text == null)
            {
                DisplayAlert("Error", "No Student ID Entered please try again", "OK");
            }
            else if (PasswordEntry.Text == null)
            {
                DisplayAlert("Error", "No Password Entered please try again", "OK");
            }
            else
            {
                DisplayAlert("Success", "You have successfully logged in", "OK");
            }

        }
    }
}