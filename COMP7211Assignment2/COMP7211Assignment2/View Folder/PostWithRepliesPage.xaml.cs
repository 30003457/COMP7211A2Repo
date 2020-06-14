using COMP7211Assignment2.Model_Folder;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace COMP7211Assignment2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostWithRepliesPage : ContentPage
    {
        Vote newvote = new Vote();
        public PostWithRepliesPage(Post clickedPost)
        {
            InitializeComponent();
            BindingContext = clickedPost;
        }

        public int UpVote { get; private set; }
        public int DwnVote { get; private set; }

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

        private void UpvoteADD (object sender, EventArgs e)   
        {
            newvote.AddUpVote(UpVote);
            UpVotes.Text = Upvote.ToString();


        }

        private void DwnvoteADD(object sender, EventArgs e) 
        {
            newvote.addDwnvote(DwnVote);
            DWNVotes.Text = DwnVote.ToString();
        }

    }
}