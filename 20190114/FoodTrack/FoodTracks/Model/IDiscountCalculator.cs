using System;

namespace FoodTracks.Model
{
    public interface IDiscountCalculator
    {
        DateTime discountDateTime { get; }
        decimal Calculate();
        int ChanceForWin();
    }
}