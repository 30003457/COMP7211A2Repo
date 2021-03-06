﻿using COMP7211Assignment2.Model_Folder;

namespace COMP7211Assignment2.Controller_Folder
{
    internal class Validator
    {
        private readonly string digits = "0123456789";
        public string errorMsg = null;
        public bool ValidateLogin(string username, string password)
        {
            User matchingUser = null;
            //*** username
            //cannot be empty
            if (string.IsNullOrEmpty(username) == false)
            {
                //8 digits - assumption based on the average student id's
                if (username.Length >= 8)
                {
                    for (int i = 0; i < username.Length; i++)
                    {
                        //must be only numbers
                        if (digits.Contains(username[i].ToString()) == false)
                        {
                            errorMsg = "The student ID must be numbers only!";
                            return false;
                        }
                    }

                    //username is all numbers
                    foreach (User item in PageData.PManager.UserRecords)
                    {
                        if (item.StudentID.ToString("00000000") == username)
                        {
                            matchingUser = item;
                        }
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
                //check existing database
                foreach (User item in PageData.PManager.UserRecords)
                {
                    //check it matches or if it exists
                    //if this is true then it is a successful login
                    if (password == item.Password)
                    {
                        if (matchingUser != null)
                        {
                            LoginSystem.LoggedInUser = matchingUser;
                            return true;
                        }
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
            return false;
        }
    }
}
