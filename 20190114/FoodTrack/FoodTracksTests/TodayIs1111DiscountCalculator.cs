using FoodTracks.Model;

namespace Tests
{
    public class TodayIs1111DiscountCalculator : IDiscountCalculator
    {
        public decimal Calculate()
        {
            return -15;
        }

        public int ChanceForWin()
        {
            return 1;
        }
    }
}