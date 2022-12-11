namespace AdventOfCode.Y2022
{
  public class Day11 : Solution<int>
  {
    protected override int PartOne(string[] input)
    {
      Barrel Monkeys = ParseMonkeys(input);
      Monkeys.SimulateRounds(20);
      Monkey[]? top2Monkeys = Monkeys.Monkeys?.OrderByDescending(monkey => monkey.InspectionCount).Take(2).ToArray();
      return top2Monkeys![0].InspectionCount * top2Monkeys[1]!.InspectionCount;
    }

    protected override int PartTwo(string[] input)
    {
      Barrel Monkeys = ParseMonkeys(input);
      Monkeys.SimulateRounds(10000, true);
      Monkey[]? top2Monkeys = Monkeys.Monkeys?.OrderByDescending(monkey => monkey.InspectionCount).Take(2).ToArray();
      return top2Monkeys![0].InspectionCount * top2Monkeys[1]!.InspectionCount;
    }

    private Barrel ParseMonkeys(string[] input)
    {
      Barrel barrel = new Barrel();
      List<string[]> monkeyStrings = new();
      List<string> currentMonkeyString = new();
      foreach (string line in input)
      {
        if (line != "")
          currentMonkeyString.Add(line);
        else
        {
          monkeyStrings.Add(currentMonkeyString.ToArray());
          currentMonkeyString = new();
        }
      }
      monkeyStrings.Add(currentMonkeyString.ToArray());
      foreach (string[] monkeyString in monkeyStrings)
      {
        barrel.AddMonkey(monkeyString);
      }
      return barrel;
    }

    protected override string[] GetInput()
      => File.ReadAllLines(@"2022\Day11\input.txt");
  }
}