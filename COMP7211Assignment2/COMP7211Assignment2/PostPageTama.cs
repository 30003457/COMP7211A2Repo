using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace COMP7211Assignment2
{
    public partial class PostPageTama : ContentPage
    {
        public PostPageTama()
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

        private async void BackButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        private async void FirstPostButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PostWithRepliesPage());
        }
    }
}