using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Cards;

namespace CardGame
{
    public class Game
    {
        public string GamesResult(List<Cards> cardsPair)
        {
            if (cardsPair.Contains(Kier))
            {
                if (cardsPair.Contains(Karo))
                {
                    return "Sukces";
                }

                if (cardsPair.Contains(Trefl) || cardsPair.Contains(Pik))
                {
                    return "Porażka";
                }

                return "Sukces";
            }

            if (cardsPair.Contains(Karo))
            {
                if (cardsPair.Contains(Trefl) || cardsPair.Contains(Pik))
                {
                    return "Porażka";
                }

                return "Remis";
            }

            return "Porażka";
        }
    }
}
