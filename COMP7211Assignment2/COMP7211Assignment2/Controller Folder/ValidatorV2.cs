using COMP7211Assignment2.Model_Folder;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace COMP7211Assignment2.Controller_Folder
{
    //code by Min 30003457
    class ValidatorV2
    {
        string digits = "0123456789";
        public string errorMsg = null;
        public async Task<bool> ValidateLogin(string studentId, string password)
        {
            User matchingUser = null;
            User dbUser;
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

                    int studentIdInt = Convert.ToInt32(studentId);
                    dbUser = await PageData.PManager.FBHelper.GetUser(studentIdInt);

                    //username is all numbers
                    if (dbUser != null)
                    {
                        matchingUser = dbUser;
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

        public bool ValidateNewPassword(string password)
        {
            //first ever login
            //15 characters like toi ohomai passwords?
            //all characters allowed
            //at least 1 digit and 1 letter
            //NYI
            return false;
        }
    }
}
