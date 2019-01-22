using System;
using System.Collections.Generic;
using System.Text;
using TaxesForFun.Business;
using TaxesForFun.TaxCalculators;

namespace TaxesForFun
{
    public class ComplexCalculator
    {
        public int ProcessCustomer(Customer customer)
        {
            if (customer.Type == CustomerType.Personal)
            {
                ITaxCalculator personalTaxCalculator = new PersonalTaxCalculator();
                return personalTaxCalculator.CalculateTax(customer.Money);
            }
            
            ITaxCalculator linearTaxCalculator = new LinearTaxCalculator();
           return linearTaxCalculator.CalculateTax(customer.Money);



        }

        public int ProcessCustomers(List<Customer> customers)
        {
            ITaxCalculator personalTaxCalculator = new PersonalTaxCalculator();
            ITaxCalculator linearTaxCalculator = new LinearTaxCalculator();
            int linear = 0;
            int personal = 0;

            foreach (var customer in customers)
            {
                if (customer.Type == CustomerType.Personal)
                {
                    personal += personalTaxCalculator.CalculateTax(customer.Money);
                }
                else
                {
                    linear+=linearTaxCalculator.CalculateTax(customer.Money);

                }
            
            }

            return linear+personal;
        }
    }
}
