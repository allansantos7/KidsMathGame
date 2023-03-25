using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5.Classes
{
    /// <summary>
    /// User class
    /// </summary>
    public class clsUser
    {
        /// <summary>
        /// User's full name
        /// </summary>
        public string userFullName { get; set; }

        /// <summary>
        /// User's age
        /// </summary>
        public int userAge { get; set; }
        
        /// <summary>
        /// User's number of correct Answers
        /// </summary>
        public int userCorrect { get; set; }

        /// <summary>
        /// User's number of incorrect Answers
        /// </summary>
        public int userIncorrect { get; set; }

        /// <summary>
        /// User's time to complete game
        /// </summary>
        public string userTime { get; set; }
    }
}
