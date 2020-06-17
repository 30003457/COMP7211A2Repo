using COMP7211Assignment2.Model_Folder;
using Firebase.Database.Query;
using Google.Api;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

//*********************
//Code by Min 30003457
//*********************
namespace COMP7211Assignment2.Controller_Folder
{
    internal class TESTER
    {
        private static readonly Random rnd = new Random();
        //private static readonly List<Course> courseDb;
        private static readonly string randomWords = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus porttitor eget nunc sit amet hendrerit. Mauris eu tempus ipsum. Vivamus placerat ante at ipsum volutpat placerat. Mauris ut dui a massa vulputate volutpat eu in sem. Pellentesque tristique metus ut varius maximus. Sed id sapien dictum, sollicitudin felis eget, maximus lacus. Phasellus a tincidunt arcu. In nec elementum ipsum. Donec quis volutpat magna. Integer justo mauris, tincidunt eu fringilla in, pulvinar sit amet magna. Sed cursus faucibus est, in elementum enim rutrum non. Vestibulum faucibus tortor id tortor malesuada rhoncus.Aenean eu neque dignissim, viverra nisi ut, fermentum mauris.In lobortis posuere eleifend. Duis non consequat arcu. Ut suscipit, nulla nec lacinia bibendum, nunc nisi porta elit, eu porttitor quam enim at lorem.Duis maximus nec nisl a commodo. Suspendisse sed est pretium, tempus dui vitae, cursus nunc.Aenean sit amet lacus at dolor tristique efficitur at sit amet dui. Donec eget fermentum mauris. Fusce semper, leo sed laoreet bibendum, purus justo pulvinar sapien, id rutrum mauris arcu sit amet velit. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Mauris consequat aliquam mauris interdum blandit. Donec in libero ac erat placerat blandit.Phasellus sodales justo ac dolor sollicitudin, lacinia vehicula quam fermentum.Donec et augue dui. Nam non aliquet nisl, a accumsan tortor. Suspendisse interdum malesuada libero posuere cursus. Nulla facilisi. Sed a sapien tortor. Praesent maximus venenatis magna quis sagittis. Morbi a turpis commodo, sollicitudin urna quis, ullamcorper dolor.Fusce non nunc vitae velit pharetra aliquet ac vel orci. In hac habitasse platea dictumst.Fusce interdum, mi eget blandit scelerisque, risus urna euismod tellus, eget malesuada diam justo at magna.Proin tristique semper justo, ac facilisis lacus molestie vel. Nullam faucibus faucibus eros sit amet pulvinar.In hendrerit consectetur nibh dignissim commodo. Maecenas vel tortor viverra, scelerisque metus suscipit, lobortis nulla.Donec ultricies mattis iaculis. Sed dolor lorem, ultricies elementum sollicitudin ac, pretium id magna. Quisque hendrerit lectus orci, non vehicula lacus rutrum vel. Aliquam in lacus nec lectus interdum tempus non viverra turpis. Curabitur eu lacinia risus. Nunc quam velit, rhoncus ut augue et, blandit imperdiet ex. Ut faucibus felis sed ultricies lobortis. In hac habitasse platea dictumst.Quisque velit leo, finibus a varius nec, mattis commodo sapien. Nullam quis eros nec leo rhoncus imperdiet ut et sem. Donec est tellus, ultrices sit amet interdum sit amet, dapibus et arcu. Aliquam vitae placerat neque. Sed rhoncus erat vulputate mauris efficitur euismod.Ut tempor mollis ipsum a rutrum. Mauris et est in velit aliquam pharetra in venenatis leo. Lorem ipsum dolor sit amet, consectetur adipiscing elit.Suspendisse at ex vitae mauris condimentum commodo.";
        private static readonly string[] randomWordsArray = randomWords.Split(' ');

        public static void Login()
        {
            int randomUserIndex = rnd.Next(PageData.PManager.UserRecords.Count - 1);
            LoginSystem.LoggedInUser = PageData.PManager.UserRecords[randomUserIndex];
        }

        public static async void RandomCourses(int amount)
        {
            List<Course> tempList = await PageData.PManager.FBHelper.GetAllCourses();
            //List<Course> tempList = new List<Course>();

            for (int i = 0; i < amount; i++)
            {
                string tempstring = null;
                for (int j = 0; j < rnd.Next(3, 6); j++)
                {
                    tempstring += (randomWordsArray[rnd.Next(randomWordsArray.Length - 1)] + " ");
                }
                tempList.Add(new Course(tempstring, rnd.Next(1000, 10000)));
            }

            await PageData.PManager.FBHelper.firebase.Child("Courses").PutAsync(tempList);
        }

        public static async void RandomVotes()
        {
            List<Post> tempList = await PageData.PManager.FBHelper.GetAllPosts();
            foreach (Post item in tempList)
            {
                item.Upvotes = rnd.Next(501);
                item.Downvotes = rnd.Next(501);
                item.UpvotesTxt = $"Upvotes: {item.Upvotes}";
                item.DownvotesTxt = $"Downvotes: {item.Downvotes}";
            }

            await PageData.PManager.FBHelper.firebase.Child("Posts").PutAsync(tempList);
        }

        public static async void UpdateVotesToDB()
        {
            foreach (Post _post in PageData.PManager.PostRecords)
            {
                await PageData.PManager.FBHelper.firebase.Child("Posts").Child(_post.Id.ToString("0000")).PutAsync(_post);
            }
        }
        public async static void RandomVotesReplies()
        {
            List<PostReply> tempList = await PageData.PManager.FBHelper.GetAllReplies();
            foreach (PostReply item in tempList)
            {
                item.Upvotes = rnd.Next(501);
                item.Downvotes = rnd.Next(501);
                item.UpvotesTxt = $"Upvotes: {item.Upvotes}";
                item.DownvotesTxt = $"Downvotes: {item.Downvotes}";
            }

            //foreach (PostReply _reply in tempList)
            //{
            //    await PageData.PManager.FBHelper.firebase.Child("PostReply").Child(_reply.Id.ToString("0000")).PutAsync(_reply);
            //}

            await PageData.PManager.FBHelper.firebase.Child("PostReply").PutAsync(tempList);
        }

        public static async void AddRandomReplies(int amount)
        {
            //List<PostReply> tempList = await PageData.PManager.FBHelper.GetAllReplies();
            List<PostReply> tempList = new List<PostReply>();
            int currentReplyId = 1;

            //random title gen and post gen
            for (int i = 0; i < amount; i++)
            {
                string randomPost = null;

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

                //await PageData.PManager.FBHelper.firebase.Child("PostReply").Child(currentReplyId.ToString("0000")).PutAsync(new PostReply(
                //    currentReplyId,
                //    await GetRandomPostId(),
                //    DateTime.Now.AddHours(rnd.Next(25) * -1).AddMinutes(rnd.Next(60) * -1).AddSeconds(rnd.Next(60) * 1),
                //    randomPost));

                tempList.Add(new PostReply(currentReplyId,
                    await GetRandomPostId(),
                    DateTime.Now.AddHours(rnd.Next(25) * -1).AddMinutes(rnd.Next(60) * -1).AddSeconds(rnd.Next(60) * 1),
                    randomPost));


                ++currentReplyId;
            }

            foreach (PostReply item in tempList)
            {
                item.Upvotes = rnd.Next(501);
                item.Downvotes = rnd.Next(501);
                item.UpvotesTxt = $"Upvotes: {item.Upvotes}";
                item.DownvotesTxt = $"Downvotes: {item.Downvotes}";
            }

            await PageData.PManager.FBHelper.firebase.Child("PostReply").PutAsync(tempList);
        }

        private async static Task<int> GetRandomPostId()
        {
            Post rndPost = await PageData.PManager.FBHelper.GetPost(PageData.PManager.PostRecords[rnd.Next(PageData.PManager.PostRecords.Count)].Id);
            return rndPost.Id;
        }

        public static async void AddRandomPosts(int amount)
        {
            //List<Post> tempList = await PageData.PManager.FBHelper.GetAllPosts();
            List<Post> tempList = new List<Post>();
            List<Course> courseDb = await PageData.PManager.FBHelper.GetAllCourses();
            int currentPostId = 1;

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

                //await PageData.PManager.FBHelper.firebase.Child("Posts").Child(currentPostId.ToString("0000")).PutAsync(new Post(
                //    currentPostId,
                //    courseDb[rnd.Next(courseDb.Count)].ID,
                //    DateTime.Now.AddHours(rnd.Next(25) * -1).AddMinutes(rnd.Next(60) * -1).AddSeconds(rnd.Next(60) * 1),
                //    randomTitle,
                //    randomPost));

                tempList.Add(new Post(currentPostId,courseDb[rnd.Next(courseDb.Count-1)].ID,DateTime.Now.AddHours(rnd.Next(25) * -1).AddMinutes(rnd.Next(60) * -1).AddSeconds(rnd.Next(60) * 1),
                    randomTitle,
                    randomPost));

                ++currentPostId;
            }

            //random votes
            foreach (Post item in tempList)
            {
                item.Upvotes = rnd.Next(501);
                item.Downvotes = rnd.Next(501);
                item.UpvotesTxt = $"Upvotes: {item.Upvotes}";
                item.DownvotesTxt = $"Downvotes: {item.Downvotes}";
            }

            await PageData.PManager.FBHelper.firebase.Child("Posts").PutAsync(tempList);
        }

        public static async void RandomEnrolledCourses()
        {
            var users = await PageData.PManager.FBHelper.GetAllUsers();
            var courses = await PageData.PManager.FBHelper.GetAllCourses();

            foreach (var item in users)
            {
                item.EnrolledCourses.Clear();
                //enroll students to random amounts of courses
                for (int i = 0; i < rnd.Next(4,9); i++)
                {
                    item.EnrolledCourses.Add(courses[rnd.Next(courses.Count-1)]);
                }
            }

            await PageData.PManager.FBHelper.firebase.Child("Students").PutAsync(users);
        }

        public static async void RandomUsers(int amount)
        {
            var users = await PageData.PManager.FBHelper.GetAllUsers();
            var courses = await PageData.PManager.FBHelper.GetAllCourses();
            for (int i = 0; i < amount; i++)
            {
                int num = rnd.Next(101);
                bool randomBool = false;
                if (num >= 90)
                    randomBool = true;
                else
                    randomBool = false;
                List<Course> item = new List<Course>();
                for (int j = 0; j < rnd.Next(4, 9); j++)
                {
                    item.Add(courses[rnd.Next(courses.Count - 1)]);
                }
                users.Add(new User(randomWordsArray[rnd.Next(randomWordsArray.Length - 1)], randomWordsArray[rnd.Next(randomWordsArray.Length - 1)], rnd.Next(10000000, 100000000), "123456789", randomBool, item));
            }
            await PageData.PManager.FBHelper.firebase.Child("Students").PutAsync(users);
        }
    }
}
