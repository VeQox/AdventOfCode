namespace AdventOfCode.Y2022
{
  public class Day05 : Solution<string>
  {
    protected override string PartOne(string[] input)
    {
      string[] rawCargos = input.TakeWhile(line => line != "").ToArray();
      string[] moves = input[rawCargos.Count()..].Skip(1).ToArray();
      Stack<char>[] cargos = ParseCargos(rawCargos);

      foreach (string move in moves)
      {
        string[] splittedMove = move.Split(" ");
        int moveAmount = int.Parse(splittedMove[1]);
        Stack<char> originialStack = cargos[int.Parse(splittedMove[3]) - 1];
        Stack<char> moveToStack = cargos[int.Parse(splittedMove[5]) - 1];

        for (int i = 0; i < moveAmount; i++)
        {
          moveToStack.Push(originialStack.Pop());
        }
      }

      return string.Join(string.Empty, cargos.Select(stack => stack.Peek()));
    }

    protected override string PartTwo(string[] input)
    {
      string[] rawCargos = input.TakeWhile(line => line != "").ToArray();
      string[] moves = input[rawCargos.Count()..].Skip(1).ToArray();
      Stack<char>[] cargos = ParseCargos(rawCargos);

      foreach (string move in moves)
      {
        string[] splittedMove = move.Split(" ");
        int moveAmount = int.Parse(splittedMove[1]);
        Stack<char> originialStack = cargos[int.Parse(splittedMove[3]) - 1];
        Stack<char> moveToStack = cargos[int.Parse(splittedMove[5]) - 1];

        List<char> removedCargos = new List<char>(moveAmount);
        for (int i = 0; i < moveAmount; i++)
        {
          removedCargos.Add(originialStack.Pop());
        }

        removedCargos.Reverse();
        foreach (char removedCargo in removedCargos)
        {
          moveToStack.Push(removedCargo);
        }
      }

      return string.Join(string.Empty, cargos.Select(stack => stack.Peek()));
    }

    static Stack<char>[] ParseCargos(string[] cargos)
    {
      Stack<char>[] stacks = new Stack<char>[cargos.Last().Split("   ").Count()];

      cargos = cargos.SkipLast(1).ToArray();

      for (int i = 0; i < stacks.Length; i++)
      {
        stacks[i] = new Stack<char>();
        int cargoIndex = i * 4 + 1;
        for (int j = cargos.Length - 1; j >= 0; j--)
        {
          if (cargos[j][cargoIndex] != ' ')
          {
            stacks[i].Push(cargos[j][cargoIndex]);
          }
        }
      }
      return stacks;
    }

    protected override string[] GetInput()
      => File.ReadAllLines(@"2022\Day05\input.txt");
  }
}