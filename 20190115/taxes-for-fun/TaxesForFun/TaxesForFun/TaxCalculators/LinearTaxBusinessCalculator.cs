namespace TaxesForFun.TaxCalculators
{
    public class LinearTaxBusinessCalculator : ITaxCalculator
    {
        public int Costs { get; set; }
        public LinearTaxBusinessCalculator(int costs)
        {
            Costs = costs;
        }
        public int CalculateTax(int receivedMoney)
        {
            return (int) ((receivedMoney - Costs) * 0.19);
        }
    }
}