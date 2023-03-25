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
using System.Windows.Threading;

namespace Assignment_5.Windows
{
    /// <summary>
    /// Game Class window
    /// Displays 10 questions to the user and receives 10 answers in response.
    /// Displays feedback on whether the user got any of the questions wrong.
    /// Displays final score window when finished.
    /// </summary>
    public partial class GameWindow : Window
    {
        /// <summary>
        /// Variable for Background music.
        /// </summary>
        SoundPlayer bgSound2 = new SoundPlayer("sw_song2.wav");
        /// <summary>
        /// Variable for when the last question is answered.
        /// </summary>
        SoundPlayer beginSound = new SoundPlayer("sw_sound1.wav");
        /// <summary>
        /// Variable for User manager class passed from main menu window
        /// </summary>
        clsUserManage newManage;
        /// <summary>
        /// Variable for Game class passed from main menu window
        /// </summary>
        clsGame newGame;
        /// <summary>
        /// Variable for Score window
        /// </summary>
        ScoreWindow scoreWindow;
        /// <summary>
        /// Variable for User's time to complete the game.
        /// </summary>
        string userTime;
        /// <summary>
        /// Variable to be used to determine the timer in seconds as an integer.
        /// </summary>
        int timeInSeconds;
        /// <summary>
        /// Variable to be used to determine the timer in seconds as a double.
        /// </summary>
        double timeDiff;
        /// <summary>
        /// Variable to be used to determine the amount of time that has passed from the timer start.
        /// </summary>
        TimeSpan timeSpan;
        /// <summary>
        /// Variable for the initial start timer.
        /// </summary>
        DateTime startTimer;
        /// <summary>
        /// Variable for the timer.
        /// </summary>
        DispatcherTimer timer;

        /// <summary>
        /// Constructor
        /// </summary>
        public GameWindow()
        {
            InitializeComponent();
            //Instantiate the DispatcherTimer
            timer = new DispatcherTimer();
            //Make the timer go off every second
            timer.Interval = TimeSpan.FromSeconds(1);
            //Tell it which method will handle the click event
            timer.Tick += new EventHandler(Timer_Tick);
        }
        /// <summary>
        /// Method for passing in the Game class
        /// </summary>
        public clsGame SetGame
        {
            set
            {
                newGame = value;
                lblGameTitle.Content = newGame.gameType;
            }
        }
        /// <summary>
        /// Method for passing in the User Manager class
        /// </summary>
        public clsUserManage SetUserManage
        {
            set
            {
                newManage = value;
            }
        }

        /// <summary>
        /// Goes off when the timer ticks
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                timeSpan = (DateTime.Now - startTimer);
                timeDiff = timeSpan.TotalSeconds;
                timeInSeconds = (int)timeDiff;
                lblTimer.Content = timeInSeconds;
            }
            catch (Exception ex) 
            {
                lblError.Content = ex.Message;
            }
        }
        /// <summary>
        /// Method for the Start button
        /// When clicked, timer starts for the game.
        /// The start button is then hidden, the textbox and submit button becomes visible
        /// A question is then generated to the user.
        /// Background music will play.
        /// Any errors will display with the appropriate label.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                startTimer = DateTime.Now;
                timer.Start();
                btnStart.Visibility = Visibility.Hidden;
                btnSubmit.Visibility = Visibility.Visible;
                txtAnswer.Visibility = Visibility.Visible;

                bgSound2.Play();

                lblQuestion.Content = newGame.generateQuestion();
            }
            catch (Exception ex)
            {
                lblError.Content = ex.Message;
            }
        }
        /// <summary>
        /// Method for the Submit button.
        /// This will submit the user's answer in the textbox and will generate an appropriate response in the label.
        /// Game continues if all 10 questions have not been answered yet.
        /// When game ends, will stop timer and display Final score window.
        /// Any errors will display in the appropriate label.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                lblFeedback.Content = newGame.generateAnswer(txtAnswer.Text);
                txtAnswer.Text = "";

                if (newGame.gameContinue())
                {
                    lblQuestion.Content = newGame.generateQuestion();
                }
                else
                {
                    Timer_End();

                    beginSound.PlaySync();

                    scoreWindow = new ScoreWindow();
                    scoreWindow.SetUserManage = newManage;
                    scoreWindow.displayScore();

                    // Hide game menu
                    this.Hide();
                    // Show Final Score window
                    scoreWindow.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                lblError.Content = ex.Message;
            }
            
        }
        /// <summary>
        /// Method for when the user presses enter in the textbox.
        /// Will act exactly as if the user clicked the submit button.
        /// Calls the submit button press method.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                btnSubmit_Click(sender, e);
            }
        }
        /// <summary>
        /// Method for ending the timer.
        /// </summary>
        public void Timer_End()
        {
            userTime = timeInSeconds.ToString();
            timer.Stop();
            newManage.setUserAnswerStats(0, newGame.returnCorrect(), newGame.returnWrong(), userTime);
        }

        /// <summary>
        /// Does nothing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAnswer_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
