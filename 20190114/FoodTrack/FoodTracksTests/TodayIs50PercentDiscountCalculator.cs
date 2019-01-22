using FoodTracks.Model;

namespace Tests
{
    public class TodayIs50PercentDiscountCalculator : IDiscountCalculator
    {
        public decimal Calculate()
        {
            return -10;
        }

        public int ChanceForWin()
        {
            return 1;
        }
    }
    
}