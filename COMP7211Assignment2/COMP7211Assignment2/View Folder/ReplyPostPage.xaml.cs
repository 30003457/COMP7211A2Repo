using COMP7211Assignment2.Model_Folder;
using Firebase.Database.Query;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace COMP7211Assignment2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReplyPostPage : ContentPage
    {
        private readonly Post clickedPost;
        public ReplyPostPage(Post _clickedPost)
        {
            InitializeComponent();
            clickedPost = _clickedPost;
            BindingContext = _clickedPost;
        }

        private async void HomeButton(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new PostViewPageTama());
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            System.Collections.Generic.List<Post> posts = await PageData.PManager.FBHelper.GetAllPosts();
            System.Collections.Generic.List<PostReply> postreplies = await PageData.PManager.FBHelper.GetAllReplies();
            foreach (Post post in posts)
            {
                if (post.Id == clickedPost.Id)
                {
                    PostReply reply = new PostReply(postreplies.Count + 1, clickedPost.Id, DateTime.Now, editorReply.Text);
                    postreplies.Add(reply);
                    post.Replies.Add(reply);
                }
            }
            await PageData.PManager.FBHelper.firebase.Child("Posts").PutAsync(posts);
            await PageData.PManager.FBHelper.firebase.Child("PostReply").PutAsync(postreplies);
            await Navigation.PopAsync();
        }
    }
}