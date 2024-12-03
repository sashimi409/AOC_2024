using System.Text.RegularExpressions;

namespace AdventOfCode;

public class Day03 : BaseDay
{
    private readonly string _input;

    public Day03()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    #region Part 1

    public string Part1()
    {
        int sum = 0;
        Regex regex = new Regex(@"mul\((\d*),(\d*)\)");
        MatchCollection match = regex.Matches(_input);
        for(int i = 0; i < match.Count; i++)
        {
            
            sum += (int.Parse(match[i].Groups[1].Captures[0].Value)) * (int.Parse(match[i].Groups[2].Captures[0].Value));
        }
        
        return sum.ToString();
    }

    #endregion

    #region Part 2

    public string Part2()
    {
        int sum = 0;
        Regex regex = new Regex(@"mul\((\d*),(\d*)\)|do\(\)|don't\(\)");
        MatchCollection match = regex.Matches(_input);
        bool addToSum = true;
        for(int i = 0; i < match.Count; i++)
        {
            Console.WriteLine(match[i].Value);
            if (match[i].Value == "do()")
            {
                addToSum = true;
                continue;
            } else if (match[i].Value == "don't()")
            {
                addToSum = false;
                continue;
            }

            if (addToSum)
            {
                sum += (int.Parse(match[i].Groups[1].Captures[0].Value)) * (int.Parse(match[i].Groups[2].Captures[0].Value));   
            }
        }
        
        return sum.ToString();
    }

    #endregion

    public override ValueTask<string> Solve_1() => new(Part1());

    public override ValueTask<string> Solve_2() => new(Part2());
}
