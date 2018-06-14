using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DeckOfCards.Classes
{
    class Deck<T> : IEnumerable
    {
        // One more than half a standard card deck, so that half of a deck can
        // be stored without needing to allocate additional memory
        T[] cards = new T[27];

        int count;

        public void Add(T card)
        {
            if (count == cards.Length)
            {
                Array.Resize(ref cards, cards.Length * 2);
            }

            cards[count++] = card;
        }
        
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
