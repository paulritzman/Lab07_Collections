using System;
using DeckOfCards.Classes;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck<Card> myDeck = new Deck<Card>();

            //myDeck.AddCard(Card newCard);

            

            // Deck<Card> secondDeck = new Deck<Card> { c };
        }

        static void DeckExample()
        {
            //Card card = new Card();
            //card.Suit = Suit.Spades;
            //card.Rank = 14;

            Card c = new Card
            {
                Suit = Suit.Spades,
                Rank = 14,
            };

            Deck<Card> secondDeck = new Deck<Card> { c };
        }



    }
}
