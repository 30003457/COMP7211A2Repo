using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;
using Firebase.Database.Query;
using System.Linq;
using System.Threading.Tasks;
using COMP7211Assignment2.Model_Folder;

namespace COMP7211Assignment2.Model_Folder
{
    //Code by Tama and Min
    class FirebaseHelper
    {
        FirebaseClient firebase = new FirebaseClient("https://student-rep-app.firebaseio.com/");

        public async Task<List<Post>> GetAllPersons()
        {
            return (await firebase
              .Child("Posts")
              .OnceSingleAsync<List<Post>>());
              //.OnceAsync<Post>()).Select(item => new Post
              //{
              //    Title = item.Object.Title,
              //    Content = item.Object.Content,
              //    Id = item.Object.Id,
              //    CourseId = item.Object.CourseId,
              //    Time = item.Object.Time,
              //    TimeString = item.Object.TimeString,
              //    Upvotes = item.Object.Upvotes,
              //    Downvotes = item.Object.Downvotes
              //}).ToList();
        }

        public async Task AddPost(string content, string title, int id, int courseId, DateTime time, int upvotes, int downvotes)
        {

            await firebase
              .Child("Posts")
              .PutAsync(new Post(id,courseId,time,title,content) { Upvotes = upvotes, Downvotes = downvotes });
        }


        public async Task AddReply(string content, int id,int postId, DateTime time, string timeString, int upvotes, int downvotes)
        {

            await firebase
              .Child("PostReply")
              .PostAsync(new PostReply(id, postId, time, content) { Upvotes = upvotes, Downvotes = downvotes });
        }
    }
}
