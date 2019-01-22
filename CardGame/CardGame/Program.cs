using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wybierz poziom trudności");
            Console.WriteLine("1 - słaba, 2 - normalna, 3 - silna");

            string poziom;
            poziom = Console.ReadLine();
            int serduszko = 0;
            int poduszka = 0;
            int koniczynka = 0;
            int strzalka = 0;
            switch (poziom)
            {
                case "1":
                    {
                        serduszko = 3;
                        break;
                    }
                case "2":
                    {
                        serduszko = 6;
                        break;
                    }
                case "3":
                    {
                        serduszko = 9;
                        break;
                    }
                default:
                    Console.WriteLine("Wybrano złą opcję, zostanie przeprowadzone słabe");
                    goto case "1";

            }

            Console.WriteLine("Wybierz poziom, 1 - łatwy, 2 - normalny, 3 - ryzykowny, 4 - heroiczny");

            poziom = Console.ReadLine();

            switch (poziom)
            {
                case "1":
                {
                    serduszko += 2;
                    koniczynka += 4;
                    poduszka += 3;
                    break;
                }
                case "2":
                {
                    koniczynka += 6;
                    poduszka += 3;
                    break;
                }
                case "3":
                {
                    serduszko -= 2;
                    koniczynka += 8;
                    poduszka += 3;
                    break;
                }
                case "4":
                {
                    serduszko -= 4;
                    koniczynka += 13;
                    poduszka += 5;
                    strzalka = 7;
                    break;
                }
                default:
                {
                    Console.WriteLine("Wybrano złą opcję, zostanie przeprowadzone łatwe");
                    goto case "1";
                }
            }

            List<string> wszystkie = new List<string>();

            int result = serduszko / 3;

            koniczynka -= result;

            for (int i = 0; i <= serduszko; i++)
            {
                wszystkie.Add("serduszko");
            }
            for (int j = 0; j <= koniczynka; j++)
            {
                wszystkie.Add("koniczynka");
            }

            for (int k = 0; k <= poduszka; k++)
            {
                wszystkie.Add("poduszka");
            }

            for (int i = 0; i <= strzalka; i++)
            {
                wszystkie.Add("strzalka");
            }

            Random rand = new Random();
            int pierwszaKarta = rand.Next(0, wszystkie.Count);
            int drugaKarta = rand.Next(0, wszystkie.Count);

            if (pierwszaKarta == drugaKarta)
            {
                do
                {
                  drugaKarta = rand.Next(0, wszystkie.Count);
                } while (pierwszaKarta.Equals(drugaKarta));
            }


            if (wszystkie[pierwszaKarta] == "serduszko")
            {
                Console.WriteLine("serduszko");
                if (wszystkie[drugaKarta] == "serduszko")
                {
                    Console.WriteLine("serduszko");
                    Console.WriteLine("SUKCES");
                }
                else if (wszystkie[drugaKarta] == "koniczynka" || wszystkie[drugaKarta] == "strzalka")
                {
                    Console.WriteLine(wszystkie[drugaKarta]);
                    Console.WriteLine("Remis");
                }
                else
                {
                    Console.WriteLine("poduszka");
                    Console.WriteLine("Sukces");
                }
            }
            else if (wszystkie[pierwszaKarta] == "koniczynka" || wszystkie[pierwszaKarta] == "strzalka")
            {
                Console.WriteLine(wszystkie[pierwszaKarta]);
                if (wszystkie[drugaKarta] == "serduszko")
                {
                    Console.WriteLine("serduszko");
                    Console.WriteLine("Remis");
                }
                else if (wszystkie[drugaKarta] == "poduszka")
                {
                    Console.WriteLine("poduszka");
                    Console.WriteLine("Porażka");
                }
                else
                {
                    Console.WriteLine(wszystkie[drugaKarta]);
                    Console.WriteLine("Porażka");
                }
            }
            else if (wszystkie[pierwszaKarta] == "poduszka")
            {
                Console.WriteLine("poduszka");
                if (wszystkie[drugaKarta] == "serduszko")
                {
                    Console.WriteLine("serduszko");
                    Console.WriteLine("Sukces");
                }
                else if (wszystkie[drugaKarta] == "koniczynka" || wszystkie[drugaKarta] == "strzalka")
                {
                    Console.WriteLine(wszystkie[drugaKarta]);
                    Console.WriteLine("Porażka");
                }
                else
                {
                    Console.WriteLine("poduszka");
                    Console.WriteLine("Remis");
                }
            }
      
            Console.ReadKey();

        }
    }
}
