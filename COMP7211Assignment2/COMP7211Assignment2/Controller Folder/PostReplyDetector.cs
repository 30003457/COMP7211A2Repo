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
        //private List<PostReply> tempList;
        public PostReplyDetector(int postId)
        {
            DetectPostsAsync(postId);
        }

        private async void DetectPostsAsync(int postId)
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
        }

        private async Task<List<PostReply>> GetPostReplies()
        {
            return await PageData.PManager.FBHelper.GetAllReplies();
        }
    }
}
