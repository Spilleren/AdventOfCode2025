using System.Collections.Immutable;
using Shouldly;

namespace AdventOfCode2025.DayThree;

public class SolverTest
{
    [Fact]
    public void GivenBatteryBank_WhenGettingHighestJoltage_ThenHightestJoltage()
    {
        var sut = new Solver();
        var bank = "818181111121119";

        var res = sut.GetHighestJoltage(bank);

        res.ShouldBe(89);
    }
    
    
    [Fact]
    public void GivenBatteryBanks_WhenGettingJoltageSum_ThenJoltageSum()
    {
        var sut = new Solver();
        var banks = ImmutableArray.Create<string>(
            "987654321111111",
            "811111111111119",
            "234234234234278",
            "818181911112111");

        var res = sut.GetSumOfJoltage(banks);
        
        res.ShouldBe(357);
    }

    [Fact]
    public void GivenPartOne_WhenSolving_ThenCorrectAnswer()
    {
        var sut = new Solver();

        var res = sut.PartOne();
        
        res.ShouldBe("16973");
    }
}