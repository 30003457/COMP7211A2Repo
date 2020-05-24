﻿using COMP7211Assignment2.Controller_Folder;
using COMP7211Assignment2.Model_Folder;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace COMP7211Assignment2.View_Folder
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostsViewPage : ContentPage
    {
        //PageManager pm;
        private readonly Sorter postSorter;
        public PostsViewPage()
        {
            InitializeComponent();
            //pm = new PageManager();
            postSorter = new Sorter();

            PageData.PManager.PDetector = new PostDetector(PageData.PManager.CurrentCourseID);
            PageData.PManager.DetectPosts();
            SortByVotes();
            lblStatus.Text = PageData.PManager.UpdateStatusText(); //set footer status text
            //Bind();
            BindingContext = PageData.PManager;
        }
        private void RefreshBind()
        {
            BindingContext = null;
            BindingContext = PageData.PManager;
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }

        private void Button_Clicked_Activity(object sender, EventArgs e)
        {
            SortByActivity();
        }

        private void Button_Clicked_Votes(object sender, EventArgs e)
        {
            SortByVotes();
        }

        private void SortByActivity()
        {
            PageData.PManager.SortSettings = 2;
            SortPosts();
            RefreshBind();
        }

        private void SortByVotes()
        {
            PageData.PManager.SortSettings = 1;
            SortPosts();
            RefreshBind();
        }

        private void SortPosts()
        {
            PageData.PManager.DetectedPostRecords = postSorter.SortPosts(PageData.PManager.SortSettings, PageData.PManager.DetectedPostRecords);
        }

        private void Home_Button_Clicked(object sender, EventArgs e)
        {
            //for (var counter = 1; counter < BackCount; counter++)
            //{
            //    Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
            //}
            //await Navigation.PopAsync();
        }

        private void Back_Button_Clicked(object sender, EventArgs e)
        {

        }

        private void Create_Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}