using System;

namespace AOC2019
{
    class Day1
    {
        private static string Name = "Day1";
        private static string InputOne = "Input1";
        private static string InputTwo = "Input2";
        private static string OutputOne = "Output1";
        private static string OutputTwo = "Output2";

        private static void ProblemOne()
        {
           string[] input = Utils.LoadInput(Name, InputOne); 

           int fuel = 0;

           for (int i = 0; i < input.Length; i++)
           {
               int n = int.Parse(input[i]);

               fuel += n / 3 - 2;
           }

           Console.WriteLine($"{Name}: Problem One Result: {fuel}");
           Utils.SaveResults(Name, OutputOne, fuel.ToString());
        }

        private static void ProblemTwo()
        {
            string[] input = Utils.LoadInput(Name, InputTwo);

            int fuel = 0;

            for (int i = 0; i < input.Length; i++)
            {
                int moduleFuel = 0;
                int n = int.Parse(input[i]);

                int result = 0;
                do

                {
                    moduleFuel += result;
                    result = n / 3 - 2;
                    n = result;
                } while (result > 0);

                fuel += moduleFuel;
            }

           Console.WriteLine($"{Name}: Problem Two Result: {fuel}");
           Utils.SaveResults(Name, OutputTwo, fuel.ToString());
        }

        public static void Solve()
        {
            ProblemOne();
            ProblemTwo();
        }
    }
}