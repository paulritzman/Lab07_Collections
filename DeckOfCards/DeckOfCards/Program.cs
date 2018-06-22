using System;
using DeckOfCards.Classes;

namespace DeckOfCards
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Call PrintGreeting to welcome the user
            PrintGreeting();
            
            // Call LaunchMainMenu to start the main application logic and accept user input
            LaunchMainMenu();
        }

        // Prints a greeting to the user
        private static void PrintGreeting()
        {
            Console.WriteLine("\tWelcome to Deck Of Cards!\n");
        }

        // Prints the main menu options that the user can select
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

        // Creates a prompt for the user to hit any key to return to the main menu
        private static void PromptReturnToMenu()
        {
            Console.Write("\nPress any key to return to the main menu...");
            Console.ReadKey();
        }

        // Method to add a card to the Deck - validates user input to ensure a Card Rank and Suit match input
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

        // Remove a card from the Deck
        // Calls VerifyIndexEntered() prior to removing the card
        public static void RemoveTheCard(Deck<Card> myDeck)
        {
            Console.WriteLine(
                            "What is the index of the card you want to remove? " +
                            "(Indexing starts at zero.)");
            string inputIndex = Console.ReadLine();
            int cardIndex = VerifyIndexEntered(inputIndex);

            myDeck.RemoveCard(cardIndex);
        }

        // Verifies that the user entered a valid index within the Deck of Cards
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

        // Logic which runs the main menu and allows user to navigate throughout the application
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
