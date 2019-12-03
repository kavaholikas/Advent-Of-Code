using System;
using System.Linq;

namespace AOC2019
{
    class Day2
    {
        private static void ProblemOne()
        {
            string input = Utils.LoadInputString("Day2", "Input1");
            int[] intcode = Array.ConvertAll(input.Split(","), int.Parse);

            intcode[1] = 12;
            intcode[2] = 2;

            int index = 0;
            bool running = true;

            while (running)
            {
                int opcode = intcode[index];

                int pos1 = intcode[index + 1];
                int pos2 = intcode[index + 2];
                int pos3 = intcode[index + 3];

                int result = 0;

                switch (opcode)
                {
                    case 1:
                        result = intcode[pos1] + intcode[pos2];
                        break;

                    case 2:
                        result = intcode[pos1] * intcode[pos2];
                        break;

                    case 99:
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Error in intcode");
                        running = false;
                        break;
                }

                if (running)
                {
                    intcode[pos3] = result;
                    index += 4;
                }
            }

            Console.WriteLine(intcode[0]);
        }

        public static void Solve()
        {
            ProblemOne();
        }
    }
}