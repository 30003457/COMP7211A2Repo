using COMP7211Assignment2.Controller_Folder;
using COMP7211Assignment2.Model_Folder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace COMP7211Assignment2.View_Folder
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostsViewPage : ContentPage
    {
        PageManager pm;

        public PostsViewPage()
        {
            InitializeComponent();
            pm = new PageManager();
            PageData.PDetector = new PostDetector(PageData.CurrentCourseID);
            pm.DetectPosts();
            BindingContext = pm;
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }
    }
}