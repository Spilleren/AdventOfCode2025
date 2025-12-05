using System.Collections;
using System.Collections.Immutable;
using Shouldly;

namespace AdventOfCode2025.DayTwo;

public class SolverTest
{
    [Fact]
    public void GivenNumberWithNoSillyPattern_WhenCheckingForSillyPattern_ThenFalse()
    {
        var sut = new Solver();

        var res = sut.CheckForSillyPattern(123);
        
        res.ShouldBe(false);
    }
    
    [Fact]
    public void GivenNumberWithSillyPattern_WhenCheckingForSillyPattern_ThenFalse()
    {
        var sut = new Solver();

        var res = sut.CheckForSillyPattern(123123);
        
        res.ShouldBe(true);
    }
    
    [Fact]
    public void GivenRange_WhenGettingSillyPattern_ThenSillyPatterns()
    {
        var sut = new Solver();
        
        var res = sut.GetSillyPattern(11, 22);
        
        res.ShouldBe([11, 22]);
    }
    
    [Fact]
    public void GivenRanges_WhenGettingSumOfSilly_ThenSumOfSillyPatterns()
    {
        var sut = new Solver();
        
        var res = sut.GetSillySum(ImmutableArray.Create<DayTwo.Range>(
            new(11, 22),
            new(95, 115),
            new(998, 1012),
            new(1188511880, 1188511890),
            new(222220, 222224),
            new(1698522, 1698528),
            new(446443, 446449),
            new(38593856, 38593862)));
        
        res.ShouldBe(1227775554);
    }
    
    [Fact]
    public void GivenPartOne_WhenSolving_ThenCorrectAnswer()
    {
        var sut = new Solver();

        var res = sut.PartOne();
        
        res.ShouldBe("32976912643");
    }
    
    [Fact]
    public void GivenRange_WhenGettingSillyPatternPartTwo_ThenSillyPatterns()
    {
        var sut = new Solver();
        
        var res = sut.GetSillyPatternPart2(11, 22);
        
        res.ShouldBe([11, 22]);
    }
    
    [Fact]
    public void GivenPartTwo_WhenSolving_ThenCorrectAnswer()
    {
        var sut = new Solver();

        var res = sut.PartTwo();
        
        res.ShouldBe("54446379122");
    }
}