using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
// Code by Lewis Evans 27033957
namespace COMP7211Assignment2.Model_Folder
{
    class ValidateLoginData
    {
        public bool idMatches = false;
        public bool passwordMatches = false;
        public bool PasswordIsSet;

        private StudentLoginFirebaseRetriever firebaseRetriever = new StudentLoginFirebaseRetriever();

        //public async void ValidatePasswordStatus(string passwordEmpty)
        //{
        //    await firebaseRetriever.RetrievePassword(passwordEmpty);
        //    var password = await firebaseRetriever.RetrievePassword(passwordEmpty);         //not working
        //    if (passwordEmpty != null)
        //    {
        //        PasswordIsSet = false;
        //    }
        //    else
        //    {
        //        PasswordIsSet = true;
        //    }
        //}
        public async void ValidateID(string StudentIDEntryText)
        {
            // firebaseRetriever.removePassword(StudentIDEntryText);
            await firebaseRetriever.RetrieveStudentID(StudentIDEntryText);
            var student = await firebaseRetriever.RetrieveStudentID(StudentIDEntryText);
            if (student != null)
            {


                idMatches = true;


            }
            else
            {
                idMatches = false;
            }

        }
        public async void ValidatePassword(string PasswordEntryText)
        {
            
            await firebaseRetriever.RetrievePassword(PasswordEntryText);
            var password = await firebaseRetriever.RetrievePassword(PasswordEntryText);
            if (password != null)
            {

                //txtId.Text = person.StudentId.ToString();
                // await DisplayAlert("Success", "Password Retrive Successfully", "OK");
                passwordMatches = true;

            }
            else
            {
                // await DisplayAlert("Success", "No Password Available", "OK");
                passwordMatches = false;
            }

        }
    }
}
