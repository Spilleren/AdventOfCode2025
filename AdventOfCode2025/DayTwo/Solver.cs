using System.Collections.Immutable;

namespace AdventOfCode2025.DayTwo;

public class Solver : ISolver
{
    public string PartOne()
    {
        var input = Input.Load("DayTwo");

        var ranges = input.First().Split(',').Select(x => x.Split('-')).Select(x => new Range(long.Parse(x[0]), long.Parse(x[1])));
        
        var sillyPatterns = ranges.Select(x => GetSillyPattern(x.First, x.Last)).SelectMany(x => x);
        
        return sillyPatterns.Sum().ToString();
    }

    public string PartTwo()
    {
        var input = Input.Load("DayTwo");

        var ranges = input.First().Split(',').Select(x => x.Split('-')).Select(x => new Range(long.Parse(x[0]), long.Parse(x[1])));
        
        var sillyPatterns = ranges.Select(x => GetSillyPatternPart2(x.First, x.Last)).SelectMany(x => x);
        
        return sillyPatterns.Sum().ToString();   
    }

    public bool CheckForSillyPattern(long i)
    {
        var digits = i.ToString();
        var first = digits.Take(digits.Length / 2).ToArray();
        var second = digits.Skip(digits.Length / 2).ToArray();
        return first.Length == second.Length && first.SequenceEqual(second);
    }

    public bool CheckForSillyPatternPart2(long i)
    {
        var digits = i.ToString();
        return (digits + digits).IndexOf(digits, 1, StringComparison.Ordinal) != digits.Length;
    }

    public IEnumerable<long> GetSillyPattern(long first, long last)
    {
        var values = GenerateRange(first, last);
        
        return [..values.Where(CheckForSillyPattern)];
    }

    public IEnumerable<long> GetSillyPatternPart2(long first, long last)
    {
        var values = GenerateRange(first, last);
        
        return [..values.Where(CheckForSillyPatternPart2)];
    }

    IEnumerable<long> GenerateRange(long first, long last)
    {
        for (var i = first; i <= last; i++)
        {
            yield return i;
        }
    }

    public long GetSillySum(ImmutableArray<Range> ranges)
    {
        var sillyPatterns = ranges.Select(x => GetSillyPattern(x.First, x.Last)).SelectMany(x => x);
        return sillyPatterns.Sum();
    }
}
public record Range(
    long First,
    long Last);