using System;
using System.Collections.Generic;
using System.Linq;
using HappyPlane;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HppyPlaneTests
{
    [TestClass]
    public class AirportTests
    {
        [TestMethod]
        public void PlaneCanLandOnEmptyAirStrip()
        {
            Airport airport = new Airport(new List<AirStrip>() { new AirStrip()});
            List<Plane> planes = new List<Plane>() { new Plane() };
            ControlTower.Landing(airport, planes);
            Assert.IsTrue(planes.Any());

        }
    }
}
