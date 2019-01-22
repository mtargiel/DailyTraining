using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaxesForFun.Business;

namespace TaxesForFun.TaxCalculators
{
    public static class TaxCalculatorFactory
    {
        public static ITaxCalculator Create(string type)
        {
            if (type == "personal first tax level")
                return new PersonalTaxCalculator();
            else if (type == "personal second tax level")
                return new PersonalSecondLevelTaxCalculator();

            return new LinearTaxCalculator();
        }

        public static ITaxCalculator Create(CustomerType type)
        {
            if (type == CustomerType.Personal)
                return new PersonalTaxCalculator();

            return new LinearTaxCalculator();
        }

        public static ITaxCalculator Create(CustomerType type, List<Goods> goods)
        {
            int AllGoodsCost = goods.Where(x=>x.Value<10000).Sum(x => x.Value);
            AllGoodsCost += (int)(goods.Where(x => x.Value > 10000).Sum(x=>x.Value)*0.25);
            
            return new LinearTaxBusinessCalculator(AllGoodsCost);
        }
    }
}