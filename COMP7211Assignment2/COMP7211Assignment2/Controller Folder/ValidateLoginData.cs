using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
// Code by Lewis Evans 27033957
namespace COMP7211Assignment2.Model_Folder
{
    class ValidateLoginData
    {
        private StudentLoginFirebaseRetriever firebaseRetriever = new StudentLoginFirebaseRetriever();

        public async Task<bool> ValidatePasswordStatus(string passwordEmpty, string StudentID)
        {
            var emptyPassword = await firebaseRetriever.CheckPasswordIsSet(passwordEmpty , StudentID);
            if (emptyPassword != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public async Task<bool> ValidateID(string StudentIDEntryText)
        {
            var student = await firebaseRetriever.RetrieveStudentID(StudentIDEntryText);
            if (student != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public async Task<bool> ValidatePassword(string passwordEntryText, string studentID)
        {
            
            var password = await firebaseRetriever.RetrievePassword(passwordEntryText, studentID);
           
            if (password != null )
            {
                return true;

            }
            else
            {
                return false;
            }

        }
    }
}
