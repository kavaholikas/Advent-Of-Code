using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC2019
{
    class Day3
    {
        private static void ProblemOne()
        {
            string[] inputs = Utils.LoadInputArray("Day3", "Input1");
            string[] wireOneInputs = inputs[0].Split(",");
            string[] wireTwoInputs = inputs[1].Split(",");

            Point[] wireOneSegments = new Point[wireOneInputs.Length + 1];
            Point[] wireTwoSegments = new Point[wireTwoInputs.Length + 1];

            wireOneSegments[0] = new Point(0, 0, 'N', "N");
            wireTwoSegments[0] = new Point(0, 0, 'N', "N");

            _GetSegments(wireOneInputs, ref wireOneSegments);
            _GetSegments(wireTwoInputs, ref wireTwoSegments);

            (int distance, int steps) = _GetIntersectionDistance(wireOneSegments, wireTwoSegments);

            Console.WriteLine($"Day3: Problem One Result: {distance}");
            Utils.SaveResults("Day3", "Output1", distance.ToString());
        }

        private static void _GetSegments(string[] inputs, ref Point[] wire)
        {
            for (int i = 0; i < inputs.Length; i++)
            {
                char direction = inputs[i][0];
                int step = int.Parse(inputs[i].Substring(1));

                Point segment = new Point(wire[i].X, wire[i].Y, direction, inputs[i]);

                switch (direction)
                {
                    case 'L':
                        segment.X -= step;
                        break;
                    case 'R':
                        segment.X += step;
                        break;
                    case 'D':
                        segment.Y -= step;
                        break;
                    case 'U':
                        segment.Y += step;
                        break;
                }

                wire[i + 1] = segment;
            }
        }

        private static (int distance, int steps) _GetIntersectionDistance(Point[] wireOne, Point[] wireTwo)
        {
            int Hit = 0;
            int Steps = 0;

            int wireOneSteps = 0;

            for (int i = 0; i < wireOne.Length - 1; i++)
            {
                Point a1 = wireOne[i];
                Point a2 = wireOne[i + 1];

                int wireTwoSteps = 0;

                for (int j = 0; j < wireTwo.Length - 1; j++)
                {
                    Point b1 = wireTwo[j];
                    Point b2 = wireTwo[j + 1];
                    
                    // Horizontal Check
                    if ((a2.D == 'L' || a2.D == 'R') && (b2.D == 'U' || b2.D == 'D'))
                    {
                        Point amin = a1.X < a2.X? a1: a2;
                        Point amax = a1.X > a2.X? a1: a2;
                        Point bmin = b1.Y < b2.Y? b1: b2;
                        Point bmax = b1.Y > b2.Y? b1: b2;

                        if (amin.X <= bmin.X && amax.X >= bmin.X && bmin.Y <= amin.Y && bmax.Y >= amin.Y)
                        {
                            // Hit
                            int X = Math.Abs(bmin.X);
                            int Y = Math.Abs(amin.Y);

                            int hit = X + Y;
                            Hit = Hit == 0? hit: Math.Min(hit, Hit);

                            int steps = wireOneSteps + wireTwoSteps;
                            Steps = Steps == 0? steps: Math.Min(steps, Steps);
                        }
                    }
                    // Vertical Check
                    else if ((a2.D == 'U' || a2.D == 'D') && (b2.D == 'L' || b2.D == 'R'))
                    {
                        Point amin = a1.X < a2.X? a1: a2;
                        Point amax = a1.X > a2.X? a1: a2;
                        Point bmin = b1.Y < b2.Y? b1: b2;
                        Point bmax = b1.Y > b2.Y? b1: b2;

                        if (bmin.X <= amin.X && bmax.X >= amin.X && amin.Y <= bmin.Y && amax.Y >= bmin.Y) 
                        {
                            // Hit
                            int X = Math.Abs(bmin.X);
                            int Y = Math.Abs(amin.Y);

                            int hit = X + Y;
                            Hit = Hit == 0? hit: Math.Min(hit, Hit);

                            int steps = wireOneSteps + wireTwoSteps;
                            Steps = Steps == 0? steps: Math.Min(steps, Steps);
                        }
                    }

                    wireTwoSteps += int.Parse(b2.Command.Substring(1));
                }

                wireOneSteps += int.Parse(a2.Command.Substring(1));
            }

            return (distance: Hit, steps:  Steps);
        }

        private static void ProblemTwo()
        {
            string[] inputs = Utils.LoadInputArray("Day3", "Input2");
            string[] wireOneInputs = inputs[0].Split(",");
            string[] wireTwoInputs = inputs[1].Split(",");

            Point[] wireOneSegments = new Point[wireOneInputs.Length + 1];
            Point[] wireTwoSegments = new Point[wireTwoInputs.Length + 1];

            wireOneSegments[0] = new Point(0, 0, 'N', "N");
            wireTwoSegments[0] = new Point(0, 0, 'N', "N");

            _GetSegments(wireOneInputs, ref wireOneSegments);
            _GetSegments(wireTwoInputs, ref wireTwoSegments);

            (int distance, int steps) = _GetIntersectionDistance(wireOneSegments, wireTwoSegments);

            Console.WriteLine($"Day3: Problem Two Result: NOT SOLVED");
            Utils.SaveResults("Day3", "Output2", "NOT SOLVED");
        }

        public static void Solve()
        {
            ProblemOne();
            ProblemTwo();
        }

    }
}
