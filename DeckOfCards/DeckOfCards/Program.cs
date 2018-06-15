using System;
using DeckOfCards.Classes;

namespace DeckOfCards
{
    public class Program
    {
        public static void Main(string[] args)
        {
            PrintGreeting();

            LaunchMainMenu();

            //Deck<Card> myDeck = new Deck<Card>();
            //myDeck.AddCard(Card newCard);
            // Deck<Card> secondDeck = new Deck<Card> { c };
        }

        private static void PrintGreeting()
        {
            Console.WriteLine("\tWelcome to Tic-Tac-Toe!\n");
        }

        private static void PrintMainMenuOptions()
        {
            Console.WriteLine(
                        "Please select an option below:\n" +
                        "1) View deck of cards\n" +
                        "2) Shuffle deck of cards\n" +
                        "3) Remove a card from the deck\n" +
                        "4) Exit Application\n");
        }

        private static void PromptReturnToMenu()
        {
            Console.Write("\nPress any key to return to the main menu...");
            Console.ReadKey();
        }

        public static void LaunchMainMenu()
        {
            string menuOptionSelected = "";

            Deck<Card> myDeck = new Deck<Card>();
            myDeck = myDeck.CreateDeck();

            do
            {
                menuOptionSelected = "";
                PrintMainMenuOptions();
                menuOptionSelected = Console.ReadLine();
                Console.Clear();

                switch (menuOptionSelected)
                {
                    case "1":
                        myDeck.PrintDeck(myDeck);
                        PromptReturnToMenu();
                        Console.Clear();
                        break;
                    case "2":
                        PromptReturnToMenu();
                        Console.Clear();
                        break;
                    case "3":
                        Console.WriteLine(
                            "What is the index of the card you want to remove? " +
                            "(Indexing starts at zero.)");
                        string inputIndex = Console.ReadLine();
                        int cardIndex = VerifyIndexEntered(inputIndex);
                        myDeck.RemoveCard(cardIndex);
                        myDeck.PrintDeck(myDeck);

                        PromptReturnToMenu();
                        Console.Clear();
                        break;
                    case "4":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Your selection did not match one of the options below...\n");
                        break;
                }
            } while (menuOptionSelected != "4");
        }

        private static int VerifyIndexEntered(string inputIndex)
        {
            try
            {
                int verifiedIndex = int.Parse(inputIndex);

                return verifiedIndex;
            }
            catch
            {
                return -1;
            }
        } 



    }
}
