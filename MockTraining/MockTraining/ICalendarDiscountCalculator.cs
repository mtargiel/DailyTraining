using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockTraining
{
    public interface ICalendarDiscountCalculator
    {
        decimal Calculate(DateTime data, Produkt produkt);

    }
}
