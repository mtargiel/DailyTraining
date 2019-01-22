using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using SklepOdziezowy.Domena.Towar;

namespace SklepOdziezowy.Domena.Sklep
{
    class Sklep : ISklep
    {
        public IKoszyk Koszyk { get; set; }
        public List<ITowar> Towar { get; set; }

        public Sklep()
        {
            Towar = new List<ITowar>()
            {
                new Sukienka() {Cena = 200, Fason = "Koktailowa", Kolor = Color.AliceBlue, Rozmiar = 40},
                new Sukienka() {Cena = 202, Fason = "Wieczorowa", Kolor =  Color.Black, Rozmiar = 50},
                new Sukienka() {Cena = 1000, Fason = "Ślubna", Kolor = Color.Cornsilk, Rozmiar = 39},
                new Buty() {Cena = 200, Kolor = Color.Black, Rozmiar = 42, Rodzaj = "Zimowe", Wiazanie = true, Zapinane = false},
                new Buty() {Cena = 213, Kolor = Color.Black, Rozmiar = 40, Rodzaj = "Balerinki", Wiazanie = false, Zapinane = false},
                new Buty() {Cena = 221, Kolor = Color.Azure, Rozmiar = 50, Rodzaj = "Klapki", Wiazanie = false, Zapinane = false},
                new Kurtka() {Cena = 1000, Kolor = Color.BlueViolet, Rozmiar = 44, Kaptur = false, Skora = false, Wodoodpornosc = false},
                new Kurtka(){Cena = 90, Kolor = Color.Aqua, Rozmiar = 50, Kaptur = true, Skora = false, Wodoodpornosc = true},
                new Kurtka(){Cena =242, Kolor = Color.Black, Rozmiar = 41, Kaptur = false, Skora = true, Wodoodpornosc = false},
                new Spodnie() {Cena = 123, Kolor = Color.Blue, Rozmiar = 30, Fason = "Jakies", Typ = "Jeans"},
                new Spodnie(){Cena = 400, Kolor = Color.Black, Rozmiar = 50, Fason = "xD", Typ = "Slim"},
                new Spodnie() {Cena = 20, Kolor = Color.Wheat, Rozmiar = 33, Fason = "omg", Typ = "Leginsy"}
            };
        }

    }
}
