using System;
using static System.Console;
using System.Collections.Generic;

namespace Assigment5
{
    class Program
    {
        static void Main(string[] args)
        {
             List<Player> players = new List<Player>
            {                
                new HighestPlayer("Paul"),
                new LowestPlayer("Tom"),
                new MiddlePlayer("Pat"),
                new RandomPlayer("Susan")
            };
            

           Console.WriteLine("\nHighest Rank Wins! Card Game Simulation");
            WriteLine("=================================================");

            Deck theDeck = new Deck();
            WriteLine($"\nHere's the new deck of cards:\n{theDeck}");

            theDeck.Shuffle();
            WriteLine($"\nHere's the shuffled deck of cards:\n{theDeck}");

            int numRounds = theDeck.Size() / players.Count;

            // Deal the cards

            while (theDeck.Size() >= players.Count)
            {
                foreach (Player player in players)
                {
                    player.AddCardToHand(theDeck.DealCard());
                }
            }          
            

            // Display each players starting hand
            WriteLine("\nAnd here are our players and their hands:");
            foreach (Player player in players)
            {
                WriteLine(player);
            }

            //int i = 0;
            // Play the game
            for (int round = 1; round <= numRounds; round++)
            {
                WriteLine($"\nStarting round #{round}...");
         
                Card maxCard = new Card(Rank.Ace, Suit.Diamonds);
                Player winner = null;
               
                foreach (Player player in players)
                {                     
                    Card cardPlayed = player.ChooseCardFromHand();
                    WriteLine($"{player.Name} played the {cardPlayed}");
                    if (cardPlayed > maxCard)
                    {
                        maxCard = cardPlayed;
                        winner = player;

                    }                    
                }          

                WriteLine($"{winner.Name} got a point for playing {maxCard}");
                winner.AddPoint();

                WriteLine($"Round #{round} is complete.");
            }


            WriteLine("\n============== Game Over! =================\n");

            WriteLine("Final Scores:");
            WriteLine("--------------------------");
            foreach (Player player in players)
            {
                WriteLine($"{player.Name} has {player.Score} points");
            }

            int winningScore = 0;
            foreach (Player player in players)
            {
                if (player.Score > winningScore)
                    winningScore = player.Score;
            }

            string ampersand = "";
            string winnerNames = "";
            foreach (Player player in players)
            {
                if (player.Score == winningScore)
                {
                    winnerNames += $"{ampersand}{player.Name}";
                    ampersand = " & ";
                }
            }

            WriteLine();
            if (winnerNames.Contains("&"))
                WriteLine($"It's a tie! With {winningScore} points, the winners are {winnerNames}!");
            else
                WriteLine($"The winner is {winnerNames} with {winningScore} points!");
            WriteLine();
        }

    }

}