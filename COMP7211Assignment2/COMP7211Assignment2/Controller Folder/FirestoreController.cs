using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Plugin.CloudFirestore;
using Google.Cloud.Firestore;
using Firebase.Database;
using Firebase.Database.Query;
using COMP7211Assignment2.Model_Folder;

namespace COMP7211Assignment2.Controller_Folder
{
    class FirestoreController
    {
        public async static void TestMethod()
        {
            FirebaseClient Firebase = new FirebaseClient("https://student-rep-app.firebaseio.com/");
            //PageData.PManager = new PageManager();
            //TESTER.Login();

            //foreach (Course _course in PageData.PManager.CDetector.DetectedCourses)
            //{
            //    await Firebase.Child("student-rep-app").Child("Courses").PostAsync(_course);
            //}
            
            //initialist databases
            PlaceholderCourseDatabase cdb = new PlaceholderCourseDatabase();
            PlaceholderUserDatabase udb = new PlaceholderUserDatabase();
            PlaceholderPostDatabase pdb = new PlaceholderPostDatabase();
            PlaceholderPostReplyDatabase prdb = new PlaceholderPostReplyDatabase();

            //push each database up to firebase
            foreach (Course _course in cdb.records)
            {
                await Firebase.Child("Courses").Child(_course.ID.ToString()).PutAsync(_course);
            }

            foreach (User _student in udb.records)
            {
                await Firebase.Child("Students").Child(_student.StudentID.ToString("00000000")).PutAsync(_student);
            }

            foreach (Post _post in pdb.records)
            {
                await Firebase.Child("Posts").Child(_post.Id.ToString()).PutAsync(_post);
            }

            foreach (PostReply _reply in prdb.records)
            {
                await Firebase.Child("PostReply").Child(_reply.Id.ToString()).PutAsync(_reply);
            }

        }
    }
}
