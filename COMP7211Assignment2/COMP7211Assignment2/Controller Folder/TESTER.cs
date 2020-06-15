using COMP7211Assignment2.Model_Folder;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;

//*********************
//Code by Min 30003457
//*********************
namespace COMP7211Assignment2.Controller_Folder
{
    internal class TESTER
    {
        private static readonly Random rnd = new Random();
        private static readonly PlaceholderCourseDatabase courseDb = new PlaceholderCourseDatabase();
        private static readonly string randomWords = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus porttitor eget nunc sit amet hendrerit. Mauris eu tempus ipsum. Vivamus placerat ante at ipsum volutpat placerat. Mauris ut dui a massa vulputate volutpat eu in sem. Pellentesque tristique metus ut varius maximus. Sed id sapien dictum, sollicitudin felis eget, maximus lacus. Phasellus a tincidunt arcu. In nec elementum ipsum. Donec quis volutpat magna. Integer justo mauris, tincidunt eu fringilla in, pulvinar sit amet magna. Sed cursus faucibus est, in elementum enim rutrum non. Vestibulum faucibus tortor id tortor malesuada rhoncus.Aenean eu neque dignissim, viverra nisi ut, fermentum mauris.In lobortis posuere eleifend. Duis non consequat arcu. Ut suscipit, nulla nec lacinia bibendum, nunc nisi porta elit, eu porttitor quam enim at lorem.Duis maximus nec nisl a commodo. Suspendisse sed est pretium, tempus dui vitae, cursus nunc.Aenean sit amet lacus at dolor tristique efficitur at sit amet dui. Donec eget fermentum mauris. Fusce semper, leo sed laoreet bibendum, purus justo pulvinar sapien, id rutrum mauris arcu sit amet velit. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Mauris consequat aliquam mauris interdum blandit. Donec in libero ac erat placerat blandit.Phasellus sodales justo ac dolor sollicitudin, lacinia vehicula quam fermentum.Donec et augue dui. Nam non aliquet nisl, a accumsan tortor. Suspendisse interdum malesuada libero posuere cursus. Nulla facilisi. Sed a sapien tortor. Praesent maximus venenatis magna quis sagittis. Morbi a turpis commodo, sollicitudin urna quis, ullamcorper dolor.Fusce non nunc vitae velit pharetra aliquet ac vel orci. In hac habitasse platea dictumst.Fusce interdum, mi eget blandit scelerisque, risus urna euismod tellus, eget malesuada diam justo at magna.Proin tristique semper justo, ac facilisis lacus molestie vel. Nullam faucibus faucibus eros sit amet pulvinar.In hendrerit consectetur nibh dignissim commodo. Maecenas vel tortor viverra, scelerisque metus suscipit, lobortis nulla.Donec ultricies mattis iaculis. Sed dolor lorem, ultricies elementum sollicitudin ac, pretium id magna. Quisque hendrerit lectus orci, non vehicula lacus rutrum vel. Aliquam in lacus nec lectus interdum tempus non viverra turpis. Curabitur eu lacinia risus. Nunc quam velit, rhoncus ut augue et, blandit imperdiet ex. Ut faucibus felis sed ultricies lobortis. In hac habitasse platea dictumst.Quisque velit leo, finibus a varius nec, mattis commodo sapien. Nullam quis eros nec leo rhoncus imperdiet ut et sem. Donec est tellus, ultrices sit amet interdum sit amet, dapibus et arcu. Aliquam vitae placerat neque. Sed rhoncus erat vulputate mauris efficitur euismod.Ut tempor mollis ipsum a rutrum. Mauris et est in velit aliquam pharetra in venenatis leo. Lorem ipsum dolor sit amet, consectetur adipiscing elit.Suspendisse at ex vitae mauris condimentum commodo.";
        private static readonly string[] randomWordsArray = randomWords.Split(' ');

        public static void Login()
        {
            int randomUserIndex = rnd.Next(PageData.PManager.UserRecords.Count - 1);
            LoginSystem.LoggedInUser = PageData.PManager.UserRecords[randomUserIndex];
        }
        public static void RandomVotes()
        {
            foreach (Post item in PageData.PManager.PostRecords)
            {
                item.Upvotes = rnd.Next(501);
                item.Downvotes = rnd.Next(501);
                item.UpvotesTxt = $"Upvotes: {item.Upvotes}";
                item.DownvotesTxt = $"Downvotes: {item.Downvotes}";
            }
        }

        public static async void UpdateVotesToDB()
        {
            foreach (Post _post in PageData.PManager.PostRecords)
            {
                await PageData.PManager.FBHelper.firebase.Child("Posts").Child(_post.Id.ToString("0000")).PutAsync(_post);
            }
        }

        public static async void AddRandomPosts(int amount)
        {
            List<Post> tempList = await PageData.PManager.FBHelper.GetAllPosts();
            int currentPostId = tempList.Count + 1;

            //random title gen and post gen
            for (int i = 0; i < amount; i++)
            {
                string randomTitle = null, randomPost = null;

                //generate title
                for (int j = 0; j < rnd.Next(3, 10); j++)
                {
                    randomTitle += randomWordsArray[rnd.Next(randomWordsArray.Length)] + " ";
                }

                //generate post
                for (int k = 0; k < rnd.Next(10, 51); k++)
                {
                    randomPost += randomWordsArray[rnd.Next(randomWordsArray.Length)] + " ";
                }

                //PageData.PManager.PostRecords.Add(new Post(
                //    currentPostId,
                //    courseDb.records[rnd.Next(courseDb.records.Count)].ID,
                //    DateTime.Now.AddHours(rnd.Next(25) * -1).AddMinutes(rnd.Next(60) * -1).AddSeconds(rnd.Next(60) * 1),
                //    randomTitle,
                //    randomPost));

                await PageData.PManager.FBHelper.firebase.Child("Posts").Child(currentPostId.ToString("0000")).PutAsync(new Post(
                    currentPostId,
                    courseDb.records[rnd.Next(courseDb.records.Count)].ID,
                    DateTime.Now.AddHours(rnd.Next(25) * -1).AddMinutes(rnd.Next(60) * -1).AddSeconds(rnd.Next(60) * 1),
                    randomTitle,
                    randomPost));

                ++currentPostId;
            }
        }
    }
}
