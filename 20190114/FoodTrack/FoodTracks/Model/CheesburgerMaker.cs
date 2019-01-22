using System.Collections.Generic;

namespace FoodTracks.Model
{
    public class CheeseburgerMaker : IBurgerMaker
    {
        public Burger Make()
        {
            return new Burger(Meet.CreateMeet(6), Cheeseness.Single, new List<AddonType>() { AddonType.None}, BurgerType.Chesseburger);
        }
    }
}