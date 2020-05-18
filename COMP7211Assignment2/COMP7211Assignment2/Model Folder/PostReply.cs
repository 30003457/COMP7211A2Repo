using System;
using System.Collections.Generic;
using System.Text;

namespace COMP7211Assignment2.Model_Folder
{
    class PostReply : IPost
    {
        public string Content { get; set; }
        public int Downvotes { get; set; }
        public int Id { get; set; }
        public int PostId { get; set; }
        public string Time { get; set; }
        public int Upvotes { get; set; }

        public PostReply(int id, int postId, DateTime time, string content)
        {
            Id = id;
            PostId = postId;
            Time = time.ToString();
            Content = content;
            Upvotes = 0;
            Downvotes = 0;
        }
    }
}
