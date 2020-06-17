using COMP7211Assignment2.Model_Folder;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Firebase.Database;
using Firebase.Database.Query;
using Newtonsoft.Json;
using System.ComponentModel;
using COMP7211Assignment2.Controller_Folder;

namespace COMP7211Assignment2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreatePostPage : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        User userDetails = new User();
        public CreatePostPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {

            base.OnAppearing();
            var allPersons = await firebaseHelper.GetAllPersons();
        }

        private async void HomeButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PostViewPageTama());
        }

        private async void CreatePostButton(object sender, EventArgs e)
        {
            await firebaseHelper.AddPost(PostTitle.Text, PostContent.Text, );
            PostTitle.Text = string.Empty;
            PostContent.Text = string.Empty;
            await DisplayAlert("Success", "Post Created", "OK");
            var allPersons = await firebaseHelper.GetAllPersons();
            
        }
    }
}