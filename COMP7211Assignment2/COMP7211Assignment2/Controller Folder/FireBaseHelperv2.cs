
using Firebase.Database;
using Firebase.Database.Query;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using COMP7211Assignment2.Model_Folder;
using Newtonsoft.Json.Linq;
using System.Reactive.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Api.Gax.Rest;

namespace COMP7211Assignment2
{
    //Code by Lewis and Min 30003457
    public class FireBaseHelperv2
    {
        public FirebaseClient firebase = new FirebaseClient($"https://student-rep-app.firebaseio.com/");

        public async Task<int> GetUpvotes(int id)
        {
            var posts = await PageData.PManager.FBHelper.GetAllPosts();
            foreach (var post in posts)
            {
                if(post.Id == id)
                {
                    return post.Upvotes;
                }
            }

            //return 0 otherwise
            return 0;
        }

        public async Task<int> GetDownvotes(int id)
        {
            var posts = await PageData.PManager.FBHelper.GetAllPosts();
            foreach (var post in posts)
            {
                if (post.Id == id)
                {
                    return post.Downvotes;
                }
            }

            //return 0 otherwise
            return 0;
        }

        public async Task<List<Post>> GetAllPersons()
        {
            return (await firebase
              .Child("Posts")
              .OnceSingleAsync<List<Post>>());
        }

        public async Task AddPost(string content, string title)
        {
            var posts = await PageData.PManager.FBHelper.GetAllPosts();
            posts.Add(new Post(posts.Count + 1, PageData.PManager.CurrentCourseID, DateTime.Now, title, content)
            {
                Downvotes = 0,
                Upvotes = 0,
                DownvotesTxt = $"Downvotes: 0",
                UpvotesTxt = $"Upvotes: 0"
            });
            await firebase
              .Child("Posts")
              .PutAsync(posts);
        }


        public async Task AddReply(string content, int id, int postId, DateTime time, int upvotes, int downvotes)
        {

            await firebase
              .Child("PostReply")
              .PostAsync(new PostReply(id, postId, time, content) { Upvotes = upvotes, Downvotes = downvotes });
        }

        public async void SetPassword(int studentId, string pw)
        {
            var users = await GetAllUsers();
            foreach (var item in users)
            {
                if (item.StudentID == studentId)
                    item.Password = pw;
            }

            await firebase.Child("Students").PutAsync(users);
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await firebase.Child("Students").OnceSingleAsync<List<User>>();
        }

        public async Task<User> GetUser(int studentId)
        {
            var users = await GetAllUsers();
            foreach (var item in users)
            {
                if (item.StudentID == studentId)
                    return item;
            }
            return null;
        }

        public async Task<List<Post>> GetAllPosts()
        {
            return (await firebase
                .Child("Posts")
                .OnceSingleAsync<List<Post>>());
        }

        public async Task<Post> GetPost(int postId)
        {
            var posts = await GetAllPosts();
            foreach (var item in posts)
            {
                if (item.Id == postId)
                    return item;
            }
            return null;
        }

        public async Task<List<PostReply>> GetAllReplies()
        {
           return (await firebase
          .Child("PostReply")
          .OnceSingleAsync<List<PostReply>>());
        }

        public async Task<List<Course>> GetAllCourses()
        {
            return (await firebase
                .Child("Courses").OnceSingleAsync<List<Course>>());
        }

        public async Task UpdatePost(Post post)
        {
            var posts = await GetAllPosts();
            foreach (var item in posts)
            {
                if (item.Id == post.Id)
                    item.Replies = post.Replies;
            }

            await firebase
              .Child("Posts")
              .PutAsync(posts);
        }
    }

}




