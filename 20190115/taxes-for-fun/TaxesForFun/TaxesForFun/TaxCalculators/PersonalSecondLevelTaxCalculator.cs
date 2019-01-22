using System.Runtime.CompilerServices;

namespace TaxesForFun.TaxCalculators
{
    public class PersonalSecondLevelTaxCalculator : ITaxCalculator
    {
        public int CalculateTax(int receivedMoney)
        {
            return (int)(receivedMoney * 0.32);
        }
    }
}