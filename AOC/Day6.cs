using System;
using System.Linq;
using System.Collections.Generic;

namespace AOC2019
{
    class Planet
    {
        public string Name { get; set; }
        public string OrbitsAround { get; set; }
        public int OrbitCount { get; set; }

        public Planet(string Name, string OrbitsAround)
        {
            this.Name = Name;
            this.OrbitsAround = OrbitsAround;
            OrbitCount = 0;
        }

        public int GetOrbitCount(List<Planet> planets)
        {
            if (OrbitCount == 0)
            {
                OrbitCount = _CalculateOrbitCount(planets);
            }

            return OrbitCount;
        }

        public List<Planet> FindPathToTarget(List<Planet> planets, Planet target)
        {
            List<Planet> path = new List<Planet>();

            // Go down with both until you find repeating or COM

            List<Planet> myPath = new List<Planet>();
            List<Planet> targetPath = new List<Planet>();

            bool searching = true;

            bool myPathHitCOM = false;
            bool targetsPathHitCOM = false;

            Planet currentPlanet = this;
            Planet currentTargetsPlanet = target;


            while (searching)
            {
                if (!myPathHitCOM)
                {
                    Planet myNextStep = planets.Find(p => p.Name == currentPlanet.OrbitsAround); 
                    myPath.Add(myNextStep);
                    currentPlanet = myNextStep;

                    if (currentPlanet.OrbitsAround == "COM")
                    {
                        myPathHitCOM = true;
                    }
                }

                if (!targetsPathHitCOM)
                {
                    Planet targetsNextStep = planets.Find(p => p.Name == currentTargetsPlanet.OrbitsAround);
                    targetPath.Add(targetsNextStep);
                    currentTargetsPlanet = targetsNextStep;

                    if (currentTargetsPlanet.OrbitsAround == "COM")
                    {
                        targetsPathHitCOM = true;
                    }
                }

                if (myPathHitCOM && targetsPathHitCOM)
                {
                    searching = false;
                }

                bool containsMyPlanet = targetPath.Contains(currentPlanet);
                bool containsTargetPlanet = myPath.Contains(currentTargetsPlanet);

                if (containsMyPlanet)
                {
                    searching = false;
                    path = myPath.Concat(targetPath).ToList();
                }
                else if (containsTargetPlanet)
                {
                    searching = false;
                    path = myPath.Concat(targetPath).ToList();
                }

            }

            return path;
        }

        private int _CalculateOrbitCount(List<Planet> planets)
        {
            if (OrbitsAround == "COM")
            {
                return 1;
            }

            return 1 + planets.Find(p => p.Name == OrbitsAround).GetOrbitCount(planets);
        }

        public override string ToString()
        {
            return $"Planet Name: {Name} Orbits Around: {OrbitsAround} Total Orbits: {OrbitCount}";
        }
    }


    class Day6
    {
        private static void ProblemOne()
        {
            string[] input = Utils.LoadInputArray("Day6", "Input1");
            List<Planet> planets = new List<Planet>();

            int totalOrbits = 0;

            foreach (string item in input)
            {
                string[] i = item.Split(")");
                planets.Add(new Planet(i[1], i[0]));
            }

            foreach (var item in planets)
            {
                totalOrbits += item.GetOrbitCount(planets);
            }


            Console.WriteLine($"Day6: Problem One Result: {totalOrbits}");
            Utils.SaveResults("Day6", "Output1", totalOrbits.ToString());
        }

        private static void ProblemTwo()
        {
            string[] input = Utils.LoadInputArray("Day6", "Input1");
            List<Planet> planets = new List<Planet>();

            foreach (string item in input)
            {
                string[] i = item.Split(")");
                planets.Add(new Planet(i[1], i[0]));
            }

            Planet start = planets.Find(p => p.Name == "YOU");
            Planet end = planets.Find(p => p.Name == "SAN");

            List<Planet> path = start.FindPathToTarget(planets, end);
            Console.WriteLine(path.Count);
        }

        private static int _GetOrbitCount()
        {

            return 0;
        }

        public static void Solve()
        {
            ProblemOne();
            ProblemTwo();
        }
    }
}