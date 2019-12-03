using System;

namespace AOC2019
{
    class Day1
    {
        private static void ProblemOne()
        {
           string[] input = Utils.LoadInputArray("Day1", "Input1"); 

           int fuel = 0;

           for (int i = 0; i < input.Length; i++)
           {
               int n = int.Parse(input[i]);

               fuel += n / 3 - 2;
           }

           Console.WriteLine($"Day1: Problem One Result: {fuel}");
           Utils.SaveResults("Day1", "Output1", fuel.ToString());
        }

        private static void ProblemTwo()
        {
            string[] input = Utils.LoadInputArray("Day1", "Input2");

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

           Console.WriteLine($"Day1: Problem Two Result: {fuel}");
           Utils.SaveResults("Day1", "Output2", fuel.ToString());
        }

        public static void Solve()
        {
            ProblemOne();
            ProblemTwo();
        }
    }
}