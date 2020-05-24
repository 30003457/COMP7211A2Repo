using COMP7211Assignment2.Model_Folder;
using System.Collections.Generic;

namespace COMP7211Assignment2.Controller_Folder
{
    internal class PostDetector
    {
        public List<Post> DetectedPosts { get; set; }
        //PageManager pm;
        //PlaceholderUserDatabase userDb;
        public PostDetector(int id)
        {
            DetectedPosts = new List<Post>();
            //pm = new PageManager();
            //userDb = new PlaceholderUserDatabase();
            foreach (Post item in PageData.PManager.PostRecords)
            {
                if (item.CourseId == id)
                {
                    DetectedPosts.Add(item);
                }
            }
        }
    }
}
