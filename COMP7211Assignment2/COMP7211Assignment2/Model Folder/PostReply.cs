using System;

//*********************
//Code by Min 30003457
//*********************
namespace COMP7211Assignment2.Model_Folder
{
    public class PostReply : IPost
    {
        public string Content { get; set; }
        public int Downvotes { get; set; }
        public int Id { get; set; }
        public int PostId { get; set; }
        public DateTime Time { get; set; }
        public string TimeString { get; set; }
        public int Upvotes { get; set; }
        public string UpvotesTxt { get; set; }
        public string DownvotesTxt { get; set; }

        /*public PostReply(int id, int postId, DateTime time, string content)
        {
            Id = id;
            PostId = postId;
            Time = time;
            TimeString = time.ToString();
            Content = content;
            Upvotes = 0;
            Downvotes = 0;
        }*/
    }
}
