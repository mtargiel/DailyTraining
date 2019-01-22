using System;
using System.Collections.Generic;
using System.Text;

namespace HappyPlanes.Entities
{
    public enum RunwayStatus
    {
        Unknown = 0, Empty, Full
    }

    public enum LandingStatus
    {
        Unknown = 0, Success, Failure
    }

    public enum PlaneLocation
    {
        Unknown = 0, InAir, OnRunway, OnHangar
    }

    public enum PlaneDamage
    {
        None, Damaged, Destroyed
    }
}
