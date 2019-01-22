using System;
using System.Collections.Generic;
using System.Text;

namespace TaxesForFun.TaxCalculators
{
    public class PersonalTaxCalculator : ITaxCalculator
    {
        public int CalculateTax(int receivedMoney)
        {
            int taxCredit = 8000;
            int nextLevel = 85528;

            int firstLevel = 0;
            int secondLevel = 0;

            if (receivedMoney > nextLevel)
            {
                secondLevel += (int) ((receivedMoney - nextLevel) * 0.32);
            }
            else
            {
                firstLevel += (int) ((receivedMoney - taxCredit) * 0.18);

            }


            return firstLevel + secondLevel;
        }
    }
}
