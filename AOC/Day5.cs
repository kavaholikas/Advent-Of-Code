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
            int step = 0;

            // Get Command
            int command = _GetCommand(intcode[index]);

            // Get Paramater modes
            int[] paramaterModes = _GetParamaterModes(intcode[12]);
            
            foreach (var item in paramaterModes)
            {
                Console.WriteLine(item);
            }

            // Execute commands

            // Get step 

            // Move index
        }

        private static void ProblemTwo()
        {

        }

        private static int _GetCommand(int number)
        {
            string command = number.ToString();
            int length = command.Length;

            if (length == 1 || number == 99)
            {
                return number;
            }

            int commandNumber = int.Parse(command.Substring(length - 2));

            return commandNumber;
        }

        private static int[] _GetParamaterModes(int number)
        {
            int[] paramaterModes = new int[3] {0, 0, 0};

            string command = number.ToString();
            int length = command.Length;

            if (length < 3)
            {
                return paramaterModes; 
            }

            for (int i = length - 2; i > 0; i++)
            {
               paramaterModes[i] = int.Parse(command[i].ToString()); 
            }

            return paramaterModes;
        }

        public static void Solve()
        {
            ProblemOne();
            ProblemTwo();
        }

    }
}