using System;
using System.Collections.Generic;
using System.Text;
using SklepOdziezowy.Domena.Towar;

namespace SklepOdziezowy.Domena.Sklep
{
    class Koszyk : IKoszyk
    {
        public List<ITowar> TowarKlienta { get; set; }
        public decimal Suma = 0;
        public Koszyk()
        {
            TowarKlienta = new List<ITowar>();
        }

        public decimal SumaTowaru()
        {
            foreach (var towar in TowarKlienta)
            {
                Suma += towar.Cena * towar.Ilosc;
            }

            return Suma;
        }

    }
}
