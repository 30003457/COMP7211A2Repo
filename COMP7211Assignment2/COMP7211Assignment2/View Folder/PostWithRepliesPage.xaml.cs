using COMP7211Assignment2.Controller_Folder;
using COMP7211Assignment2.Model_Folder;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace COMP7211Assignment2
{
    //code by Tama and Min 30003457
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostWithRepliesPage : ContentPage
    {
        Vote newvote = new Vote();
        Post clickedPost;
        public PostWithRepliesPage(Post _clickedPost)
        {
            InitializeComponent();
            clickedPost = _clickedPost;
            lblStatus.Text = PageData.PManager.UpdateStatusText();
            PageData.PManager.PRDetector = new PostReplyDetector(_clickedPost);
            AddPostRepliesGUI(_clickedPost);
            BindingContext = _clickedPost;
        }
        private async Task<List<Post>> RetrieveUpdatedPosts()
        {
            return await PageData.PManager.FBHelper.GetAllPosts();
        }
        private async void AddPostRepliesGUI(Post clickedPost)
        {
            List<Post> posts = await RetrieveUpdatedPosts();
            foreach (var item in posts)
            {
                if(item.Id == clickedPost.Id)
                {
                    if (item.Replies != null)
                    {
                        for (int i = 0; i < item.Replies.Count; i++)
                        {
                            mainStack.Children.Add(CreateStack(i));
                        }
                    }
                    return;
                }
            }
        }
        public int UpVote { get; private set; }
        public int DwnVote { get; private set; }

        private async void HomeButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PostViewPageTama());
        }

        public async void ReplyButton1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ReplyPostPage(clickedPost));
        }

        private void UpvoteADD (object sender, EventArgs e)   
        {
            newvote.AddUpVote(UpVote);
            //UpVotes.Text = Upvote.ToString();


        }

        private void DwnvoteADD(object sender, EventArgs e) 
        {
            newvote.addDwnvote(DwnVote);
            //DWNVotes.Text = DwnVote.ToString();
        }

        private StackLayout CreateStack(int i)
        {
            StackLayout stack = new StackLayout();

            Label lblcontent = new Label { Text = clickedPost.Replies[i].Content };
            Label lbldate = new Label { Text = clickedPost.Replies[i].TimeString };

            Grid gridvotes = new Grid
            {
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = 80 },
                    new ColumnDefinition { Width = 80 },
                    new ColumnDefinition()
                },

                RowDefinitions =
                {
                    new RowDefinition { Height = 20 },
                    new RowDefinition()
                },
            };

            Label lbldownvote = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                Text = clickedPost.Replies[i].Downvotes.ToString(),
                TextColor = Color.Black,
                VerticalOptions = LayoutOptions.Start,
                FontAttributes = FontAttributes.Bold
            };

            Label lblupvote = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                Text = clickedPost.Replies[i].Upvotes.ToString(),
                TextColor = Color.Black,
                VerticalOptions = LayoutOptions.Start,
                FontAttributes = FontAttributes.Bold,
            };
            Grid.SetColumn(lblupvote, 1);

            Button btndownvote = new Button
            {
                Text = "Downvote",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Button)),
                TextColor = Color.Black,
                WidthRequest = 70
            };
            Grid.SetRow(btndownvote, 1);

            Button btnupvote = new Button
            {
                Text = "Upvote",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Button)),
                TextColor = Color.Black,
                WidthRequest = 70
            };
            Grid.SetRow(btnupvote, 1);
            Grid.SetColumn(btnupvote, 1);

            Button btnreply = new Button
            {
                Text = "Reply",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.End,
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Button)),
                TextColor = Color.Black,
                WidthRequest = 70,
                TranslationX = -10,
            };
            Grid.SetRow(btnreply, 1);
            Grid.SetColumn(btnreply, 2);

            btnreply.Clicked += Btnreply_Clicked; ;

            stack.Children.Add(lblcontent);
            stack.Children.Add(lbldate);
            gridvotes.Children.Add(lbldownvote);
            gridvotes.Children.Add(lblupvote);
            gridvotes.Children.Add(btndownvote);
            gridvotes.Children.Add(btnupvote);
            gridvotes.Children.Add(btnreply);
            stack.Children.Add(gridvotes);

            return stack;
        }

        private void Btnreply_Clicked(object sender, EventArgs e)
        {
            ReplyButton1(sender, e);
        }
    }
}