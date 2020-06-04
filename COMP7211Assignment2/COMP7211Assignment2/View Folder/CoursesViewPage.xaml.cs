using COMP7211Assignment2.Controller_Folder;
using COMP7211Assignment2.Model_Folder;
using COMP7211Assignment2.View_Folder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
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
            PageData.PManager = new PageManager(); //initiate page manager
            TESTER.Login(); //random login
            lblStatus.Text = PageData.PManager.UpdateStatusText(); //set footer status text
            PageData.PManager.CDetector = new CourseDetector(LoginSystem.LoggedInUser.StudentID);
            BindingContext = PageData.PManager.CDetector;

            TESTER.AddRandomPosts(100); //add random posts
            TESTER.RandomVotes(); //add random votes

            lblStatus.Text = PageData.PManager.UpdateStatusText();
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
            await Navigation.PopToRootAsync();
        }
    }
}