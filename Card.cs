using System;
using System.Collections;
using System.Collections.Generic;

namespace MyCardGame
{
    /// <summary>
    /// provides functionality to play card game
    /// </summary>
    public class Card
    {
        public Card()
        {
            rand = new Random();
        }

        private readonly Random rand;

        private List<string> suits = new List<string>();

        private ArrayList ranks = new ArrayList();

        private List<string> cardsInPlay = new List<string>();

        private int cardsLeftInHand;

        /// <summary>
        /// method to go to initial state of the game
        /// </summary>
        void InitialState()
        {
            Console.WriteLine("          !!!!Resetting your game!!!!           ");
            suits.Clear();
            ranks.Clear();
            cardsInPlay.Clear();
            LoadCards();
        }

        /// <summary>
        /// load cards in the game!
        /// </summary>
        public void LoadCards()
        {
            Console.WriteLine("--------------Loading your cards! --------------");
            // adding the types of card
            suits.Add("♣");
            suits.Add("♥");
            suits.Add("♣");
            suits.Add("♦");

            // adding the number of cards of each type
            ranks.Add("Ace");
            ranks.Add(2);
            ranks.Add(3);
            ranks.Add(4);
            ranks.Add(5);
            ranks.Add(6);
            ranks.Add(7);
            ranks.Add(8);
            ranks.Add(9);
            ranks.Add(10);
            ranks.Add("Jack");
            ranks.Add("Queen");
            ranks.Add("King");

            LoadCards(suits, ranks);
        }

        /// <summary>
        /// private method to be called in this class only
        /// </summary>
        /// <param name="cardType"></param>
        /// <param name="myList"></param>
        private void LoadCards(List<string> cardType, ArrayList myList)
        {
            foreach (string type in cardType)
            {
                foreach (var card in myList)
                {
                    cardsInPlay.Add(type + " " + card + " " + type);
                }
            }
            cardsLeftInHand = cardsInPlay.Count;
            Console.WriteLine("------------ Yay! your cards are loaded! ---------------");
            InsertEmptyLine();
            ProvideOptionsAndPlayGame();
        }

        /// <summary>
        /// starts the actual game with providing options and playing cards
        /// </summary>
        private void ProvideOptionsAndPlayGame()
        {
            Console.WriteLine("Game started! Please see options carefully and choose properly while playing!");
            Console.WriteLine("--------------------------Starting the game--------------------------------");

            ShowGameOptions();

            Console.WriteLine("Please enter your choice! Waiting for your move!");

            ChooseOption:
            string choice = Console.ReadLine();


            switch (choice.ToLower())
            {
                case "p":
                    if (cardsLeftInHand == 0)
                        MessageWhenNocardLeft("play");
                    else
                        PlayCard(cardsInPlay);
                    InsertEmptyLine();
                    goto ChooseOption;

                case "s":
                    if (cardsLeftInHand == 0)
                        MessageWhenNocardLeft("shuffle");
                    else
                        ShuffleDeck(cardsInPlay);
                    Console.WriteLine();
                    goto ChooseOption;

                case "r":
                    RestartGame();
                    InsertEmptyLine();
                    goto ChooseOption;

                case "c":
                    if (cardsLeftInHand == 0)
                        MessageWhenNocardLeft("display");
                    else
                        DisplayCards(cardsInPlay);
                    InsertEmptyLine();
                    goto ChooseOption;

                case "h":
                    ShowGameOptions();
                    InsertEmptyLine();
                    goto ChooseOption;

                case "x":
                    Console.WriteLine("---------------------------Closing the Game--------------------------------");
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Please enter correct choice! Waiting for your move!");
                    InsertEmptyLine();
                    goto ChooseOption;
            }

        }

        /// <summary>
        /// displays cards left at hand in the order in which they are held
        /// </summary>
        /// <param name="cardsInPlay"></param>
        private void DisplayCards(List<string> cardsInPlay)
        {
            foreach (string card in cardsInPlay)
            {
                Console.WriteLine(card);
                Console.WriteLine();
            }
        }

        /// <summary>
        /// plays a card from the front of the cards left in hand
        /// </summary>
        /// <param name="cardsInPlay"></param>
        private void PlayCard(List<string> cardsInPlay)
        {
            if (cardsInPlay.Count > 0)
            {
                Console.WriteLine("You played : " + cardsInPlay[0]);
                cardsInPlay.RemoveAt(0);
                cardsLeftInHand = cardsInPlay.Count;
                Console.WriteLine("Cards left in hand : " + cardsInPlay.Count);
            }
            else
            {
                Console.WriteLine("Hey buddy! You have played all your cards! Please press R to restart the game!");
            }
        }

        /// <summary>
        /// provides the functionality to shuffle the deck of cards
        /// </summary>
        /// <param name="cardsInPlay"></param>
        private void ShuffleDeck(List<string> cardsInPlay)
        {
            if (cardsInPlay.Count == 1)
            {
                Console.WriteLine("Only one card left! Shuffling is not possible/useful!");
            }
            else
            {
                Console.WriteLine("------------- Shuffling your cards --------------");

                for (int i = 1; i < cardsInPlay.Count - 1 && cardsInPlay.Count > 1; i++)
                {
                    int m = rand.Next(0, i);
                    int n = rand.Next(0, i + 1);

                    string temp = cardsInPlay[m];
                    cardsInPlay[m] = cardsInPlay[n];
                    cardsInPlay[n] = temp;
                }

                Console.WriteLine("------------- Cards have been shuffled! Ready to play--------------");
            }
        }

        /// <summary>
        /// method to restart the game
        /// </summary>
        private void RestartGame()
        {
            InitialState();
        }

        /// <summary>
        /// method to display options for playing the game
        /// </summary>
        private void ShowGameOptions()
        {
            Console.WriteLine("Press P to Play a card!");
            Console.WriteLine("Press S to shuffle cards in hands!");
            Console.WriteLine("Press R to restart play!");
            Console.WriteLine("Press C to see your cards at hand!");
            Console.WriteLine("Press H to see your options anytime!");
            Console.WriteLine("Press X to see your options anytime!");

        }

        /// <summary>
        /// message to display when no cards are left
        /// </summary>
        /// <param name="word"></param>
        private void MessageWhenNocardLeft(string word)
        {
            Console.WriteLine("No more cards left to " + word + "! Please press R to restart the game");
        }

        /// <summary>
        /// insert empty line in console
        /// </summary>
        private static void InsertEmptyLine()
        {
            Console.WriteLine();
        }
    }
}
