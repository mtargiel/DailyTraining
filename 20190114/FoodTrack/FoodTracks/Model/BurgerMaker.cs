namespace FoodTracks.Model
{
    public class BurgerMaker : IBurgerMaker
    {
        public Burger Make()
        {
            return new Burger();
        }
    }
}