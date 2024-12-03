using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventOfCode2024_Solutions.day_3
{
    public class Task1
    {
        public static void Main(string[] args)
        {
            string input = File.ReadAllText("../../../input.txt");

            string pattern = @"mul\((\d{1,3}),(\d{1,3})\)";

            MatchCollection matches = Regex.Matches(input, pattern);

            int sum = 0;
            foreach (Match match in matches)
            {
                int x = int.Parse(match.Groups[1].Value);
                int y = int.Parse(match.Groups[2].Value);

                sum += x * y;
            }

            Console.WriteLine(sum);
        }
    }
}