namespace AdventOfCode2025.Day01;

public class Solver : ISolver
{
    public string PartOne()
    {
        var input = Input.Load("Day01");

        var zeroCounter = 0;
        var currentValue = 50;
        foreach (var instruction in input)
        {
            currentValue = Rotate(currentValue, instruction);
            
            if(currentValue == 0) zeroCounter++;
        }
        return zeroCounter.ToString(); 
    }

    public string PartTwo()
    {
        throw new NotImplementedException();
    }
   
    public static int Rotate(int current, string instruction)
    {
        var direction = instruction[0];
        var amount = int.Parse(instruction[1..]);

        return direction switch
        {
            'L' => (current - amount + 100) % 100,
            'R' => (current + amount) % 100,
            _ => throw new ArgumentException(nameof(direction))
        };
    }
}