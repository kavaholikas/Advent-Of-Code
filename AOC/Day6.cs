using System;
using System.Collections.Generic;

namespace AOC2019
{
    class Day6
    {
        private static void ProblemOne()
        {
            string[] input = Utils.LoadInputArray("Day6", "Input1");
            Dictionary<string, string> planets = new Dictionary<string, string>();

            int totalOrbits = 0;

            foreach (var item in input)
            {
                string[] keyValue = item.Split(")");
                planets.Add(keyValue[1], keyValue[0]);
            }

            foreach (var item in planets)
            {
                totalOrbits = _GetOrbitCount(item, planets, totalOrbits);
            }

            Console.WriteLine($"Day6: Problem One Result: {totalOrbits}");
            Utils.SaveResults("Day6", "Output1", totalOrbits.ToString());
        }

        private static void ProblemTwo()
        {
        
        }

        private static int _GetOrbitCount(KeyValuePair<string, string> planet, Dictionary<string, string> planets, int count)
        {
            if (planets.ContainsKey(planet.Value))
            {
                KeyValuePair<string, string> planetParent = new KeyValuePair<string, string>(planet.Value, planets[planet.Value]);
                count += _GetOrbitCount(planetParent, planets, count);
            }
            else
            {
                return 1;
            }

            return count;
        }

        public static void Solve()
        {
            ProblemOne();
            ProblemTwo();
        }
    }
}