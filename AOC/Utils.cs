using System.IO;

namespace AOC2019
{
    class Utils
    {
        public static string InputDir = Path.Combine("AOC", "Input");
        public static string OutputDir = Path.Combine("AOC", "Output"); 
        public static string[] LoadInputArray(string day, string input)
        {
            string filePath = Path.Combine(InputDir, day, input + ".txt");
            return File.ReadAllLines(filePath);
        }

        public static string LoadInputString(string day, string input)
        {
            string filePath = Path.Combine(InputDir, day, input + ".txt");
            return File.ReadAllText(filePath);
        }

        public static void SaveResults(string day, string output, string result)
        {
            string filePath = Path.Combine(OutputDir, day, output + ".txt");
            File.WriteAllText(filePath, result);
        }

        public static void CreateInputOutputFolders()
        {
            for (int i = 1; i < 26; i++)
            {
                Directory.CreateDirectory(Path.Combine(InputDir, "Day" + i));
                Directory.CreateDirectory(Path.Combine(OutputDir, "Day" + i));
            }
        }
    }
}