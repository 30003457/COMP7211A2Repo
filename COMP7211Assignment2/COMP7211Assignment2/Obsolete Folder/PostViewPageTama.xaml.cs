using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace COMP7211Assignment2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostViewPageTama : ContentPage
    {
        public PostViewPageTama()
        {
            InitializeComponent();
        }

        private async void NewPostButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreatePostPage());
        }

        private async void HomeButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        private async void FirstPostButton(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new PostWithRepliesPage());
        }
    }
}