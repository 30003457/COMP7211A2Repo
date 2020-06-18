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
    //code by Tama and Min
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreatePostPage : ContentPage
    {
        FireBaseHelperv2 firebaseHelper = new FireBaseHelperv2();
        public CreatePostPage()
        {
            InitializeComponent();
            BindingContext = PageData.PManager;
        }

        protected async override void OnAppearing()
        {

            base.OnAppearing();
            var allUsers = await firebaseHelper.GetAllUsers();
        }

        private async void HomeButton(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new PostViewPageTama());
        }

        private async void CreatePostButton(object sender, EventArgs e)
        {
            await firebaseHelper.AddPost(PostContent.Text,PostTitle.Text);
            PostTitle.Text = string.Empty;
            PostContent.Text = string.Empty;
            var allUsers = await firebaseHelper.GetAllUsers();
            await Navigation.PopAsync();
        }
    }
}