using COMP7211Assignment2.Controller_Folder;
using COMP7211Assignment2.Model_Folder;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace COMP7211Assignment2
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            PageData.PManager = new PageManager();
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
            //await Navigation.PushAsync(new PostWithRepliesPage());
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CoursesViewPage());
        }
        private async void Button(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ResetPassword());
        }


        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LogInPage());

        }
        private async void ButtonEmail(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Email());
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            FirestoreController.TestMethod();
        }

        private async void Button_Clicked_3(object sender, EventArgs e)
        {
            List<User> testList = await PageData.PManager.FBHelper.GetAllUsers();
            foreach (var item in testList)
            {
                lblUsers.Text += (item.StudentID.ToString("00000000") + "\n");
            }
        }

        private async void Button_Clicked_4(object sender, EventArgs e)
        {
            try
            {
                List<Post> testList = await PageData.PManager.FBHelper.GetAllPosts();
                foreach (var item in testList)
                {
                    lblUsers.Text += (item.Title.ToString() + "\n");
                }
            }
            catch (Exception _e)
            {
                lblUsers.Text = _e.Message;
            }
        }

        private void Button_Clicked_5(object sender, EventArgs e)
        {
            lblUsers.Text = null;
        }

        private async void Button_Clicked_6(object sender, EventArgs e)
        {
            try
            {
                List<PostReply> testList = await PageData.PManager.FBHelper.GetAllReplies();
                foreach (var item in testList)
                {
                    lblUsers.Text += (item.Content + "\n");
                }
            }
            catch (Exception _e)
            {
                lblUsers.Text = _e.Message;
            }
        }

        private async void Button_Clicked_7(object sender, EventArgs e)
        {
            //TESTER.AddRandomPosts(100);
            //TESTER.RandomVotes();
            //TESTER.UpdateVotesToDB();

            //add random replies and votes
            //TESTER.AddRandomReplies(100);

            //await CreateReplies(10);
            DisplayPosts();
            //TESTER.RandomUsers(100);
            //TESTER.RandomVotesReplies();

            //add random courses
            //TESTER.RandomCourses(10);
            //TESTER.RandomEnrolledCourses();

            //try
            //{
            //    List<Course> testList = await PageData.PManager.FBHelper.GetAllCourses();
            //    foreach (var item in testList)
            //    {
            //        lblUsers.Text += ($"{item.IDName} {item.Name}\n");
            //    }
            //}
            //catch (Exception _e)
            //{
            //    lblUsers.Text = _e.Message;
            //}
        }

        private async void DisplayPosts()
        {
            List<Post> posts = new List<Post>();
            List<PostReply> replies = await PageData.PManager.FBHelper.GetAllReplies();
            lblUsers.Text += "course id: "+PageData.PManager.UserRecords[0].EnrolledCourses[0].ID.ToString()+"\n";
            foreach (var item in PageData.PManager.PostRecords)
            {
                if (item.CourseId == PageData.PManager.UserRecords[0].EnrolledCourses[0].ID)
                {
                    posts.Add(item);
                    lblUsers.Text += "contains post: " + item.Id+"\n";
                }   
            }

            foreach (var reply in replies)
            {
                foreach (var post in posts)
                {
                    if (reply.PostId == post.Id)
                        lblUsers.Text += $"post {post.Id} contains reply {reply.Id}\n";
                }
            }
        }

        private async Task CreateReplies(int amount)
        {
            Random rnd = new Random();

            List<PostReply> tempList = await PageData.PManager.FBHelper.GetAllReplies();
            //List<PostReply> tempList = new List<PostReply>();
            int currentReplyId = tempList[tempList.Count - 1].Id + 1;

            //random title gen and post gen
            for (int i = 0; i < amount; i++)
            {
                lblUsers.Text += $"Adding reply: {i}\n";
                string randomPost = null;

                //generate post
                for (int k = 0; k < rnd.Next(10, 51); k++)
                {
                    randomPost += TESTER.randomWordsArray[rnd.Next(TESTER.randomWordsArray.Length)] + " ";
                }

                //PageData.PManager.PostRecords.Add(new Post(
                //    currentPostId,
                //    courseDb.records[rnd.Next(courseDb.records.Count)].ID,
                //    DateTime.Now.AddHours(rnd.Next(25) * -1).AddMinutes(rnd.Next(60) * -1).AddSeconds(rnd.Next(60) * 1),
                //    randomTitle,
                //    randomPost));

                //await PageData.PManager.FBHelper.firebase.Child("PostReply").Child(currentReplyId.ToString("0000")).PutAsync(new PostReply(
                //    currentReplyId,
                //    await GetRandomPostId(),
                //    DateTime.Now.AddHours(rnd.Next(25) * -1).AddMinutes(rnd.Next(60) * -1).AddSeconds(rnd.Next(60) * 1),
                //    randomPost));

                tempList.Add(new PostReply(currentReplyId,
                    await TESTER.GetRandomPostId(),
                    DateTime.Now.AddHours(rnd.Next(25) * -1).AddMinutes(rnd.Next(60) * -1).AddSeconds(rnd.Next(60) * 1),
                    randomPost));


                ++currentReplyId;
            }

            foreach (PostReply item in tempList)
            {
                lblUsers.Text += $"Adding votes to reply {item.Id}\n";
                item.Upvotes = rnd.Next(501);
                item.Downvotes = rnd.Next(501);
                item.UpvotesTxt = $"Upvotes: {item.Upvotes}";
                item.DownvotesTxt = $"Downvotes: {item.Downvotes}";
            }

            lblUsers.Text += "****************** complete ******************";

            await PageData.PManager.FBHelper.firebase.Child("PostReply").PutAsync(tempList);
        }
    }
}
