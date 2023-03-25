using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Assignment_5.Classes
{
    /// <summary>
    /// Class for managing users
    /// Contains a list for all user's created for the game
    /// Will validate and throw errors if user information is incorrect.
    /// Contains the stats of the user to be updated or returned from the User class
    /// </summary>
    public class clsUserManage
    {
        /// <summary>
        /// List for the user classes
        /// </summary>
        public List<clsUser> lstUsers { get; set; }

        /// <summary>
        /// Constructor
        /// Determines if the name and age passed in is valid, throws an error if not.
        /// </summary>
        /// <param name="fullName"></param>
        /// <param name="age"></param>
        public clsUserManage(string fullName, string age) { 
            lstUsers = new List<clsUser>();

            try 
            {
                if (validateUserInfo(fullName, age)) 
                {
                    int iAge = int.Parse(age);
                    if (3 <= iAge && iAge <= 10)
                    {
                        lstUsers.Add(new clsUser { userFullName = fullName, 
                            userAge = iAge, 
                            userCorrect = 0,
                            userIncorrect = 0, 
                            userTime = "0"});
                    }
                    else
                    {
                        throw new Exception("Age must be a number between 3 and 10.");
                    }
                }  
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        /// <summary>
        /// Method for creating a new user to be added to the list.
        /// </summary>
        /// <param name="fullName"></param>
        /// <param name="age"></param>
        /// <returns></returns>
        public bool CreateNewUser(string fullName, string age)
        {
            try
            {
                validateUserInfo(fullName, age);

                int iAge = int.Parse(age);

                if (3 <= iAge && iAge <= 10)
                {
                    lstUsers.Add(new clsUser { 
                        userFullName = fullName, 
                        userAge = iAge,
                        userCorrect = 0,
                        userIncorrect = 0,
                        userTime = "0"
                    });
                    return true;
                }
                else
                {
                    throw new Exception("Age must be a number between 3 and 10.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Method for validing user information passed in.
        /// Name must not be blank and age will be converting to a number if possible.
        /// </summary>
        /// <param name="fullName"></param>
        /// <param name="age"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool validateUserInfo(string fullName, string age)
        {
            if (fullName != "")
            {
                bool convertAge = Int32.TryParse(age, out int iAge);

                if (convertAge)
                {
                    return true;
                }
                else
                {
                    throw new Exception("Age is not a number.");
                }
            }
            else
            {
                throw new Exception("Name is blank.");
            }
        }
        /// <summary>
        /// Method for updating users Game stats for: answers and completion time
        /// </summary>
        /// <param name="index"></param>
        /// <param name="correct"></param>
        /// <param name="incorrect"></param>
        /// <param name="time"></param>
        public void setUserAnswerStats(int index, int correct, int incorrect, string time)
        {
            try
            {
                lstUsers[index].userCorrect = correct;
                lstUsers[index].userIncorrect = incorrect;
                lstUsers[index].userTime = time;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        /// <summary>
        /// Method for displaying user information as a string.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string DisplayUser(int index)
        {
            string userStats = $"Name: {lstUsers[index].userFullName} \nAge: {lstUsers[index].userAge}" +
                $"\nAnswers Correct: {lstUsers[index].userCorrect} \nAnswers Incorrect: {lstUsers[index].userIncorrect}" +
                $"\nTime to Finish: {lstUsers[index].userTime} seconds";

            return userStats;
        }
    }
}
