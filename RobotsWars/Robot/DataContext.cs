using System;
using System.Collections.Generic;
using System.IO;

namespace Robot
{
    static class DataContext
    {
        static string[] GetDataFromFile(string fileName)
        {
           return File.ReadAllLines(fileName);
        }
        public static List<Robot> GetListRobotsFromFile(string fileName)
        {
            List<Robot> robots = new List<Robot>();

            foreach (string line in GetDataFromFile(fileName))
            {
                var cols = line.Split(new string[] { ";" }, StringSplitOptions.None);

                robots.Add(new Robot(
                    iloscGlow: int.Parse(cols[0])
                    ,iloscKorpus: int.Parse(cols[1])
                    ,iloscDol:int.Parse(cols[2])
                    ,Atak: int.Parse(cols[3])
                    ,Obrona: int.Parse(cols[4])));
            }

            return robots;
        }
     
    }

}