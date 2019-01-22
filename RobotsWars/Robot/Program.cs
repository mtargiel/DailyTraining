using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot
{
    class Program
    {
        private static readonly string _fileName = "wejscie.txt";

        static void Main(string[] args)
        {
            List<Robot> robots = DataContext.GetListRobotsFromFile(_fileName);
            foreach (Robot robot in robots)
            {
                Console.WriteLine(robot.ToString());
            }
            BattleGround battleGround = new BattleGround(robots[0], robots[1]);

            Console.WriteLine("And the winner IS: {0}", battleGround.StartFight().ToString());


            Console.ReadKey();

        }
    }
}
