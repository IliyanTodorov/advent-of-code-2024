namespace AdventOfCode2024_Solutions.day_2
{
    public class Task1
    {
        public static void Main(string[] args)
        {
            var reports = File.ReadAllLines("../../../input.txt")
                        .Select(line => line.Split(' ', StringSplitOptions.RemoveEmptyEntries))
                        .Select(x => x
                            .Select(int.Parse)
                            .ToList())
                        .ToList();

            int validReports = reports.Count(report =>
            IsReportValid(report, (current, next) => current < next) ||
            IsReportValid(report, (current, next) => current > next));

            Console.WriteLine(validReports);
        }

        static bool IsReportValid(List<int> report, Func<int, int, bool> compare)
        {
            for (int level = 0; level < report.Count - 1; level++)
            {
                int currentLevel = report[level];
                int nextLevel = report[level + 1];
                int difference = Math.Abs(currentLevel - nextLevel);

                if (!(difference >= 1 && difference <= 3) || currentLevel == nextLevel || !compare(currentLevel, nextLevel))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
