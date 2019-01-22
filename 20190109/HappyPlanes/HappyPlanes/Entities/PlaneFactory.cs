namespace HappyPlanes.Entities
{
    #region DO NOT CHANGE THIS CODE

    public static class PlaneFactory
    {
        public static Plane Create(PlaneLocation location)
        {
            return Create(name: "default", location: location, fuel: int.MaxValue, 
                maxFuel: int.MaxValue, passingTime: new PassingTime(), damage: PlaneDamage.None);
        }

        public static Plane Create(PlaneLocation location, int fuel, PassingTime passingTime)
        {
            return Create(name: "default", location: location, fuel: fuel,
                maxFuel: int.MaxValue, passingTime: passingTime, damage: PlaneDamage.None);
        }

        public static Plane Create(PlaneLocation location, int fuel, int maxFuel,
            PassingTime passingTime, string name = "default")
        {
            return Create(name: name, location: location, damage: PlaneDamage.None,
                fuel: fuel, maxFuel: maxFuel, passingTime: passingTime);
        }

        public static Plane Create(PlaneLocation location, int fuel, int maxFuel,
            PassingTime passingTime, PlaneDamage damage, string name = "default")
        {
            return new Plane(name: name, location: location, damage: damage,
                fuel: fuel, maxFuel: maxFuel, passingTime: passingTime);
        }

    }

    #endregion DO NOT CHANGE THIS CODE

}
