using System.Collections.Generic;

namespace FoodTracks.Model
{
    public class VegeBurgerMaker : IBurgerMaker
    {
        public Burger Make()
        {
            return new Burger(Meet.CreateMeet(), Cheeseness.Single, new List<AddonType>() { AddonType.None}, BurgerType.Vegeburger);
        }
    }
}