using System;

namespace AOC2019
{
    class Program
    {
        static void Main(string[] args)
        {
            switch (args[0])
            {
                case "1":
                    Day1.Solve();
                    break;
                
                default:
                    Console.WriteLine("Wrong Day");
                    break;
            }
        }
    }
}
