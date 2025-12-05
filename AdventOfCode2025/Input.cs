using System.Collections.Immutable;

namespace AdventOfCode2025;

public static class Input
{
    public static ImmutableArray<string> Load(string day) => [..File.ReadAllLines($"{day}/Input.txt")];
}