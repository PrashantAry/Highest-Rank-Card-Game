using System;
using System.Collections.Generic;
// Uses Automatic .NET Properties

namespace Assigment5
{
    public abstract class Player
    {
        public string Name { get; private set; }
        public int Score { get; private set; }
        protected Hand hand;

        public Player(string name)
        {
            if(name == null)
            throw new ArgumentNullException("Player can't be null");
            if(name.Length == 0)
            throw new ArgumentException("Player cannot be empty");

            Name = name;
            Score = 0;
            hand = new Hand();
        }

        public abstract Card ChooseCardFromHand();

        public void AddCardToHand(Card card)
        {
            if (card == null)
               throw new ArgumentNullException("Cannot have null class in the hand");

            hand.AddCard(card);
        }

        public void AddPoint()
        {
            Score++;
        }       

        public override string ToString()
        {
            return $"{Name}'s Hand: {hand}";
        }

        
    }

     public class RandomPlayer:Player 
    {
        public RandomPlayer(string name) : base(name + "(Rnd)") { }

        public override Card ChooseCardFromHand()
        {
            return hand.RemoveRandomCard();
        }
    }

    public class HighestPlayer : Player
    {
        public HighestPlayer(string name) : base(name + "(Hgh)")
        { }
        public override Card ChooseCardFromHand()
        {
            return hand.RemoveHighestCard();
        }
    }
     public class MiddlePlayer : Player
    {
        public MiddlePlayer(string name) : base(name + "(Mid)") { }

        public override Card ChooseCardFromHand()
        {
            return hand.RemoveMiddleCard();
        }
    }    

     public class LowestPlayer : Player
    {
        public LowestPlayer(string name) : base(name + "(Low)") { }

        public override Card ChooseCardFromHand()
        {
            return hand.RemoveLowestCard();
        }
    }


    // -------------------------------------------------------------------------------------------

public class Hand
    { 

        private List<Card> cards;

        public Hand()
        {
                cards = new List<Card>();
        }

        public int Size()
        {
            return cards.Count;
        }

        public Stack<Card> GetCards()
        {
            return new Stack<Card>(cards);
        }

        public void AddCard(Card card)
        {
            if (card == null)
               throw new ArgumentNullException("Cannot have null class in the hand");
            cards.Add(card);
        }
        public Card RemoveRandomCard()
        {
            if (Size() == 0)
                throw new ApplicationException("ERROR: Cannot deal card for empty deck");
            Card output = cards[0];
            cards.RemoveAt(0);
            return output;
        }

        public Card RemoveHighestCard()
        {
            if (Size() == 0)
            throw new ApplicationException("Cannot deal card for empty deck");
             Card output = new Card(Rank.Ace, Suit.Diamonds);
            foreach(Card c in cards)
               if(c > output)
               {
                 output  = c;
               } 
            cards.Remove(output);
            return output;
        }

        public Card RemoveLowestCard()
        {
            if (Size() == 0)
             throw new ApplicationException("Cannot deal card for empty deck");
            Card output = new Card(Rank.King, Suit.Spades);
            foreach(Card c in cards)
               if(c < output)
               {
                 output  = c;
               } 
            cards.Remove(output);
            return output;
        }

        public Card RemoveMiddleCard()
        {
            if (Size() == 0)
             throw new ApplicationException("Cannot deal card for empty deck");
            int index = cards.Count / 2;
            Card output = cards[index];
            cards.Remove(output);
            return output;
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

            return s;
        }

    }

}