using COMP7211Assignment2.Controller_Folder;
using COMP7211Assignment2.Model_Folder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        private void Button_Clicked_7(object sender, EventArgs e)
        {
            //TESTER.AddRandomPosts(100);
            //TESTER.RandomVotes();
            //TESTER.UpdateVotesToDB();

            //add random replies and votes
            //TESTER.AddRandomReplies(100);
            TESTER.RandomUsers(100);
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
    }
}
