using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Xml.Schema;
using SklepOdziezowy.Domena.Klient;
using SklepOdziezowy.Domena.Sklep;
using SklepOdziezowy.Domena.Towar;

namespace SklepOdziezowy
{
    class Program
    {
        static Klient klient;
        static void Main(string[] args)
        {
            Console.WriteLine("Witojcie na szaberplacu! Wyber se co tam chcesz! Momy");
            klient = new Klient(new Koszyk());
            Menu();

            Console.ReadKey();
        }

        private static void Menu()
        {
            Sklep sklep = new Sklep();

            var types = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(x => x.IsInterface == false && x.Namespace.StartsWith("SklepOdziezowy.Domena.Towar")).ToList();
            foreach (var type in types)
            {
                Console.WriteLine(type.Name);
            }

            Console.WriteLine("Napisz co chcesz");

            string result = Console.ReadLine();

            result = result.Trim().ToUpper();
            switch (result)
            {
                case "SPODNIE":
                    {
                        WyswietlTowar(sklep.Towar.Where(x => x.GetType() == typeof(Spodnie)).ToList());
                        break;
                    }
                case "SUKIENKA":
                    {
                        WyswietlTowar(sklep.Towar.Where(x => x.GetType() == typeof(Sukienka)).ToList());

                        break;
                    }
                case "BUTY":
                    {
                        WyswietlTowar(sklep.Towar.Where(x => x.GetType() == typeof(Buty)).ToList());
                        break;
                    }
                case "KURTKA":
                    {
                        WyswietlTowar(sklep.Towar.Where(x => x.GetType() == typeof(Kurtka)).ToList());
                        break;
                    }
            }
        }

        private static void WyswietlTowar(List<ITowar> towary)
        {
            foreach (var towar in towary)
            {
                Console.WriteLine(towary.IndexOf(towar) + " " + towar);
            }

            Kup(towary);
        }

        private static void Kup(List<ITowar> towary)
        {
            Console.WriteLine("Co chcesz?");
            int CoChcesz = int.Parse(Console.ReadLine());
            Console.WriteLine("Wiela tego chcesz?");
            int Wiela = int.Parse(Console.ReadLine());
            var kupowane = (towary[CoChcesz]);
            kupowane.Ilosc = Wiela;
            klient.Koszyk.TowarKlienta.Add(kupowane);

            Console.WriteLine("Do zapłaty: " + klient.Koszyk.SumaTowaru() + " Wyjście wybierz X");
            string reakcja = Console.ReadLine();
            if (reakcja == "X")
                Environment.Exit(0);
 
             Menu();
        }
    }

}
