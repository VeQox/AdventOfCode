namespace AdventOfCode.Y2022
{
  public class Day10 : Solution<int>
  {
    protected override int PartOne(string[] input)
    {
      int cycle = 0;
      int signalStrength = 0;
      int register = 1;

      foreach (string line in input)
      {
        string[] linesplit = line.Split(" ");
        string instruction = linesplit[0];
        if (instruction == "addx")
        {
          cycle++;
          signalStrength = GetSignalStrength(signalStrength, cycle, register);
          cycle++;
          signalStrength = GetSignalStrength(signalStrength, cycle, register);
          register += int.Parse(linesplit[1]);
        }
        else if (instruction == "noop")
        {
          cycle++;
          signalStrength = GetSignalStrength(signalStrength, cycle, register);
        }
      }

      return signalStrength;
    }

    private int GetSignalStrength(int signalStrength, int cycle, int register)
    {
      if (cycle == 20 || cycle == 60 || cycle == 100 || cycle == 140 || cycle == 180 || cycle == 220)
      {
        return (signalStrength += cycle * register);
      }
      return signalStrength;
    }

    protected override int PartTwo(string[] input)
    {
      char[][] screen = new char[6][];
      for (int i = 0; i < screen.GetLength(0); i++)
        Array.Fill(screen[i] = new char[40], '.');

      int register = 1;
      int cycle = 0;

      foreach (string line in input)
      {
        string[] linesplit = line.Split(" ");
        string instruction = linesplit[0];
        if (instruction == "addx")
        {
          cycle++;
          DrawToCrtScreen(screen, cycle, register);
          cycle++;
          DrawToCrtScreen(screen, cycle, register);
          register += int.Parse(linesplit[1]);
        }
        else if (instruction == "noop")
        {
          cycle++;
          DrawToCrtScreen(screen, cycle, register);
        }
      }

      foreach (char[] line in screen)
        Console.WriteLine(line);

      return 0;
    }

    private void DrawToCrtScreen(char[][] screen, int cycle, int register)
    {
      int col = (cycle - 1) % 40;
      int row = (int)Math.Floor(cycle / 40.0);
      if (GetSpritePos(register).Contains(col))
        screen[row][col] = '#';
    }

    private int[] GetSpritePos(int register)
      => Enumerable.Range(register - 1, 3).ToArray();

    protected override string[] GetInput()
      => File.ReadAllLines(@"2022\Day10\input.txt");
  }
}