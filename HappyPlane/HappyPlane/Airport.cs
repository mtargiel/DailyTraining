using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPlane
{
    public class Airport
    {
        public List<AirStrip> AirStrips { get; private set; }

        public Airport(List<AirStrip> airStrips)
        {
            AirStrips = airStrips;
        }

    }
}
