using Shouldly;

namespace AdventOfCode2025.DayOne;

public class SolverTest
{
    [Fact]
    public void GivenCurrent_WhenRotatingRight_ThenCurrentIncrease()
    {
        var result = Solver.Rotate(50, "R10");
        
        result.Current.ShouldBe(60);
    }
    
    [Fact]
    public void GivenCurrent_WhenRotatingLeft_ThenCurrentDecrease()
    {
        var result = Solver.Rotate(50, "L10");

        result.Current.ShouldBe(40);
    }
    
    [Fact]
    public void GivenCurrent_WhenRotatingBelow0_ThenRotationResult()
    {
        var result = Solver.Rotate(50, "L500");

        result.Current.ShouldBe(50);
        result.Wraps.ShouldBe(5);
    }
 
    [Fact]
    public void GivenCurrent_WhenRotatingAbove99_ThenRotationResult()
    {
        var result = Solver.Rotate(95, "R100");

        result.Current.ShouldBe(95);
        result.Wraps.ShouldBe(1);
    }

    [Fact]
    public void GivenInstructions_WhenCountingZeroHits_ThenNumberOfTimesZeroIsHit()
    {

        var result = Solver.CountZeroHits(["L50", "R10", "L10"]);
        
        result.ShouldBe(2);
    }

    [Fact]
    public void GivenPartOne_WhenSolving_ThenCorrectAnswer()
    {
        var sut = new Solver();

        var result = sut.PartOne();
        
        result.ShouldBe("1074");
    }

    [Fact]
    public void GivenInstructions_WhenCountinZeroPassed_ThenNumberOfTimeZeroIsPassed()
    {
        var result = Solver.CountZeroPassings(["L68", "L30", "R48", "L5", "R60", "L55", "L1", "L99", "R14", "L82", "R200"]);

        result.ShouldBe(8);
    }

    [Fact]
    public void GivenInstructions_WhenCountinZeroPassed2_ThenNumberOfTimeZeroIsPassed()
    {
        var result = Solver.CountZeroPassings(["R1000", "L1000", "L50", "R1", "L1", "L1", "R1", "R100", "R1"]);

        result.ShouldBe(24);
    }

    [Fact]
    public void GivenPartTwo_WhenSolving_ThenCorrectAnswer()
    {
        var sut = new Solver();

        var result = sut.PartTwo();

        result.ShouldBe("6254");
    }
}