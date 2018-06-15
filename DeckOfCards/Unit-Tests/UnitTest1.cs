using System;
using DeckOfCards;
using DeckOfCards.Classes;
using Xunit;

namespace Unit_Tests
{
    public class UnitTest1
    {
        [Fact]
        public void CanAddCardToDeck()
        {
            Card[] cards = new Card[1];
            Deck<Card> newDeck = new Deck<Card>();

            Card testCard = new Card((Rank)1, (Suit)1);
            newDeck.Add(testCard);

            Assert.NotEmpty(newDeck);
        }

        [Fact]
        public void CanRemoveCardFromDeck()
        {
            Card[] cards = new Card[1];
            Deck<Card> newDeck = new Deck<Card>();

            Card testCard = new Card((Rank)1, (Suit)1);
            newDeck.Add(testCard);

            newDeck.RemoveCard(0);

            Assert.Empty(newDeck);
        }

        [Fact]
        public void CanNotRemoveCardThatDoesNotExistFromDeck()
        {
            Card[] cards = new Card[1];
            Deck<Card> newDeck = new Deck<Card>();

            Card testCard = new Card((Rank)1, (Suit)1);
            newDeck.Add(testCard);

            newDeck.RemoveCard(16);

            Assert.NotEmpty(newDeck);
        }
    }
}
