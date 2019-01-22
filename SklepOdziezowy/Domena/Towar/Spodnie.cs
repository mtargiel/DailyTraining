using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace SklepOdziezowy.Domena.Towar
{
    class Spodnie : ITowar
    {
        public decimal Cena { get; set; }
        public int Ilosc { get; set; }
        public string Typ { get; set; }
        public string Fason { get; set; }
        public Color Kolor { get; set; }
        public short Rozmiar { get; set; }

        public override string ToString()
        {
            return Rozmiar + " " + Kolor + " " + Fason + " " + Typ + " " + Cena;
        }
    }
}
