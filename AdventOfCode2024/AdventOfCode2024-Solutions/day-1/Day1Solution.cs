namespace AdventOfCode2024_Solutions.Day_1
{
    public class Day1Solution
    {
        const int inputLines = 1000;

        public static void Main(string[] args)
        {
            var input = File.ReadAllLines("../../../day-1/input.txt")
                        .Select(line => line.Split(' ', StringSplitOptions.RemoveEmptyEntries))
                        .Select(parts => new
                        {
                            LeftColumn = int.Parse(parts[0]),
                            RightColumn = int.Parse(parts[1])
                        })
                        .ToArray();

            var leftColumn = input.Select(x => x.LeftColumn).ToList();
            var rightColumn = input.Select(x => x.RightColumn).ToList();

            int part1Result = SolvePart1(leftColumn, rightColumn);
            Console.WriteLine($"Part 1: {part1Result}");

            int part2Result = SolvePart2(leftColumn, rightColumn);
            Console.WriteLine($"Part 2: {part2Result}");
        }

        public static int SolvePart1(List<int> leftColumn, List<int> rightColumn)
        {
            var leftList = new List<int>(leftColumn);
            var rightList = new List<int>(rightColumn);

            int totalDistance = 0;

            leftList.Sort();
            rightList.Sort();

            for (int i = 0; i < inputLines; i++)
            {
                totalDistance += Math.Abs(leftList[i] - rightList[i]);   
            }

            return totalDistance;
        }

        public static int SolvePart2(List<int> leftColumn, List<int> rightColumn)
        {
            int similarity = 0;

            for (int i = 0; i < leftColumn.Count; i++)
            {
                int leftNum = leftColumn[i];

                int count = rightColumn.FindAll(x => x == leftNum).Count();

                similarity += leftNum * count;
            }

            return similarity;
        }
    }
}