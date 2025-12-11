using System.Collections.Immutable;
using System.Text.RegularExpressions;

namespace AdventOfCode2025.DaySix;

public class Solver : ISolver
{

    public long PartOne()
    {
        throw new NotImplementedException();
    }

    public long PartTwo()
    {
        throw new NotImplementedException();
    }

    public static ImmutableDictionary<long, List<string>> ToMatrix(ImmutableArray<string> input)
    {
        var rows = input.Select(x => Regex.Split(x.Trim(), @"\s+")).ToImmutableArray();
        
        var rowLength = rows.Length;
        var colLength = rows[0].Length;

        var dict = new Dictionary<long, List<string>>();

        for (var i = 0; i < colLength; i++)
        {
            dict[i] = [];
            for (var j = 0; j < rowLength; j++)
            {
                dict[i].Add(rows[j][i]);
            }
            
        }
        return dict.ToImmutableDictionary();
    }

}