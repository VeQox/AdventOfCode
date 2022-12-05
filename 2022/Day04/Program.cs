class Program
{
  const string INPUT_PATH = "input.txt";
  static void Main()
  {
    Console.WriteLine($"PartOne: {PartOne(GetInput())}");
    Console.WriteLine($"PartTwo: {PartTwo(GetInput())}");
  }

  static int PartTwo(string[] input)
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

  static int PartOne(string[] input)
  {
    int count = 0;
    foreach (string line in input)
      if (CompletlyOverlaps(line.Split(",")[0], line.Split(",")[1]))
        count++;

    return count;
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

  static string[] GetInput()
    => File.ReadAllLines(INPUT_PATH);
}