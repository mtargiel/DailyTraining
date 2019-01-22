using System;
using System.Collections.Generic;
using System.Text;
using SklepOdziezowy.Domena.Sklep;

namespace SklepOdziezowy.Domena.Klient
{
    class Klient
    {
        public IKoszyk Koszyk { get; }

        public Klient(IKoszyk koszyk)
        {
            this.Koszyk = koszyk;
        }
    }
}
