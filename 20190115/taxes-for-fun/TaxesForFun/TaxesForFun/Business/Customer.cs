using System;
using System.Collections.Generic;
using System.Text;

namespace TaxesForFun.Business
{
    public class Customer
    {

        public Customer(int money, CustomerType type)
        {
            Money = money;
            Type = type;
        }

        public int Money { get; }
        public CustomerType Type { get; }
    }
}
