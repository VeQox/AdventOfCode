namespace AdventOfCode.Y2022
{
  public class Day03 : Solution<int>
  {
    protected override int PartOne(string[] input)
    {
      int sumOfPrios = 0;

      foreach (string backback in input)
        sumOfPrios += GetPriority(GetDuplicate(backback.Substring(0, backback.Length / 2), backback.Substring(backback.Length / 2))[0]);

      return sumOfPrios;
    }

    protected override int PartTwo(string[] input)
    {
      int sumOfPrios = 0;

      for (int i = 0; i < input.Length; i += 3)
        sumOfPrios += GetPriority(GetDuplicate(input[i], input[i + 1], input[i + 2])[0]);

      return sumOfPrios;
    }

    static int GetPriority(char item)
    {
      if (char.IsUpper(item))
      {
        return item - 'A' + 27;
      }
      return item - 'a' + 1;
    }

    static char[] GetDuplicate(string first, string second)
    {
      return first.ToCharArray().Intersect(second.ToCharArray()).ToArray();
    }
    static char[] GetDuplicate(string first, string second, string third)
    {
      return GetDuplicate(first, second).Intersect(third).ToArray();
    }

    protected override string[] GetInput()
      => File.ReadAllLines(@"2022\Day03\input.txt");
  }
}