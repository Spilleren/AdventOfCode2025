using System.Collections.Immutable;
using Shouldly;

namespace AdventOfCode2025.DayFour;

public class SolverTest
{
   [Fact]
   public void GivenInput_WhenLoading_ThenArrayOfBoolArray()
   {
      var input = ImmutableArray.Create<string>(
         "..@@",
         "@@@.",
         "@@@@");

      var res = Solver.TooPaperRollMatrix(input);

      bool[,] expected = { { false, false, true, true }, { true, true, true, false }, { true, true, true, true } };
      res.ShouldBe(expected);
   }

   [Fact]
   public void GivenCoordinateWithFewerThanFourAdjacentTrueValues_WhenValidatingForkliftAccess_ThenTrue()
   {
      var sut = new Solver();
      bool[,] matrix = { { true, true, true }, { false, true, true }, { false, false, false } };

      sut.ValidateForkliftAccess(new(0, 0), matrix).ShouldBeTrue();
   }

   [Fact]
   public void GivenCoordinate_WhenGettingAdjacentCoordinates_ThenAdjacentCoordinates()
   {
      var coordinate = new Coordinate(1, 1);
      
      var res = Solver.CreateAdjenctCoordinates(coordinate);
      
      res.ShouldBe([
         new(0, 0), new(1, 0), new(2, 0), 
         new(0, 1), new(2, 1),
         new(0, 2), new(1, 2), new(2, 2)]);
   }

   [Fact]
   public void GivenCoordinateWithFourAdjacentTrueValues_WhenValidatingForkliftAccess_ThenFalse()
   {
      var sut = new Solver();
      bool[,] matrix= { { true, true, true }, { false, true, true }, { false, false, false } };

      sut.ValidateForkliftAccess(new(1, 1), matrix) .ShouldBeFalse();
   }

   [Fact]
   public void GivenPaperRollMatrix_WhenCountingRollsAccessibleForForklift_ThenAccessible()
   {
      var sut = new Solver();
      var input = ImmutableArray.Create<string>(
         "..@@.@@@@.",
         "@@@.@.@.@@",
         "@@@@@.@.@@",
         "@.@@@@..@.",
         "@@.@@@@.@@",
         ".@@@@@@@.@",
         ".@.@.@.@@@",
         "@.@@@.@@@@",
         ".@@@@@@@@.",
         "@.@.@@@.@.");
      var matrix = Solver.TooPaperRollMatrix(input);
      
      var res = sut.RemoveAccessibleRolls(matrix);
      
      res.Removed.ShouldBe(13);
   }

   [Fact]
   public void GivenPartOne_WhenSolving_ThenSolve()
   {
      var sut = new Solver();

      var res = sut.PartOne();
      
      res.ShouldBe("1419");
   }
   
   

   [Fact]
   public void GivenPaperRollMatrix_WhenRemovingPaperRolls_ThenMatrixWithoutRemovedRolls()
   {
      var sut = new Solver();
      var input = ImmutableArray.Create<string>(
         "..@@.@@@@.",
         "@@@.@.@.@@",
         "@@@@@.@.@@",
         "@.@@@@..@.",
         "@@.@@@@.@@",
         ".@@@@@@@.@",
         ".@.@.@.@@@",
         "@.@@@.@@@@",
         ".@@@@@@@@.",
         "@.@.@@@.@.");
      var matrix = Solver.TooPaperRollMatrix(input);
      
      var res = sut.RemoveAccessibleRolls(matrix);

      var expected = Solver.TooPaperRollMatrix([
         ".......@..",
         ".@@.@.@.@@",
         "@@@@@...@@",
         "@.@@@@..@.",
         ".@.@@@@.@.",
         ".@@@@@@@.@",
         ".@.@.@.@@@",
         "..@@@.@@@@",
         ".@@@@@@@@.",
         "....@@@..."
      ]);
      res.ShouldBeEquivalentTo(new RollState(expected, 13));
   }

   [Fact]
   public void GivenPart2_WhenSolving_ThenSolved()
   {
      var sut = new Solver();

      var res = sut.PartTwo();
      
      res.ShouldBe("8739");
   }
}