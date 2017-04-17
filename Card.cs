using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollTheDice
{
    public class Card
    {

        public int points;    //points awarded to winner
        public String winner = "";    //player color who won the card and has in hand
        public int location = 0;    // 0 = deck, 1-3 = in play   4 = players hand
        public int numDice;     //number of dice need to get card

        //Number on die needed to win card.   Some may be left blank if not needed
        public int num1 =0;
        public int num2 =0;
        public int num3 =0;
        public int num4 =0;
        public int num5 =0;
        public int num6 =0;

        public String image;


        

        public Card(int points,int numDice, int num1, int num2, int num3, int num4, int num5, int num6,String image)
        {
            this.points = points;
            this.numDice = numDice;
            this.num1 = num1;
            this.num2 = num2;
            this.num3 = num3;
            this.num4 = num4;
            this.num5 = num5;
            this.num6 = num6;
            this.image = image;
        }

        public bool isOnCard(int i)
        {
            if (i == num1) { return true; }
            else if (i == num2) { return true; }
            else if (i== num3) { return true; }
            else if (i == num4) { return true; }
            else if (i == num5) { return true; }
            else if (i == num6) { return true; }
            else { return false; }
        }

        public int getDiceNumLocation(String s)
        {
           switch (s)
            {
                case "num1":
                    return num1;
                case "num2":
                    return num2;
                case "num3":
                    return num3;
                case "num4":
                    return num4;
                case "num5":
                    return num5;
                case "num6":
                    return num6;
            }
            return 0;
        }

        public void setLocation(int l)
        {
            location = l;
        }

        public string toString()
        {
            return "points = " + points + ", location = " + location + " , dice = " + num1 + "," + num2 + "," + num3 + "," + num4 + "," + num5 + "," + num6;
        }
        public int getPoints()
        {
            return points;
        }
    }
}
