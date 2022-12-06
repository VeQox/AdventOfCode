namespace AdventOfCode.Y2022
{
  public class Day06 : Solution<int>
  {
    protected override int PartOne(string[] input)
    {
      string line = input[0];
      for (int i = 0; i < line.Length - 4; i++)
      {
        char[] currentRange = line[i..(i + 4)].ToCharArray();
        if (AreAllDifferent(currentRange))
        {
          return i + 4;
        }
      }
      return 0;
    }

    protected override int PartTwo(string[] input)
    {
      string line = input[0];
      for (int i = 0; i < line.Length - 14; i++)
      {
        char[] currentRange = line[i..(i + 14)].ToCharArray();
        if (AreAllDifferent(currentRange))
        {
          return i + 14;
        }
      }
      return 0;
    }

    static bool AreAllDifferent(char[] range)
      => range.Distinct().ToArray().Length == range.Length;

    protected override string[] GetInput()
      => File.ReadAllLines(@"2022\Day06\input.txt");
  }
}