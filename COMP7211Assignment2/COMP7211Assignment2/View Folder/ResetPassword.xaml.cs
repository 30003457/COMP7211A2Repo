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


        private void Button1(object sender, EventArgs e)
        {
            if (emailbox.Text == null)
            {
                var message = "please enter a Email ID!";
                DependencyService.Get<IMessage>().Longtime(message);
            }
            else
            {
                var message = "Success!";
                DependencyService.Get<IMessage>().Longtime(message);
            }


        }
    }
}
