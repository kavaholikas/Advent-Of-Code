using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC2019
{
    class Day3
    {
        public struct EndPoints 
        {
            public Point Start { get; set; }
            public Point End { get; set; }
            public char Direction { get; set; }

            public EndPoints(Point Start, Point End, char Direction)
            {
                this.Start = Start;
                this.End = End;
                this.Direction = Direction;
            }
        }
        private static void ProblemOne()
        {
            string[] inputs = Utils.LoadInputArray("Day3", "Input1");

            string[] wireOneInputs = inputs[0].Split(",");
            string[] wireTwoInputs = inputs[1].Split(",");

            int inputLength = wireOneInputs.Length;

            EndPoints[] wireOneEndPoints = new EndPoints[inputLength];
            EndPoints[] wireTwoEndPoints = new EndPoints[inputLength];

            Point wireOneLastPoint = new Point(0, 0);
            Point wireTwoLastPoint = new Point(0, 0);

            int distance = 0;

            for (int i = 0; i < inputLength; i++)
            {
                // generate wire one.
                string inputOne = wireOneInputs[i];
                wireOneEndPoints[i] = _GetStep(inputOne, wireOneLastPoint);
                wireOneLastPoint = wireOneEndPoints[i].End;

                // compare new wire with all old wires
                distance = _TestForHits(wireOneEndPoints, wireTwoEndPoints, i, distance);

                //generate wire two
                string inputTwo = wireTwoInputs[i];
                wireTwoEndPoints[i] = _GetStep(inputTwo, wireOneLastPoint);
                wireTwoLastPoint = wireOneEndPoints[i].End;

                // compare new wire with all old wires
                distance = _TestForHits(wireTwoEndPoints, wireOneEndPoints, i, distance);
            }

            Console.WriteLine("Distance: " + distance);
        }

        private static EndPoints _GetStep(string input, Point lastPos)
        {
                char dir = input[0];
                int step = int.Parse(input.Substring(1));

                Point end = new Point(lastPos.X, lastPos.Y);

                switch (dir)
                {
                    case 'L':
                        end.X -= step;
                        break;
                    case 'R':
                        end.X += step;
                        break;
                    case 'D':
                        end.Y -= step;
                        break;
                    case 'U':
                        end.Y += step;
                        break;
                }

                return new EndPoints(lastPos, end, dir);
        }

        private static int _TestForHits(EndPoints[] mainWireEndpoints, EndPoints[] targetWireEndPoints, int i, int distance)
        {
            for (int j = 0; j < i; j++)
            {
                EndPoints mainWire = mainWireEndpoints[i];
                EndPoints targetWire = targetWireEndPoints[j];

                char dir = mainWire.Direction;
                char targetDir = targetWire.Direction;

                // Horizontal Hit
                bool horizontalHit = (dir == 'L' || dir == 'R') && (targetDir == 'U' || targetDir == 'D');
                if (horizontalHit)
                {
                    int MY = Math.Abs(mainWire.End.Y);
                    int TSY = Math.Abs(targetWire.Start.Y);
                    int TEY = Math.Abs(targetWire.End.Y);

                    if (MY >= TSY && MY <= TEY)
                    {
                        int TX = Math.Abs(targetWire.End.X);
                        int MSX = Math.Abs(mainWire.Start.X);
                        int MEX = Math.Abs(mainWire.End.X);
                        if (TX >= MSX && TX <= MEX)
                        {
                            Console.WriteLine("HIT");
                            int hitDistance = Math.Abs(targetWire.Start.X) + Math.Abs(mainWire.Start.Y);
                            if (distance == 0)
                            {
                                distance = hitDistance;
                            }
                            else
                            {
                                distance = Math.Min(distance, hitDistance);
                            }
                        }
                    }
                }

                // Vertical Hit
                bool verticalHit = (dir == 'U' || dir == 'D') && (targetDir == 'L' || targetDir == 'R');
                if (verticalHit)
                {
                    int MX = Math.Abs(mainWire.End.X);
                    int TSX = Math.Abs(targetWire.Start.X);
                    int TEX = Math.Abs(targetWire.End.X);
                    if (MX >= TSX && MX <= TEX)
                    {
                        int TY = Math.Abs(targetWire.End.Y);
                        int MSY = Math.Abs(mainWire.Start.Y);
                        int MEY = Math.Abs(mainWire.End.Y);
                        if (TY >= MSY && TY <= MEY)
                        {
                            Console.WriteLine("HIT");
                            int hitDistance = Math.Abs(targetWire.Start.X) + Math.Abs(mainWire.Start.Y);
                            if (distance == 0)
                            {
                                distance = hitDistance;
                            }
                            else
                            {
                                distance = Math.Min(distance, hitDistance);
                            }
                        }
                    }

                }
            }

            return distance;
        }

        private static void ProblemTwo()
        {

        }

        public static void Solve()
        {
            ProblemOne();
            ProblemTwo();
        }

    }
}
