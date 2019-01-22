using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPlane
{
    public static class ControlTower
    {


        public static void Landing(Airport airport, List<Plane> planes)
        {
            foreach (var plane in planes)
            {
                foreach (var airportAirStrip in airport.AirStrips)
                {
                    if (airportAirStrip.HourToReleaseAirStrip == 0 && plane.OnAir)
                    {
                        airportAirStrip.plane = plane;
                    }

                    if (airportAirStrip.plane != null && airportAirStrip.HourToReleaseAirStrip>=0)
                        airportAirStrip.HourToReleaseAirStrip--;

                    plane.Fuel--;
                    if (plane.Fuel <= 0)
                        throw new ArgumentOutOfRangeException("No fuel!");
                }
            }
        }
    }
}
