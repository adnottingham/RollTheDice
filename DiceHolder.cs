using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace RollTheDice
{
    class DiceHolder
    {
        
        //private String type;  //player or diceCard
        private int cardPosition = 0;  // 0 = PlayerHand   1,2 or 3 = under a card
        private String color;
        private int numDice = 0;
        private Point firstLocation;
        private Card card;
        
        
        private static int DieWidth = 46;

        public int spot1 = 341;
        public int spot2 = 387;
        public int spot3 = 433;
        public int spot4 = 479;
        public int spot5 = 525;
        public int spot6 = 571;

        Dice dice1 = null;
        Dice dice2 = null;
        Dice dice3 = null;
        Dice dice4 = null;
        Dice dice5 = null;
        Dice dice6 = null;


        //private Dice[] dice = new Dice[6];


        public DiceHolder(String type,String color)
        {
           
            this.color = color;

        }

        public DiceHolder( String color, int cardPosition,Point firstLocation,Card card)
        {
           
            this.color = color;
            this.cardPosition = cardPosition;
            this.firstLocation = firstLocation;
            this.card = card;
        }

        public bool addDie(Dice d)
        {
            //check if it can be added , then add or return false if cannot add
            if (!d.isLocked())
            {
                if (dice1 == null && card.getDiceNumLocation("num1") == d.getDice())
                {
                    dice1 = d;
                    numDice++;
                    return true;
                }
                else if (dice2 == null && card.getDiceNumLocation("num2") == d.getDice())
                {
                    dice2 = d;
                    numDice++;
                    return true;
                }
                else if (dice3 == null && card.getDiceNumLocation("num3") == d.getDice())
                {
                    dice3 = d;
                    numDice++;
                    return true;
                }
                else if (dice4 == null && card.getDiceNumLocation("num4") == d.getDice())
                {
                    dice4 = d;
                    numDice++;
                    return true;
                }
                else if (dice5 == null && card.getDiceNumLocation("num5") == d.getDice())
                {
                    dice5 = d;
                    numDice++;
                    return true;
                }
                else if (dice6 == null && card.getDiceNumLocation("num6") == d.getDice())
                {
                    dice6 = d;
                    numDice++;
                    return true;
                }
                else
                {
                    return false;
                }

            } else   //the dice is already in a diceholder so it cannot be moved top another one
            {
                return false;
            }
            


        }


        public void removeDice(String pb)
        {
            if (pb != null)
            {
                // find the dice from the pbName and remove it.   move the rest of the die up one space
                if (dice1 != null && dice1.getPBName() == pb)
                {
                    dice1 = dice2;
                    if (dice1 != null) { dice1.setLocation(new Point(dice1.getLocation().X, dice1.getLocation().Y - DieWidth)); }
                    dice2 = dice3;
                    if (dice2 != null) { dice2.setLocation(new Point(dice2.getLocation().X, dice2.getLocation().Y - DieWidth)); }
                    dice3 = dice4;
                    if (dice3 != null) { dice3.setLocation(new Point(dice3.getLocation().X, dice3.getLocation().Y - DieWidth)); }
                    dice4 = dice5;
                    if (dice4 != null) { dice4.setLocation(new Point(dice4.getLocation().X, dice4.getLocation().Y - DieWidth)); }
                    dice5 = dice6;
                    if (dice5 != null) { dice5.setLocation(new Point(dice5.getLocation().X, dice5.getLocation().Y - DieWidth)); }
                    dice6 = null;
                }
                else if (dice2 != null && dice2.getPBName() == pb)
                {
                    dice2 = dice3;
                    if (dice2 != null) { dice2.setLocation(new Point(dice2.getLocation().X, dice2.getLocation().Y - DieWidth)); }
                    dice3 = dice4;
                    if (dice3 != null) { dice3.setLocation(new Point(dice3.getLocation().X, dice3.getLocation().Y - DieWidth)); }
                    dice4 = dice5;
                    if (dice4 != null) { dice4.setLocation(new Point(dice4.getLocation().X, dice4.getLocation().Y - DieWidth)); }
                    dice5 = dice6;
                    if (dice5 != null) { dice5.setLocation(new Point(dice5.getLocation().X, dice5.getLocation().Y - DieWidth)); }
                    dice6 = null;
                }
                else if (dice3 != null && dice3.getPBName() == pb)
                {
                    dice3 = dice4;
                    if (dice3 != null) { dice3.setLocation(new Point(dice3.getLocation().X, dice3.getLocation().Y - DieWidth)); }
                    dice4 = dice5;
                    if (dice4 != null) { dice4.setLocation(new Point(dice4.getLocation().X, dice4.getLocation().Y - DieWidth)); }
                    dice5 = dice6;
                    if (dice5 != null) { dice5.setLocation(new Point(dice5.getLocation().X, dice5.getLocation().Y - DieWidth)); }
                    dice6 = null;
                }
                else if (dice4 != null && dice4.getPBName() == pb)
                {

                    dice4 = dice5;
                    if (dice4 != null) { dice4.setLocation(new Point(dice4.getLocation().X, dice4.getLocation().Y - DieWidth)); }
                    dice5 = dice6;
                    if (dice5 != null) { dice5.setLocation(new Point(dice5.getLocation().X, dice5.getLocation().Y - DieWidth)); }
                    dice6 = null;
                }
                else if (dice5 != null && dice5.getPBName() == pb)
                {
                    dice5 = dice6;
                    if (dice5 != null) { dice5.setLocation(new Point(dice5.getLocation().X, dice5.getLocation().Y - DieWidth)); }
                    dice6 = null;
                }
                else if (dice6 != null && dice6.getPBName() == pb)
                {
                    dice6 = null;
                }

                numDice--;
                
            }
        }


        public void removeAllDice()
        {
            if (dice1 != null)
            {
                dice1.setLocation(dice1.getStartLocation());
                dice1.disable();
                dice1.unLockIt();
                dice1.setPlace("Hand");
            }
            if (dice2 != null)
            {
                dice2.setLocation(dice2.getStartLocation());
                dice2.disable();
                dice2.unLockIt();
                dice2.setPlace("Hand"); 
            }
            if (dice3 != null)
            {
                dice3.setLocation(dice3.getStartLocation());
                dice3.disable();
                dice3.unLockIt();
                dice3.setPlace("Hand");
            }
            if (dice4 != null)
            {
                dice4.setLocation(dice4.getStartLocation());
                dice4.disable();
                dice4.unLockIt();
                dice4.setPlace("Hand");
            }
            if (dice5 != null)
            {
                dice5.setLocation(dice5.getStartLocation());
                dice5.disable();
                dice5.unLockIt();
                dice5.setPlace("Hand");
            }
            if (dice6 != null)
            {
                dice6.setLocation(dice6.getStartLocation());
                dice6.disable();
                dice6.unLockIt();
                dice6.setPlace("Hand");
            }
        }
       
        public int getNumDice()
        {
            return numDice;
        }

        public String getColor()
        {
            return color;
        }
        
        
       

        public bool cardWinner()
        {
            int winnerNumDice = card.numDice;

            if (winnerNumDice == numDice)
            {
                if (winnerNumDice == 2)
                {
                    if (dice1.getDice() == card.num1 && dice2.getDice() == card.num2)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (winnerNumDice == 3)
                {
                    if (dice1.getDice() == card.num1 && dice2.getDice() == card.num2 && dice3.getDice() == card.num3)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (winnerNumDice == 4)
                {
                    if (dice1.getDice() == card.num1 && dice2.getDice() == card.num2 && dice3.getDice() == card.num3 && dice4.getDice() == card.num4)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (winnerNumDice == 6)
                {
                    if (dice1.getDice() == card.num1 && dice2.getDice() == card.num2 && dice3.getDice() == card.num3 && dice4.getDice() == card.num4
                            && dice5.getDice() == card.num5 && dice6.getDice() == card.num6)
                    {

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                } else
                {
                    return false;
                } 

            }
            else
            {
                return false;
            }

        }

        public int CanWin(Dice d1, Dice d2, Dice d3, Dice d4, Dice d5, Dice d6)
        {
            //return the number of dice still needed
            int total = 0;

            bool[] slots = new bool[6];
            
            if (dice1 == null) { slots[0] = false; } else { slots[0] = true; }
            if (dice2 == null) { slots[1] = false; } else { slots[1] = true; }
            if (dice3 == null && card.numDice >= 3) { slots[2] = false; } else { slots[2] = true; }
            if (dice4 == null && card.numDice >= 4) { slots[3] = false; } else { slots[3] = true; }
            if (dice5 == null && card.numDice >= 4) { slots[4] = false; } else { slots[4] = true; }
            if (dice5 == null && card.numDice == 6) { slots[4] = false; } else { slots[4] = true; }
            if (dice6 == null && card.numDice == 6) { slots[5] = false; } else { slots[5] = true; }

           
            if (d1 != null)
            {
                if (!slots[0] && card.num1 == d1.getDice() && !d1.isLocked()) { slots[0] = true; }
                else if (!slots[1] && card.num2 == d1.getDice() && !d2.isLocked()) { slots[1] = true; }
                else if (!slots[2]   && card.num3 == d1.getDice() && !d3.isLocked()) { slots[2] = true; }
                else if (!slots[3]  && card.num4 == d1.getDice() && !d4.isLocked()) { slots[3] = true; }
                else if (!slots[4]  && card.num4 == d1.getDice() && !d5.isLocked()) { slots[4] = true; }
                else if (!slots[5]  && card.num5 == d1.getDice() && !d6.isLocked()) { slots[5] = true; }
            }

            if (d2 != null)
            {
                if (!slots[0]  && card.num1 == d2.getDice() && !d1.isLocked()) { slots[0] = true; }
                else if (!slots[1]  && card.num2 == d2.getDice() && !d2.isLocked()) { slots[1] = true; }
                else if (!slots[2]  && card.num3 == d2.getDice() && !d3.isLocked()) { slots[2] = true; }
                else if (!slots[3]  && card.num4 == d2.getDice() && !d4.isLocked()) { slots[3] = true; }
                else if (!slots[4]  && card.num5 == d2.getDice() && !d5.isLocked()) { slots[4] = true; }
                else if (!slots[5]  && card.num6 == d2.getDice() && !d6.isLocked()) { slots[5] = true; }
            }

            if (d3 != null)
            {
                if (!slots[0]  && card.num1 == d3.getDice() && !d1.isLocked()) { slots[0] = true; }
                else if (!slots[1]  && card.num2 == d3.getDice() && !d2.isLocked()) { slots[1] = true; }
                else if (!slots[2]  && card.num3 == d3.getDice() && !d3.isLocked()) { slots[2] = true; }
                else if (!slots[3]  && card.num4 == d3.getDice() && !d4.isLocked()) { slots[3] = true; }
                else if (!slots[4]  && card.num5 == d3.getDice() && !d5.isLocked()) { slots[4] = true; }
                else if (!slots[5]  && card.num6 == d3.getDice() && !d6.isLocked()) { slots[5] = true; }
            }

            if (d4 != null)
            {
                if (!slots[0]  && card.num1 == d4.getDice() && !d1.isLocked()) { slots[0] = true; }
                else if (!slots[1]  && card.num2 == d4.getDice() && !d2.isLocked()) { slots[1] = true; }
                else if (!slots[2]  && card.num3 == d4.getDice() && !d3.isLocked()) { slots[2] = true; }
                else if (!slots[3]  && card.num4 == d4.getDice() && !d4.isLocked()) { slots[3] = true; }
                else if (!slots[4]  && card.num5 == d4.getDice() && !d5.isLocked()) { slots[4] = true; }
                else if (!slots[5]  && card.num6 == d4.getDice() && !d6.isLocked()) { slots[5] = true; }
            }

            if (d5 != null)
            {
                if (!slots[0]  && card.num1 == d5.getDice() && !d1.isLocked()) { slots[0] = true; }
                else if (!slots[1]  && card.num2 == d5.getDice() && !d2.isLocked()) { slots[1] = true; }
                else if (!slots[2]  && card.num3 == d5.getDice() && !d3.isLocked()) { slots[2] = true; }
                else if (!slots[3]  && card.num4 == d5.getDice() && !d4.isLocked()) { slots[3] = true; }
                else if (!slots[4]  && card.num5 == d5.getDice() && !d5.isLocked()) { slots[4] = true; }
                else if (!slots[5] && card.num6 == d5.getDice() && !d6.isLocked()) { slots[5] = true; }
            }

            if (d6 != null)
            {
                if (!slots[0]  && card.num1 == d6.getDice() && !d1.isLocked()) { slots[0] = true; }
                else if (!slots[1]  && card.num2 == d6.getDice() && !d2.isLocked()) { slots[1] = true; }
                else if (!slots[2]  && card.num3 == d6.getDice() && !d3.isLocked()) { slots[2] = true; }
                else if (!slots[3]  && card.num4 == d6.getDice() && !d4.isLocked()) { slots[3] = true; }
                else if (!slots[4]  && card.num5 == d6.getDice() && !d5.isLocked()) { slots[4] = true; }
                else if (!slots[5]  && card.num6 == d6.getDice() && !d6.isLocked()) { slots[5] = true; }
            }

            for(int f =0; f< 6; f++)
            {
                if (slots[f])
                {
                    total++;
                }
            }

            return 6 - total;
        }

       

    }
}
