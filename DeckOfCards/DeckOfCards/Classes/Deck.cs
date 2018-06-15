using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DeckOfCards.Classes
{
    public class Deck<T> : IEnumerable
    {
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

        public void ShuffleDeck()
        {
            int randomIndex;
            Random rand = new Random();

            int[] randArray = new int[cards.Length];
            T[] tempArray = new T[cards.Length];

            for (int k = 0; k < randArray.Length; k++)
            {
                randArray[k] = -1;
            }

            for (int i = 0; i < cards.Length; i++)
            {
                do
                {
                    randomIndex = rand.Next(0, cards.Length);
                }
                while (Array.IndexOf(randArray, randomIndex) != -1);
                
                randArray[i] = randomIndex;
            }

            for (int j = 0; j < cards.Length; j++)
            {
                tempArray[j] = cards[randArray[j]];
            }

            cards = tempArray;
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
    }
}
