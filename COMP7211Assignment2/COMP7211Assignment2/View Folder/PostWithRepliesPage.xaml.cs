﻿using COMP7211Assignment2.Model_Folder;
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
    public partial class PostWithRepliesPage : ContentPage
    {
        public PostWithRepliesPage(Post clickedPost)
        {
            InitializeComponent();
            BindingContext = clickedPost;
        }

        private async void HomeButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PostViewPageTama());
        }

        private async void ReplyButton1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ReplyPostPage());
        }

        private async void ReplyButton2(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ReplyPostPage());
        }
    }
}