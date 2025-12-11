using System.Collections.Immutable;

namespace AdventOfCode2025.DayFour;

public class Solver : ISolver
{
    public long PartOne()
    {
        var input = Input.Load("DayFour");
        
        var paperRollMatrix = TooPaperRollMatrix(input);

        return RemoveAccessibleRolls(paperRollMatrix).Removed;
    }

    public long PartTwo()
    {
        var input = Input.Load("DayFour");

        var paperRollMatrix = TooPaperRollMatrix(input);

        var totalRemoved = 0;
        var currentState = new RollState(paperRollMatrix, 0);
        do
        {
            var newState = RemoveAccessibleRolls(currentState.State);
            currentState = newState;
            totalRemoved += newState.Removed;
        } while (currentState.Removed != 0);

        return totalRemoved;
    }

    public static bool[,] TooPaperRollMatrix(ImmutableArray<string> input)
    {
        var rows = input.Length;
        var cols = input[0].Length;

        var matrix = new bool[rows, cols];
        for (var r = 0; r < rows; r++)
        {
            for (var c = 0; c < cols; c++)
            {
                matrix[r, c] = input[r][c] == '@';
            }
        }
        return matrix;
    }

    public bool ValidateForkliftAccess(Coordinate coordinate, bool[,] input)
    {
        var width = input.GetLength(0);
        var height = input.GetLength(1);

        var validAdjacetCoordinates = CreateAdjenctCoordinates(coordinate)
            .Where(x => x is { X: >= 0, Y: >= 0, } && x.X < width && x.Y < height);
        var res = validAdjacetCoordinates.Select(x => input[x.X, x.Y]);
        return res.Count(x => x) < 4;
    }

    public static ImmutableArray<Coordinate> CreateAdjenctCoordinates(Coordinate c)
    {
        var builder = ImmutableArray.CreateBuilder<Coordinate>();
        foreach (var offset in Offsets)
        {
            builder.Add(new(c.X + offset.X, c.Y + offset.Y));
        }
        return builder.ToImmutable();
    }

    static readonly Coordinate[] Offsets =
    {
        new(-1, -1), new(0, -1), new(1, -1),
        new(-1, 0), new(1, 0),
        new(-1, 1), new(0, 1), new(1, 1),
    };

    public RollState RemoveAccessibleRolls(bool[,] matrix)
    {
        var updatedRolls = (bool [,])matrix.Clone();
        var count = 0;
        for (var x = 0; x < matrix.GetLength(0); x++)
        {
            for (var y = 0; y < matrix.GetLength(1); y++)
            {
                if (matrix[x, y])
                {
                    if (ValidateForkliftAccess(new(x, y), matrix))
                    {
                        count++;
                        updatedRolls[x, y] = false;
                    }      
                }
               
            }
        }
        return new(updatedRolls, count);
    }
}
public record Coordinate(
    int  X, 
    int Y);
    
public record RollState(
        bool [,] State, 
        int Removed);