using COMP7211Assignment2.Controller_Folder;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace COMP7211Assignment2
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

        private async void NewPostButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreatePostPage());
        }

        private async void HomeButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        private async void BackButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        private async void FirstPostButton(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new PostWithRepliesPage());
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CoursesViewPage());
        }
        private async void Button(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ResetPassword());
        }


        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LogInPage());

        }
        private async void ButtonEmail(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Email());
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            lblMain.Text = FirestoreDatabase.TestMethod();
        }
    }
}
