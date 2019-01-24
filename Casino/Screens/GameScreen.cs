using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameSystemServices;
using System.Media;

namespace Casino
{

    public partial class GameScreen : UserControl
    {
        Random randGen = new Random();
        int valuesInt;
        int numbersInt;
        string suitString;
        int limit = 52;
        int playerTotal =0;
        int dealerTotal=0;
        int money = 50;
        int chipTotal = 0;
       

        List<int> cardValues = new List<int>(new int[] {1,2,3,4,5,6,7,8,9,10,10,10,10,
                                                  1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10 ,
                                                  1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10 ,
                                                  1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10 });
        List<int> cardNumber = new List<int>(new int[] {1,2,3,4,5,6,7,8,9,10,11,12,13,
                                                         14, 15, 16, 17, 18, 19, 20, 21, 22, 23,24, 25,26
                                                         ,27,28,29,30,31,32,33, 34,35,36,37,38,39,
                                                             40,41,42,43,44,45,46,47,48,49,50,51,52 });
       /* List<string> cards = new List<string>(new string[]{"H", "H", "H", "H", "H", "H", "H", "H", "H", "H", "H", "H", "H",
                                                           "D", "D", "D", "D", "D", "D", "D", "D", "D", "D", "D", "D", "D",
                                                           "S", "S", "S", "S", "S", "S", "S", "S", "S", "S", "S", "S", "S",
                                                           "C","C","C","C","C","C","C","C","C","C","C","C","C"}); */
        List<int> playerHand = new List<int>(new int[] { });
        List<int> dealerHand = new List<int>(new int[] { });



        /*  List<int> cardvaluesUsed = new List<int>();
          List<int> cardnumbersUsed = new List<int>();
          List<string> cardsUsed = new List<string>(); */
        //player1 button control keys - DO NOT CHANGE
        Boolean leftArrowDown, downArrowDown, rightArrowDown, upArrowDown, bDown, nDown, mDown, spaceDown;

        //player2 button control keys - DO NOT CHANGE
        Boolean aDown, sDown, dDown, wDown, cDown, vDown, xDown, zDown;

        private void GameScreen_Paint_1(object sender, PaintEventArgs e)
        {
            //imagePicker();
        }

        private void stayButton_Click(object sender, EventArgs e)
        {  
            while (dealerTotal < 17)
            {
                int rand = randGen.Next(0, cardNumber.Count());
                numbersInt = cardNumber[rand];
                valuesInt = cardValues[rand];
                dealerHand.Add(numbersInt);
                cardValues.RemoveAt(rand);
                cardNumber.RemoveAt(rand);
                imagePickerD();
                dealerTotal = dealerTotal + valuesInt;
                dealertotalLabel1.Text = dealerTotal + "";
                System.Threading.Thread.Sleep(500);

            }
            if (playerTotal > dealerTotal || dealerTotal > 21)
            {
                chipTotal = chipTotal * 2;
                money = money + chipTotal;          
            }
            else if (playerTotal == dealerTotal)
            {
                money = money + chipTotal;
  
            }
            else if (playerTotal < dealerTotal)
            {
                money = money - chipTotal;
            }
            null1();
            playerHand.Clear();
            dealerHand.Clear();
            playerTotal = 0;
            dealerTotal = 0;
            chipTotal = 0;
            moneyLabel.Text = money + "";
            yourbetLabel.Text = "0";
            System.Threading.Thread.Sleep(500);
            // new code trying to get stay button to work how it should

        }


        private void bet10Button_Click(object sender, EventArgs e)
        {
            if (money > 9)
            {
                chipTotal = chipTotal + 10;
                money = money - 10;
                yourbetLabel.Text = chipTotal + "";
                moneyLabel.Text = money + "";
            }
        }

        private void bet5Button_Click(object sender, EventArgs e)
        {
            if (money > 4)
            {
                chipTotal = chipTotal + 5;
                money = money - 5;
                yourbetLabel.Text = chipTotal + "";
                moneyLabel.Text = money + "";
            }
        }

        private void betButton_Click(object sender, EventArgs e)
        {
            bet5Button.Visible = true;
            bet10Button.Visible = true;
        }

        private void cardButton_Click(object sender, EventArgs e)
        {
            //create graphics object g
            //g.DrawImage(img, X, Y, width, height);
            //Graphics b = this.CreateGraphics();
            betButton.Visible = true;

            //value used to pull random card. rand=indexOf(card)
            int rand = randGen.Next(0, cardNumber.Count());
           
            numbersInt = cardNumber[rand];
            valuesInt = cardValues[rand];
           // suitString = cards[rand];

            playerTotal = playerTotal + valuesInt;
            scoreLabel.Text = playerTotal + "";
                  
            playerHand.Add(numbersInt);     
            cardValues.RemoveAt(rand);
            cardNumber.RemoveAt(rand);
            //cards.RemoveAt(rand);
            //limit--;

            imagePicker();
            //Refresh();
            if (playerTotal > 21)
            {
               // money = money - chipTotal;
                moneyLabel.Text = money + "";
                playerTotal = 0;
                null1();
                playerHand.Clear();
                chipTotal = 0;
                yourbetLabel.Text = "0";
                /*cardNumber.Clear();
                cardValues.Clear();
                cardValues = new List<int>(new int[] {1,2,3,4,5,6,7,8,9,10,10,10,10,
                                                  1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10 ,
                                                  1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10 ,
                                                  1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10 });
                cardNumber = new List<int>(new int[] {1,2,3,4,5,6,7,8,9,10,11,12,13,
                                                         14, 15, 16, 17, 18, 19, 20, 21, 22, 23,24, 25,26
                                                         ,27,28,29,30,31,32,33, 34,35,36,37,38,39,
                                                             40,41,42,43,44,45,46,47,48,49,50,51,52 });*/
            }
            else if (playerTotal == 21)
            {
                chipTotal = chipTotal * 2;
                money = money + chipTotal;
                playerHand.Clear();
                playerTotal = 0;
                null1();
                yourbetLabel.Text = "0";
            }
        }
        private void null1()
        {
            card1P.BackgroundImage = null;
            card2P.BackgroundImage = null;
            card3P.BackgroundImage = null;
            card4P.BackgroundImage = null;
            card5P.BackgroundImage = null;
            card1D.BackgroundImage = null;
            card2D.BackgroundImage = null;
            card3D.BackgroundImage = null;
            card4D.BackgroundImage = null;
            card5D.BackgroundImage = null;
        }
        private void cardPicker ()
        {        
            switch (valuesInt)
            {
                case 1:
                    //  Properties.Resources.AH(;
                 // .BackgroundImage = Properties.Resources.AH;
                    break;
                case 2:

                    break;
                case 3:

                    break;
                case 4:

                    break;
                case 5:

                    break;
                case 6:

                    break;
                case 7:

                    break;
                case 8:

                    break;
                case 9:

                    break;
                case 10:

                    break;
                case 11:

                    break;
                case 12:

                    break;
                case 13:

                    break;
                case 14:

                    break;
                case 15:

                    break;
                case 16:

                    break;
                case 17:

                    break;
                case 18:

                    break;
                case 19:

                    break;
                case 20:

                    break;
                case 21:

                    break;
                case 22:

                    break;
                case 23:

                    break;
                case 24:

                    break;
                case 25:

                    break;
                case 26:

                    break;
                case 27:

                    break;
                case 28:

                    break;
                case 29:

                    break;
                case 30:

                    break;
                case 31:

                    break;
                case 32:

                    break;
                case 33:

                    break;
                case 34:

                    break;
                case 35:

                    break;
                case 36:

                    break;
                case 37:

                    break;
                case 38:

                    break;
                case 39:

                    break;
                case 40:

                    break;
                case 41:

                    break;
                case 42:

                    break;
                case 43:

                    break;
                case 44:

                    break;
                case 45:

                    break;
                case 46:

                    break;
                case 47:

                    break;
                case 48:

                    break;
                case 49:

                    break;
                case 50:

                    break;
                case 51:

                    break;
                case 52:

                    break;
            }
        }

        private void imagePickerD()
        {
            foreach (int c in dealerHand)
            {
                int x = dealerHand.IndexOf(c);
                x++;
                string card = "" + c;
                var img = (Image)Properties.Resources.ResourceManager.GetObject(card);
                switch (x)
                {
                    case 1:
                        card1D.BackgroundImage = img;
                        break;
                    case 2:
                        card2D.BackgroundImage = img;
                        break;

                    case 3:
                        card3D.BackgroundImage = img;
                        break;

                    case 4:
                        card4D.BackgroundImage = img;
                        break;

                    case 5:
                        card5D.BackgroundImage = img;
                        break;
                }
            }
            Refresh();
        }
        private void imagePicker ()
        {
            foreach (int c in playerHand)
            {
                int x = playerHand.IndexOf(c);
                x++;
                string card = "" + c;
                var img = (Image)Properties.Resources.ResourceManager.GetObject(card);
                switch (x)
                {
                    case 1:     
                        card1P.BackgroundImage = img;
                        break;
                    case 2:
                        card2P.BackgroundImage = img;
                        break;

                    case 3:
                        card3P.BackgroundImage = img;
                        break;

                    case 4:
                        card4P.BackgroundImage = img;
                        break;

                    case 5:
                        card5P.BackgroundImage = img;
                        break;
                }
            }
            Refresh();
        }

        //TODO create your global game variables here
        int heroX, heroY, heroSize, heroSpeed;
        SolidBrush heroBrush = new SolidBrush(Color.Black);

        public GameScreen()
        {
            InitializeComponent();
            InitializeGameValues();
            cardButton.PerformClick();
            cardButton.PerformClick();
            chipTotal = chipTotal + 3;        
            yourbetLabel.Text = chipTotal + "";
           

        }

        public void InitializeGameValues()
        {
            //TODO - setup all your initial game values here. Use this method
            // each time you restart your game to reset all values.
            heroX = 100;
            heroY = 100;
            heroSize = 20;
            heroSpeed = 5;
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            // opens a pause screen is escape is pressed. Depending on what is pressed
            // on pause screen the program will either continue or exit to main menu
            if (e.KeyCode == Keys.Escape && gameTimer.Enabled)
            {
                gameTimer.Enabled = false;
                rightArrowDown = leftArrowDown = upArrowDown = downArrowDown = false;

                DialogResult result = PauseForm.Show();

                if (result == DialogResult.Cancel)
                {
                    gameTimer.Enabled = true;
                }
                else if (result == DialogResult.Abort)
                {
                    MainForm.ChangeScreen(this, "MenuScreen");
                }
            }

            //TODO - basic player 1 key down bools set below. Add remainging key down
            // required for player 1 or player 2 here.

            //player 1 button presses
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Space:
                    spaceDown = true;
                    break;
                case Keys.M:
                    mDown = true;
                    break;
            }
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            //TODO - basic player 1 key up bools set below. Add remainging key up
            // required for player 1 or player 2 here.

            //player 1 button releases
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
            }
        }

        /// <summary>
        /// This is the Game Engine and repeats on each interval of the timer. For example
        /// if the interval is set to 16 then it will run each 16ms or approx. 50 times
        /// per second
        /// </summary>
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //TODO move main character 
            if (leftArrowDown == true)
            {
                heroX = heroX - heroSpeed;
            }
            if (downArrowDown == true)
            {
                heroY = heroY + heroSpeed;
            }
            if (rightArrowDown == true)
            {
                heroX = heroX + heroSpeed;
            }
            if (upArrowDown == true)
            {
                heroY = heroY - heroSpeed;
            }

            //TODO move npc characters


            //TODO collisions checks 


            //calls the GameScreen_Paint method to draw the screen.
            Refresh();
        }


        //Everything that is to be drawn on the screen should be done here
        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            //draw rectangle to screen
            e.Graphics.FillRectangle(heroBrush, heroX, heroY, heroSize, heroSize);
        }
    }

}
