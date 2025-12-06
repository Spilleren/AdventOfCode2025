using System.Collections.Immutable;
using Shouldly;

namespace AdventOfCode2025.DayThree;

public class SolverTest
{
    [Fact]
    public void GivenBatteryBank_WhenGettingMaxNumberWithTwoDigits_ThenHightestTwoDigitJoltage()
    {
        var sut = new Solver();
        var bank = "818181111121119";

        var res = Solver.MaxNumberFromDigits(bank, 2);

        res.ShouldBe(89);
    }
    
    [Fact]
    public void GivenPartOne_WhenSolving_ThenCorrectAnswer()
    {
        var sut = new Solver();

        var res = sut.PartOne();
        
        res.ShouldBe("16973");
    }
    
    [Fact]
    public void GivenBatteryBank_WhenGettingMaxNumberWithTwelveDigits_ThenHightestTwelveDigitJoltage()
    {
        var sut = new Solver();
        var bank = "987654321111111";

        var res = Solver.MaxNumberFromDigits(bank, 12);

        res.ShouldBe(987654321111);
    }
    
    [Fact]
    public void GivenPartTwo_WhenSolving_ThenCorrectAnswer()
    {
        var sut = new Solver();

        var res = sut.PartTwo();
        
        res.ShouldBe("168027167146027");
    }

}