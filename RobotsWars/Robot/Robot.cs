using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot
{
    class Robot
    {
        public int IloscGlow { get; set; }
        public int IloscKorpus { get; set; }
        public int IloscDol { get; set; }
        public int Atak { get; set; }
        public int Obrona { get; set; }
        public double Hp { get; set; }
        public override string ToString()
        {
            return string.Format("Robot o parametrach, ilość głów: {0}, ilość korpusów {1}, ilość nóg: {2} Atak:{3}, Obrona:{4}"
                ,IloscGlow, IloscKorpus, IloscDol, Atak, Obrona);
        }

        public Robot(int iloscGlow, int iloscKorpus, int iloscDol, int Atak, int Obrona)
        {
            IloscGlow = iloscGlow;
            IloscKorpus = iloscKorpus;
            IloscDol = iloscDol;
            this.Atak = Atak;
            this.Obrona = Obrona;
            Hp = GetHp();
        }

        double GetHp()
        {
            return (IloscGlow * 2) + (IloscKorpus * 50) - (IloscDol * 0.5);
        }

        public double Hit(int EnemyDefence)
        {
            if (0 < (Atak - (EnemyDefence * 0.75)))
                return (Atak - (EnemyDefence * 0.75));
            else return 0;
        }
    }
}
