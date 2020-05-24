using System;

namespace COMP7211Assignment2.Model_Folder
{
    internal interface IPost
    {
        string Content { get; set; }
        int Downvotes { get; set; }
        int Id { get; set; }
        DateTime Time { get; set; }
        string TimeString { get; set; }
        int Upvotes { get; set; }
        string UpvotesTxt { get; set; }
        string DownvotesTxt { get; set; }
    }
}