using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPlane
{
    class Program
    {
        static void Main(string[] args)
        {

            Airport airport = new Airport(new List<AirStrip>() { new AirStrip()});
            List<Plane> planes = new List<Plane>() { new Plane() };

            for (int i = 1; i < 50; i++)
            {
                planes.Add(new Plane());
            }

            for (int i = 1; i < 10; i++)
            {
                airport.AirStrips.Add(new AirStrip());
            }

            do
            {
                ControlTower.Landing(airport, planes);
                airport.AirStrips
                    .Select(x=>x.plane)
                    .ToList()
                    .ForEach(x=>planes.Remove(x));

            } while (planes.Any());



            var test = airport;
            var test2 = planes;
            Console.WriteLine("");
            Console.ReadKey();

        }
    }
}
