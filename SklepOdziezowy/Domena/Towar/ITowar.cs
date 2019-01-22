using System;
using System.Collections.Generic;
using System.Text;

namespace SklepOdziezowy.Domena.Towar
{
    public interface ITowar
    {
        decimal Cena { get; set; }
        int Ilosc { get; set; }
    }
}
