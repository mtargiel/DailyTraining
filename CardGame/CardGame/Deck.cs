using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class Deck
    {
        private int _pikAmount;
        private int _kierAmount;
        private int _treflAmount;
        private int _karoAmount;

        public int PikAmount
        {
            get => _pikAmount;
            set
            {
                if (value<14)
                    _pikAmount = value;
                else
                {
                   new ArgumentOutOfRangeException();
                }
            } 
        }

        public int KierAmount
        {
            get => _kierAmount;
            set
            {
                if (value < 14)
                    _kierAmount = value;
                else
                {
                    new ArgumentOutOfRangeException();
                }
            }
        }

        public int TreflAmount
        {
            get => _treflAmount;
            set
            {
                if (value < 14)
                    _treflAmount = value;
                else
                {
                    new ArgumentOutOfRangeException();
                }
            }
        }

        public int KaroAmount
        {
            get => _karoAmount;
            set
            {
                if (value < 14)
                    _karoAmount = value;
                else
                {
                    new ArgumentOutOfRangeException();
                }
            }
        }

        List<Cards> GetAllCardsFromDeck()
        {
            List<Cards> cards = new List<Cards>();
            for (int i = 0; i < PikAmount; i++)
            {
                cards.Add(Cards.Pik);
            }

            for (int i = 0; i < KierAmount; i++)
            {
                cards.Add(Cards.Kier);
            }

            for (int i = 0; i < TreflAmount; i++)
            {
                cards.Add(Cards.Trefl);
            }

            for (int i = 0; i < KaroAmount; i++)
            {
                cards.Add(Cards.Karo);
            }

            return cards;
        }

        public List<Cards> GetTwoRandomCardsFromDeck()
        {
            var Cards = GetAllCardsFromDeck();
            Random rand = new Random();
            int firstCard = rand.Next(0, Cards.Count);
            int secondCard = rand.Next(0, Cards.Count);

            if (firstCard == secondCard)
            {
                do
                {
                    secondCard = rand.Next(0, Cards.Count);
                } while (firstCard.Equals(secondCard));
            }

            return new List<Cards>() { Cards[firstCard], Cards[secondCard]};
        }

    }
}
