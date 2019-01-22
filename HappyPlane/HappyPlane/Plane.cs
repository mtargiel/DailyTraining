using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPlane
{
    public class Plane
    {
        public int Fuel { get; set; }
        public bool OnAir { get; set; }
        public Plane()
        {
            Fuel = 200;
            OnAir = true;
        }
    }
}
