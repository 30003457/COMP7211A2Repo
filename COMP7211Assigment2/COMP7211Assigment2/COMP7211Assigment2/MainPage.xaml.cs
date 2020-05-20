using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace COMP7211Assigment2
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void HomeButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
        
        private void FirstPostButton(object sender, EventArgs e)
        {

        }

        private void NewPostButton(object sender, EventArgs e)
        {

        }
    }
}
