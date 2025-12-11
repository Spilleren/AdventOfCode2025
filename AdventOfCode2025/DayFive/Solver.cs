using System.Collections;
using System.Collections.Immutable;
using System.Runtime.InteropServices.ComTypes;

namespace AdventOfCode2025.DayFive;

public class Solver : ISolver
{

    public long PartOne()
    {
        var input = Input.Load("DayFive");
        var database = ToDatabase(input);
        
        return CountFreshIngredients(database);
    }

    public long PartTwo()
    {
        var input = Input.Load("DayFive");
        var ranges = ToDatabase(input).Ranges;
        
        return CountIds(ranges);
    }

    static IEnumerable<long> GenerateRange(long first, long last)
    {
        for (var i = first; i <= last; i++)
        {
            yield return i;
        }
    }

    public static bool IsInRange(long id, long first, long last) =>
        (ulong)(id - first) <= (ulong)(last - first);

    public static int CountFreshIngredients(Database database)
    {
        var freshIds = ImmutableList.Create<long>();
        freshIds = (database.Ranges.SelectMany(range => database.Ids, (range, id) => new { range, id })
            .Where(@t => IsInRange(@t.id, @t.range.First, @t.range.Last))
            .Select(@t => @t.id)).Aggregate(freshIds, (current, id) => current.Add(id));
        return freshIds.Distinct().ToImmutableArray().Length;
    }

    public static Database ToDatabase(ImmutableArray<string> input)
    {
        var indexOfEmptyLine = input.IndexOf(string.Empty);
        var ranges = input.Take(indexOfEmptyLine).Select(x => x.Split('-')).Select(x => new Range(long.Parse(x[0]), long.Parse(x[1]))).ToImmutableArray();
        var enumerable = input.Skip(indexOfEmptyLine + 1);
        var ids = enumerable.Select(long.Parse).ToImmutableArray();
        
        return new(ranges, ids);
    }

    public static long CountRange(Range range) =>
        GenerateRange(range.First, range.Last).Count();


    public static long CountIds(ImmutableArray<Range> ranges)
    {
        var ordered = ranges.OrderBy(x => x.First).ToList();

         var merged = new List<Range>();
         var current = ordered[0];

         foreach (var range in ordered.Skip(1))
         {
             if (range.First <= current.Last)
             {
                 
                 current = current with { Last = Math.Max(range.Last, current.Last) };
             }
             else
             {
                 merged.Add(current);
                 current = range;
             }
         }
         
         merged.Add(current);

         return merged.Sum(x => x.Last - x.First + 1);
    }
}
public record Range(long First, long Last);

public record Database(ImmutableArray<Range> Ranges, ImmutableArray<long> Ids);