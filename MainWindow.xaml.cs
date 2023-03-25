using Assignment_5.Classes;
using Assignment_5.Windows;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Assignment_5
{
    /// <summary>
    /// Main Menu window class.
    /// Main menu for the Math game.
    /// Displays ui for the user to input their information and type of game they want to play.
    /// Displays error for any invalid input.
    /// Opens Game window if all input is valid.
    /// Plays background music normally and sound for any errors.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Variable for the background music.
        /// </summary>
        SoundPlayer bgSound = new SoundPlayer("sw_song.wav");
        /// <summary>
        /// Variable for error sound.
        /// </summary>
        SoundPlayer errorSound = new SoundPlayer("wookie.wav");
        /// <summary>
        /// Declaration of User manage class
        /// </summary>
        clsUserManage newManage;
        /// <summary>
        /// Declaration of Game class
        /// </summary>
        clsGame newGame;
        /// <summary>
        /// Variable for the type of class the user has selected.
        /// </summary>
        int gameType = 0;
        /// <summary>
        /// Game window declaration
        /// </summary>
        GameWindow gameWindow;

        /// <summary>
        /// constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;

            bgSound.Play();
        }
        /// <summary>
        /// Method for clearing error labels.
        /// </summary>
        private void clearLabels()
        {
            lblInfoError.Content = "";
        }
        /// <summary>
        /// Method for the Game Start Button
        /// Validates user input for their Information: name, age, game typea
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGameStart_Click(object sender, RoutedEventArgs e)
        {
            clearLabels();
            try
            {
                newManage = new clsUserManage(txtUserName.Text, txtUserAge.Text);
                newGame = new clsGame(gameType);


                gameWindow = new GameWindow();
                gameWindow.SetGame = newGame;
                gameWindow.SetUserManage  = newManage;

                // Hide main menu
                this.Hide();
                // Show Game window
                gameWindow.ShowDialog();
                // show main menu
                this.Show();
                bgSound.Play();
            }
            catch (Exception ex)
            {
                errorSound.Play();
                lblInfoError.Content = ex.Message;
            }
        }
        /// <summary>
        /// Method for updating the Game type the user has selected to Addition
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnAdd_Checked(object sender, RoutedEventArgs e)
        {
            gameType = 1;
        }
        /// <summary>
        /// Method for updating the Game type the user has selected to Subtraction
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnSubtract_Checked(object sender, RoutedEventArgs e)
        {
            gameType = 2;
        }
        /// <summary>
        /// Method for updating the Game type the user has selected to Multiplication
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnMultiply_Checked(object sender, RoutedEventArgs e)
        {
            gameType = 3;
        }
        /// <summary>
        /// Method for updating the Game type the user has selected to Division
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnDivide_Checked(object sender, RoutedEventArgs e)
        {
            gameType = 4;
        }

        /// <summary>
        /// Does nothing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUserName_TextChanged(object sender, TextChangedEventArgs e)
        {
        }
    }
}
