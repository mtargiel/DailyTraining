using System.Collections.Generic;
using SklepOdziezowy.Domena.Towar;

namespace SklepOdziezowy.Domena.Sklep
{
    public interface ISklep
    {
        IKoszyk Koszyk { get; set; }
        List<ITowar> Towar { get; set; }

    }
}
