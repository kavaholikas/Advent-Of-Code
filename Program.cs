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
                Day6.Solve();
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
                case "4":
                    Day4.Solve();
                    break;
                case "5":
                    Day5.Solve();
                    break;
                case "6":
                    Day6.Solve();
                    break;

                case "all":
                    Day1.Solve();
                    Day2.Solve();
                    Day3.Solve();
                    Day4.Solve();
                    Day5.Solve();
                    Day6.Solve();
                    break;
                default:
                    Console.WriteLine("Wrong Day");
                    break;
            }
        }
    }
}
