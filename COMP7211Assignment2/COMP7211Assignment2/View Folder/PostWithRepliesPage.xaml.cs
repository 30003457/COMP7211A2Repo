using COMP7211Assignment2.Controller_Folder;
using COMP7211Assignment2.Model_Folder;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace COMP7211Assignment2
{
    //code by Tama, Patrick, Min 30003457
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostWithRepliesPage : ContentPage
    {
        private readonly Post clickedPost;
        public int Downvotes { get; private set; }
        public int Upvotes { get; private set; }
     

        public PostWithRepliesPage(Post _clickedPost)
        {
            InitializeComponent();

            clickedPost = _clickedPost;
            AddPostRepliesGUI(_clickedPost);
            BindingContext = _clickedPost;
        }
        private async Task<List<Post>> RetrieveUpdatedPosts()
        {
            return await PageData.PManager.FBHelper.GetAllPosts();
        }
        private async void AddPostRepliesGUI(Post clickedPost)
        {
            PageData.PManager.PostRecords = await RetrieveUpdatedPosts();
            foreach (Post item in PageData.PManager.PostRecords)
            {
                if (item.Id == clickedPost.Id)
                {
                    //update clickedPost data with latest DB data and refresh detected posts list
                    clickedPost = item;
                    PageData.PManager.PDetector = new PostDetector(item.Id);

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


        private async void HomeButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CoursesViewPage());
        }

        public async void ReplyButton1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ReplyPostPage(clickedPost));
        }
        //============================
        //vote - patrick and adjustments by min

        private async void UpvoteADD(object sender, EventArgs e)
        {
            clickedPost.Upvotes++;
            clickedPost.UpvotesTxt = PageData.PManager.UpdateUpvoteText(clickedPost.Upvotes);
            Uvotes.Text = clickedPost.Upvotes.ToString();
            await RefreshPostDB();

        }

        private async void DwnvoteADD(object sender, EventArgs e)
        {
            clickedPost.Downvotes++;
            clickedPost.DownvotesTxt = PageData.PManager.UpdateDownvoteText(clickedPost.Downvotes);
            Dvotes.Text = clickedPost.Downvotes.ToString();
            await RefreshPostDB();
        }

        private async Task RefreshPostDB()
        {
            //refresh DB
            await PageData.PManager.FBHelper.firebase.Child("Posts").Child((clickedPost.Id - 1).ToString()).PutAsync(clickedPost);
            PageData.PManager.PostRecords = await RetrieveUpdatedPosts();
        }

        //=======================================
        private StackLayout CreateStack(int i)
        {
            StackLayout stack = new StackLayout();

            Label lblcontent = new Label { Text = clickedPost.Replies[i].Content, TextColor = Color.White, BackgroundColor = Color.Teal, Margin = new Thickness(0, 50, 0, 0) };
            Label lbldate = new Label { Text = clickedPost.Replies[i].TimeString, TextColor = Color.White };


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
                TextColor = Color.White,
                VerticalOptions = LayoutOptions.Start,
                FontAttributes = FontAttributes.Bold
            };

            Label lblupvote = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                Text = clickedPost.Replies[i].Upvotes.ToString(),
                TextColor = Color.White,
                VerticalOptions = LayoutOptions.Start,
                FontAttributes = FontAttributes.Bold,
            };
            Grid.SetColumn(lblupvote, 1);

            ImageButton btndownvote = new ImageButton
            {
                Source = "dislike1.png",
                BackgroundColor = Color.Black,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Start,
                WidthRequest = 70
            };
            Grid.SetRow(btndownvote, 1);

            ImageButton btnupvote = new ImageButton
            {
                Source = "like1.png",
                BackgroundColor = Color.Black,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Start,
                WidthRequest = 70
            };
            Grid.SetRow(btnupvote, 1);
            Grid.SetColumn(btnupvote, 1);

            Button btnreply = new Button
            {
                Text = "Reply",
                VerticalOptions = LayoutOptions.End,
                HorizontalOptions = LayoutOptions.End,
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Button)),
                TextColor = Color.Black,
                WidthRequest = 80,
                HeightRequest = 40,
                CornerRadius = 20,
                TranslationX = -10,
                BackgroundColor = Color.LightGray,
            };
            Grid.SetRow(btnreply, 1);
            Grid.SetColumn(btnreply, 2);

            btnreply.Clicked += Btnreply_Clicked; 
            btnupvote.Clicked += async (sender, args) =>
            {
                int UpVote = clickedPost.Replies[i].Upvotes;
                UpVote++;
                clickedPost.Replies[i].Upvotes = UpVote;
                lblupvote.Text = UpVote.ToString();

                await PageData.PManager.FBHelper.firebase.Child("Posts").Child((clickedPost.Id - 1).ToString()).Child("Replies").PutAsync(clickedPost.Replies);
            };
            btndownvote.Clicked += async (sender, args) =>
            {
                int DwnVote = clickedPost.Replies[i].Downvotes;
                DwnVote++;
                clickedPost.Replies[i].Downvotes = DwnVote;
                lbldownvote.Text = DwnVote.ToString();

                await PageData.PManager.FBHelper.firebase.Child("Posts").Child((clickedPost.Id - 1).ToString()).Child("Replies").PutAsync(clickedPost.Replies);
            };//this will update the replies votes

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