namespace AdventOfCode.Y2022
{
  public class Day04 : Solution<int>
  {
    protected override int PartOne(string[] input)
    {
      int count = 0;
      foreach (string line in input)
        if (CompletlyOverlaps(line.Split(",")[0], line.Split(",")[1]))
          count++;

      return count;
    }

    protected override int PartTwo(string[] input)
    {
      int count = 0;
      foreach (string line in input)
        if (Overlaps(line.Split(",")[0], line.Split(",")[1]))
          count++;

      return count;
    }

    static bool Overlaps(string firstPair, string secondPair)
    {
      int[] firstRange = Array.ConvertAll(firstPair.Split("-"), int.Parse);
      int[] secondRange = Array.ConvertAll(secondPair.Split("-"), int.Parse);

      List<int> first = Enumerable.Range(firstRange[0], firstRange[1] - firstRange[0] + 1).ToList();
      List<int> second = Enumerable.Range(secondRange[0], secondRange[1] - secondRange[0] + 1).ToList();

      return first.Intersect(second).ToList().Count > 0;
    }

    static bool CompletlyOverlaps(string firstPair, string secondPair)
    {
      int[] firstRange = Array.ConvertAll(firstPair.Split("-"), int.Parse);
      int[] secondRange = Array.ConvertAll(secondPair.Split("-"), int.Parse);

      if (firstRange[0] <= secondRange[0] && firstRange[1] >= secondRange[1])
        return true;

      if (secondRange[0] <= firstRange[0] && secondRange[1] >= firstRange[1])
        return true;

      return false;
    }

    protected override string[] GetInput()
      => File.ReadAllLines(@"2022\Day04\input.txt");
  }
}