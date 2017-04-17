using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollTheDice
{
    public class Deck
    {

        List<Card> deckList = new List<Card>();



        public Deck()
        {
            //populate deck and shuffle
            deckList.Add(new Card(2, 2, 1, 1, 0, 0, 0, 0, "img1.jpg"));
            deckList.Add(new Card(2, 2, 2, 2, 0, 0, 0, 0, "img2.jpg"));
            deckList.Add(new Card(2, 2, 3, 3, 0, 0, 0, 0, "img3.jpg"));
            deckList.Add(new Card(2, 2, 4, 4, 0, 0, 0, 0, "img4.jpg"));
            deckList.Add(new Card(2, 2, 5, 5, 0, 0, 0, 0, "img5.jpg"));
            deckList.Add(new Card(2, 2, 6, 6, 0, 0, 0, 0, "img6.jpg"));

            deckList.Add(new Card(5, 3, 1, 1, 1, 0, 0, 0, "img7.jpg"));
            deckList.Add(new Card(5, 3, 2, 2, 2, 0, 0, 0, "img8.jpg"));
            deckList.Add(new Card(5, 3, 3, 3, 3, 0, 0, 0, "img9.jpg"));
            deckList.Add(new Card(5, 3, 4, 4, 4, 0, 0, 0, "img10.jpg"));
            deckList.Add(new Card(5, 3, 5, 5, 5, 0, 0, 0, "img11.jpg"));
            deckList.Add(new Card(5, 3, 6, 6, 6, 0, 0, 0, "img12.jpg"));
            deckList.Add(new Card(5, 3, 1, 2, 6, 0, 0, 0, "img13.jpg"));
            deckList.Add(new Card(5, 3, 2, 4, 6, 0, 0, 0, "img14.jpg"));
            deckList.Add(new Card(5, 3, 1, 3, 5, 0, 0, 0, "img15.jpg"));

            deckList.Add(new Card(10, 4, 1, 2, 3, 4, 0, 0, "img16.jpg"));
            deckList.Add(new Card(10, 4, 3, 4, 5, 6, 0, 0, "img17.jpg"));
            deckList.Add(new Card(10, 4, 1, 1, 2, 2, 0, 0, "img18.jpg"));
            deckList.Add(new Card(10, 4, 3, 3, 4, 4, 0, 0, "img19.jpg"));
            deckList.Add(new Card(10, 4, 5, 5, 6, 6, 0, 0, "img20.jpg"));
            deckList.Add(new Card(10, 4, 2, 2, 4, 4, 0, 0, "img21.jpg"));
            deckList.Add(new Card(10, 4, 5, 5, 6, 6, 0, 0, "img22.jpg"));
            deckList.Add(new Card(10, 4, 2, 2, 2, 2, 0, 0, "img23.jpg"));

            deckList.Add(new Card(15, 6, 1, 1, 1, 1, 1, 1, "img24.jpg"));
            deckList.Add(new Card(15, 6, 2, 2, 2, 2, 2, 2, "img25.jpg"));
            deckList.Add(new Card(15, 6, 3, 3, 3, 3, 3, 3, "img26.jpg"));
            deckList.Add(new Card(15, 6, 4, 4, 4, 4, 4, 4, "img27.jpg"));
            deckList.Add(new Card(15, 6, 5, 5, 5, 5, 5, 5, "img28.jpg"));
            deckList.Add(new Card(15, 6, 6, 6, 6, 6, 6, 6, "img29.jpg"));
            deckList.Add(new Card(15, 6, 1, 2, 3, 4, 5, 6, "img30.jpg"));



           

            int n = deckList.Count;
            Random rnd = new Random();
            while (n > 1)
            {
                int k = (rnd.Next(0, n) % n);
                n--;
                Card value = deckList[k];
                deckList[k] = deckList[n];
                deckList[n] = value;
            }
            
        }

        public Card drawCard()
        {
            Card c = deckList[0];
            deckList.RemoveAt(0);
            return c;
        }

       

    }
}
