namespace FoodTracks.Model
{
    public class Cook
    {
        public Burger Create(IBurgerMaker burgerMaker)
        {
            if (burgerMaker == null)
            {
                burgerMaker = new BurgerMaker();
            }
            
            return burgerMaker.Make();
        }
    }
}