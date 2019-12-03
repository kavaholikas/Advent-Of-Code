using System;
using System.Linq;

namespace AOC2019
{
    class Day2
    {
        private static string Name = "Day2";
        private static string InputOne = "Input1";
        private static string InputTwo = "Input2";
        private static string OutputOne = "Output1";
        private static string OutputTwo = "Output2";
        private static void ProblemOne()
        {
            string[] input = Utils.LoadInput(Name, InputOne);
            int[] intcode = Array.ConvertAll(input[0].Split(","), int.Parse);

            intcode[1] = 12;
            intcode[2] = 2;

            foreach (int item in intcode)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            int index = 0;
            bool running = true;

            while (running)
            {
                int opcode = intcode[index];
                int i1 = index + 1, i2 = index + 2, i3 = index + 3;

                if (opcode == 1 || opcode == 2) {
                    int v1 = intcode[i1], v2 = intcode[i2];
                    int result = opcode == 1? v1 + v2: v1 * v2;
                    intcode[i3] = result;
                    index += 4;
                }
                else
                {
                    running = false;
                }
            }

            Console.WriteLine($"{Name}: Problem Two Result: {intcode[0]}");
            Utils.SaveResults(Name, OutputOne, intcode[0].ToString());
        }

        public static void Solve()
        {
            ProblemOne();
        }
    }
}