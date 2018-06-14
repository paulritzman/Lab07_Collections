using System;
using System.Collections.Generic;
using System.Text;

namespace DeckOfCards.Classes
{
    class Card
    {
        public int Rank { get; set; }

        public Suit Suit {get; set;}
    }

    enum Suit
    {
        Hearts,
        Diamonds,
        Clubs,
        Spades
    }

}
