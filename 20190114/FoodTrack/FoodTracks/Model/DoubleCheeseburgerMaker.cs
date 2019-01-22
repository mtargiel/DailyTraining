using System.Collections.Generic;

namespace FoodTracks.Model
{
    public class DoubleCheeseburgerMaker : IBurgerMaker
    {
        public Burger Make()
        {
            return new Burger(Meet.CreateMeet(6), Cheeseness.Double, new List<AddonType>() { AddonType.None}, BurgerType.Doublecheesseburger);
        }
    }
}