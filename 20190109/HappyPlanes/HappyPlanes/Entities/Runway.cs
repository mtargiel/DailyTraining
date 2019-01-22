using System;
using System.Collections.Generic;
using System.Text;

namespace HappyPlanes.Entities
{
    public class Runway
    {
        #region DO NOT TOUCH THIS CODE

        private string name;
        private RunwayStatus status;
        private Plane landedPlane;

        public Runway(string name, RunwayStatus status = RunwayStatus.Empty)
        {
            this.name = name;
            this.status = status;
            this.landedPlane = null;
        }

        public RunwayStatus Status { get => status; set => status = value; }
        public string Name { get => name; }

        #endregion DO NOT TOUCH THIS CODE

        #region IMPLEMENT THIS CODE

        public void AcceptPlane(Plane plane)
        {
            landedPlane = plane;

            if (this.status == RunwayStatus.Empty)
                this.status = RunwayStatus.Full;

            if (plane.Location == PlaneLocation.OnRunway
                && this.status == RunwayStatus.Full)
                this.status = RunwayStatus.Empty;


        }

        public Plane LaunchPlane()
        {
            

            if (landedPlane.Fuel > (int) landedPlane.MaxFuel / 2 
                && landedPlane.Damage != PlaneDamage.Damaged 
                && landedPlane.Damage != PlaneDamage.Destroyed)
            {
                this.status = RunwayStatus.Empty;
                return landedPlane;
            }
            this.status = RunwayStatus.Full;

            return null;
        }

        #endregion IMPLEMENT THIS CODE
    }

}
