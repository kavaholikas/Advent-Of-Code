using System;

namespace AOC2019
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            if (args.Length == 0) 
            {
                Day3.Solve();
                return;
            }

            switch (args[0])
            {
                case "1":
                    Day1.Solve();
                    break;
                case "2":
                    Day2.Solve();
                    break;
                case "3":
                    Day3.Solve();
                    break;
                
                default:
                    Console.WriteLine("Wrong Day");
                    break;
            }
        }
    }
}
