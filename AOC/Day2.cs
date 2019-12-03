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
                int result = 0;

                switch (opcode)
                {
                    case 1:
                        result = intcode[intcode[index + 1]] + intcode[intcode[index + 2]];
                        break;

                    case 2:
                        result = intcode[intcode[index + 1]] * intcode[intcode[index + 2]];
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
                    intcode[intcode[index + 3]] = result;
                    index += 4;
                }
            }

            Console.WriteLine($"Day2: Problem One Result: {intcode[0]}");
            Utils.SaveResults("Day2", "Output1", intcode[0].ToString());
        }

        private static void ProblemTwo()
        {
            string input = Utils.LoadInputString("Day2", "Input2");
            int[] originalIntcode = Array.ConvertAll(input.Split(","), int.Parse);

            int requiredOutput = 19690720;
            bool searching = true;
            bool noResults = false;

            int noun = 0;
            int verb = 0;

            while (searching)
            {
                int[] intcode = new int[originalIntcode.Length];
                originalIntcode.CopyTo(intcode, 0);

                intcode[1] = noun;
                intcode[2] = verb;

                int index = 0;
                bool running = true;

                while (running)
                {
                    int opcode = intcode[index];
                    int result = 0;

                    switch (opcode)
                    {
                        case 1:
                            result = intcode[intcode[index + 1]] + intcode[intcode[index + 2]];
                            break;
                        case 2:
                            result = intcode[intcode[index + 1]] * intcode[intcode[index + 2]];
                            break;
                        case 99:
                            running = false;
                            break;
                        default:
                            running = false;
                            break;
                    }

                    if (running)
                    {
                        intcode[intcode[index + 3]] = result;
                        index += 4;
                    }
                }

                if (intcode[0] == requiredOutput)
                {
                    searching = false;
                }
                else
                {
                    noun++;
                    if (noun > 99) 
                    {
                        noun = 0;
                        verb++;
                    }

                    if (verb > 99)
                    {
                        noResults = true;
                        searching = false;   
                    }
                }
            }

            if (noResults)
            {
                Console.WriteLine("FAILED TO FIND A VALUE");
            }
            else
            {
                int result = 100 * noun + verb;

                Console.WriteLine($"Day2: Problem Two Result: {result}");
                Utils.SaveResults("Day2", "Output2", result.ToString());
            }
        }

        public static void Solve()
        {
            ProblemOne();
            ProblemTwo();
        }
    }
}