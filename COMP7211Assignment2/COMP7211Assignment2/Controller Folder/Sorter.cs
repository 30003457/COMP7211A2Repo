using COMP7211Assignment2.Model_Folder;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace COMP7211Assignment2.Controller_Folder
{
    class Sorter
    {
        private List<Post> SortedPosts { get; set; }
        bool votesDescending = false;
        bool activityDescending = false;

        public List<Post> SortPosts(int sortSettings, List<Post> postList)
        {
            if (sortSettings == 1) //upvotes
            {
                return SortPostsVotes(postList);
            }
            else //activity
            {
                return SortPostsActivity(postList);
            }
        }

        private List<Post> SortPostsVotes(List<Post> postList)
        {
            SortedPosts = new List<Post>();

            if(votesDescending == true)
            {
                SortedPosts = postList.OrderBy(o => o.Upvotes).ToList();
                votesDescending = false;
            }
            else
            {
                SortedPosts = postList.OrderByDescending(o => o.Upvotes).ToList();
                votesDescending = true;
            }


            return SortedPosts;
        }
        private List<Post> SortPostsActivity(List<Post> postList)
        {
            SortedPosts = new List<Post>();

            if(activityDescending == true)
            {
                SortedPosts = postList.OrderBy(o => o.Time).ToList();
                activityDescending = false;
            }
            else
            {
                SortedPosts = postList.OrderByDescending(o => o.Time).ToList();
                activityDescending = true;
            }
            

            return SortedPosts;
        }
    }
}
