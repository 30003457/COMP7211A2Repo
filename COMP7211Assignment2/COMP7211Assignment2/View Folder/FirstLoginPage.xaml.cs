using COMP7211Assignment2.Controller_Folder;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace COMP7211Assignment2
{
    //Code by Lewis Evans 27033957

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FirstLoginPage : ContentPage
    {
        private ValidatorV2 vd;
        public FirstLoginPage()
        {
            vd = new ValidatorV2();
            InitializeComponent();
        }

        private async void CreatePasswordClicked(object sender, EventArgs e)
        {

            if (await vd.ValidateLogin(Password1.Text, Password2.Text))
            {
                Password1.Text = null;
                Password2.Text = null;
                await DisplayAlert("Valid", "Password Correct Check", "OK");
                await Navigation.PushAsync(new CoursesViewPage());
            }
            else
            {
                await DisplayAlert("Invalid", vd.errorMsg, "OK");
            }


        }
    }
}