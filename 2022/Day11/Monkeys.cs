namespace AdventOfCode.Y2022
{
  public class Barrel
  {
    /*
    Monkey 0:
      Starting items: 79, 98
      Operation: new = old * 19
      Test: divisible by 23
        If true: throw to monkey 2
        If false: throw to monkey 3
    */
    public static Monkey ParseMonkey(string[] monkeyString)
    {
      // Remove Monkey x:
      monkeyString = monkeyString.Skip(1).ToArray();
      long[] items = Array.ConvertAll(monkeyString[0].Split(":")[1].Split(","), long.Parse);// 79, 98
      char operation = monkeyString[1].Split(":")[1].Skip(11).Take(1).ToArray()[0];// *
      long operationAmount = 0;
      bool isSpecial = false;
      try
      {
        operationAmount = long.Parse(monkeyString[1].Split(":")[1].Split(operation)[1]);// 19
      }
      catch
      {
        operationAmount = 0;
        isSpecial = true;
      }
      long test = long.Parse(monkeyString[2].Split(":")[1].Split("divisible by")[1]);// 23
      int monkeyT = int.Parse(monkeyString[3].TakeLast(1).ToArray());// 2
      int monkeyF = int.Parse(monkeyString[4].TakeLast(1).ToArray());// 3
      return new Monkey(
        new Queue<long>(items),
        test,
        monkeyT,
        monkeyF,
        operation,
        operationAmount,
        isSpecial
      );
    }

    public Barrel()
    {
      Monkeys = new();
    }

    public List<Monkey>? Monkeys { get; set; }

    public void AddMonkey(string[] monkeyString)
      => Monkeys?.Add(Barrel.ParseMonkey(monkeyString));

    public void SimulateRounds(int amount, bool partTwo = false)
    {
      for (int i = 0; i < amount; i++)
      {
        foreach (Monkey monkey in Monkeys!)
        {
          Monkey monkeyT = Monkeys[monkey.MonkeyT];
          Monkey monkeyF = Monkeys[monkey.MonkeyF];
          int itemsCount = monkey.Items.Count();
          for (int j = 0; j < itemsCount; j++)
          {
            monkey.ThrowItem(monkey.InspectItem(partTwo), monkeyT, monkeyF);
          }
        }
      }
    }

    public override string ToString()
      => $"{string.Join("|", Monkeys!)}";
  }
}