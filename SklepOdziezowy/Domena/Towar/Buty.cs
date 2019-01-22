using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace SklepOdziezowy.Domena.Towar
{
    class Buty : ITowar
    {
        public decimal Cena { get; set; }
        public int Ilosc { get; set; }
        public string Rodzaj { get; set; }
        public short Rozmiar { get; set; }
        public Color Kolor { get; set; }
        public bool Wiazanie { get; set; }
        public bool Zapinane { get; set; }

        public override string ToString()
        {
            return Zapinane + " " + Wiazanie + " " + Kolor + " " + Rozmiar + " " + Rodzaj + " " + Cena;
        }
    }
}
