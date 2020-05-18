using System;
using System.Collections.Generic;
using System.Text;

namespace COMP7211Assignment2.Model_Folder
{
    class Post : IPost
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string Time { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Upvotes { get; set; }
        public int Downvotes { get; set; }
        public string UpvotesTxt { get; set; }
        public string DownvotesTxt { get; set; }
        public List<PostReply> Replies { get; set; }

        public Post(int id, int courseId, DateTime time, string title, string content)
        {
            Id = id;
            CourseId = courseId;
            Time = time.ToString();
            Title = title;
            Content = content;
            Upvotes = 0;
            Downvotes = 0;
        }
    }
}
