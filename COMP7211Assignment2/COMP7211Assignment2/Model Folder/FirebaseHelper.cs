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
    class FirebaseHelper
    {
        FirebaseClient firebase = new FirebaseClient("https://student-rep-app.firebaseio.com/");

        public async Task<List<Post>> GetAllPersons()
        {
            return (await firebase
              .Child("Post")
              .OnceAsync<Post>()).Select(item => new Post
              {
                  Title = item.Object.Title,
                  Content = item.Object.Content,
                  Id = item.Object.Id,
                  CourseId = item.Object.CourseId,
                  Time = item.Object.Time,
                  TimeString = item.Object.TimeString,
                  Upvotes = item.Object.Upvotes,
                  Downvotes = item.Object.Downvotes
              }).ToList();
        }

        public async Task AddPost(string content, string title, int id, int courseId, DateTime time, string timeString, int upvotes, int downvotes)
        {

            await firebase
              .Child("Post")
              .PostAsync(new Post() { Title = title, Content = content, Id = id, CourseId = courseId, Time = time, TimeString = timeString, Upvotes = upvotes, Downvotes = downvotes });
        }


        public async Task AddReply(string content, int id, DateTime time, string timeString, int upvotes, int downvotes)
        {

            await firebase
              .Child("Reply")
              .PostAsync(new PostReply() { Content = content, Id = id, Time = time, TimeString = timeString, Upvotes = upvotes, Downvotes = downvotes });
        }
    }
}
