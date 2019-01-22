using System.Collections.Generic;

namespace FoodTracks.Model
{
    public class EnglishBurgerMaker : IBurgerMaker
    {
        public Burger Make()
        {
            return new Burger(Meet.CreateMeet(10), Cheeseness.Single, new List<AddonType>() { AddonType.Egg, AddonType.Halapenio}, BurgerType.Englishburger);
        }
        
      
    }
}