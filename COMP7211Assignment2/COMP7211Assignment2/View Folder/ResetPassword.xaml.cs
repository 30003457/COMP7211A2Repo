using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace COMP7211Assignment2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResetPassword
    {
        public ResetPassword()
        {
            InitializeComponent();
        }


        private async void Button1(object sender, EventArgs e)
        {
            //Validation for email here?
            string UserEmailInput = EmailText.Text;
            await DisplayAlert("Success", "Link has been sent to email " + UserEmailInput, "OK");

            //Set Password on account to null?
            //Take User to FirstLoginPage to setup new password?

            //string message = "Link has been sent!";
            //DependencyService.Get<IMessage>().Longtime(message);
        }
    }
}
