using COMP7211Assignment2.Model_Folder;
using System;
using System.Collections.Generic;
using System.Text;

namespace COMP7211Assignment2.Controller_Folder
{
    class PostDetector
    {
        public List<Post> DetectedPosts { get; set; }
        //PageManager pm;
        //PlaceholderUserDatabase userDb;
        public PostDetector(int id)
        {
            DetectedPosts = new List<Post>();
            //pm = new PageManager();
            //userDb = new PlaceholderUserDatabase();
            foreach (var item in PageData.PostRecords)
            {
                if (item.CourseId == id)
                {
                    DetectedPosts.Add(item);
                    break;
                }
            }
        }
    }
}
