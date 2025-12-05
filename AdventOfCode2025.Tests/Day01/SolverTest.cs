using Shouldly;

namespace AdventOfCode2025.Day01;

public class SolverTest
{
    [Fact]
    public void GivenCurrent_WhenRotatingRight_ThenCurrentIncrease()
    {
        var result = Solver.Rotate(50, "R10");
        
        result.ShouldBe(60);
    }
    
    [Fact]
    public void GivenCurrent_WhenRotatingLeft_ThenCurrentDecrease()
    {
        var result = Solver.Rotate(50, "L10");

        result.ShouldBe(40);
    }
    
    [Fact]
    public void GivenCurrent_WhenRotatingBelow0_ThenWrap()
    {
        var result = Solver.Rotate(5, "L10");

        result.ShouldBe(95);
    }
 
    [Fact]
    public void GivenCurrent_WhenRotatingAbove99_ThenWrap()
    {
        var result = Solver.Rotate(95, "R10");

        result.ShouldBe(5);
    }


    [Fact]
    public void GivenInstructions_WhenSolving_ThenNumberOfTimesZeroIsHit()
    {
        var sut = new Solver();

        var result = sut.PartOne();
        
        result.ShouldBe("1074");
    }
}