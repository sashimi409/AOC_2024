namespace AdventOfCode;

public class Day01 : BaseDay
{
    private readonly string[] _input;
    List<int> FirstList = new List<int>();
    List<int> SecondList = new List<int>();

    public Day01()
    {
        _input = File.ReadAllLines(InputFilePath);

        foreach (string Line in _input)
        {
            string[] TempSplit = Line.Split("   ");
            FirstList.Add(int.Parse(TempSplit[0]));
            SecondList.Add(int.Parse(TempSplit[1]));
        }
        
    }

    public string Part1()
    {
        int sum = 0;
        FirstList.Sort();
        SecondList.Sort();
        for (int i = 0; i < FirstList.Count; i++)
        {
            int difference = SecondList[i] - FirstList[i];
            int distance = difference>0 ? difference : difference*-1;
            sum += distance;
        }
        
        return sum.ToString();
    }
    
    public string Part2()
    {
        int sum = 0;
       Dictionary<int, int> Occurances = new Dictionary<int, int>();

       foreach (int location in SecondList)
       {
           if(!Occurances.ContainsKey(location))
           {
               Occurances.Add(location, 1);
           }
           else
           {
               Occurances[location]++;
           }
       }

       foreach (int location in FirstList)
       {
           if (!Occurances.ContainsKey(location))
           {
               continue;
           }
           else
           {
               sum += Occurances[location]*location;
           }
       }
       
       return sum.ToString();
    }
    public override ValueTask<string> Solve_1() => new(Part1());

    public override ValueTask<string> Solve_2() => new(Part2());
}
