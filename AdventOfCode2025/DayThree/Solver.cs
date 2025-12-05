using System.Collections.Immutable;

namespace AdventOfCode2025.DayThree;

public class Solver : ISolver
{
    public string PartOne()
    {
        var input = Input.Load("DayThree");
        
        return GetSumOfJoltage(input).ToString();
    }

    public int GetSumOfJoltage(ImmutableArray<string> input)
    {
        return input.Select(GetHighestJoltage).Sum();
    }

    public string PartTwo()
    {
        throw new NotImplementedException();
    }


    public int GetHighestJoltage(string bank)
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
}