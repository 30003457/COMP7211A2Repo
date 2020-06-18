using COMP7211Assignment2.Model_Folder;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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

        protected override async void OnAppearing()
        {

            base.OnAppearing();
            var allPersons = await firebaseHelper.GetAllPersons();
        }

        private async void HomeButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CoursesViewPage());
            //await Navigation.PushAsync(new PostViewPageTama());
        }

        private async void CreatePostButton(object sender, EventArgs e)
        {
            await firebaseHelper.AddPost(PostContent.Text,PostTitle.Text);
            PostTitle.Text = string.Empty;
            PostContent.Text = string.Empty;
            await DisplayAlert("Success", "Post Created", "OK");
            var allPersons = await firebaseHelper.GetAllPersons();
            
        }
    }
}