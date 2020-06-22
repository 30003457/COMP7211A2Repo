using COMP7211Assignment2.Controller_Folder;
using COMP7211Assignment2.Model_Folder;
using Java.Lang;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

//***************************
//Code by Min 30003457
//***************************

namespace COMP7211Assignment2.View_Folder
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostsViewPage : ContentPage
    {
        private Sorter postSorter;
        public PostsViewPage()
        {
            InitializeComponent();

            LoadPageData();

            SizeChanged += PostsViewPage_SizeChanged;
        }

        protected override void OnAppearing()
        {
            LoadPageData();
        }

        private void LoadPageData()
        {
            //retrieve from post db
            RetrievePostDB();

            postSorter = new Sorter();

            PageData.PManager.PDetector = new PostDetector(PageData.PManager.CurrentCourseID);
            PageData.PManager.DetectPosts();
            SortByVotes();
            lblStatus.Text = PageData.PManager.UpdateStatusText(); //set footer status text
            BindingContext = PageData.PManager;
        }

        private async void RetrievePostDB()
        {
            PageData.PManager.PostRecords = await PageData.PManager.FBHelper.GetAllPosts();
        }


        private void PostsViewPage_SizeChanged(object sender, EventArgs e)
        {
            //landscape
            if (Width > Height)
            {
                fListview.FlowColumnCount = 2;
                SortUI.Orientation = StackOrientation.Horizontal;
                FooterUI.Orientation = StackOrientation.Horizontal;
                BtnActivity.HeightRequest = 80;
                BtnVotes.HeightRequest = 80;
            }
            //portrait
            else
            {
                fListview.FlowColumnCount = 1;
                SortUI.Orientation = StackOrientation.Vertical;
                FooterUI.Orientation = StackOrientation.Vertical;
                BtnActivity.HeightRequest = 60;
                BtnVotes.HeightRequest = 60;
            }
        }

        private void RefreshBind()
        {
            BindingContext = null;
            BindingContext = PageData.PManager;
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new PostWithRepliesPage((Post)e.Item));
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

        private async void Home_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CoursesViewPage());
        }

        private async void Create_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreatePostPage());
        }
    }
}