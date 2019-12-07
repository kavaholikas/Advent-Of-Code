using System;
using System.Text.RegularExpressions;

namespace AOC2019
{
    class Day4
    {
        private static void ProblemOne()
        {
            string input = Utils.LoadInputString("Day4", "Input1");

            int lowerRange = int.Parse(input.Split("-")[0]);
            int upperRange = int.Parse(input.Split("-")[1]);

            int passwordCount = 0;
            int root = 1;

            passwordCount = _GeneratePassword("", root, passwordCount, lowerRange, upperRange);

            Console.WriteLine($"Day4: Problem One Result: {passwordCount}");
            Utils.SaveResults("Day4", "Output1", passwordCount.ToString());
        }

        private static int _GeneratePassword(string password, int root, int count, int lowerRange, int upperRange)
        {
            if (password.Length < 6)
            {
                for (int i = root; i < 10; i++)
                {
                    string s = password + i;
                    count = _GeneratePassword(s, i, count, lowerRange, upperRange);
                }
            }
            else
            {
                int p = int.Parse(password);
                if (password.Length == 6 && p > lowerRange && p < upperRange)
                {
                    bool repeating = false;
                    for (int i = 0; i < password.Length - 1; i++)
                    {
                        if (password[i] == password[i + 1])
                        {
                            repeating = true;
                            break;
                        }
                    }
                    if (repeating)
                    {
                        return count + 1;
                    }
                    else
                    {
                        return count;
                    }
                }
                else
                {
                    return count;
                }
            }

            return count;
        }

        private static int _GeneratePassword2(string password, int root, int count, int lowerRange, int upperRange)
        {
            if (password.Length < 6)
            {
                for (int i = root; i < 10; i++)
                {
                    string s = password + i;
                    count = _GeneratePassword2(s, i, count, lowerRange, upperRange);
                }
            }
            else
            {
                int p = int.Parse(password);
                if (password.Length == 6 && p > lowerRange && p < upperRange)
                {
                    bool pair = false;

                    int r = 0;
                    for (int i = 0; i < password.Length - 1; i++)
                    {
                        if (password[i] == password[i + 1])
                        {
                            r++;    
                        }
                        else 
                        {
                            if (r == 1)
                            {
                                pair = true;
                                break;
                            }
                            r = 0;
                        }
                    }

                    if (r == 1)
                    {
                        pair = true;
                    }

                    if (pair)
                    {
                        return count + 1;
                    }
                    else
                    {
                        return count;
                    }
                }
                else
                {
                    return count;
                }
            }

            return count;
        }


        private static void ProblemTwo()
        {
            string input = Utils.LoadInputString("Day4", "Input1");

            int lowerRange = int.Parse(input.Split("-")[0]);
            int upperRange = int.Parse(input.Split("-")[1]);

            int passwordCount = 0;
            int root = 1;

            passwordCount = _GeneratePassword2("", root, passwordCount, lowerRange, upperRange);

            Console.WriteLine($"Day4: Problem Two Result: {passwordCount}");
            Utils.SaveResults("Day4", "Output2", passwordCount.ToString());
        }

        public static void Solve()
        {
            ProblemOne();
            ProblemTwo();
        }
    }
}