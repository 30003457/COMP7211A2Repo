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
            string message = "Link has been send!";
            DependencyService.Get<IMessage>().Longtime(message);
        }
    }
}
