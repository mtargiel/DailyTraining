using System.Collections.Generic;
using SklepOdziezowy.Domena.Towar;

namespace SklepOdziezowy.Domena.Sklep
{
    public interface IKoszyk
    {
       List<ITowar> TowarKlienta { get; set; }
        decimal SumaTowaru();
    }
}
