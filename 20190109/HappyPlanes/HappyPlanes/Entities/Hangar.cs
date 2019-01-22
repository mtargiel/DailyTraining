using System;
using System.Collections.Generic;
using System.Text;

namespace HappyPlanes.Entities
{
    public static class Hangar
    {
        static public List<Plane> Planes { get; private set; }

        static Hangar()
        {
            Planes = new List<Plane>();
        }
        static public void AddPlaneToHangar(Plane plane)
        {
            Planes.Add(plane);
            
        }
    }
}
