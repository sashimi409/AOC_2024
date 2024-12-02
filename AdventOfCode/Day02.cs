namespace AdventOfCode;

public class Day02 : BaseDay
{
    private readonly string[] _input;

    public Day02()
    {
        _input = File.ReadAllLines(InputFilePath);

        foreach (string Line in _input)
        {
            string[] TempSplit = Line.Split("   ");
        }
        
    }

    #region Part 1

    public string Part1()
    {
        return 0.ToString();
    }

    #endregion

    #region Part 2

    public string Part2()
    {
        return 0.ToString();
    }

    #endregion

    public override ValueTask<string> Solve_1() => new(Part1());

    public override ValueTask<string> Solve_2() => new(Part2());
}