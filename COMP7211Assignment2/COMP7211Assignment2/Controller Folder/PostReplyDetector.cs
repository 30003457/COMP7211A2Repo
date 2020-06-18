using COMP7211Assignment2.Model_Folder;
using System.Collections.Generic;
using System.Threading.Tasks;

//*********************
//Code by Min 30003457
//*********************
namespace COMP7211Assignment2.Controller_Folder
{
    public class PostReplyDetector
    {
        public List<PostReply> DetectedPostReplies { get; set; }
        public PostReplyDetector(Post post)
        {
            AddRepliesToPost(post);
        }

        private async void AddRepliesToPost(Post post)
        {
            post.Replies = await DetectPostsAsync(post.Id);
            await PageData.PManager.FBHelper.UpdatePost(post);
        }

        private async Task<List<PostReply>> DetectPostsAsync(int postId)
        {
            List<PostReply> tempList = await PageData.PManager.FBHelper.GetAllReplies();

            DetectedPostReplies = new List<PostReply>();
            foreach (var item in tempList)
            {
                if (item.PostId == postId)
                {
                    DetectedPostReplies.Add(item);
                }
            }
            return DetectedPostReplies;
        }
    }
}
