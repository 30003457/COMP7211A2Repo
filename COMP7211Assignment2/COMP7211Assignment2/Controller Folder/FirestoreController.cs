using COMP7211Assignment2.Model_Folder;
using Firebase.Database;
using Firebase.Database.Query;

namespace COMP7211Assignment2.Controller_Folder
{
    internal class FirestoreController
    {
        public static async void TestMethod()
        {
            FirebaseClient Firebase = new FirebaseClient("https://student-rep-app.firebaseio.com/");
            //PageData.PManager = new PageManager();
            //TESTER.Login();

            //foreach (Course _course in PageData.PManager.CDetector.DetectedCourses)
            //{
            //    await Firebase.Child("student-rep-app").Child("Courses").PostAsync(_course);
            //}

            //initialise databases
            PlaceholderCourseDatabase cdb = new PlaceholderCourseDatabase();
            PlaceholderUserDatabase udb = new PlaceholderUserDatabase();
            PlaceholderPostDatabase pdb = new PlaceholderPostDatabase();
            PlaceholderPostReplyDatabase prdb = new PlaceholderPostReplyDatabase();

            //push each database up to firebase
            foreach (Course _course in cdb.records)
            {
                await Firebase.Child("Courses").Child(_course.ID.ToString("0000")).PutAsync(_course);
            }

            foreach (User _student in udb.records)
            {
                await Firebase.Child("Students").Child(_student.StudentID.ToString("00000000")).PutAsync(_student);
            }

            foreach (Post _post in pdb.records)
            {
                await Firebase.Child("Posts").Child(_post.Id.ToString("0000")).PutAsync(_post);
            }

            foreach (PostReply _reply in prdb.records)
            {
                await Firebase.Child("PostReply").Child(_reply.Id.ToString("0000")).PutAsync(_reply);
            }
        }
    }
}
