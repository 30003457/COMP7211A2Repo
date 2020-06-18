using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
//Code by Lewis
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
            string UserEmailInput = EmailText.Text;
            await DisplayAlert("Success", "Link has been sent to email " + UserEmailInput, "OK");


            //Old code by Agassi Shaju
            //string message = "Link has been sent!";
            //DependencyService.Get<IMessage>().Longtime(message);
        }
    }
}
