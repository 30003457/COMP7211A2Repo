using System.Threading.Tasks;
// Code by Lewis Evans 27033957
namespace COMP7211Assignment2.Model_Folder
{
    internal class ValidateLoginData
    {
        private StudentLoginFirebaseRetriever firebaseRetriever = new StudentLoginFirebaseRetriever();

        public async Task<bool> ValidatePasswordStatus(string passwordEmpty, string StudentID)
        {
            Student emptyPassword = await firebaseRetriever.CheckPasswordIsSet(passwordEmpty, StudentID);
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
            Student student = await firebaseRetriever.RetrieveStudentID(StudentIDEntryText);
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

            Student password = await firebaseRetriever.RetrievePassword(passwordEntryText, studentID);

            if (password != null)
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
