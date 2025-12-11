using System.Collections.Immutable;
using Shouldly;

namespace AdventOfCode2025.DayFive;

public class SolverTest
{
    [Fact]
    public void GivenIdOutOfRange_WhenCheckingIfInside_ThenFalse()
    {
        const int id = 10;

        Solver.IsInRange(id, 11, 15).ShouldBeFalse();
    }
    
    [Fact]
    public void GivenIdInOfRange_WhenCheckingIfInside_ThenTrue()
    {
        const int id = 10;

        Solver.IsInRange(id, 9, 15).ShouldBeTrue();
    }

    [Fact]
    public void GivenInput_WhenLoadingDatabase_ThenRangesAndIds()
    {
        var input = ImmutableArray.Create<string>("3-5", "10-14", "16-20", "12-18", string.Empty, "1", "5", "8", "11", "17", "32");
        
        var res = Solver.ToDatabase(input);
        
        res.ShouldBeEquivalentTo(new Database([new Range(3,5), new Range(10, 14), new Range(16, 20), new(12, 18)], [1,5,8,11,17,32]));
    }


    [Fact]
    public void GivenRangesAndIds_WhenCountingFreshIngredients_ThenCount()
    {
        var ranges = ImmutableArray.Create<Range>(new Range(3,5), new Range(10, 14), new Range(16, 20), new(12, 18));
        var ids = ImmutableArray.Create<long>(1, 5, 8, 11, 17, 32);

        var count = Solver.CountFreshIngredients(new Database(ranges, ids));
        
        count.ShouldBe(3);
    }

    [Fact]
    public void GivenPartOne_WhenSolving_ThenSolved()
    {
        var sut = new Solver();

        var res = sut.PartOne();
        
        res.ShouldBe(529);
    }
    
    [Fact]
    public void GivenRange_WhenCountingIdsInRange_ThenCount()
    {
        var res = Solver.CountRange(new Range(3, 5));
        
        res.ShouldBe(3);
    }

    
    [Fact]
    public void GivenArrayOfRanges_WhenCountingIdsInRange_ThenCount()
    {
        var ranges = ImmutableArray.Create<Range>(
            new(3,5),
            new(10, 14),
            new(16, 20),
            new(12, 18));
        
        var res = Solver.CountIds(ranges);

        res.ShouldBe(14);
    }

    [Fact]
    public void GivenPartTwo_WhenSolving_ThenSolved()
    {
        var sut = new Solver();

        sut.PartTwo().ShouldBe(123);
    }

}