using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Assignment_5.Classes
{ 
    /// <summary>
    /// Game class
    /// Class contains methods for determing:
    /// The type of game, questions and answers that will display to the user
    /// </summary>
    public class clsGame
    {
        /// <summary>
        /// Variable for generating a random integer.
        /// </summary>
        Random rand;
        /// <summary>
        /// Variable for the first randomly generated integer.
        /// </summary>
        int firstNum;
        /// <summary>
        /// Variable for the second randomly generated integer.
        /// </summary>
        int secondNum;
        /// <summary>
        /// Variable for the answer integer.
        /// </summary>
        int answer;
        /// <summary>
        /// Variable for operator displayed in the question.
        /// </summary>
        string sOperator;
        /// <summary>
        /// Variable holds the amount of correct answers from the user.
        /// </summary>
        int correctNum = 0;
        /// <summary>
        /// Variable for the amount of incorrect answers from the user.
        /// </summary>
        int wrongNum = 0;
        /// <summary>
        /// Variable for the current question displayed to the user.
        /// </summary>
        int questionNum = 1;
        /// <summary>
        /// Enum for the current type of the game user selected.
        /// </summary>
        public enum GameType
        {
            Add = 1 ,
            Subtract = 2,
            Multiply = 3,
            Divide = 4,
        }
        /// <summary>
        /// Variable for the current type of game user selected.
        /// </summary>
        public GameType gameType { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="currentType"></param>
        public clsGame(int currentType) { 
            try
            {
                if (validateType(currentType))
                {
                    gameType = (GameType)currentType;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Method for validating the user selected game type.
        /// Throws an exeception if invalid.
        /// </summary>
        /// <param name="currentType"></param>
        /// <returns></returns>
        public bool validateType(int currentType)
        {
            try
            {
                if (1 <= currentType && currentType <= 4)
                {
                    return true;
                }
                else
                {
                    throw new Exception("Select a Game Type.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Method for generating a question to the user.
        /// Depending on the game type, will display an appropriate question.
        /// Throws an exception if it occurs.
        /// </summary>
        /// <returns></returns>
        public string generateQuestion()
        {
            try
            {
                rand = new Random();

                switch (gameType)
                {
                    case GameType.Add:
                        addType();
                        break;
                    case GameType.Subtract:
                        subtractType();
                        break;
                    case GameType.Multiply:
                        multiplyType();
                        break;
                    case GameType.Divide:
                        divideType();
                        break;
                    default: 
                        throw new Exception("No Game Type Selected.");
                }
                return $"Question {questionNum}: What does {firstNum} {sOperator} {secondNum} equal?";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Method for determing the addition question variables.
        /// Generates a random number for each operand between 1-10
        /// Sets the operator string to the appropriate symbol
        /// </summary>
        public void addType()
        {
            try
            {
                sOperator = "+";
                firstNum = rand.Next(1, 10);
                secondNum = rand.Next(1, 10);
                answer = firstNum + secondNum;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        /// <summary>
        /// Method for determing the subtraction question variables.
        /// Generates a random number for each operand between 1-10
        /// First operand will always be equal or greater than second operand to prevent negative numbers as answers
        /// Sets the operator string to the appropriate symbol
        /// </summary>
        public void subtractType()
        {
            try
            {
                sOperator = "-";

                do
                {
                    firstNum = rand.Next(1, 10);
                    secondNum = rand.Next(1, 10);
                } while (firstNum - secondNum < 0);

                answer = firstNum - secondNum;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Method for determing the multiplication question variables.
        /// Generates a random number for each operand between 1-10
        /// Sets the operator string to the appropriate symbol
        /// </summary>
        public void multiplyType()
        {
            try
            {
                sOperator = "*";
                firstNum = rand.Next(1, 10);
                secondNum = rand.Next(1, 10);
                answer = firstNum * secondNum;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Method for determing the division question variables.
        /// Generates a random number for each operator between 1-10
        /// Ensures second operand divides evenly into first to prevent decimals
        /// Sets the operator string to the appropriate symbol
        /// </summary>
        public void divideType()
        {
            try
            {
                sOperator = "/";

                firstNum = rand.Next(1, 10);
                secondNum = rand.Next(1, 10);

                int temp = firstNum;
                firstNum = firstNum * secondNum;
                answer = secondNum;
                secondNum = temp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Method determines if the user's answer matches the correct answer.
        /// Generates an appropriate responds to the user's answer passed in.
        /// Increments correct or incorrect variables depending on the result.
        /// </summary>
        /// <param name="userAnswer"></param>
        /// <returns></returns>
        public string generateAnswer(string userAnswer)
        {
            try
            {
                if (Int32.TryParse(userAnswer, out int iAnswer)) {
                    if (answer == iAnswer)
                    {
                        correctNum++;
                        return "Correct!";
                    }
                    else
                    {
                        wrongNum++;
                        return "Sorry, your Answer was Incorrect.";
                    }
                }
                else
                {
                    wrongNum++;
                    return "Sorry, your Answer was Incorrect.";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Method determines if the game will continue.
        /// If all 10 questions have been displayed and answered, returns false
        /// </summary>
        /// <returns></returns>
        public bool gameContinue()
        {
            try
            {
                questionNum++;

                if (questionNum > 10)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Method for returning the correct amount of user answers
        /// </summary>
        /// <returns></returns>
        public int returnCorrect()
        {
            return correctNum;
        }
        /// <summary>
        /// Method for returning the incorrect amount of user answers
        /// </summary>
        /// <returns></returns>
        public int returnWrong()
        {
            return wrongNum;
        }
    }
}
