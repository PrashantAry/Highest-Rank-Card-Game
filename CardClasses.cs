using System;
using System.Collections.Generic;

// Uses Automatic .NET Properties

namespace Assigment5
{
    public enum Suit { Diamonds, Clubs, Hearts, Spades };
    public enum Rank { Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King };

    // -------------------------------------------------------------------------------------------


    public class Card : IComparable
    {
        public Rank Rank { get; private set; }
        public Suit Suit { get; private set; }

        public Card(Rank rank, Suit suit)
        {
            this.Suit = suit;
            this.Rank = rank;
        }

        public int CompareTo(object obj)
        {
            Card c = obj as Card;
            if (c == null)
                throw new ArgumentException("Invalid comparison to Card. Object is not a Card.");

            int result = 0;
            if (this.Rank > c.Rank)

                result = 1;
            else if (this.Rank < c.Rank)

                result = -1;

            else if (this.Suit > c.Suit)

                result = 1;

            else if (this.Suit < c.Suit)

                result = -1;


            else

                result = 0;

            return result;
        }



        // OPTIONAL COMPARISON OPERATOR OVERRIDES

        public static bool operator <(Card c1, Card c2)
        {
            return c1.CompareTo(c2) < 0;
        }

        public static bool operator >(Card c1, Card c2)
        {
            return c1.CompareTo(c2) > 0;
        }



        public override string ToString()

        {

            return ("[" + Rank + " of " + Suit + "]");

        }

    }
    // -------------------------------------------------------------------------------------------

    public class Deck
    {
        private Stack<Card> cards;

        public Deck()
        {
            Array suits = Enum.GetValues(typeof(Suit));
            Array ranks = Enum.GetValues(typeof(Rank));
            cards = new Stack<Card>();

            foreach (Suit suit in suits)
            {
                foreach (Rank rank in ranks)
                {
                    Card card = new Card(rank, suit);
                    cards.Push(card);
                }
            }

        }

        public int Size()
        {
            return cards.Count;
        }

        public void Shuffle()
        {
            Random rng = new Random();

            int deckSize = Size();
            if (deckSize == 0) return;                    // Cannot shuffle an empty deck

            // Fisher-Yates Shuffle (modern algorithm)
            //   - http://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle
            Card[] cardsToArray = cards.ToArray();
            for (int i = 0; i < deckSize; i++)
            {
                int j = rng.Next(i, deckSize);
                Card c = cardsToArray[i];
                cardsToArray[i] = cardsToArray[j];
                cardsToArray[j] = c;
            }
            cards = new Stack<Card>(cardsToArray);
        }

        public Card DealCard()
        {
            if (Size() == 0)
                throw new ApplicationException("Cannot deal card for empty deck");
            return cards.Pop();
        }

        public override string ToString()
        {
            string s = "[";
            string comma = "";
            foreach (Card c in cards)
            {
                s += comma + c.ToString();
                comma = ", ";
            }
            s += "]";
            s += "\n " + Size() + " cards in deck.\n";

            return s;
        }
    }
}