using System.Collections.Immutable;
using Shouldly;

namespace AdventOfCode2025.DaySix;

public class SolverTest
{
    [Fact]
    public void GivenInput_WhenMakingMatrix_ThenMatrix()
    {
        var input = ImmutableArray.Create(
            "123 328 51 64 ",
            " 45 64 387 23 ",
            "6 98 215 314",
            "* + * + "
        );
        
        var res = Solver.ToMatrix(input);

        var expected = new Dictionary<long, List<string>>
        {
            { 0, ["123", "45", "6", "*"] },
            { 1, ["328", "64", "98", "+"] },
            { 2, ["51", "387", "215", "*"] },
            { 3, ["64", "23", "314", "+"] }
        }.ToImmutableDictionary();   
        res.Keys.ShouldBeEquivalentTo(expected.Keys);
        res.Values.ShouldBeEquivalentTo(expected.Values);
    }
    
    [Fact]
    public void GivenPartOne_WhenSolving_ThenSolved()
    {
        
    }
}