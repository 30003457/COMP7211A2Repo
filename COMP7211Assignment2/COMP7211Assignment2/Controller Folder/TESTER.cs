using COMP7211Assignment2.Model_Folder;
using System;
using System.Collections.Generic;
using System.Text;

namespace COMP7211Assignment2.Controller_Folder
{
    class TESTER
    {
        static Random rnd = new Random();

        public static void Login()
        {
            int randomUserIndex = rnd.Next(PageData.PManager.UserRecords.Count - 1);
            LoginSystem.LoggedInUser = PageData.PManager.UserRecords[randomUserIndex];
        }
        public static void RandomVotes()
        {
            foreach (var item in PageData.PManager.PostRecords)
            {
                item.Upvotes = rnd.Next(501);
                item.Downvotes = rnd.Next(501);
                item.UpvotesTxt = $"Upvotes: {item.Upvotes}";
                item.DownvotesTxt = $"Downvotes: {item.Downvotes}";
            }
        }
    }
}
