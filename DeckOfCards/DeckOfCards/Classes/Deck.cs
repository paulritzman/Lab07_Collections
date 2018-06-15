using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DeckOfCards.Classes
{
    public class Deck<T> : IEnumerable
    {
        // One more than half a standard card deck, so that half of a deck can
        // be stored without needing to allocate additional memory
        T[] cards = new T[16];

        int count;

        public Deck<Card> CreateDeck()
        {
            Random rand = new Random();

            Deck<Card> newDeck = new Deck<Card>();

            for (int i = 0; i < cards.Length - 1; i++)
            {
                int randRank = rand.Next(1, 14);
                int randSuit = rand.Next(1, 5);

                newDeck.Add(new Card((Rank)randRank, (Suit)randSuit));
            }

            return newDeck;
        }

        public void Add(T card)
        {
            if (count == cards.Length)
            {
                Array.Resize(ref cards, cards.Length * 2);
            }

            cards[count++] = card;
        }

        public void RemoveCard(int index)
        {
            if (index >= 0 && index < cards.Length)
            {
                for (int i = index; i < cards.Length; i++)
                {
                    if (cards[i + 1] != null)
                    {
                        cards[i] = cards[i + 1];
                    }
                    else
                    {
                        cards[i] = default(T);
                        count--;
                        return;
                    }
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("No card exists at that index.\n");
            }
        }

        public void PrintDeck(Deck<Card> inputDeck)
        {
            foreach (Card c in inputDeck)
            {
                if (c != null)
                {
                    Console.WriteLine($"{c.Rank} of {c.Suit}");
                }
            }
        }



















        // IEnumerator Declarations
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return cards[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        //static void DeckExample()
        //{
        //Card card = new Card();
        //card.Suit = Suit.Spades;
        //card.Rank = 14;

        //Card c = new Card
        //{
        //    Suit = Suit.Spades,
        //    Rank = 14,
        //};

        //Deck<Card> secondDeck = new Deck<Card> { c };
        //}
    }
}
