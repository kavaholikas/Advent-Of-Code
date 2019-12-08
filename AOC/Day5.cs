using System;

namespace AOC2019
{
    class Day5
    {
        private static void ProblemOne()
        {
            string input = Utils.LoadInputString("Day5", "Input1");
            int[] intcode = Array.ConvertAll(input.Split(","), int.Parse);

            int index = 0;
            int i = 1;
            int o = 0;

            bool halt = false;

            while (!halt)
            {
                halt = _ExecuteCommand(ref intcode, ref index, ref i, ref o);
            }

            Console.WriteLine($"Day5: Problem One Result: {o}");
            Utils.SaveResults("Day5", "Output1", o.ToString());
        }

        private static void ProblemTwo()
        {
            string input = Utils.LoadInputString("Day5", "Input1");
            int[] intcode = Array.ConvertAll(input.Split(","), int.Parse);

            int index = 0;
            int i = 5;
            int o = 0;

            bool halt = false;

            while (!halt)
            {
                halt = _ExecuteCommand2(ref intcode, ref index, ref i, ref o);
            }

            Console.WriteLine($"Day5: Problem Two Result: {o}");
            Utils.SaveResults("Day5", "Output2", o.ToString());
        }

        private static int _GetCommand(int number)
        {
            string command = number.ToString();
            int length = command.Length;

            if (length == 1 || length == 2)
            {
                return number;
            }

            return int.Parse(command.Substring(command.Length - 2));
        }

        private static int[] _GetParamaterModes(int number)
        {
            int[] paramaterModes = new int[3] {0, 0, 0};

            string command = number.ToString();
            int length = command.Length;

            switch (length)
            {
                case 1:
                case 2:
                    break;
                case 3:
                    paramaterModes[0] = int.Parse(command.Substring(0, 1));
                    break;
                case 4:
                    paramaterModes[0] = int.Parse(command.Substring(1, 1));
                    paramaterModes[1] = int.Parse(command.Substring(0, 1));
                    break;
                case 5:
                    paramaterModes[0] = int.Parse(command.Substring(2, 1));
                    paramaterModes[1] = int.Parse(command.Substring(1, 1));
                    paramaterModes[2] = int.Parse(command.Substring(0, 1));
                    break;
            }

            return paramaterModes;
        }

        private static bool _ExecuteCommand(ref int[] intcode, ref int index, ref int input, ref int output)
        {
            int command = _GetCommand(intcode[index]);
            int[] paramaters = _GetParamaterModes(intcode[index]);

            int p1, p2, p3;

            bool halt = false;

            switch (command)
            {
                case 1:
                case 2:
                    p1 = intcode[index + 1];
                    p2 = intcode[index + 2];
                    p3 = intcode[index + 3];

                    p1 = paramaters[0] == 0? intcode[p1]: p1;
                    p2 = paramaters[1] == 0? intcode[p2]: p2;
                    
                    intcode[p3] = command == 1? p1 + p2: p1 * p2;
                    
                    index += 4;
                    break;
                case 3:
                    p1 = intcode[index + 1];
                    intcode[p1] = input;

                    index += 2;
                    break;
                case 4:
                    p1 = intcode[index + 1];
                    p1 = paramaters[0] == 0? intcode[p1]: p1;

                    output = p1;

                    index += 2;
                    break;
                case 99:
                    halt = true;
                    break;
                default:
                    Console.WriteLine("ERROR: UNKNOWN COMMAND");
                    break;
            }

            return halt;            
        }

        private static bool _ExecuteCommand2(ref int[] intcode, ref int index, ref int input, ref int output)
        {
            int command = _GetCommand(intcode[index]);
            int[] paramaters = _GetParamaterModes(intcode[index]);

            int p1, p2, p3;

            bool halt = false;

            switch (command)
            {
                case 1:
                case 2:
                    p1 = intcode[index + 1];
                    p2 = intcode[index + 2];
                    p3 = intcode[index + 3];

                    p1 = paramaters[0] == 0? intcode[p1]: p1;
                    p2 = paramaters[1] == 0? intcode[p2]: p2;
                    
                    intcode[p3] = command == 1? p1 + p2: p1 * p2;
                    
                    index += 4;
                    break;
                case 3:
                    p1 = intcode[index + 1];
                    intcode[p1] = input;

                    index += 2;
                    break;
                case 4:
                    p1 = intcode[index + 1];
                    p1 = paramaters[0] == 0? intcode[p1]: p1;

                    output = p1;

                    index += 2;
                    break;
                case 5:
                case 6:
                    p1 = intcode[index + 1];
                    p2 = intcode[index + 2];

                    p1 = paramaters[0] == 0? intcode[p1]: p1;
                    p2 = paramaters[1] == 0? intcode[p2]: p2;

                    if (command == 5)
                    {
                        index = p1 != 0? p2: index + 3;
                    }
                    else
                    {
                        index = p1 == 0? p2: index + 3;
                    }
                    break;
                case 7:
                case 8:
                    p1 = intcode[index + 1];
                    p2 = intcode[index + 2] ;
                    p3 = intcode[index + 3];

                    p1 = paramaters[0] == 0? intcode[p1]: p1;
                    p2 = paramaters[1] == 0? intcode[p2]: p2;

                    if (command == 7)
                    {
                        intcode[p3] = p1 < p2? 1: 0;
                        index += 4;
                    }
                    else
                    {
                        intcode[p3] = p1 == p2? 1: 0;
                        index += 4;
                    }
                    break;
                case 99:
                    halt = true;
                    break;
                default:
                    Console.WriteLine("ERROR: UNKNOWN COMMAND");
                    break;
            }

            return halt;            
        }

        public static void Solve()
        {
            ProblemOne();
            ProblemTwo();
        }

    }
}