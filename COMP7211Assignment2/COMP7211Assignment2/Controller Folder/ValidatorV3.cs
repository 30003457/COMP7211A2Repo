using COMP7211Assignment2.Model_Folder;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace COMP7211Assignment2.Controller_Folder
{
    //code by Min 30003457 and Lewis
    internal class ValidatorV3
    {
        private readonly string digits = "0123456789";
        public string errorMsg = null;
        private User matchingUser = null;
        private User dbUser;
        private int studentIdInt = 0;
        public async Task<bool> ValidateUser(string studentId)
        {
            //*** username
            //cannot be empty
            if (string.IsNullOrEmpty(studentId) == false)
            {
                //8 digits - assumption based on the average student id's
                if (studentId.Length >= 8)
                {
                    for (int i = 0; i < studentId.Length; i++)
                    {
                        //must be only numbers
                        if (digits.Contains(studentId[i].ToString()) == false)
                        {
                            errorMsg = "The student ID must be numbers only!";
                            return false;
                        }
                    }

                    studentIdInt = Convert.ToInt32(studentId);
                    dbUser = await PageData.PManager.FBHelper.GetUser(studentIdInt);

                    //username is all numbers
                    if (dbUser != null)
                    {
                        matchingUser = dbUser;
                        return true;
                    }
                    else
                    {
                        errorMsg = "Student ID cannot be blank!";
                        return false;
                    }

                }
                else
                {
                    errorMsg = "Student ID must be 8 digits or more!";
                    return false;
                }
            }
            else
            {
                errorMsg = "Student ID cannot be blank!";
                return false;
            }
        }

        public bool CheckFirstLogin()
        {
            if (string.IsNullOrEmpty(dbUser.Password) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ValidatePassword(string password)
        {
            //*** password
            if (string.IsNullOrEmpty(password) == false)
            {
                //check it matches or if it exists
                //if this is true then it is a successful login
                if (password == dbUser.Password)
                {
                    if (matchingUser != null)
                    {
                        LoginSystem.LoggedInUser = matchingUser;
                        return true;
                    }
                }


                if (matchingUser == null)
                {
                    errorMsg = "Student not found!";
                    return false;
                }
                else
                {
                    errorMsg = "Invalid password!";
                    return false;
                }

            }
            else
            {
                errorMsg = "Password cannot be blank!";
                return false;
            }
        }



        public async Task<bool> ValidateNewPassword(string password1, string password2, int _studentIdInt)
        {
            //all characters allowed
            //at least 1 digit and 1 letter
            //NYI
            //first ever login
            //15 characters like toi ohomai passwords?

            if (password1 == null || password2 == null)
            {
                errorMsg = "Both passwords cannot blank!";
                return false;
            }
            else if (password1 != password2)
            {
                errorMsg = "Both passwords must match";
                return false;
            }
            else if (password1 == password2)
            {
                if (password1.Length >= 15)
                {
                    if (password1.Any(char.IsLetter) && password1.Any(char.IsDigit))
                    {
                        //LoginSystem.LoggedInUser = dbUser;
                        PageData.PManager.FBHelper.SetPassword(_studentIdInt, password1);
                        return true;
                    }
                    else
                    {
                        errorMsg = "The password must contain at least 1 letter and 1 digit";
                        return false;
                    }
                }
                else
                {
                    errorMsg = "Password must be 15 or more characters";
                    return false;
                }
            }
            return false;
        }
    }
}
