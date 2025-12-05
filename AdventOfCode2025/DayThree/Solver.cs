using System.Collections.Immutable;

namespace AdventOfCode2025.DayThree;

public class Solver : ISolver
{
    public string PartOne()
    {
        var input = Input.Load("DayThree");
        
        return GetSumOfJoltage(input).ToString();
    }

    public long GetSumOfJoltage(ImmutableArray<string> input)
    {
        return input.Select(GetHighestTwoDigitJoltage).Sum();
    }

    public string PartTwo()
    {
        var input = Input.Load("DayThree");

        return input.Select(GetHighestTwelveDigitJoltage).Sum().ToString();
    }


    public int GetHighestTwoDigitJoltage(string bank)
    {
        var digits = bank.Select(x => Convert.ToInt64(x) - '0').ToArray();
        var max = digits.Max();
        if (max != digits[^1])
        {
            var secondHighest= digits.Skip(digits.IndexOf(max)+1).Max();
            return Convert.ToInt32($"{max}{secondHighest}");
        }
        
        var orderedDigits = digits.OrderBy(x => x).ToArray();
        return Convert.ToInt32($"{orderedDigits[^2]}{orderedDigits[^1]}");
    }

    public long GetHighestTwelveDigitJoltage(string bank)
    {
        var digits = bank.Select(x => Convert.ToInt64(x) - '0').ToArray();
        var withOutThelastTwelve= digits.SkipLast(11).ToArray();
        var max = withOutThelastTwelve.Max();
        if (withOutThelastTwelve.Contains(max))
        {
            var secondHighest= string.Concat(digits.Skip(digits.IndexOf(max)+1).Take(11));
            return Convert.ToInt64($"{max}{secondHighest}");
        }
        
        var orderedDigits = digits.OrderBy(x => x).ToArray();
        return Convert.ToInt32($"{orderedDigits[^2]}{orderedDigits[^1]}");
    }
}