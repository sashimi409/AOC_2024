namespace AdventOfCode;

public class Day02 : BaseDay
{
    private readonly string[] _input;

    public Day02()
    {
        _input = File.ReadAllLines(InputFilePath);

        foreach (string Line in _input)
        {
            int[] levels = Line.Split(' ').Select(int.Parse).ToArray();
            string[] TempSplit = Line.Split("   ");
        }
        
    }

    #region Shared

    public bool isSafe(int[] levels)
    {
        bool Ascending = (levels[0] < levels[1]);
        for (int i = 1; i < levels.Length; i++)
        {
            if (Ascending)
            {
                if (levels[i] > levels[i - 1])
                {
                    if (levels[i] - levels[i-1] <= 3)
                    {
                        if (i == levels.Length - 1)
                        {
                            return true;
                        }
                        continue;
                    }
                }

                break;

            }
            else
            {
                if (levels[i] < levels[i - 1])
                {
                    if (levels[i-1] - levels[i] <= 3)
                    {
                        if (i == levels.Length - 1)
                        {
                            return true;
                        }
                        continue;
                    }
                }

                break;
            }
        }

        return false;
    }
    
    #endregion
    
    #region Part 1

    public string Part1()
    {
        int safeReports = 0;
        foreach (string line in _input)
        {
            int[] levels = line.Split(' ').Select(int.Parse).ToArray();
            if(isSafe(levels)) safeReports++ ;
        }
        return safeReports.ToString();
    }

    #endregion

    #region Part 2

    public string Part2()
    {
        int safeReports = 0;
        foreach (string line in _input)
        {
            int[] levels = line.Split(' ').Select(int.Parse).ToArray();
            if (isSafe(levels))
            {
                safeReports++ ;
            }
            else
            {
                for (int i = 0; i < levels.Length; i++)
                {
                    int[] tempArray = levels.Where((source, index) => index != i).ToArray();
                    if (isSafe(tempArray))
                    {
                        safeReports++;
                        break;
                    }
                }
            }
        }
        return safeReports.ToString();
    }

    #endregion

    public override ValueTask<string> Solve_1() => new(Part1());

    public override ValueTask<string> Solve_2() => new(Part2());
}