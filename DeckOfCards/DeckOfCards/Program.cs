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
        }

        private static void PrintGreeting()
        {
            Console.WriteLine("\tWelcome to Deck Of Cards!\n");
        }

        private static void PrintMainMenuOptions()
        {
            Console.WriteLine(
                        "Please select an option below:\n" +
                        "1) View deck of cards\n" +
                        "2) Shuffle deck of cards\n" +
                        "3) Add a new card to the deck\n" +
                        "4) Remove a card from the deck\n" +
                        "5) Exit Application\n");
        }

        private static void PromptReturnToMenu()
        {
            Console.Write("\nPress any key to return to the main menu...");
            Console.ReadKey();
        }

        public static void AddACard(Deck<Card> myDeck)
        {
            Console.WriteLine(
                            "Please enter the rank for your card.\n" +
                            "Ace = 1, King = 13\n");
            string inputRank = Console.ReadLine();
            Console.Clear();

            Console.WriteLine(
                "Please enter the suit you would like you card to be.\n" +
                "Hearts = 1\n" +
                "Diamonds = 2\n" +
                "Clubs = 3\n" +
                "Spades = 4\n");
            string inputSuit = Console.ReadLine();
            Console.Clear();

            if (int.TryParse(inputRank, out int rankNum) && int.TryParse(inputSuit, out int suitNum))
            {
                if ((rankNum >= 1 && rankNum <= 13) && (suitNum >= 1 && suitNum <= 4))
                {
                    myDeck.Add(new Card((Rank)rankNum, (Suit)suitNum));
                }
                else
                {
                    Console.WriteLine("Sorry, you didn't enter valid rank/suit numbers.\n");
                }
            }
            else
            {
                Console.WriteLine("Sorry, you didn't enter valid integers for the rank/suit.\n");
            }
        }

        public static void RemoveTheCard(Deck<Card> myDeck)
        {
            Console.WriteLine(
                            "What is the index of the card you want to remove? " +
                            "(Indexing starts at zero.)");
            string inputIndex = Console.ReadLine();
            int cardIndex = VerifyIndexEntered(inputIndex);

            myDeck.RemoveCard(cardIndex);
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
                        myDeck.ShuffleDeck();

                        myDeck.PrintDeck(myDeck);
                        PromptReturnToMenu();
                        Console.Clear();
                        break;
                    case "3":
                        AddACard(myDeck);

                        myDeck.PrintDeck(myDeck);
                        PromptReturnToMenu();
                        Console.Clear();
                        break;
                    case "4":
                        RemoveTheCard(myDeck);

                        myDeck.PrintDeck(myDeck);
                        PromptReturnToMenu();
                        Console.Clear();
                        break;
                    case "5":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Your selection did not match one of the options below...\n");
                        break;
                }
            } while (menuOptionSelected != "5");
        }
    }
}
