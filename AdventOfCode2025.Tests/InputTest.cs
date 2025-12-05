using Shouldly;

namespace AdventOfCode2025;

public class InputTest
{
    [Fact]
    public void GivenPath_WhenLoading_ThenInputRead()
    {
        var input = Input.Load("DayTest");
        
        input.ShouldBe(["R22", "L23", "L2", "R40"]);
    }
    
}