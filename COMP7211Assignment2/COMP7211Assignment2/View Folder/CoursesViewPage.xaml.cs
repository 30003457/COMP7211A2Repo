using COMP7211Assignment2.Controller_Folder;
using COMP7211Assignment2.Model_Folder;
using COMP7211Assignment2.View_Folder;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

//*********************
//Code by Min 30003457
//*********************
namespace COMP7211Assignment2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CoursesViewPage : ContentPage
    {
        Course selectedCourse;
        public CoursesViewPage()
        {
            InitializeComponent();
            //PageData.PManager = new PageManager(); //initiate page manager
            //TESTER.Login(); //random login
            lblStatus.Text = PageData.PManager.UpdateStatusText(); //set footer status text
            PageData.PManager.CDetector = new CourseDetector(LoginSystem.LoggedInUser.StudentID);
            BindingContext = PageData.PManager.CDetector;

            //TESTER.AddRandomPosts(100); //add random posts
            //TESTER.RandomVotes(); //add random votes

            //lblStatus.Text = PageData.PManager.UpdateStatusText();

            //responsive ui
            //SizeChanged += CoursesViewPage_SizeChanged;
        }

        private void CoursesViewPage_SizeChanged(object sender, EventArgs e)
        {
            //responsive ui section
            //this is currently doing nothing but the layout is there so we can implement something in the future
            //landscape
            if (Width > Height)
            {
                fListview.FlowColumnCount = 2;
            }

            //portrait
            else
            {
                fListview.FlowColumnCount = 2;
            }
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            selectedCourse = (Course)e.Item;
            PageData.PManager.CurrentTitle = selectedCourse.IDName;
            PageData.PManager.CurrentCourseID = selectedCourse.ID;
            PageData.PManager.CurrentSubtext = selectedCourse.Name;

            await Navigation.PushAsync(new PostsViewPage());
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            LoginSystem.LoggedInUser = null;
            await Navigation.PopToRootAsync();
        }
    }
}