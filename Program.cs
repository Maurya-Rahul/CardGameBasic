using System;
using System.Text;

namespace MyCardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hey there, welcome to the Card play game!");
            Console.WriteLine("Please press 1 to start the game, then press enter");

            Console.OutputEncoding = Encoding.UTF8;

            GoToStart:
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.WriteLine("You have entered the Card Game. Strap your seat belt! ");
                    Card card = new Card();
                    card.LoadCards();
                    break;

                default:
                    Console.WriteLine("Oops! Wrong choice. Please try again!");
                    goto GoToStart;
            }
        }
    }
}
