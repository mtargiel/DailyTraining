using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot
{
    class BattleGround
    {


        public Robot FirstRobot { get; set; }
        public Robot SecondRobot { get; set; }
        public BattleGround(Robot firstRobot, Robot secondRobot)
        {
            FirstRobot = firstRobot;
            SecondRobot = secondRobot;
        }

        public Robot StartFight()
        {

            do
            {
                SecondRobot.Hp -= FirstRobot.Hit(SecondRobot.Obrona);
                FirstRobot.Hp -= SecondRobot.Hit(FirstRobot.Obrona);

            } while (SecondRobot.Hp<0 || FirstRobot.Hp<0);

            if (FirstRobot.Hp < 0)
                return SecondRobot;

            return FirstRobot;
        }
    }
}
