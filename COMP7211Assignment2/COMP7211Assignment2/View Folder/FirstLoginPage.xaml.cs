using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace COMP7211Assignment2
{
    //Code by Lewis Evans 27033957

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FirstLoginPage : ContentPage
    {
        public FirstLoginPage()
        {
            InitializeComponent();
        }

        private void CreatePasswordClicked(object sender, EventArgs e)
        {

            if (Password1.Text == null)
            {
                DisplayAlert("Error", "No Student ID Entered please try again", "OK");
            }
            else if (Password2.Text == null)
            {
                DisplayAlert("Error", "No Password Entered please try again", "OK");
            }
            else
            {
                DisplayAlert("Success", "Creating Login...", "ok");
            }

        }
    }
}