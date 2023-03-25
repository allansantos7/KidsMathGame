using Assignment_5.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Assignment_5.Windows
{
    /// <summary>
    /// Score Window class
    /// Displays the score to the user
    /// Taking information passed from the User class
    /// </summary>
    public partial class ScoreWindow : Window
    {
        /// <summary>
        /// Variable for the background music
        /// </summary>
        SoundPlayer bgSound3 = new SoundPlayer("sw_song3.wav");
        /// <summary>
        /// User Manage class passed in from game menu
        /// </summary>
        clsUserManage newManage;
        
        /// <summary>
        /// Constructor
        /// </summary>
        public ScoreWindow()
        {
            InitializeComponent();
            rtxtFinalScore.Document.Blocks.Clear();
            bgSound3.Play();
        }
        /// <summary>
        /// Method for displaying the score
        /// </summary>
        public void displayScore()
        {
            try
            {
                string scoreDisplay;
                scoreDisplay = newManage.DisplayUser(0);
                rtxtFinalScore.AppendText(scoreDisplay);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Method for passing in the User manage class from the Game menu
        /// </summary>
        public clsUserManage SetUserManage
        {
            set
            {
                newManage = value;
            }
        } 
    }
}
