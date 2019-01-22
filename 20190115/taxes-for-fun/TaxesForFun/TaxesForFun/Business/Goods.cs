using System;
using System.Collections.Generic;
using System.Text;

namespace TaxesForFun.Business
{
    public class Goods
    {
        public Goods(int value, string name)
        {
            Value = value;
            Name = name;
        }

        public int Value { get;}
        public string Name { get;}

    }
}
