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

        [Fact]
        public void CanShuffleDeck()
        {
            Deck<Card> newDeck = new Deck<Card>();

            newDeck.Add(new Card((Rank)1, (Suit)1));
            newDeck.Add(new Card((Rank)2, (Suit)1));
            newDeck.Add(new Card((Rank)3, (Suit)1));
            newDeck.Add(new Card((Rank)4, (Suit)1));
            newDeck.Add(new Card((Rank)5, (Suit)1));
            newDeck.Add(new Card((Rank)6, (Suit)1));
            newDeck.Add(new Card((Rank)7, (Suit)1));
            newDeck.Add(new Card((Rank)8, (Suit)1));
            newDeck.Add(new Card((Rank)9, (Suit)1));
            newDeck.Add(new Card((Rank)10, (Suit)1));
            newDeck.Add(new Card((Rank)11, (Suit)1));
            newDeck.Add(new Card((Rank)12, (Suit)1));
            newDeck.Add(new Card((Rank)13, (Suit)1));

            Card[] preShuffleDeck = newDeck.ShuffleDeck();
            Card[] postShuffleDeck = newDeck.ShuffleDeck();

            Card preShuffleCard = preShuffleDeck[0];
            Card postShuffleCard = postShuffleDeck[0];
            int count = 1;

            while ((preShuffleCard == null || postShuffleCard == null) && count < 12)
            {
                preShuffleCard = preShuffleDeck[count];
                postShuffleCard = postShuffleDeck[count];
                count++;
            }

            Assert.NotEqual(preShuffleCard.Rank.ToString(), postShuffleCard.Rank.ToString());
        }

        [Theory]
        [InlineData(1, "Ace")]
        [InlineData(10, "Ten")]
        [InlineData(12, "Queen")]
        [InlineData(13, "King")]
        public void CanGetAndSetCardRank(int cardRank, string stringRank)
        {
            Card testCard = new Card((Rank)cardRank, (Suit)1);

            Assert.Equal(testCard.Rank.ToString(), stringRank);
        }

        [Theory]
        [InlineData(1, "Hearts")]
        [InlineData(2, "Diamonds")]
        [InlineData(3, "Clubs")]
        [InlineData(4, "Spades")]
        public void CanGetAndSetCardSuit(int cardSuit, string stringSuit)
        {
            Card testCard = new Card((Rank)1, (Suit)cardSuit);

            Assert.Equal(testCard.Suit.ToString(), stringSuit);
        }
    }
}
