using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RollTheDice
{
    public partial class TableTop : Form
    {

        bool currentTurn = false;
        bool testing = false;
        Random rnd = new Random();
        private Point MouseDownLocation;
        private Point MouseDownOriginalLocation;
        Dice[] arrayOfDice = new Dice[6];
        Deck deckOfCards = new Deck();
        bool blackCanRoll = true;
        int blackRolls = 0;
        bool endTurn = true;

        String turn = "black";   
            

        int blackPoints = 0;
        int redPoints = 0;
        int bluePoints = 0;
        int yellowPoints = 0;

        //Y coordinates for the dice holders below the cards
        public static int YSPOT1 = 341;
        public static int YSPOT2 = 387;
        public static int YSPOT3 = 433;
        public static int YSPOT4 = 479;
        public static int YSPOT5 = 525;
        public static int YSPOT6 = 571;

        //players black dice
        Dice dice1 = new Dice(1, 7, new Point(264, 646), "Black", "blackDice1");
        Dice dice2 = new Dice(1, 7, new Point(310, 646), "Black", "blackDice2");
        Dice dice3 = new Dice(1, 7, new Point(356, 646), "Black", "blackDice3");
        Dice dice4 = new Dice(1, 7, new Point(400, 646), "Black", "blackDice4");
        Dice dice5 = new Dice(1, 7, new Point(446, 646), "Black", "blackDice5");
        Dice dice6 = new Dice(1, 7, new Point(491, 646), "Black", "blackDice6");

        Dice blueDice1 = new Dice(1, 7, new Point(0, 199), "Blue", "blueDice1");
        Dice blueDice2 = new Dice(1, 7, new Point(0, 242), "Blue", "blueDice2");
        Dice blueDice3 = new Dice(1, 7, new Point(0, 285), "Blue", "blueDice3");
        Dice blueDice4 = new Dice(1, 7, new Point(0, 328), "Blue", "blueDice4");
        Dice blueDice5 = new Dice(1, 7, new Point(0, 371), "Blue", "blueDice5");
        Dice blueDice6 = new Dice(1, 7, new Point(0, 414), "Blue", "blueDice6");

        Dice redDice1 = new Dice(1, 7, new Point(233, 64), "Red", "redDice1");
        Dice redDice2 = new Dice(1, 7, new Point(279, 64), "Red", "redDice2");
        Dice redDice3 = new Dice(1, 7, new Point(321, 64), "Red", "redDice3");
        Dice redDice4 = new Dice(1, 7, new Point(367, 64), "Red", "redDice4");
        Dice redDice5 = new Dice(1, 7, new Point(413, 63), "Red", "redDice5");
        Dice redDice6 = new Dice(1, 7, new Point(459, 63), "Red", "redDice6");

        Dice yellowDice1 = new Dice(1, 7, new Point(752, 199), "Yellow", "yellowDice1");
        Dice yellowDice2 = new Dice(1, 7, new Point(752, 242), "Yellow", "yellowDice2");
        Dice yellowDice3 = new Dice(1, 7, new Point(752, 285), "Yellow", "yellowDice3");
        Dice yellowDice4 = new Dice(1, 7, new Point(752, 328), "Yellow", "yellowDice4");
        Dice yellowDice5 = new Dice(1, 7, new Point(752, 371), "Yellow", "yellowDice5");
        Dice yellowDice6 = new Dice(1, 7, new Point(752, 414), "Yellow", "yellowDice6");



        Card c1;
        Card c2;
        Card c3;


        DiceHolder black1;
        DiceHolder black2;
        DiceHolder black3;
        DiceHolder red1;
        DiceHolder red2;
        DiceHolder red3;
        DiceHolder blue1;
        DiceHolder blue2;
        DiceHolder blue3;
        DiceHolder yellow1;
        DiceHolder yellow2;
        DiceHolder yellow3;

        public TableTop()
        {
            InitializeComponent();

            timer1.Interval = 1000;
            timer1.Start();

            arrayOfDice[0] = dice1;
            arrayOfDice[1] = dice2;
            arrayOfDice[2] = dice3;
            arrayOfDice[3] = dice4;
            arrayOfDice[4] = dice5;
            arrayOfDice[5] = dice6;

            c1 = deckOfCards.drawCard();
            c2 = deckOfCards.drawCard();
            c3 = deckOfCards.drawCard();

            c1.location = 1;
            c2.location = 2;
            c3.location = 3;

            Card1.Image = cardImage(c1.image);
            Card2.Image = cardImage(c2.image);
            Card3.Image = cardImage(c3.image);

            black1 = new DiceHolder("Black", 1, new Point(67, 341), c1);
            black2 = new DiceHolder("Black", 2, new Point(304, 341), c2);
            black3 = new DiceHolder("Black", 3, new Point(542, 341), c3);

            blue1 = new DiceHolder("Blue", 1, new Point(110, 341), c1);
            blue2 = new DiceHolder("Blue", 2, new Point(347, 341), c2);
            blue3 = new DiceHolder("Blue", 3, new Point(585, 341), c3);

            red1 = new DiceHolder("Red", 1, new Point(153, 341), c1);
            red2 = new DiceHolder("Red", 2, new Point(390, 341), c2);
            red3 = new DiceHolder("Red", 3, new Point(628, 341), c3);

            yellow1 = new DiceHolder("Yellow", 1, new Point(196, 341), c1);
            yellow2 = new DiceHolder("Yellow", 2, new Point(433, 341), c2);
            yellow3 = new DiceHolder("Yellow", 3, new Point(671, 341), c3);

            buttonEndTurn.Enabled = false;
            
        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        //buttons methods
        private void buttonRoll_Click(object sender, EventArgs e)
        {
            
            if (blackCanRoll && turn =="black")
            {
                blackRolls++;
                blackCanRoll = false;

                dice1.CanMove();
                dice2.CanMove();
                dice3.CanMove();
                dice4.CanMove();
                dice5.CanMove();
                dice6.CanMove();
                dice1.reEnable();
                dice2.reEnable();
                dice3.reEnable();
                dice4.reEnable();
                dice5.reEnable();
                dice6.reEnable();



                if (!dice1.isLocked())
                {
                    dice1.rollDice(rnd);
                    dice1.CanMove();
                }
                if (!dice2.isLocked())
                {
                    dice2.rollDice(rnd);
                    dice2.CanMove();

                }
                if (!dice3.isLocked())
                {
                    dice3.rollDice(rnd);
                    dice3.CanMove();
                }
                if (!dice4.isLocked())
                {
                    dice4.rollDice(rnd);
                    dice4.CanMove();
                }
                if (!dice5.isLocked())
                {
                    dice5.rollDice(rnd);
                    dice5.CanMove();
                }
                if (!dice6.isLocked())
                {
                    dice6.rollDice(rnd);
                    dice6.CanMove();

                }


                blackDice1.Image = diceImage(dice1.getDice(),"black");
                blackDice2.Image = diceImage(dice2.getDice(), "black");
                blackDice3.Image = diceImage(dice3.getDice(), "black");
                blackDice4.Image = diceImage(dice4.getDice(), "black");
                blackDice5.Image = diceImage(dice5.getDice(), "black");
                blackDice6.Image = diceImage(dice6.getDice(), "black");

                endTurn = false;
            }
            buttonRoll.Enabled = false;
            buttonEndTurn.Enabled = true;
        }

        private void buttonEndTurn_Click(object sender, EventArgs e)
        {
            buttonEndTurn.Enabled = false;
            endTurn = true;
            blackCanRoll = true;
            

            if (dice1.getPlace() == "hand")
            {
                dice1.CannotMove();
            }
            if (dice2.getPlace() == "hand")
            {
                dice2.CannotMove(); }
            if (dice3.getPlace() == "hand")
            {
                dice3.CannotMove(); }
            if (dice4.getPlace() == "hand")
            {
                dice4.CannotMove(); }
            if (dice5.getPlace() == "hand")
            {
                dice5.CannotMove(); }
            if (dice6.getPlace() == "hand")
            {
                dice6.CannotMove();
            }
            


            redrawDice();
            
            turn = "blue";

            
            endTurn = false;
            
        }


        //moving the dice methods
        private void mouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {

                try
                {
                    PictureBox pb = (PictureBox)sender;
                    if (getDice(pb).isEnabled())
                    {
                        MouseDownLocation = e.Location;

                        //Find where on the form the object is and save it

                        MouseDownOriginalLocation = pb.Location;
                    }
                }
                catch { }

            }
        }

        private void mouseMove(object sender, MouseEventArgs e)
        {
            if (blackRolls > 0 && !endTurn )
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    PictureBox pb = (PictureBox)sender;
                    if (getDice(pb).isEnabled() && !getDice(pb).getMovedBackToHand())
                    {
                        pb.Left = e.X + pb.Left - MouseDownLocation.X;
                        pb.Top = e.Y + pb.Top - MouseDownLocation.Y;
                        pb.BringToFront();
                    }
                }
            }
        }

        private void mouseUp(object sender, MouseEventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            int diceNum = getDice(pb).getDice();

            if (getDice(pb).isEnabled())
            {
                //find where the dice is and return that location 
                if (pb.Bounds.IntersectsWith(dice1Space.Bounds))
                {
                    //Check if it matches one of the dice on the card.  If not return to dice holder.  If alowed in diceSpace place in vertical line with matching color dice.
                    if (c1.isOnCard(diceNum) && black1.addDie(getDice(pb)))
                    {

                        getDice(pb).lockIt();
                        int y = 0;
                        switch (black1.getNumDice())
                        {
                            case 1:
                                y = black1.spot1;
                                break;
                            case 2:
                                y = black1.spot2;
                                break;
                            case 3:
                                y = black1.spot3;
                                break;
                            case 4:
                                y = black1.spot4;
                                break;
                            case 5:
                                y = black1.spot5;
                                break;
                            case 6:
                                y = black1.spot6;
                                break;
                        }


                        pb.Left = 67;
                        pb.Top = y;
                        getDice(pb).setLocation(new Point(67, y));

                        //positionDice(pb, "black1");

                        getDice(pb).setPlace("Black1");
                        if (black1.cardWinner())
                        {
                            
                            newCard("black", 1);
                        }
                    }
                    else
                    {

                        pb.Left = MouseDownOriginalLocation.X;
                        pb.Top = MouseDownOriginalLocation.Y;
                    }


                }
                else if (pb.Bounds.IntersectsWith(dice2Space.Bounds))
                {

                    //Check if it matches one of the dice on the card.  If not return to dice holder.  If alowed in diceSpace place in vertical line with matching color dice.
                    if (c2.isOnCard(diceNum) && black2.addDie(getDice(pb)))
                    {

                        getDice(pb).lockIt();
                        int y = 0;
                        switch (black2.getNumDice())
                        {
                            case 1:
                                y = black2.spot1;
                                break;
                            case 2:
                                y = black2.spot2;
                                break;
                            case 3:
                                y = black2.spot3;
                                break;
                            case 4:
                                y = black2.spot4;
                                break;
                            case 5:
                                y = black2.spot5;
                                break;
                            case 6:
                                y = black2.spot6;
                                break;
                        }


                        pb.Left = 304;
                        pb.Top = y;
                        getDice(pb).setLocation(new Point(304, y));


                        getDice(pb).setPlace("Black2");
                        if (black2.cardWinner())
                        {
                            
                            newCard("black", 2);
                        }
                    }
                    else
                    {
                        // MessageBox.Show("Cannot place here");
                        pb.Left = MouseDownOriginalLocation.X;
                        pb.Top = MouseDownOriginalLocation.Y;
                    }
                }
                else if (pb.Bounds.IntersectsWith(dice3Space.Bounds))
                {
                    //Check if it matches one of the dice on the card.  If not return to dice holder.  If alowed in diceSpace place in vertical line with matching color dice.
                    if (c3.isOnCard(diceNum) && black3.addDie(getDice(pb)))
                    {

                        getDice(pb).lockIt();
                        int y = 0;
                        switch (black3.getNumDice())
                        {
                            case 1:
                                y = black3.spot1;
                                break;
                            case 2:
                                y = black3.spot2;
                                break;
                            case 3:
                                y = black3.spot3;
                                break;
                            case 4:
                                y = black3.spot4;
                                break;
                            case 5:
                                y = black3.spot5;
                                break;
                            case 6:
                                y = black3.spot6;
                                break;
                        }


                        pb.Left = 542;
                        pb.Top = y;
                        getDice(pb).setLocation(new Point(542, y));


                        getDice(pb).setPlace("Black3");
                        if (black3.cardWinner())
                        {
                            
                            newCard("black", 3);
                        }
                    }
                    else
                    {
                        // MessageBox.Show("Cannot place here");
                        pb.Left = MouseDownOriginalLocation.X;
                        pb.Top = MouseDownOriginalLocation.Y;
                    }

                }

                //moving the dice back to the hand
                else if (pb.Bounds.IntersectsWith(blackDiceBlind.Bounds))
                {
                    //move dice back to hand and allow to roll.
                    getDice(pb).unLockIt();
                    if (getDice(pb).getPlace() != "hand")
                    {
                        switch (getDice(pb).getPlace())
                        {
                            case "Black1":
                                black1.removeDice(getDice(pb).getPBName());
                                getDice(pb).CannotMove();
                                break;
                            case "Black2":
                                black2.removeDice(getDice(pb).getPBName());
                                getDice(pb).CannotMove();
                                break;
                            case "Black3":
                                black3.removeDice(getDice(pb).getPBName());
                                getDice(pb).CannotMove();
                                break;

                        }
                        

                    }
                    getDice(pb).setPlace("hand");

                    getDice(pb).setLocation(new Point(pb.Left, pb.Top));
                    /////////////////////////////////////////////////////////
                    //Need to design something to lookup all the location according to dice1.getLocation() and move all the dice to there matching locations

                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    blackDice1.Left = dice1.getLocation().X;
                    blackDice1.Top = dice1.getLocation().Y;
                    blackDice2.Left = dice2.getLocation().X;
                    blackDice2.Top = dice2.getLocation().Y;
                    blackDice3.Left = dice3.getLocation().X;
                    blackDice3.Top = dice3.getLocation().Y;
                    blackDice4.Left = dice4.getLocation().X;
                    blackDice4.Top = dice4.getLocation().Y;
                    blackDice5.Left = dice5.getLocation().X;
                    blackDice5.Top = dice5.getLocation().Y;
                    blackDice6.Left = dice6.getLocation().X;
                    blackDice6.Top = dice6.getLocation().Y;

                }
                else
                {
                    //return the die to it's last position

                    pb.Left = MouseDownOriginalLocation.X;
                    pb.Top = MouseDownOriginalLocation.Y;
                }
            } //end of isEnabled if
            totalScores();
            
        }


        //helper methods for getting images, and referencing between pictureboxes and Dice

        private void newCard(String color, int cardPosition)
        {
           
            if (cardPosition == 1)
            {
                if (color == "black")
                {
                    blackPoints += c1.getPoints();
                }
                else if (color == "red")
                {
                    redPoints += c1.getPoints();
                }
                else if (color == "blue")
                {
                    bluePoints += c1.getPoints();
                }
                else if (color == "yellow")
                {
                    yellowPoints += c1.getPoints();
                }
                c1 = deckOfCards.drawCard();
                c1.setLocation(1);
                removeAllCards("black1");
                removeAllCards("blue1");
                removeAllCards("red1");
                removeAllCards("yellow1");
                Card1.Image = cardImage(c1.image);
                black1 = new DiceHolder("Black", 1, new Point(67, 341), c1);
                blue1 = new DiceHolder("Blue", 1, new Point(110, 341), c1);
                red1 = new DiceHolder("Red", 1, new Point(153, 341), c1);
                yellow1 = new DiceHolder("Yellow", 1, new Point(196, 341), c1);
            }
            else if (cardPosition == 2)
            {
                if (color == "black")
                {
                    blackPoints += c2.getPoints();
                }
                else if (color == "red")
                {
                    redPoints += c2.getPoints();
                }
                else if (color == "blue")
                {
                    bluePoints += c2.getPoints();
                }
                else if (color == "yellow")
                {
                    yellowPoints += c2.getPoints();
                }
                c2 = deckOfCards.drawCard();
                c2.setLocation(2);
                removeAllCards("black2");
                removeAllCards("blue2");
                removeAllCards("red2");
                removeAllCards("yellow2");
                Card2.Image = cardImage(c2.image);
                black2 = new DiceHolder("Black", 2, new Point(304, 341), c2);
                blue2 = new DiceHolder("Blue", 2, new Point(347, 341), c2);
                red2 = new DiceHolder("Red", 2, new Point(390, 341), c2);
                yellow2 = new DiceHolder("Yellow", 2, new Point(433, 341), c2);
            }
            else if (cardPosition == 3)
            {
                if (color == "black")
                {
                    blackPoints += c3.getPoints();
                }
                else if (color == "red")
                {
                    redPoints += c3.getPoints();
                }
                else if (color == "blue")
                {
                    bluePoints += c3.getPoints();
                }
                else if (color == "yellow")
                {
                    yellowPoints += c3.getPoints();
                }
                c3 = deckOfCards.drawCard();
                c3.setLocation(3);
                removeAllCards("black3");
                removeAllCards("blue3");
                removeAllCards("red3");
                removeAllCards("yellow3");

                Card3.Image = cardImage(c3.image);
                black3 = new DiceHolder("Black", 3, new Point(542, 341), c3);
                blue3 = new DiceHolder("Blue", 3, new Point(585, 341), c3);
                red3 = new DiceHolder("Red", 3, new Point(628, 341), c3);
                yellow3 = new DiceHolder("Yellow", 3, new Point(671, 341), c3);
            }
            
            //Check if there is a winner
            if (!testing)
            {
                if (blackPoints >= 40)
                {
                    MessageBox.Show("Black Wins");
                }
                else if (redPoints >= 40)
                {
                    MessageBox.Show("Red Wins");
                }
                else if (yellowPoints >= 40)
                {
                    MessageBox.Show("Yellow Wins");
                }
                else if (bluePoints >= 40)
                {
                    MessageBox.Show("Blue Wins");
                }
            }
            totalScores();
        }



        private void totalScores()
        {
            textBoxBlackScore.Text = "" + blackPoints;
            textBoxBlueScore.Text = "" + bluePoints;
            textBoxYellowScore.Text = "" + yellowPoints;
            textBoxRedScore.Text = "" + redPoints;
            textBoxFocus.Focus();
        }


        private void rollBlue()
        {
            currentTurn = true;
            
            if (!blueDice1.isLocked()) { blueDice1.rollDice(rnd); }
            if (!blueDice2.isLocked()) { blueDice2.rollDice(rnd); }
            if (!blueDice3.isLocked()) { blueDice3.rollDice(rnd); }
            if (!blueDice4.isLocked()) { blueDice4.rollDice(rnd); }
            if (!blueDice5.isLocked()) { blueDice5.rollDice(rnd); }
            if (!blueDice6.isLocked()) { blueDice6.rollDice(rnd); }


            pbBlueDice1.Image = diceImage(blueDice1.getDice(), "blue");
            pbBlueDice2.Image = diceImage(blueDice2.getDice(), "blue");
            pbBlueDice3.Image = diceImage(blueDice3.getDice(), "blue");
            pbBlueDice4.Image = diceImage(blueDice4.getDice(), "blue");
            pbBlueDice5.Image = diceImage(blueDice5.getDice(), "blue");
            pbBlueDice6.Image = diceImage(blueDice6.getDice(), "blue");

        
            redrawDice();
            System.Threading.Thread.Sleep(500);
            playDice("blue");

            
            
            
               
        }


        private void rollRed()
        {
            
            currentTurn = true;
            if (!redDice1.isLocked()) { redDice1.rollDice(rnd); }
            if (!redDice2.isLocked()) { redDice2.rollDice(rnd); }
            if (!redDice3.isLocked()) { redDice3.rollDice(rnd); }
            if (!redDice4.isLocked()) { redDice4.rollDice(rnd); }
            if (!redDice5.isLocked()) { redDice5.rollDice(rnd); }
            if (!redDice6.isLocked()) { redDice6.rollDice(rnd); }


            pbRedDice1.Image = diceImage(redDice1.getDice(), "red");
            pbRedDice2.Image = diceImage(redDice2.getDice(), "red");
            pbRedDice3.Image = diceImage(redDice3.getDice(), "red");
            pbRedDice4.Image = diceImage(redDice4.getDice(), "red");
            pbRedDice5.Image = diceImage(redDice5.getDice(), "red");
            pbRedDice6.Image = diceImage(redDice6.getDice(), "red");

          
            redrawDice();
            System.Threading.Thread.Sleep(500);
            playDice("red");
            
            


        }

        private void rollYellow()
        {
           
            currentTurn = true;
            if (!yellowDice1.isLocked()) { yellowDice1.rollDice(rnd); }
            if (!yellowDice2.isLocked()) { yellowDice2.rollDice(rnd); }
            if (!yellowDice3.isLocked()) { yellowDice3.rollDice(rnd); }
            if (!yellowDice4.isLocked()) { yellowDice4.rollDice(rnd); }
            if (!yellowDice5.isLocked()) { yellowDice5.rollDice(rnd); }
            if (!yellowDice6.isLocked()) { yellowDice6.rollDice(rnd); }


            pbYellowDice1.Image = diceImage(yellowDice1.getDice(), "yellow");
            pbYellowDice2.Image = diceImage(yellowDice2.getDice(), "yellow");
            pbYellowDice3.Image = diceImage(yellowDice3.getDice(), "yellow");
            pbYellowDice4.Image = diceImage(yellowDice4.getDice(), "yellow");
            pbYellowDice5.Image = diceImage(yellowDice5.getDice(), "yellow");
            pbYellowDice6.Image = diceImage(yellowDice6.getDice(), "yellow");

           
           
            redrawDice();
            System.Threading.Thread.Sleep(500);
            playDice("yellow");
            
            


        }

        private void playDice(String color)
        {
            System.Threading.Thread.Sleep(500);
            //First check if you can complete any cards with available dice, start with largest value first 15, 10, 5, 3.  

            if (color == "blue")
            {
                
                int playCard = 0;

                int card1 = blue1.CanWin(blueDice1, blueDice2, blueDice3, blueDice4, blueDice5, blueDice6);
                int card2 = blue2.CanWin(blueDice1, blueDice2, blueDice3, blueDice4, blueDice5, blueDice6);
                int card3 = blue3.CanWin(blueDice1, blueDice2, blueDice3, blueDice4, blueDice5, blueDice6);

                if (card3 == 0 && card2 == 0 && card1 == 0)
                {
                    if (c1.getPoints() >= c2.getPoints() && c1.getPoints() >= c3.getPoints())
                    {
                        playCard = 1;
                    }
                    else if (c2.getPoints() >= c1.getPoints() && c2.getPoints() >= c3.getPoints())
                    {
                        playCard = 2;
                    }
                    else if (c3.getPoints() >= c2.getPoints() && c3.getPoints() >= c1.getPoints())
                    {
                        playCard = 3;
                    }
                }
                else
                {

                    if ((card3 == 0 && card2 == 0) || (card2 == 0 && card1 == 0) || (card3 == 0 && card1 == 0))
                    { // more than one card can score so find the one with hte highest points
                        if (card1 == 0 && card2 == 0 && c1.getPoints() >= c2.getPoints())
                        {
                            playCard = 1;
                        }
                        else if (card1 == 0 && card2 == 0 && c1.getPoints() < c2.getPoints())
                        {
                            playCard = 2;
                        }
                        else if (card1 == 0 && card3 == 0 && c1.getPoints() >= c3.getPoints())
                        {
                            playCard = 1;
                        }
                        else if (card1 == 0 && card3 == 0 && c1.getPoints() < c3.getPoints())
                        {
                            playCard = 3;
                        }
                        else if (card2 == 0 && card3 == 0 && c2.getPoints() >= c3.getPoints())
                        {
                            playCard = 2;
                        }
                        else if (card2 == 0 && card3 == 0 && c2.getPoints() < c3.getPoints())
                        {
                            playCard = 3;
                        }

                    }
                    else  //only one card can score so play that card
                    {
                        if (card3 == 0)
                        {
                            playCard = 3;
                        }
                        else if (card2 == 0)
                        {
                            playCard = 2;
                        }
                        else if (card1 == 0)
                        {
                            playCard = 1;
                        }
                    }
                }

                if (playCard > 0)
                {
                    playBlueCards(playCard);
                }
                else
                {  // figure out the best play even though it does not win a card
                   //count available dice
                    int countDice = 0;

                    if (!blueDice1.isLocked())
                    {
                        countDice++;
                    }
                    if (!blueDice2.isLocked())
                    {
                        countDice++;
                    }
                    if (!blueDice3.isLocked())
                    {
                        countDice++;
                    }
                    if (!blueDice4.isLocked())
                    {
                        countDice++;
                    }
                    if (!blueDice5.isLocked())
                    {
                        countDice++;
                    }
                    if (!blueDice6.isLocked())
                    {
                        countDice++;
                    }

                    if (card1 < card2 && card1 < card3 && c1.numDice - blue1.getNumDice() <= countDice)
                    {
                        playBlueCards(1);
                    }
                    else if (card2 < card1 && card2 < card3 && c2.numDice - blue2.getNumDice() <= countDice)
                    {
                        playBlueCards(2);
                    }
                    else if (card3 < card1 && card3 < card2 && c3.numDice - blue3.getNumDice() <= countDice)
                    {
                        playBlueCards(3);
                    }


                }







                currentTurn = false;
                turn = "red";
            }  

            else if (color == "red")
            {
                int playCard = 0;

                int card1 = red1.CanWin(redDice1, redDice2, redDice3, redDice4, redDice5, redDice6);
                int card2 = red2.CanWin(redDice1, redDice2, redDice3, redDice4, redDice5, redDice6);
                int card3 = red3.CanWin(redDice1, redDice2, redDice3, redDice4, redDice5, redDice6);


                if (card3 == 0 && card2 == 0 && card1 == 0)
                {
                    if (c1.getPoints() >= c2.getPoints() && c1.getPoints() >= c3.getPoints())
                    {
                        playCard = 1;
                    }
                    else if (c2.getPoints() >= c1.getPoints() && c2.getPoints() >= c3.getPoints())
                    {
                        playCard = 2;
                    }
                    else if (c3.getPoints() >= c2.getPoints() && c3.getPoints() >= c1.getPoints())
                    {
                        playCard = 3;
                    }
                }
                else
                {

                    if ((card3 == 0 && card2 == 0) || (card2 == 0 && card1 == 0) || (card3 == 0 && card1 == 0))
                    { // more than one card can score so find the one with hte highest points
                        if (card1 == 0 && card2 == 0 && c1.getPoints() >= c2.getPoints())
                        {
                            playCard = 1;
                        }
                        else if (card1 == 0 && card2 == 0 && c1.getPoints() < c2.getPoints())
                        {
                            playCard = 2;
                        }
                        else if (card1 == 0 && card3 == 0 && c1.getPoints() >= c3.getPoints())
                        {
                            playCard = 1;
                        }
                        else if (card1 == 0 && card3 == 0 && c1.getPoints() < c3.getPoints())
                        {
                            playCard = 3;
                        }
                        else if (card2 == 0 && card3 == 0 && c2.getPoints() >= c3.getPoints())
                        {
                            playCard = 2;
                        }
                        else if (card2 == 0 && card3 == 0 && c2.getPoints() < c3.getPoints())
                        {
                            playCard = 3;
                        }

                    }
                    else  //only one card can score so play that card
                    {
                        if (card3 == 0)
                        {
                            playCard = 3;
                        }
                        else if (card2 == 0)
                        {
                            playCard = 2;
                        }
                        else if (card1 == 0)
                        {
                            playCard = 1;
                        }
                    }
                }

                if (playCard > 0)
                {
                    playRedCards(playCard);
                }
                else
                {  // figure out the best play even though it does not win a card
                   //count available dice
                    int countDice = 0;

                    if (!redDice1.isLocked())
                    {
                        countDice++;
                    }
                    if (!redDice2.isLocked())
                    {
                        countDice++;
                    }
                    if (!redDice3.isLocked())
                    {
                        countDice++;
                    }
                    if (!redDice4.isLocked())
                    {
                        countDice++;
                    }
                    if (!redDice5.isLocked())
                    {
                        countDice++;
                    }
                    if (!redDice6.isLocked())
                    {
                        countDice++;
                    }

                    if (card1 < card2 && card1 < card3 && c1.numDice - red1.getNumDice() <= countDice)
                    {
                        playRedCards(1);
                    }
                    else if (card2 < card1 && card2 < card3 && c2.numDice - red2.getNumDice() <= countDice)
                    {
                        playRedCards(2);
                    }
                    else if (card3 < card1 && card3 < card2 && c3.numDice - red3.getNumDice() <= countDice)
                    {
                        playRedCards(3);
                    }


                }


                currentTurn = false;
                turn = "yellow";
            } else if (color == "yellow")
            {
                int playCard = 0;

                int card1 = yellow1.CanWin(yellowDice1, yellowDice2, yellowDice3, yellowDice4, yellowDice5, yellowDice6);
                int card2 = yellow2.CanWin(yellowDice1, yellowDice2, yellowDice3, yellowDice4, yellowDice5, yellowDice6);
                int card3 = yellow3.CanWin(yellowDice1, yellowDice2, yellowDice3, yellowDice4, yellowDice5, yellowDice6);

                if (card3 == 0 && card2 == 0 && card1 == 0)
                {
                    if (c1.getPoints() >= c2.getPoints() && c1.getPoints() >= c3.getPoints())
                    {
                        playCard = 1;
                    }
                    else if (c2.getPoints() >= c1.getPoints() && c2.getPoints() >= c3.getPoints())
                    {
                        playCard = 2;
                    }
                    else if (c3.getPoints() >= c2.getPoints() && c3.getPoints() >= c1.getPoints())
                    {
                        playCard = 3;
                    }
                }
                else
                {

                    if ((card3 == 0 && card2 == 0) || (card2 == 0 && card1 == 0) || (card3 == 0 && card1 == 0))
                    { // more than one card can score so find the one with hte highest points
                        if (card1 == 0 && card2 == 0 && c1.getPoints() >= c2.getPoints())
                        {
                            playCard = 1;
                        }
                        else if (card1 == 0 && card2 == 0 && c1.getPoints() < c2.getPoints())
                        {
                            playCard = 2;
                        }
                        else if (card1 == 0 && card3 == 0 && c1.getPoints() >= c3.getPoints())
                        {
                            playCard = 1;
                        }
                        else if (card1 == 0 && card3 == 0 && c1.getPoints() < c3.getPoints())
                        {
                            playCard = 3;
                        }
                        else if (card2 == 0 && card3 == 0 && c2.getPoints() >= c3.getPoints())
                        {
                            playCard = 2;
                        }
                        else if (card2 == 0 && card3 == 0 && c2.getPoints() < c3.getPoints())
                        {
                            playCard = 3;
                        }

                    }
                    else  //only one card can score so play that card
                    {
                        if (card3 == 0)
                        {
                            playCard = 3;
                        }
                        else if (card2 == 0)
                        {
                            playCard = 2;
                        }
                        else if (card1 == 0)
                        {
                            playCard = 1;
                        }
                    }
                }

                if (playCard > 0)
                {
                    playYellowCards(playCard);
                } else
                {  // figure out the best play even though it does not win a card
                   //count available dice
                    int countDice = 0;
                        
                    if (!yellowDice1.isLocked())
                    {
                        countDice++;
                    }
                    if (!yellowDice2.isLocked())
                    {
                        countDice++;
                    }
                    if (!yellowDice3.isLocked())
                    {
                        countDice++;
                    }
                    if (!yellowDice4.isLocked())
                    {
                        countDice++;
                    }
                    if (!yellowDice5.isLocked())
                    {
                        countDice++;
                    }
                    if (!yellowDice6.isLocked())
                    {
                        countDice++;
                    }

                    if (card1 < card2 && card1 < card3 && c1.numDice - yellow1.getNumDice() <= countDice)
                    {
                        playYellowCards(1);
                    } else if (card2 < card1 && card2 < card3 && c2.numDice - yellow2.getNumDice() <= countDice)
                    {
                        playYellowCards(2);
                    } else if (card3 < card1 && card3 < card2 && c3.numDice - yellow3.getNumDice() <= countDice)
                    {
                        playYellowCards(3);
                    }


                }
                currentTurn = false;
                turn = "black";
                
                buttonRoll.Enabled = true;
                buttonEndTurn.Enabled = false;
                
            }
            redrawDice();
            System.Threading.Thread.Sleep(500);
            
        }

        public void checkWinner()
        {
            if (black1.cardWinner())
            {
                newCard("black", 1);
            }
            if (blue1.cardWinner())
            {
                newCard("blue", 1);
            }
            if (red1.cardWinner())
            {
                newCard("red", 1);
            }
            if (yellow1.cardWinner())
            {
                newCard("yellow", 1);
            }

            if (black2.cardWinner())
            {
                newCard("black", 2);
            }
            if (blue2.cardWinner())
            {
                newCard("blue", 2);
            }
            if (red2.cardWinner())
            {
                newCard("red", 2);
            }
            if (yellow2.cardWinner())
            {
                newCard("yellow", 2);
            }


            if (black3.cardWinner())
            {
                newCard("black", 3);
            }
            if (blue3.cardWinner())
            {
                newCard("blue", 3);
            }
            if (red3.cardWinner())
            {
                newCard("red", 3);
            }
            if (yellow3.cardWinner())
            {
                newCard("yellow", 3);
            }
        }
        public void playBlueCards(int playCard)
        {
            if (playCard == 1)
            {
                //Play all available dice on Card 1
                if (c1.isOnCard(blueDice1.getDice()) && blue1.addDie(blueDice1))
                {

                    blueDice1.lockIt();
                    int y = 0;
                    switch (blue1.getNumDice())
                    {
                        case 1:
                            y = blue1.spot1;
                            break;
                        case 2:
                            y = blue1.spot2;
                            break;
                        case 3:
                            y = blue1.spot3;
                            break;
                        case 4:
                            y = blue1.spot4;
                            break;
                        case 5:
                            y = blue1.spot5;
                            break;
                        case 6:
                            y = blue1.spot6;
                            break;
                    }


                    pbBlueDice1.Left = 110;
                    pbBlueDice1.Top = y;
                    blueDice1.setLocation(new Point(110, y));


                }

                if (c1.isOnCard(blueDice2.getDice()) && blue1.addDie(blueDice2))
                {

                    blueDice2.lockIt();
                    int y = 0;
                    switch (blue1.getNumDice())
                    {
                        case 1:
                            y = blue1.spot1;
                            break;
                        case 2:
                            y = blue1.spot2;
                            break;
                        case 3:
                            y = blue1.spot3;
                            break;
                        case 4:
                            y = blue1.spot4;
                            break;
                        case 5:
                            y = blue1.spot5;
                            break;
                        case 6:
                            y = blue1.spot6;
                            break;
                    }


                    pbBlueDice2.Left = 110;
                    pbBlueDice2.Top = y;
                    blueDice2.setLocation(new Point(110, y));


                }

                if (c1.isOnCard(blueDice3.getDice()) && blue1.addDie(blueDice3))
                {

                    blueDice3.lockIt();
                    int y = 0;
                    switch (blue1.getNumDice())
                    {
                        case 1:
                            y = blue1.spot1;
                            break;
                        case 2:
                            y = blue1.spot2;
                            break;
                        case 3:
                            y = blue1.spot3;
                            break;
                        case 4:
                            y = blue1.spot4;
                            break;
                        case 5:
                            y = blue1.spot5;
                            break;
                        case 6:
                            y = blue1.spot6;
                            break;
                    }


                    pbBlueDice3.Left = 110;
                    pbBlueDice3.Top = y;
                    blueDice3.setLocation(new Point(110, y));


                }


                if (c1.isOnCard(blueDice4.getDice()) && blue1.addDie(blueDice4))
                {

                    blueDice4.lockIt();
                    int y = 0;
                    switch (blue1.getNumDice())
                    {
                        case 1:
                            y = blue1.spot1;
                            break;
                        case 2:
                            y = blue1.spot2;
                            break;
                        case 3:
                            y = blue1.spot3;
                            break;
                        case 4:
                            y = blue1.spot4;
                            break;
                        case 5:
                            y = blue1.spot5;
                            break;
                        case 6:
                            y = blue1.spot6;
                            break;
                    }


                    pbBlueDice4.Left = 110;
                    pbBlueDice4.Top = y;
                    blueDice4.setLocation(new Point(110, y));


                }

                if (c1.isOnCard(blueDice5.getDice()) && blue1.addDie(blueDice5))
                {

                    blueDice5.lockIt();
                    int y = 0;
                    switch (blue1.getNumDice())
                    {
                        case 1:
                            y = blue1.spot1;
                            break;
                        case 2:
                            y = blue1.spot2;
                            break;
                        case 3:
                            y = blue1.spot3;
                            break;
                        case 4:
                            y = blue1.spot4;
                            break;
                        case 5:
                            y = blue1.spot5;
                            break;
                        case 6:
                            y = blue1.spot6;
                            break;
                    }


                    pbBlueDice5.Left = 110;
                    pbBlueDice5.Top = y;
                    blueDice5.setLocation(new Point(110, y));


                }


                if (c1.isOnCard(blueDice6.getDice()) && blue1.addDie(blueDice6))
                {

                    blueDice6.lockIt();
                    int y = 0;
                    switch (blue1.getNumDice())
                    {
                        case 1:
                            y = blue1.spot1;
                            break;
                        case 2:
                            y = blue1.spot2;
                            break;
                        case 3:
                            y = blue1.spot3;
                            break;
                        case 4:
                            y = blue1.spot4;
                            break;
                        case 5:
                            y = blue1.spot5;
                            break;
                        case 6:
                            y = blue1.spot6;
                            break;
                    }


                    pbBlueDice6.Left = 110;
                    pbBlueDice6.Top = y;
                    blueDice6.setLocation(new Point(110, y));


                }

                checkWinner();
            } //End of playing Card1
            else if (playCard == 2)
            {
                //Play all available dice on Card 2
                if (c2.isOnCard(blueDice1.getDice()) && blue2.addDie(blueDice1))
                {

                    blueDice1.lockIt();
                    int y = 0;
                    switch (blue2.getNumDice())
                    {
                        case 1:
                            y = blue2.spot1;
                            break;
                        case 2:
                            y = blue2.spot2;
                            break;
                        case 3:
                            y = blue2.spot3;
                            break;
                        case 4:
                            y = blue2.spot4;
                            break;
                        case 5:
                            y = blue2.spot5;
                            break;
                        case 6:
                            y = blue2.spot6;
                            break;
                    }


                    pbBlueDice1.Left = 347;
                    pbBlueDice1.Top = y;
                    blueDice1.setLocation(new Point(347, y));


                }

                if (c2.isOnCard(blueDice2.getDice()) && blue2.addDie(blueDice2))
                {

                    blueDice2.lockIt();
                    int y = 0;
                    switch (blue2.getNumDice())
                    {
                        case 1:
                            y = blue2.spot1;
                            break;
                        case 2:
                            y = blue2.spot2;
                            break;
                        case 3:
                            y = blue2.spot3;
                            break;
                        case 4:
                            y = blue2.spot4;
                            break;
                        case 5:
                            y = blue2.spot5;
                            break;
                        case 6:
                            y = blue2.spot6;
                            break;
                    }


                    pbBlueDice2.Left = 347;
                    pbBlueDice2.Top = y;
                    blueDice2.setLocation(new Point(347, y));


                }

                if (c2.isOnCard(blueDice3.getDice()) && blue2.addDie(blueDice3))
                {

                    blueDice3.lockIt();
                    int y = 0;
                    switch (blue2.getNumDice())
                    {
                        case 1:
                            y = blue2.spot1;
                            break;
                        case 2:
                            y = blue2.spot2;
                            break;
                        case 3:
                            y = blue2.spot3;
                            break;
                        case 4:
                            y = blue2.spot4;
                            break;
                        case 5:
                            y = blue2.spot5;
                            break;
                        case 6:
                            y = blue2.spot6;
                            break;
                    }


                    pbBlueDice3.Left = 347;
                    pbBlueDice3.Top = y;
                    blueDice3.setLocation(new Point(347, y));


                }


                if (c2.isOnCard(blueDice4.getDice()) && blue2.addDie(blueDice4))
                {

                    blueDice4.lockIt();
                    int y = 0;
                    switch (blue2.getNumDice())
                    {
                        case 1:
                            y = blue2.spot1;
                            break;
                        case 2:
                            y = blue2.spot2;
                            break;
                        case 3:
                            y = blue2.spot3;
                            break;
                        case 4:
                            y = blue2.spot4;
                            break;
                        case 5:
                            y = blue2.spot5;
                            break;
                        case 6:
                            y = blue2.spot6;
                            break;
                    }


                    pbBlueDice4.Left = 347;
                    pbBlueDice4.Top = y;
                    blueDice4.setLocation(new Point(347, y));


                }

                if (c2.isOnCard(blueDice5.getDice()) && blue2.addDie(blueDice5))
                {

                    blueDice5.lockIt();
                    int y = 0;
                    switch (blue2.getNumDice())
                    {
                        case 1:
                            y = blue2.spot1;
                            break;
                        case 2:
                            y = blue2.spot2;
                            break;
                        case 3:
                            y = blue2.spot3;
                            break;
                        case 4:
                            y = blue2.spot4;
                            break;
                        case 5:
                            y = blue2.spot5;
                            break;
                        case 6:
                            y = blue2.spot6;
                            break;
                    }


                    pbBlueDice5.Left = 347;
                    pbBlueDice5.Top = y;
                    blueDice5.setLocation(new Point(347, y));


                }


                if (c2.isOnCard(blueDice6.getDice()) && blue2.addDie(blueDice6))
                {

                    blueDice6.lockIt();
                    int y = 0;
                    switch (blue2.getNumDice())
                    {
                        case 1:
                            y = blue2.spot1;
                            break;
                        case 2:
                            y = blue2.spot2;
                            break;
                        case 3:
                            y = blue2.spot3;
                            break;
                        case 4:
                            y = blue2.spot4;
                            break;
                        case 5:
                            y = blue2.spot5;
                            break;
                        case 6:
                            y = blue2.spot6;
                            break;
                    }


                    pbBlueDice6.Left = 347;
                    pbBlueDice6.Top = y;
                    blueDice6.setLocation(new Point(347, y));


                }

                checkWinner();
            } //End of playing Card2

            else if (playCard == 3)
            {
                //Play all available dice on Card 3
                if (c3.isOnCard(blueDice1.getDice()) && blue3.addDie(blueDice1))
                {

                    blueDice1.lockIt();
                    int y = 0;
                    switch (blue3.getNumDice())
                    {
                        case 1:
                            y = blue3.spot1;
                            break;
                        case 2:
                            y = blue3.spot2;
                            break;
                        case 3:
                            y = blue3.spot3;
                            break;
                        case 4:
                            y = blue3.spot4;
                            break;
                        case 5:
                            y = blue3.spot5;
                            break;
                        case 6:
                            y = blue3.spot6;
                            break;
                    }


                    pbBlueDice1.Left = 585;
                    pbBlueDice1.Top = y;
                    blueDice1.setLocation(new Point(585, y));


                }

                if (c3.isOnCard(blueDice2.getDice()) && blue3.addDie(blueDice2))
                {

                    blueDice2.lockIt();
                    int y = 0;
                    switch (blue3.getNumDice())
                    {
                        case 1:
                            y = blue3.spot1;
                            break;
                        case 2:
                            y = blue3.spot2;
                            break;
                        case 3:
                            y = blue3.spot3;
                            break;
                        case 4:
                            y = blue3.spot4;
                            break;
                        case 5:
                            y = blue3.spot5;
                            break;
                        case 6:
                            y = blue3.spot6;
                            break;
                    }


                    pbBlueDice2.Left = 585;
                    pbBlueDice2.Top = y;
                    blueDice2.setLocation(new Point(585, y));


                }

                if (c3.isOnCard(blueDice3.getDice()) && blue3.addDie(blueDice3))
                {

                    blueDice3.lockIt();
                    int y = 0;
                    switch (blue3.getNumDice())
                    {
                        case 1:
                            y = blue3.spot1;
                            break;
                        case 2:
                            y = blue3.spot2;
                            break;
                        case 3:
                            y = blue3.spot3;
                            break;
                        case 4:
                            y = blue3.spot4;
                            break;
                        case 5:
                            y = blue3.spot5;
                            break;
                        case 6:
                            y = blue3.spot6;
                            break;
                    }


                    pbBlueDice3.Left = 585;
                    pbBlueDice3.Top = y;
                    blueDice3.setLocation(new Point(585, y));


                }


                if (c3.isOnCard(blueDice4.getDice()) && blue3.addDie(blueDice4))
                {

                    blueDice4.lockIt();
                    int y = 0;
                    switch (blue3.getNumDice())
                    {
                        case 1:
                            y = blue3.spot1;
                            break;
                        case 2:
                            y = blue3.spot2;
                            break;
                        case 3:
                            y = blue3.spot3;
                            break;
                        case 4:
                            y = blue3.spot4;
                            break;
                        case 5:
                            y = blue3.spot5;
                            break;
                        case 6:
                            y = blue3.spot6;
                            break;
                    }


                    pbBlueDice4.Left = 585;
                    pbBlueDice4.Top = y;
                    blueDice4.setLocation(new Point(585, y));


                }

                if (c3.isOnCard(blueDice5.getDice()) && blue3.addDie(blueDice5))
                {

                    blueDice5.lockIt();
                    int y = 0;
                    switch (blue3.getNumDice())
                    {
                        case 1:
                            y = blue3.spot1;
                            break;
                        case 2:
                            y = blue3.spot2;
                            break;
                        case 3:
                            y = blue3.spot3;
                            break;
                        case 4:
                            y = blue3.spot4;
                            break;
                        case 5:
                            y = blue3.spot5;
                            break;
                        case 6:
                            y = blue3.spot6;
                            break;
                    }


                    pbBlueDice5.Left = 585;
                    pbBlueDice5.Top = y;
                    blueDice5.setLocation(new Point(585, y));


                }


                if (c3.isOnCard(blueDice6.getDice()) && blue3.addDie(blueDice6))
                {

                    blueDice6.lockIt();
                    int y = 0;
                    switch (blue3.getNumDice())
                    {
                        case 1:
                            y = blue3.spot1;
                            break;
                        case 2:
                            y = blue3.spot2;
                            break;
                        case 3:
                            y = blue3.spot3;
                            break;
                        case 4:
                            y = blue3.spot4;
                            break;
                        case 5:
                            y = blue3.spot5;
                            break;
                        case 6:
                            y = blue3.spot6;
                            break;
                    }


                    pbBlueDice6.Left = 585;
                    pbBlueDice6.Top = y;
                    blueDice6.setLocation(new Point(585, y));


                }

                checkWinner();
            } //End of playing Card3
        }


        public void playRedCards(int playCard)
        {
            if (playCard == 1)
            {
                //Play all available dice on Card 1
                if (c1.isOnCard(redDice1.getDice()) && red1.addDie(redDice1))
                {

                    redDice1.lockIt();
                    int y = 0;
                    switch (red1.getNumDice())
                    {
                        case 1:
                            y = red1.spot1;
                            break;
                        case 2:
                            y = red1.spot2;
                            break;
                        case 3:
                            y = red1.spot3;
                            break;
                        case 4:
                            y = red1.spot4;
                            break;
                        case 5:
                            y = red1.spot5;
                            break;
                        case 6:
                            y = red1.spot6;
                            break;
                    }


                    pbRedDice1.Left = 153;
                    pbRedDice1.Top = y;
                    redDice1.setLocation(new Point(153, y));


                }

                if (c1.isOnCard(redDice2.getDice()) && red1.addDie(redDice2))
                {

                    redDice2.lockIt();
                    int y = 0;
                    switch (red1.getNumDice())
                    {
                        case 1:
                            y = red1.spot1;
                            break;
                        case 2:
                            y = red1.spot2;
                            break;
                        case 3:
                            y = red1.spot3;
                            break;
                        case 4:
                            y = red1.spot4;
                            break;
                        case 5:
                            y = red1.spot5;
                            break;
                        case 6:
                            y = red1.spot6;
                            break;
                    }


                    pbRedDice2.Left = 153;
                    pbRedDice2.Top = y;
                    redDice2.setLocation(new Point(153, y));


                }

                if (c1.isOnCard(redDice3.getDice()) && red1.addDie(redDice3))
                {

                    redDice3.lockIt();
                    int y = 0;
                    switch (red1.getNumDice())
                    {
                        case 1:
                            y = red1.spot1;
                            break;
                        case 2:
                            y = red1.spot2;
                            break;
                        case 3:
                            y = red1.spot3;
                            break;
                        case 4:
                            y = red1.spot4;
                            break;
                        case 5:
                            y = red1.spot5;
                            break;
                        case 6:
                            y = red1.spot6;
                            break;
                    }


                    pbRedDice3.Left = 153;
                    pbRedDice3.Top = y;
                    redDice3.setLocation(new Point(153, y));


                }


                if (c1.isOnCard(redDice4.getDice()) && red1.addDie(redDice4))
                {

                    redDice4.lockIt();
                    int y = 0;
                    switch (red1.getNumDice())
                    {
                        case 1:
                            y = red1.spot1;
                            break;
                        case 2:
                            y = red1.spot2;
                            break;
                        case 3:
                            y = red1.spot3;
                            break;
                        case 4:
                            y = red1.spot4;
                            break;
                        case 5:
                            y = red1.spot5;
                            break;
                        case 6:
                            y = red1.spot6;
                            break;
                    }


                    pbRedDice4.Left = 153;
                    pbRedDice4.Top = y;
                    redDice4.setLocation(new Point(153, y));


                }

                if (c1.isOnCard(redDice5.getDice()) && red1.addDie(redDice5))
                {

                    redDice5.lockIt();
                    int y = 0;
                    switch (red1.getNumDice())
                    {
                        case 1:
                            y = red1.spot1;
                            break;
                        case 2:
                            y = red1.spot2;
                            break;
                        case 3:
                            y = red1.spot3;
                            break;
                        case 4:
                            y = red1.spot4;
                            break;
                        case 5:
                            y = red1.spot5;
                            break;
                        case 6:
                            y = red1.spot6;
                            break;
                    }


                    pbRedDice5.Left = 153;
                    pbRedDice5.Top = y;
                    redDice5.setLocation(new Point(153, y));


                }


                if (c1.isOnCard(redDice6.getDice()) && red1.addDie(redDice6))
                {

                    redDice6.lockIt();
                    int y = 0;
                    switch (red1.getNumDice())
                    {
                        case 1:
                            y = red1.spot1;
                            break;
                        case 2:
                            y = red1.spot2;
                            break;
                        case 3:
                            y = red1.spot3;
                            break;
                        case 4:
                            y = red1.spot4;
                            break;
                        case 5:
                            y = red1.spot5;
                            break;
                        case 6:
                            y = red1.spot6;
                            break;
                    }


                    pbRedDice6.Left = 153;
                    pbRedDice6.Top = y;
                    redDice6.setLocation(new Point(153, y));


                }

                checkWinner();
            } //End of playing Card1
            else if (playCard == 2)
            {
                //Play all available dice on Card 2
                if (c2.isOnCard(redDice1.getDice()) && red2.addDie(redDice1))
                {

                    redDice1.lockIt();
                    int y = 0;
                    switch (red2.getNumDice())
                    {
                        case 1:
                            y = red2.spot1;
                            break;
                        case 2:
                            y = red2.spot2;
                            break;
                        case 3:
                            y = red2.spot3;
                            break;
                        case 4:
                            y = red2.spot4;
                            break;
                        case 5:
                            y = red2.spot5;
                            break;
                        case 6:
                            y = red2.spot6;
                            break;
                    }


                    pbRedDice1.Left = 390;
                    pbRedDice1.Top = y;
                    redDice1.setLocation(new Point(390, y));


                }

                if (c2.isOnCard(redDice2.getDice()) && red2.addDie(redDice2))
                {

                    redDice2.lockIt();
                    int y = 0;
                    switch (red2.getNumDice())
                    {
                        case 1:
                            y = red2.spot1;
                            break;
                        case 2:
                            y = red2.spot2;
                            break;
                        case 3:
                            y = red2.spot3;
                            break;
                        case 4:
                            y = red2.spot4;
                            break;
                        case 5:
                            y = red2.spot5;
                            break;
                        case 6:
                            y = red2.spot6;
                            break;
                    }


                    pbRedDice2.Left = 390;
                    pbRedDice2.Top = y;
                    redDice2.setLocation(new Point(390, y));


                }

                if (c2.isOnCard(redDice3.getDice()) && red2.addDie(redDice3))
                {

                    redDice3.lockIt();
                    int y = 0;
                    switch (red2.getNumDice())
                    {
                        case 1:
                            y = red2.spot1;
                            break;
                        case 2:
                            y = red2.spot2;
                            break;
                        case 3:
                            y = red2.spot3;
                            break;
                        case 4:
                            y = red2.spot4;
                            break;
                        case 5:
                            y = red2.spot5;
                            break;
                        case 6:
                            y = red2.spot6;
                            break;
                    }


                    pbRedDice3.Left = 390;
                    pbRedDice3.Top = y;
                    redDice3.setLocation(new Point(390, y));


                }


                if (c2.isOnCard(redDice4.getDice()) && red2.addDie(redDice4))
                {

                    redDice4.lockIt();
                    int y = 0;
                    switch (red2.getNumDice())
                    {
                        case 1:
                            y = red2.spot1;
                            break;
                        case 2:
                            y = red2.spot2;
                            break;
                        case 3:
                            y = red2.spot3;
                            break;
                        case 4:
                            y = red2.spot4;
                            break;
                        case 5:
                            y = red2.spot5;
                            break;
                        case 6:
                            y = red2.spot6;
                            break;
                    }


                    pbRedDice4.Left = 390;
                    pbRedDice4.Top = y;
                    redDice4.setLocation(new Point(390, y));


                }

                if (c2.isOnCard(redDice5.getDice()) && red2.addDie(redDice5))
                {

                    redDice5.lockIt();
                    int y = 0;
                    switch (red2.getNumDice())
                    {
                        case 1:
                            y = red2.spot1;
                            break;
                        case 2:
                            y = red2.spot2;
                            break;
                        case 3:
                            y = red2.spot3;
                            break;
                        case 4:
                            y = red2.spot4;
                            break;
                        case 5:
                            y = red2.spot5;
                            break;
                        case 6:
                            y = red2.spot6;
                            break;
                    }


                    pbRedDice5.Left = 390;
                    pbRedDice5.Top = y;
                    redDice5.setLocation(new Point(390, y));


                }


                if (c2.isOnCard(redDice6.getDice()) && red2.addDie(redDice6))
                {

                    redDice6.lockIt();
                    int y = 0;
                    switch (red2.getNumDice())
                    {
                        case 1:
                            y = red2.spot1;
                            break;
                        case 2:
                            y = red2.spot2;
                            break;
                        case 3:
                            y = red2.spot3;
                            break;
                        case 4:
                            y = red2.spot4;
                            break;
                        case 5:
                            y = red2.spot5;
                            break;
                        case 6:
                            y = red2.spot6;
                            break;
                    }


                    pbRedDice6.Left = 390;
                    pbRedDice6.Top = y;
                    redDice6.setLocation(new Point(390, y));


                }

                checkWinner();
            } //End of playing Card2

            else if (playCard == 3)
            {
                //Play all available dice on Card 3
                if (c3.isOnCard(redDice1.getDice()) && red3.addDie(redDice1))
                {

                    redDice1.lockIt();
                    int y = 0;
                    switch (red3.getNumDice())
                    {
                        case 1:
                            y = red3.spot1;
                            break;
                        case 2:
                            y = red3.spot2;
                            break;
                        case 3:
                            y = red3.spot3;
                            break;
                        case 4:
                            y = red3.spot4;
                            break;
                        case 5:
                            y = red3.spot5;
                            break;
                        case 6:
                            y = red3.spot6;
                            break;
                    }


                    pbRedDice1.Left = 628;
                    pbRedDice1.Top = y;
                    redDice1.setLocation(new Point(628, y));


                }

                if (c3.isOnCard(redDice2.getDice()) && red3.addDie(redDice2))
                {

                    redDice2.lockIt();
                    int y = 0;
                    switch (red3.getNumDice())
                    {
                        case 1:
                            y = red3.spot1;
                            break;
                        case 2:
                            y = red3.spot2;
                            break;
                        case 3:
                            y = red3.spot3;
                            break;
                        case 4:
                            y = red3.spot4;
                            break;
                        case 5:
                            y = red3.spot5;
                            break;
                        case 6:
                            y = red3.spot6;
                            break;
                    }


                    pbRedDice2.Left = 628;
                    pbRedDice2.Top = y;
                    redDice2.setLocation(new Point(628, y));


                }

                if (c3.isOnCard(redDice3.getDice()) && red3.addDie(redDice3))
                {

                    redDice3.lockIt();
                    int y = 0;
                    switch (red3.getNumDice())
                    {
                        case 1:
                            y = red3.spot1;
                            break;
                        case 2:
                            y = red3.spot2;
                            break;
                        case 3:
                            y = red3.spot3;
                            break;
                        case 4:
                            y = red3.spot4;
                            break;
                        case 5:
                            y = red3.spot5;
                            break;
                        case 6:
                            y = red3.spot6;
                            break;
                    }


                    pbRedDice3.Left = 628;
                    pbRedDice3.Top = y;
                    redDice3.setLocation(new Point(628, y));


                }


                if (c3.isOnCard(redDice4.getDice()) && red3.addDie(redDice4))
                {

                    redDice4.lockIt();
                    int y = 0;
                    switch (red3.getNumDice())
                    {
                        case 1:
                            y = red3.spot1;
                            break;
                        case 2:
                            y = red3.spot2;
                            break;
                        case 3:
                            y = red3.spot3;
                            break;
                        case 4:
                            y = red3.spot4;
                            break;
                        case 5:
                            y = red3.spot5;
                            break;
                        case 6:
                            y = red3.spot6;
                            break;
                    }


                    pbRedDice4.Left = 628;
                    pbRedDice4.Top = y;
                    redDice4.setLocation(new Point(628, y));


                }

                if (c3.isOnCard(redDice5.getDice()) && red3.addDie(redDice5))
                {

                    redDice5.lockIt();
                    int y = 0;
                    switch (red3.getNumDice())
                    {
                        case 1:
                            y = red3.spot1;
                            break;
                        case 2:
                            y = red3.spot2;
                            break;
                        case 3:
                            y = red3.spot3;
                            break;
                        case 4:
                            y = red3.spot4;
                            break;
                        case 5:
                            y = red3.spot5;
                            break;
                        case 6:
                            y = red3.spot6;
                            break;
                    }


                    pbRedDice5.Left = 628;
                    pbRedDice5.Top = y;
                    redDice5.setLocation(new Point(628, y));


                }


                if (c3.isOnCard(redDice6.getDice()) && red3.addDie(redDice6))
                {

                    redDice6.lockIt();
                    int y = 0;
                    switch (red3.getNumDice())
                    {
                        case 1:
                            y = red3.spot1;
                            break;
                        case 2:
                            y = red3.spot2;
                            break;
                        case 3:
                            y = red3.spot3;
                            break;
                        case 4:
                            y = red3.spot4;
                            break;
                        case 5:
                            y = red3.spot5;
                            break;
                        case 6:
                            y = red3.spot6;
                            break;
                    }


                    pbRedDice6.Left = 628;
                    pbRedDice6.Top = y;
                    redDice6.setLocation(new Point(628, y));


                }

                checkWinner();
            } //End of playing Card3
        }

        public void playYellowCards(int playCard)
        {
            if (playCard == 1)
            {
                //Play all available dice on Card 1
                if (c1.isOnCard(yellowDice1.getDice()) && yellow1.addDie(yellowDice1))
                {

                    yellowDice1.lockIt();
                    int y = 0;
                    switch (yellow1.getNumDice())
                    {
                        case 1:
                            y = yellow1.spot1;
                            break;
                        case 2:
                            y = yellow1.spot2;
                            break;
                        case 3:
                            y = yellow1.spot3;
                            break;
                        case 4:
                            y = yellow1.spot4;
                            break;
                        case 5:
                            y = yellow1.spot5;
                            break;
                        case 6:
                            y = yellow1.spot6;
                            break;
                    }


                    pbYellowDice1.Left = 196;
                    pbYellowDice1.Top = y;
                    yellowDice1.setLocation(new Point(196, y));


                }

                if (c1.isOnCard(yellowDice2.getDice()) && yellow1.addDie(yellowDice2))
                {

                    yellowDice2.lockIt();
                    int y = 0;
                    switch (yellow1.getNumDice())
                    {
                        case 1:
                            y = yellow1.spot1;
                            break;
                        case 2:
                            y = yellow1.spot2;
                            break;
                        case 3:
                            y = yellow1.spot3;
                            break;
                        case 4:
                            y = yellow1.spot4;
                            break;
                        case 5:
                            y = yellow1.spot5;
                            break;
                        case 6:
                            y = yellow1.spot6;
                            break;
                    }


                    pbYellowDice2.Left = 196;
                    pbYellowDice2.Top = y;
                    yellowDice2.setLocation(new Point(196, y));


                }

                if (c1.isOnCard(yellowDice3.getDice()) && yellow1.addDie(yellowDice3))
                {

                    yellowDice3.lockIt();
                    int y = 0;
                    switch (yellow1.getNumDice())
                    {
                        case 1:
                            y = yellow1.spot1;
                            break;
                        case 2:
                            y = yellow1.spot2;
                            break;
                        case 3:
                            y = yellow1.spot3;
                            break;
                        case 4:
                            y = yellow1.spot4;
                            break;
                        case 5:
                            y = yellow1.spot5;
                            break;
                        case 6:
                            y = yellow1.spot6;
                            break;
                    }


                    pbYellowDice3.Left = 196;
                    pbYellowDice3.Top = y;
                    yellowDice3.setLocation(new Point(196, y));


                }


                if (c1.isOnCard(yellowDice4.getDice()) && yellow1.addDie(yellowDice4))
                {

                    yellowDice4.lockIt();
                    int y = 0;
                    switch (yellow1.getNumDice())
                    {
                        case 1:
                            y = yellow1.spot1;
                            break;
                        case 2:
                            y = yellow1.spot2;
                            break;
                        case 3:
                            y = yellow1.spot3;
                            break;
                        case 4:
                            y = yellow1.spot4;
                            break;
                        case 5:
                            y = yellow1.spot5;
                            break;
                        case 6:
                            y = yellow1.spot6;
                            break;
                    }


                    pbYellowDice4.Left = 196;
                    pbYellowDice4.Top = y;
                    yellowDice4.setLocation(new Point(196, y));


                }

                if (c1.isOnCard(yellowDice5.getDice()) && yellow1.addDie(yellowDice5))
                {

                    yellowDice5.lockIt();
                    int y = 0;
                    switch (yellow1.getNumDice())
                    {
                        case 1:
                            y = yellow1.spot1;
                            break;
                        case 2:
                            y = yellow1.spot2;
                            break;
                        case 3:
                            y = yellow1.spot3;
                            break;
                        case 4:
                            y = yellow1.spot4;
                            break;
                        case 5:
                            y = yellow1.spot5;
                            break;
                        case 6:
                            y = yellow1.spot6;
                            break;
                    }


                    pbYellowDice5.Left = 196;
                    pbYellowDice5.Top = y;
                    yellowDice5.setLocation(new Point(196, y));


                }


                if (c1.isOnCard(yellowDice6.getDice()) && yellow1.addDie(yellowDice6))
                {

                    yellowDice6.lockIt();
                    int y = 0;
                    switch (yellow1.getNumDice())
                    {
                        case 1:
                            y = yellow1.spot1;
                            break;
                        case 2:
                            y = yellow1.spot2;
                            break;
                        case 3:
                            y = yellow1.spot3;
                            break;
                        case 4:
                            y = yellow1.spot4;
                            break;
                        case 5:
                            y = yellow1.spot5;
                            break;
                        case 6:
                            y = yellow1.spot6;
                            break;
                    }


                    pbYellowDice6.Left = 196;
                    pbYellowDice6.Top = y;
                    yellowDice6.setLocation(new Point(196, y));


                }

                checkWinner();
            } //End of playing Card1
            else if (playCard == 2)
            {
                //Play all available dice on Card 2
                if (c2.isOnCard(yellowDice1.getDice()) && yellow2.addDie(yellowDice1))
                {

                    yellowDice1.lockIt();
                    int y = 0;
                    switch (yellow2.getNumDice())
                    {
                        case 1:
                            y = yellow2.spot1;
                            break;
                        case 2:
                            y = yellow2.spot2;
                            break;
                        case 3:
                            y = yellow2.spot3;
                            break;
                        case 4:
                            y = yellow2.spot4;
                            break;
                        case 5:
                            y = yellow2.spot5;
                            break;
                        case 6:
                            y = yellow2.spot6;
                            break;
                    }


                    pbYellowDice1.Left = 433;
                    pbYellowDice1.Top = y;
                    yellowDice1.setLocation(new Point(433, y));


                }

                if (c2.isOnCard(yellowDice2.getDice()) && yellow2.addDie(yellowDice2))
                {

                    yellowDice2.lockIt();
                    int y = 0;
                    switch (yellow2.getNumDice())
                    {
                        case 1:
                            y = yellow2.spot1;
                            break;
                        case 2:
                            y = yellow2.spot2;
                            break;
                        case 3:
                            y = yellow2.spot3;
                            break;
                        case 4:
                            y = yellow2.spot4;
                            break;
                        case 5:
                            y = yellow2.spot5;
                            break;
                        case 6:
                            y = yellow2.spot6;
                            break;
                    }


                    pbYellowDice2.Left = 433;
                    pbYellowDice2.Top = y;
                    yellowDice2.setLocation(new Point(433, y));


                }

                if (c2.isOnCard(yellowDice3.getDice()) && yellow2.addDie(yellowDice3))
                {

                    yellowDice3.lockIt();
                    int y = 0;
                    switch (yellow2.getNumDice())
                    {
                        case 1:
                            y = yellow2.spot1;
                            break;
                        case 2:
                            y = yellow2.spot2;
                            break;
                        case 3:
                            y = yellow2.spot3;
                            break;
                        case 4:
                            y = yellow2.spot4;
                            break;
                        case 5:
                            y = yellow2.spot5;
                            break;
                        case 6:
                            y = yellow2.spot6;
                            break;
                    }


                    pbYellowDice3.Left = 433;
                    pbYellowDice3.Top = y;
                    yellowDice3.setLocation(new Point(433, y));


                }


                if (c2.isOnCard(yellowDice4.getDice()) && yellow2.addDie(yellowDice4))
                {

                    yellowDice4.lockIt();
                    int y = 0;
                    switch (yellow2.getNumDice())
                    {
                        case 1:
                            y = yellow2.spot1;
                            break;
                        case 2:
                            y = yellow2.spot2;
                            break;
                        case 3:
                            y = yellow2.spot3;
                            break;
                        case 4:
                            y = yellow2.spot4;
                            break;
                        case 5:
                            y = yellow2.spot5;
                            break;
                        case 6:
                            y = yellow2.spot6;
                            break;
                    }


                    pbYellowDice4.Left = 433;
                    pbYellowDice4.Top = y;
                    yellowDice4.setLocation(new Point(433, y));


                }

                if (c2.isOnCard(yellowDice5.getDice()) && yellow2.addDie(yellowDice5))
                {

                    yellowDice5.lockIt();
                    int y = 0;
                    switch (yellow2.getNumDice())
                    {
                        case 1:
                            y = yellow2.spot1;
                            break;
                        case 2:
                            y = yellow2.spot2;
                            break;
                        case 3:
                            y = yellow2.spot3;
                            break;
                        case 4:
                            y = yellow2.spot4;
                            break;
                        case 5:
                            y = yellow2.spot5;
                            break;
                        case 6:
                            y = yellow2.spot6;
                            break;
                    }


                    pbYellowDice5.Left = 433;
                    pbYellowDice5.Top = y;
                    yellowDice5.setLocation(new Point(433, y));


                }


                if (c2.isOnCard(yellowDice6.getDice()) && yellow2.addDie(yellowDice6))
                {

                    yellowDice6.lockIt();
                    int y = 0;
                    switch (yellow2.getNumDice())
                    {
                        case 1:
                            y = yellow2.spot1;
                            break;
                        case 2:
                            y = yellow2.spot2;
                            break;
                        case 3:
                            y = yellow2.spot3;
                            break;
                        case 4:
                            y = yellow2.spot4;
                            break;
                        case 5:
                            y = yellow2.spot5;
                            break;
                        case 6:
                            y = yellow2.spot6;
                            break;
                    }


                    pbYellowDice6.Left = 433;
                    pbYellowDice6.Top = y;
                    yellowDice6.setLocation(new Point(433, y));


                }

                checkWinner();
            } //End of playing Card2

            else if (playCard == 3)
            {
                //Play all available dice on Card 3
                if (c3.isOnCard(yellowDice1.getDice()) && yellow3.addDie(yellowDice1))
                {

                    yellowDice1.lockIt();
                    int y = 0;
                    switch (yellow3.getNumDice())
                    {
                        case 1:
                            y = yellow3.spot1;
                            break;
                        case 2:
                            y = yellow3.spot2;
                            break;
                        case 3:
                            y = yellow3.spot3;
                            break;
                        case 4:
                            y = yellow3.spot4;
                            break;
                        case 5:
                            y = yellow3.spot5;
                            break;
                        case 6:
                            y = yellow3.spot6;
                            break;
                    }


                    pbYellowDice1.Left = 671;
                    pbYellowDice1.Top = y;
                    yellowDice1.setLocation(new Point(671, y));


                }

                if (c3.isOnCard(yellowDice2.getDice()) && yellow3.addDie(yellowDice2))
                {

                    yellowDice2.lockIt();
                    int y = 0;
                    switch (yellow3.getNumDice())
                    {
                        case 1:
                            y = yellow3.spot1;
                            break;
                        case 2:
                            y = yellow3.spot2;
                            break;
                        case 3:
                            y = yellow3.spot3;
                            break;
                        case 4:
                            y = yellow3.spot4;
                            break;
                        case 5:
                            y = yellow3.spot5;
                            break;
                        case 6:
                            y = yellow3.spot6;
                            break;
                    }


                    pbYellowDice2.Left = 671;
                    pbYellowDice2.Top = y;
                    yellowDice2.setLocation(new Point(671, y));


                }

                if (c3.isOnCard(yellowDice3.getDice()) && yellow3.addDie(yellowDice3))
                {

                    yellowDice3.lockIt();
                    int y = 0;
                    switch (yellow3.getNumDice())
                    {
                        case 1:
                            y = yellow3.spot1;
                            break;
                        case 2:
                            y = yellow3.spot2;
                            break;
                        case 3:
                            y = yellow3.spot3;
                            break;
                        case 4:
                            y = yellow3.spot4;
                            break;
                        case 5:
                            y = yellow3.spot5;
                            break;
                        case 6:
                            y = yellow3.spot6;
                            break;
                    }


                    pbYellowDice3.Left = 671;
                    pbYellowDice3.Top = y;
                    yellowDice3.setLocation(new Point(671, y));


                }


                if (c3.isOnCard(yellowDice4.getDice()) && yellow3.addDie(yellowDice4))
                {

                    yellowDice4.lockIt();
                    int y = 0;
                    switch (yellow3.getNumDice())
                    {
                        case 1:
                            y = yellow3.spot1;
                            break;
                        case 2:
                            y = yellow3.spot2;
                            break;
                        case 3:
                            y = yellow3.spot3;
                            break;
                        case 4:
                            y = yellow3.spot4;
                            break;
                        case 5:
                            y = yellow3.spot5;
                            break;
                        case 6:
                            y = yellow3.spot6;
                            break;
                    }


                    pbYellowDice4.Left = 671;
                    pbYellowDice4.Top = y;
                    yellowDice4.setLocation(new Point(671, y));


                }

                if (c3.isOnCard(yellowDice5.getDice()) && yellow3.addDie(yellowDice5))
                {

                    yellowDice5.lockIt();
                    int y = 0;
                    switch (yellow3.getNumDice())
                    {
                        case 1:
                            y = yellow3.spot1;
                            break;
                        case 2:
                            y = yellow3.spot2;
                            break;
                        case 3:
                            y = yellow3.spot3;
                            break;
                        case 4:
                            y = yellow3.spot4;
                            break;
                        case 5:
                            y = yellow3.spot5;
                            break;
                        case 6:
                            y = yellow3.spot6;
                            break;
                    }


                    pbYellowDice5.Left = 671;
                    pbYellowDice5.Top = y;
                    yellowDice5.setLocation(new Point(671, y));


                }


                if (c3.isOnCard(yellowDice6.getDice()) && yellow3.addDie(yellowDice6))
                {

                    yellowDice6.lockIt();
                    int y = 0;
                    switch (yellow3.getNumDice())
                    {
                        case 1:
                            y = yellow3.spot1;
                            break;
                        case 2:
                            y = yellow3.spot2;
                            break;
                        case 3:
                            y = yellow3.spot3;
                            break;
                        case 4:
                            y = yellow3.spot4;
                            break;
                        case 5:
                            y = yellow3.spot5;
                            break;
                        case 6:
                            y = yellow3.spot6;
                            break;
                    }


                    pbYellowDice6.Left = 671;
                    pbYellowDice6.Top = y;
                    yellowDice6.setLocation(new Point(671, y));


                }

                checkWinner();
            } //End of playing Card3
        }
        public int diceNotLocked(String color)
        {
            int total = 0;

            if(color == "blue")
            {
                if(!blueDice1.isLocked()) { total++; }
                if (!blueDice2.isLocked()) { total++; }
                if (!blueDice3.isLocked()) { total++; }
                if (!blueDice4.isLocked()) { total++; }
                if (!blueDice5.isLocked()) { total++; }
                if (!blueDice6.isLocked()) { total++; }
               
            } else if (color =="red")
            {
                if (!redDice1.isLocked()) { total++; }
                if (!redDice2.isLocked()) { total++; }
                if (!redDice3.isLocked()) { total++; }
                if (!redDice4.isLocked()) { total++; }
                if (!redDice5.isLocked()) { total++; }
                if (!redDice6.isLocked()) { total++; }
            } else if (color == "yellow")
            {
                if (!yellowDice1.isLocked()) { total++; }
                if (!yellowDice2.isLocked()) { total++; }
                if (!yellowDice3.isLocked()) { total++; }
                if (!yellowDice4.isLocked()) { total++; }
                if (!yellowDice5.isLocked()) { total++; }
                if (!yellowDice6.isLocked()) { total++; }
            }

            return total;
        }



        private void removeAllCards(String s)
        {
            // remove the cards after winning and disable them until end of turn button is clicked.
            switch (s)
            {
                case "black1":
                    black1.removeAllDice();
                    break;
                case "black2":
                    black2.removeAllDice();
                    break;
                case "black3":
                    black3.removeAllDice();
                    break;
                case "blue1":
                    blue1.removeAllDice();
                    break;
                case "blue2":
                    blue2.removeAllDice();
                    break;
                case "blue3":
                    blue3.removeAllDice();
                    break;
                case "red1":
                    red1.removeAllDice();
                    break;
                case "red2":
                    red2.removeAllDice();
                    break;
                case "red3":
                    red3.removeAllDice();
                    break;
                case "yellow1":
                    yellow1.removeAllDice();
                    break;
                case "yellow2":
                    yellow2.removeAllDice();
                    break;
                case "yellow3":
                    yellow3.removeAllDice();
                    break;

            }
            redrawDice();
        }

        public void redrawDice()
        {

            if (dice1.getLocation().Y > 610)
            {
                dice1.setLocation(dice1.getStartLocation());
            }
            if (dice2.getLocation().Y > 610)
            {
                dice2.setLocation(dice2.getStartLocation());
            }
            if (dice3.getLocation().Y > 610)
            {
                dice3.setLocation(dice3.getStartLocation());
            }
            if (dice4.getLocation().Y > 610)
            {
                dice4.setLocation(dice4.getStartLocation());
            }
            if (dice5.getLocation().Y > 610)
            {
                dice5.setLocation(dice5.getStartLocation());
            }
            if (dice6.getLocation().Y > 610)
            {
                dice6.setLocation(dice6.getStartLocation());
            }
            blackDice1.Top = dice1.getLocation().Y;
            blackDice1.Left = dice1.getLocation().X;
            blackDice1.Top = dice1.getLocation().Y;
            blackDice1.Left = dice1.getLocation().X;
            blackDice2.Top = dice2.getLocation().Y;
            blackDice2.Left = dice2.getLocation().X;
            blackDice3.Top = dice3.getLocation().Y;
            blackDice3.Left = dice3.getLocation().X;
            blackDice4.Top = dice4.getLocation().Y;
            blackDice4.Left = dice4.getLocation().X;
            blackDice5.Top = dice5.getLocation().Y;
            blackDice5.Left = dice5.getLocation().X;
            blackDice6.Top = dice6.getLocation().Y;
            blackDice6.Left = dice6.getLocation().X;

            pbBlueDice1.Top = blueDice1.getLocation().Y;
            pbBlueDice1.Left = blueDice1.getLocation().X;
            pbBlueDice1.Top = blueDice1.getLocation().Y;
            pbBlueDice1.Left = blueDice1.getLocation().X;
            pbBlueDice2.Top = blueDice2.getLocation().Y;
            pbBlueDice2.Left = blueDice2.getLocation().X;
            pbBlueDice3.Top = blueDice3.getLocation().Y;
            pbBlueDice3.Left = blueDice3.getLocation().X;
            pbBlueDice4.Top = blueDice4.getLocation().Y;
            pbBlueDice4.Left = blueDice4.getLocation().X;
            pbBlueDice5.Top = blueDice5.getLocation().Y;
            pbBlueDice5.Left = blueDice5.getLocation().X;
            pbBlueDice6.Top = blueDice6.getLocation().Y;
            pbBlueDice6.Left = blueDice6.getLocation().X;

            pbRedDice1.Top = redDice1.getLocation().Y;
            pbRedDice1.Left = redDice1.getLocation().X;
            pbRedDice1.Top = redDice1.getLocation().Y;
            pbRedDice1.Left = redDice1.getLocation().X;
            pbRedDice2.Top = redDice2.getLocation().Y;
            pbRedDice2.Left = redDice2.getLocation().X;
            pbRedDice3.Top = redDice3.getLocation().Y;
            pbRedDice3.Left = redDice3.getLocation().X;
            pbRedDice4.Top = redDice4.getLocation().Y;
            pbRedDice4.Left = redDice4.getLocation().X;
            pbRedDice5.Top = redDice5.getLocation().Y;
            pbRedDice5.Left = redDice5.getLocation().X;
            pbRedDice6.Top = redDice6.getLocation().Y;
            pbRedDice6.Left = redDice6.getLocation().X;

            pbYellowDice1.Top = yellowDice1.getLocation().Y;
            pbYellowDice1.Left = yellowDice1.getLocation().X;
            pbYellowDice1.Top = yellowDice1.getLocation().Y;
            pbYellowDice1.Left = yellowDice1.getLocation().X;
            pbYellowDice2.Top = yellowDice2.getLocation().Y;
            pbYellowDice2.Left = yellowDice2.getLocation().X;
            pbYellowDice3.Top = yellowDice3.getLocation().Y;
            pbYellowDice3.Left = yellowDice3.getLocation().X;
            pbYellowDice4.Top = yellowDice4.getLocation().Y;
            pbYellowDice4.Left = yellowDice4.getLocation().X;
            pbYellowDice5.Top = yellowDice5.getLocation().Y;
            pbYellowDice5.Left = yellowDice5.getLocation().X;
            pbYellowDice6.Top = yellowDice6.getLocation().Y;
            pbYellowDice6.Left = yellowDice6.getLocation().X;

            if (!dice1.isEnabled())
            {
                blackDice1.Image = null;

            }
            if (!dice2.isEnabled())
            {
                blackDice2.Image = null;

            }
            if (!dice3.isEnabled())
            {
                blackDice3.Image = null;

            }
            if (!dice4.isEnabled())
            {
                blackDice4.Image = null;

            }
            if (!dice5.isEnabled())
            {
                blackDice5.Image = null;

            }
            if (!dice6.isEnabled())
            {
                blackDice6.Image = null;

            }

        }


        public Image diceImage(int i, String color)
        {
            if (color == "black")
            {
                switch (i)
                {
                    case 1:
                        return Properties.Resources.Black_1;

                    case 2:
                        return Properties.Resources.Black_2;

                    case 3:
                        return Properties.Resources.Black_3;

                    case 4:
                        return Properties.Resources.Black_4;

                    case 5:
                        return Properties.Resources.Black_5;

                    case 6:
                        return Properties.Resources.Black_6;

                    default:
                        return Properties.Resources.Black_6;

                }
            }
            else if (color == "blue")
            {
                switch (i)
                {
                    case 1:
                        return Properties.Resources.Blue_1;

                    case 2:
                        return Properties.Resources.Blue_2;

                    case 3:
                        return Properties.Resources.Blue_3;

                    case 4:
                        return Properties.Resources.Blue_4;

                    case 5:
                        return Properties.Resources.Blue_5;

                    case 6:
                        return Properties.Resources.Blue_6;

                    default:
                        return Properties.Resources.Blue_6;

                }
            }
            else if (color == "red")
            {
                switch (i)
                {
                    case 1:
                        return Properties.Resources.Red_1;

                    case 2:
                        return Properties.Resources.Red_2;

                    case 3:
                        return Properties.Resources.Red_3;

                    case 4:
                        return Properties.Resources.Red_4;

                    case 5:
                        return Properties.Resources.Red_5;

                    case 6:
                        return Properties.Resources.Red_6;

                    default:
                        return Properties.Resources.Red_6;

                }
            }
            else if (color == "yellow")
            {
                switch (i)
                {
                    case 1:
                        return Properties.Resources.Yellow_1;

                    case 2:
                        return Properties.Resources.Yellow_2;

                    case 3:
                        return Properties.Resources.Yellow_3;

                    case 4:
                        return Properties.Resources.Yellow_4;

                    case 5:
                        return Properties.Resources.Yellow_5;

                    case 6:
                        return Properties.Resources.Yellow_6;

                    default:
                        return Properties.Resources.Yellow_6;

                }

            }
            else
            {
                return Properties.Resources.Black_1;
            }
        }

        public Image cardImage(String st)
        {
            switch (st)
            {

                case "img1.jpg":
                    return Properties.Resources.img1;
                case "img2.jpg":
                    return Properties.Resources.img2;
                case "img3.jpg":
                    return Properties.Resources.img3;
                case "img4.jpg":
                    return Properties.Resources.img4;
                case "img5.jpg":
                    return Properties.Resources.img5;
                case "img6.jpg":
                    return Properties.Resources.img6;
                case "img7.jpg":
                    return Properties.Resources.img7;
                case "img8.jpg":
                    return Properties.Resources.img8;
                case "img9.jpg":
                    return Properties.Resources.img9;
                case "img10.jpg":
                    return Properties.Resources.img10;
                case "img11.jpg":
                    return Properties.Resources.img11;
                case "img12.jpg":
                    return Properties.Resources.img12;
                case "img13.jpg":
                    return Properties.Resources.img13;
                case "img14.jpg":
                    return Properties.Resources.img14;
                case "img15.jpg":
                    return Properties.Resources.img15;
                case "img16.jpg":
                    return Properties.Resources.img16;
                case "img17.jpg":
                    return Properties.Resources.img17;
                case "img18.jpg":
                    return Properties.Resources.img18;
                case "img19.jpg":
                    return Properties.Resources.img19;
                case "img20.jpg":
                    return Properties.Resources.img20;

                case "img21.jpg":
                    return Properties.Resources.img21;
                case "img22.jpg":
                    return Properties.Resources.img22;
                case "img23.jpg":
                    return Properties.Resources.img23;
                case "img24.jpg":
                    return Properties.Resources.img24;
                case "img25.jpg":
                    return Properties.Resources.img25;
                case "img26.jpg":
                    return Properties.Resources.img26;
                case "img27.jpg":
                    return Properties.Resources.img27;
                case "img28.jpg":
                    return Properties.Resources.img28;
                case "img29.jpg":
                    return Properties.Resources.img29;
                case "img30.jpg":
                    return Properties.Resources.img30;

            }

            return Properties.Resources.img1;
        }

        public Dice getDice(PictureBox pb)
        {
            if (pb.Name == "blackDice1")
            {
                return dice1;
            }
            else if (pb.Name == "blackDice2")
            {
                return dice2;
            }
            else if (pb.Name == "blackDice3")
            {
                return dice3;
            }
            else if (pb.Name == "blackDice4")
            {
                return dice4;
            }
            else if (pb.Name == "blackDice5")
            {
                return dice5;
            }
            else if (pb.Name == "blackDice6")
            {
                return dice6;
            }
            else if (pb.Name == "pbBlueDice1")
            {
                return blueDice1;
            }
            else if (pb.Name == "pbBlueDice2")
            {
                return blueDice2;
            }
            else if (pb.Name == "pbBlueDice3")
            {
                return blueDice3;
            }
            else if (pb.Name == "pbBlueDice4")
            {
                return blueDice4;
            }
            else if (pb.Name == "pbBlueDice5")
            {
                return blueDice5;
            }
            else if (pb.Name == "pbBlueDice6")
            {
                return blueDice6;
            }

            else if (pb.Name == "pbRedeDice1")
            {
                return redDice1;
            }
            else if (pb.Name == "pbRedDice2")
            {
                return redDice2;
            }
            else if (pb.Name == "pbRedDice3")
            {
                return redDice3;
            }
            else if (pb.Name == "pbBlueDice4")
            {
                return blueDice4;
            }
            else if (pb.Name == "pbRedDice5")
            {
                return redDice5;
            }
            else if (pb.Name == "pbRedDice6")
            {
                return redDice6;
            }
            else if (pb.Name == "pbYellowDice1")
            {
                return yellowDice1;
            }
            else if (pb.Name == "pbYellowDice2")
            {
                return yellowDice2;
            }
            else if (pb.Name == "pbYellowDice3")
            {
                return yellowDice3;
            }
            else if (pb.Name == "pbYellowDice4")
            {
                return yellowDice4;
            }
            else if (pb.Name == "pbYellowDice5")
            {
                return yellowDice5;
            }
            else if (pb.Name == "pbYellowDice6")
            {
                return yellowDice6;

            }
            else
            {
                return dice1;
            }


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!currentTurn && turn == "blue")
            {
                
                rollBlue();

            } else if (!currentTurn && turn == "red")
            {
                rollRed();
                
            }
            else if (!currentTurn && turn == "yellow")
            {
                rollYellow();
                
            } else if (!currentTurn && turn =="black")
            {
                
                
            }
        }

        private void TableTop_Load(object sender, EventArgs e)
        {

        }

        private void blackDice1_Click(object sender, EventArgs e)
        {

        }
    }



}
