using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RollTheDice
{
    public class Dice
    {
        int start = 1;
        int end = 7;

        int current = 1;
        bool locked = false;
        Point location;
        String color;
        Point startLocation;
        String place = "hand";
        String pbName ="";
        bool enabled = true;
        bool movedBackToHand = false;

        public Dice()
        {

        }

        public Dice(int a,int b)
        {
            start = a;
            end = b;

        }

        public Dice(int a, int b,Point location)
        {
            start = a;
            end = b;
            this.location = location;
        }

        public Dice(int a,int b, Point location, String color,String pbName)
        {
            start = a;
            end = b;
            this.location = location;
            this.color = color;
            this.pbName = pbName;
            startLocation = location;
        }

        public void rollDice(Random rnd)
        {
            current = rnd.Next(start, end);
           
        }

        public int getDice()
        {
            return current;
        }

        public bool isLocked()
        {
            return locked;
        }

        public void lockIt()
        {
            locked = true;
        }
        public void unLockIt()
        {
            locked = false;
        }
        public void setLocation(Point p)
        {
            location = p;
        }
        public Point getLocation()
        {
            return location;
        }

        public void setPlace(String p)
        {
            place = p;
        }

        public String getPlace()
        {
            return place;
        }
      
        public String getPBName()
        {
            return pbName;
        }
        public void disable()
        {
            enabled = false;
        }
        public void reEnable()
        {
            enabled = true;
        }

        public bool isEnabled()
        {
            return enabled;
        }
        public Point getStartLocation()
        {
            return startLocation;
        }
        public bool getMovedBackToHand()
        {
            return movedBackToHand;
        }
        public void CannotMove()
        {
            movedBackToHand = true;
        }
        public void CanMove()
        {
            movedBackToHand = false;
        }
    }
}
