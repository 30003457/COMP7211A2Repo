using COMP7211Assignment2.Controller_Folder;
using COMP7211Assignment2.Model_Folder;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace COMP7211Assignment2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostViewPageTama : ContentPage
    {
        readonly Sorter postSorter;
        public PostViewPageTama()
        {
            InitializeComponent();
            postSorter = new Sorter();
            SortByVotes();
            lblStatus.Text = PageData.PManager.UpdateStatusText(); //set footer status text
        }
        private void RefreshBind()
        {
            BindingContext = null;
            BindingContext = PageData.PManager;
        }
        private void Button_Clicked_Activity(object sender, EventArgs e)
        {
            SortByActivity();
        }

        private void Button_Clicked_Votes(object sender, EventArgs e)
        {
            SortByVotes();
        }

        private void SortByActivity()
        {
            PageData.PManager.SortSettings = 2;
            SortPosts();
            RefreshBind();
        }

        private void SortByVotes()
        {
            PageData.PManager.SortSettings = 1;
            SortPosts();
            RefreshBind();
        }

        private void SortPosts()
        {
            PageData.PManager.DetectedPostRecords = postSorter.SortPosts(PageData.PManager.SortSettings, PageData.PManager.DetectedPostRecords);
        }
        private async void NewPostButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreatePostPage());
        }

        private async void HomeButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}