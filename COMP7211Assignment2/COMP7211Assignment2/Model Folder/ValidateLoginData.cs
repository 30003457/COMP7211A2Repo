using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
// Code by Lewis Evans 27033957
namespace COMP7211Assignment2.Model_Folder
{
    class ValidateLoginData
    {
        public string StudentIdCheck(string StudentID)
        {
            StudentLoginFirebaseRetriever firebaseRetriever = new StudentLoginFirebaseRetriever();
            firebaseRetriever.GetPerson(StudentID);
            if (firebaseRetriever.StudentFound)
            {
                return "Student ID found";
            }
            else
            {
                return "Student not found";
            }
            
        }
    }
}
