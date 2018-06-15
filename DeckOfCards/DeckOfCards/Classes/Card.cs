using System;
using System.Collections.Generic;
using System.Text;

namespace DeckOfCards.Classes
{
    public class Card
    {
        public Rank Rank { get; set; }

        public Suit Suit {get; set;}

        public Card(Rank rank, Suit suit)
        {
            Rank = rank;
            Suit = suit;
        }
    }

    public enum Suit
    {
        Hearts = 1,
        Diamonds = 2,
        Clubs = 3,
        Spades = 4,
    }

    public enum Rank
    {
        Ace = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13,
    }
}
