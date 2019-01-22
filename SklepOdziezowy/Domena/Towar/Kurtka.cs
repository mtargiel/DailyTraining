using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace SklepOdziezowy.Domena.Towar
{
    class Kurtka : ITowar
    {
        public decimal Cena { get; set; }
        public int Ilosc { get; set; }
        public Color Kolor { get; set; }
        public bool Kaptur { get; set; }
        public bool Wodoodpornosc { get; set; }
        public short Rozmiar { get; set; }
        public bool Skora { get; set; }

        public override string ToString()
        {
            return Rozmiar + " " + Skora + " " + Wodoodpornosc + " " + Kaptur + " " + Kolor + " " + Cena;
        }
    }
}
