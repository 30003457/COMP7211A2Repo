using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COMP7211Assignment2.Controller_Folder;
using COMP7211Assignment2.Model_Folder;
using COMP7211Assignment2.View_Folder;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace COMP7211Assignment2.View_Folder
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CoursesViewRepPage : ContentPage
    {
        Course selectedCourse;

        public CoursesViewRepPage()
        {
            //masterStackLayout = new StackLayout();
            InitializeComponent();
            //PageData.PManager = new PageManager(); //initiate page manager
            lblStatus.Text = PageData.PManager.UpdateStatusText(); //set footer status text

            PageData.PManager.CDetector = new CourseDetector(LoginSystem.LoggedInUser.StudentID);
            BindingContext = PageData.PManager.CDetector;

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

        private async void Contact_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Email());
        }
    }
}