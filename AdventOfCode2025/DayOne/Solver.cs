using System.Collections.Immutable;

namespace AdventOfCode2025.DayOne;

public class Solver : ISolver
{
    public string PartOne()
    {
        var input = Input.Load("DayOne");

        return CountZeroHits(input).ToString();
    }

    public string PartTwo()
    {
        var input = Input.Load("DayOne");
        
        return CountZeroPassings(input).ToString();
    }

    public static int CountZeroHits(ImmutableArray<string> input)
    {
        var zeroCounter = 0;
        var currentValue = 50;
        foreach (var instruction in input)
        {
            currentValue = Rotate(currentValue, instruction).Current;
            
            if(currentValue == 0) zeroCounter++;
        }
        return zeroCounter;
    }

    public static int CountZeroPassings(ImmutableArray<string> input)
    {
        var zeroCounter = 0;
        var currentValue = 50;
        
        foreach (var instruction in input)
        {
            var res = Rotate(currentValue, instruction);
            currentValue = res.Current;
            zeroCounter += res.Wraps;
        }
        return zeroCounter;
    }

    public static RotationResult Rotate(int current, string instruction)
    {
        var direction = instruction[0];
        var amount = int.Parse(instruction[1..]);

        return direction switch
        {
            'L' => new RotationResult(
                Current: (current - amount) % 100 < 0 ? (current - amount) % 100 + 100 : (current - amount) % 100,
                Wraps: current - amount <= 0 ? Math.Abs(current - amount) / 100 + 1 - (current == 0 ? 1 : 0) : 0),
            'R' => new RotationResult(
                Current: (current + amount) % 100,
                Wraps: current + amount >= 100 ? (current + amount) / 100 : 0),
            _ => throw new ArgumentException(nameof(direction))
        };
    }
}