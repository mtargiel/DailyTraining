using HappyPlanes.Entities;
using NUnit.Framework;
using System.Collections.Generic;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void T01_RunwayAcceptsAPlaneIfPlaneInAirAndRunwayEmpty()
        {
            // Given
            Plane plane = PlaneFactory.Create(PlaneLocation.InAir);
            Runway runway = new Runway("runway 01", RunwayStatus.Empty);

            // When
            runway.AcceptPlane(plane);

            // Then
            Assert.IsTrue(runway.Status == RunwayStatus.Full);
        }

        [Test]
        public void T02_RunwayDoesNotAcceptAPlaneIfPlaneOnRunwayAndRunwayEmpty()
        {
            // Given
            Plane plane = PlaneFactory.Create(location: PlaneLocation.OnRunway);
            Runway runway = new Runway("runway 01", RunwayStatus.Empty);

            // When
            runway.AcceptPlane(plane);

            // Then
            Assert.IsTrue(runway.Status == RunwayStatus.Empty);
        }

        [Test]
        public void T03_SinglePlaneCannotLandOnSingleFullRunway()
        {
            // Given
            Plane plane = PlaneFactory.Create(location: PlaneLocation.InAir);
            Runway runway = new Runway("runway 01", RunwayStatus.Full);

            // When
            LandingStatus result = plane.TryLandOn(runway);

            // Then
            Assert.IsTrue(result == LandingStatus.Failure);
            Assert.IsTrue(plane.Location == PlaneLocation.InAir);
            Assert.IsTrue(runway.Status == RunwayStatus.Full);
        }

        [Test]
        public void T04_SinglePlaneCanLandOnSingleEmptyRunway()
        {
            // Given
            Plane plane = PlaneFactory.Create(location: PlaneLocation.InAir);
            Runway runway = new Runway("runway 01", RunwayStatus.Empty);

            // When
            LandingStatus result = plane.TryLandOn(runway);

            // Then
            Assert.IsTrue(result == LandingStatus.Success);
            Assert.IsTrue(plane.Location == PlaneLocation.OnRunway);
            Assert.IsTrue(runway.Status == RunwayStatus.Full);
        }

        [Test]
        public void T05_ControlTowerGivesEmptyRunwayIfPresentAndRequested()
        {
            // Given
            Runway runway = new Runway("runway 01", RunwayStatus.Empty);
            ControlTower tower = new ControlTower(new Runway[] { runway });

            // When
            Runway result = tower.GetAvailableRunway();

            // Then
            Assert.IsTrue(result != null);
            Assert.IsTrue(result.Name == runway.Name);
        }

        [Test]
        public void T06_ControlTowerGivesNullRunwayIfNotPresentAndRequested()
        {
            // Given
            Runway runway = new Runway("runway 01", RunwayStatus.Full);
            ControlTower tower = new ControlTower(new Runway[] { runway });

            // When
            Runway result = tower.GetAvailableRunway();

            // Then
            Assert.IsTrue(result == null);
        }

        [Test]
        public void T07_SinglePlaneCannotLandOnNullRunway()
        {
            // Given
            Plane plane = PlaneFactory.Create(location: PlaneLocation.InAir);
            Runway runway = null;

            // When
            LandingStatus result = plane.TryLandOn(runway);

            // Then
            Assert.IsTrue(runway == null);
            Assert.IsTrue(result == LandingStatus.Failure);
            Assert.IsTrue(plane.Location == PlaneLocation.InAir);
        }

        [Test]
        public void T08_ControlTowerGives3EmptyRunways1NullIf3PresentAndRequested()
        {
            // Given
            ControlTower tower = new ControlTower(new Runway[] {
                new Runway("r1"), new Runway("r2"), new Runway("r3") });

            // When
            List<Runway> results = new List<Runway>();
            for (int i = 0; i < 4; i++)
            {
                Runway r = tower.GetAvailableRunway();
                if (r != null) { r.Status = RunwayStatus.Full; }
                results.Add(r);
            }

            // Then
            Assert.IsTrue(results[0].Name == "r1");
            Assert.IsTrue(results[1].Name == "r2");
            Assert.IsTrue(results[2].Name == "r3");
            Assert.IsTrue(results[3] == null);
        }

        [Test]
        public void T09_PlaneLosesFuelInAir()
        {
            // Given
            int initialFuel = 100;
            int fuelBurn = 1;

            PassingTime time = new PassingTime();
            Plane plane = PlaneFactory.Create(location: PlaneLocation.InAir, fuel: initialFuel, passingTime: time);

            // When
            time.AddTurn();

            // Then
            Assert.IsTrue(plane.Fuel == initialFuel - fuelBurn);
        }

        [Test]
        public void T10_PlaneRefuelsOnGround()
        {
            // Given
            int initialFuel = 100;
            int fuelGain = 3;

            PassingTime time = new PassingTime();
            Plane plane = PlaneFactory.Create(location: PlaneLocation.OnRunway, fuel: initialFuel, passingTime: time);

            // When
            time.AddTurn();

            // Then
            Assert.IsTrue(plane.Fuel == initialFuel + fuelGain);
        }

        [Test]
        public void T11_MakingSurePlaneWorksProperly()
        {
            // Given
            int initialFuel = 100;
            int fuelBurn = 1;
            int fuelGain = 3;

            PassingTime time = new PassingTime();
            Plane plane = PlaneFactory.Create(location: PlaneLocation.InAir, fuel: initialFuel, passingTime: time);

            time.AddTurn();
            time.AddTurn();
            time.AddTurn();
            time.AddTurn();

            Runway runway = new Runway("runway 01", RunwayStatus.Empty);

            plane.TryLandOn(runway);

            // When
            time.AddTurn();

            // Then
            Assert.IsTrue(plane.Fuel == initialFuel - 4*fuelBurn + 1*fuelGain);
        }

        [Test]
        public void T12_PlaneHasMaxFuel()
        {
            // Given
            int initialFuel = 100;
            int maxFuel = 100;

            PassingTime time = new PassingTime();
            Plane plane = PlaneFactory.Create(location: PlaneLocation.OnRunway, 
                fuel: initialFuel, maxFuel: maxFuel, passingTime: time);

            // When
            time.AddTurn();

            // Then
            Assert.IsTrue(plane.Fuel == initialFuel);
        }

        [Test]
        public void T13_PlaneCanStartIfItHasMoreThanHalfMaxFuel()
        {
            // Given
            int initialFuel = 100;
            int maxFuel = 100;

            PassingTime time = new PassingTime();
            Plane plane = PlaneFactory.Create(name: "Omega Flight", location: PlaneLocation.InAir,
                fuel: initialFuel, maxFuel: maxFuel, passingTime: time);
            Runway runway = new Runway("runway 01", RunwayStatus.Empty);

            runway.AcceptPlane(plane);
            time.AddTurn();

            // When
            Plane launched = runway.LaunchPlane();

            // Then
            Assert.IsTrue(plane.Name == launched.Name);
            Assert.IsTrue(runway.Status == RunwayStatus.Empty);
        }

        [Test]
        public void T14_PlaneCannotStartIfHasLessThanHalfMaxFuel()
        {
            // Given
            int initialFuel = 10;
            int maxFuel = 100;

            PassingTime time = new PassingTime();
            Plane plane = PlaneFactory.Create(name: "Omega Flight", location: PlaneLocation.InAir,
                fuel: initialFuel, maxFuel: maxFuel, passingTime: time);
            Runway runway = new Runway("runway 01", RunwayStatus.Empty);

            runway.AcceptPlane(plane);
            time.AddTurn();

            // When
            Plane launched = runway.LaunchPlane();

            // Then
            Assert.IsTrue(launched == null);
            Assert.IsTrue(runway.Status == RunwayStatus.Full);
        }

        [Test]
        public void T15_PlaneCannotStartIfIsDamaged()
        {
            // Given
            int initialFuel = 100;
            int maxFuel = 100;

            PassingTime time = new PassingTime();
            Plane plane = PlaneFactory.Create(location: PlaneLocation.InAir, damage: PlaneDamage.Damaged,
                fuel: initialFuel, maxFuel: maxFuel, passingTime: time);
            Runway runway = new Runway("runway 01", RunwayStatus.Empty);

            runway.AcceptPlane(plane);
            time.AddTurn();

            // When
            Plane launched = runway.LaunchPlane();

            // Then
            Assert.IsTrue(launched == null);
            Assert.IsTrue(runway.Status == RunwayStatus.Full);
        }

        [Test]
        public void T16_PlaneGetsRepairedAfter10TurnsOnRunway()
        {
            // Given
            int initialFuel = 100;
            int maxFuel = 100;

            PassingTime time = new PassingTime();
            Plane plane = PlaneFactory.Create(location: PlaneLocation.InAir, damage: PlaneDamage.Damaged,
                fuel: initialFuel, maxFuel: maxFuel, passingTime: time);
            Runway runway = new Runway("runway 01", RunwayStatus.Empty);

            runway.AcceptPlane(plane);

            for(int i=0; i<9; i++) // 9 turns have passed
            {
                time.AddTurn();
            }

            Assert.IsTrue(plane.Damage == PlaneDamage.Damaged);

            // When
            time.AddTurn();

            // Then
            Assert.IsTrue(plane.Damage == PlaneDamage.None);
        }
        [Test]
        public void T17_PlaneAddToHangarAfter25TurnsOnRunway()
        {
            // Given
            int initialFuel = 100;
            int maxFuel = 100;

            PassingTime time = new PassingTime();
            Plane plane = PlaneFactory.Create(location: PlaneLocation.OnRunway, damage: PlaneDamage.None,
                fuel: initialFuel, maxFuel: maxFuel, passingTime: time);
            Runway runway = new Runway("runway 01", RunwayStatus.Empty);
            ControlTower tower = new ControlTower(new Runway[]{runway});

            runway.AcceptPlane(plane);

            for (int i = 0; i < 24; i++) // 9 turns have passed
            {
                time.AddTurn();
            }

            // When
            time.AddTurn();
            // Then
            Assert.IsTrue(Hangar.Planes.Contains(plane));
        }
        [Test]
        public void T18_GoToRunwayAfter3TurnsOnHangar()
        {
            // Given
            int initialFuel = 100;
            int maxFuel = 100;

            PassingTime time = new PassingTime();
            Plane plane = PlaneFactory.Create(location: PlaneLocation.OnRunway, damage: PlaneDamage.None,
                fuel: initialFuel, maxFuel: maxFuel, passingTime: time);
            Plane plane2 = PlaneFactory.Create(location: PlaneLocation.OnRunway, damage: PlaneDamage.None,
                fuel: initialFuel, maxFuel: maxFuel, passingTime: time);

            Hangar.AddPlaneToHangar(plane);
            Hangar.AddPlaneToHangar(plane2);

            Runway runway = new Runway("runway 01", RunwayStatus.Empty);

            ControlTower tower = new ControlTower(new Runway[] { runway });

            runway.AcceptPlane(plane);

            for (int i = 0; i < 3; i++) // 9 turns have passed
            {
                time.AddTurn();
            }

            // When
            time.AddTurn();
            // Then
            Assert.IsTrue(plane.Location == PlaneLocation.OnRunway);
            Assert.IsTrue(plane2.Location == PlaneLocation.OnRunway);

        }

    }
}