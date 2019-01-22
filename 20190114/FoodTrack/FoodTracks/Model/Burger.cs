using System.Collections.Generic;

namespace FoodTracks.Model
{
    public class Burger
    {
        public Meet Meet { get; }

        public BurgerType BurgerType { get; }
        public Cheeseness Cheeseness { get; }
        public List<AddonType> Addons { get; set; }

        public Burger()
        {
            BurgerType = BurgerType.none;
            Meet =  Meet.CreateMeet();
            Cheeseness = Cheeseness.None;
            Addons = new List<AddonType>() {AddonType.None};
        }

        public Burger(Meet meet, Cheeseness cheeseness, List<AddonType> addonTypes, BurgerType burgerType)
        {
            BurgerType = burgerType;
            Meet = meet;
            Cheeseness = cheeseness;
            Addons = addonTypes;
        }
    }
   
}