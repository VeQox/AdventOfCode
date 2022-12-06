namespace AdventOfCode.Y2022
{
  public class Day01 : Solution<int>
  {
    protected override int PartOne(string[] input)
    {
      int maxCalories = 0;
      int elfSum = 0;

      foreach (string line in input)
      {
        if (line != "")
        {
          elfSum += int.Parse(line);
        }
        else
        {
          maxCalories = elfSum > maxCalories ? elfSum : maxCalories;
          elfSum = 0;
        }
      }

      return maxCalories;
    }

    protected override int PartTwo(string[] input)
    {
      List<int> calories = new();

      int elfSum = 0;

      foreach (string line in input)
      {
        if (line != "")
        {
          elfSum += int.Parse(line);
        }
        else
        {
          calories.Add(elfSum);
          elfSum = 0;
        }
      }

      return calories.AsEnumerable().OrderByDescending(calorie => calorie).Take(3).Sum();
    }

    protected override string[] GetInput()
        => File.ReadAllLines(@"2022\Day01\input.txt");
  }
}
