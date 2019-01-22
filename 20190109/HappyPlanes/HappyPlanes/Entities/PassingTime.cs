using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyPlanes.Entities
{
    public class PassingTime
    {
        List<Plane> planes;

        public PassingTime()
        {
            CurrentTurn = 0;
            planes = new List<Plane>();
        }

        public int CurrentTurn { get; private set; }

        public void RegisterPlane(Plane plane) => planes.Add(plane);

        public void AddTurn()
        {
            CurrentTurn = CurrentTurn + 1;
            foreach(var plane in planes) { plane.OnTurnTick(); }
        }
        
        

    }
}
