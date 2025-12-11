using System.Collections.Immutable;

namespace AdventOfCode2025.DayThree;

public class Solver : ISolver
{
    public long PartOne()
    {
        var input = Input.Load("DayThree");

        return input.Select(x => MaxNumberFromDigits(x, 2)).Sum();
    }

    public long PartTwo()
    {
        var input = Input.Load("DayThree");

        return input.Select(x => MaxNumberFromDigits(x, 12)).Sum();
    }

    public static long MaxNumberFromDigits(string bank, int k)
    {
        var n = bank.Length;
        var stack = new List<int>(capacity: k);

        for (var i = 0; i < n; i++)
        {
            var d = bank[i] - '0';
            while (stack.Count > 0 && d > stack[^1] && (stack.Count - 1 + (n - i)) >= k)
            {
                stack.RemoveAt(stack.Count - 1);
            }
            if (stack.Count < k)
            {
                stack.Add(d);
            }
        }

        return stack.Aggregate(0L, (current, digit) => current * 10 + digit);
    }
}