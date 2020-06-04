using COMP7211Assignment2.Model_Folder;
using System;
using System.Collections.Generic;
using System.Text;

//*********************
//Code by Min 30003457
//*********************
namespace COMP7211Assignment2.Controller_Folder
{
    class PostDetector
    {
        public List<Post> DetectedPosts { get; set; }
        public PostDetector(int id)
        {
            DetectedPosts = new List<Post>();
            foreach (var item in PageData.PManager.PostRecords)
            {
                if (item.CourseId == id)
                {
                    DetectedPosts.Add(item);
                }
            }
        }
    }
}
