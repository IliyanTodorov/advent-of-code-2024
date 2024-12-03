using System.Text.RegularExpressions;

namespace AdventOfCode2024_Solutions.day_3.part_2
{
    public class Task2
    {
        public static void Main(string[] args)
        {
            string input = File.ReadAllText("../../../input.txt");

            string pattern = @"mul\((\d{1,3}),(\d{1,3})\)|(don't\(\)|do\(\))";

            MatchCollection matches = Regex.Matches(input, pattern);

            int sum = 0;
            bool isEnaibled = true;
            foreach (Match match in matches)
            {
                switch (match.Value)
                {
                    case "do()":
                        isEnaibled = true;
                        continue;
                    case "don't()":
                        isEnaibled = false;
                        continue;
                    default:
                        if (!isEnaibled) continue;

                        int x = int.Parse(match.Groups[1].Value);
                        int y = int.Parse(match.Groups[2].Value);

                        sum += x * y;

                        break;
                }
            }

            Console.WriteLine(sum);
        }
    }
}
