using COMP7211Assignment2.Model_Folder;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace COMP7211Assignment2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreatePostPage : ContentPage
    {
        private readonly FirebaseHelper firebaseHelper = new FirebaseHelper();
        //User userDetails = new User();
        public CreatePostPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {

            base.OnAppearing();
            System.Collections.Generic.List<Post> allPersons = await firebaseHelper.GetAllPersons();
        }

        private async void HomeButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PostViewPageTama());
        }

        private async void CreatePostButton(object sender, EventArgs e)
        {
            //await firebaseHelper.AddPost(PostTitle.Text, PostContent.Text,DateTime.Now,0,0);
            PostTitle.Text = string.Empty;
            PostContent.Text = string.Empty;
            await DisplayAlert("Success", "Post Created", "OK");
            System.Collections.Generic.List<Post> allPersons = await firebaseHelper.GetAllPersons();

        }
    }
}