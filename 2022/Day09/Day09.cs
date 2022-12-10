namespace AdventOfCode.Y2022
{
  public class Day09 : Solution<int>
  {
    protected override int PartOne(string[] input)
    {
      List<Coord> coords = new();
      Coord[] knots = new Coord[2];
      Array.Fill(knots, new(0, 0));
      coords.Add(knots.First());

      foreach (string line in input)
      {
        string[] lineSplit = line.Split(" ");
        coords.AddRange(GetTailMoves(char.Parse(lineSplit[0]), int.Parse(lineSplit[1]), knots));
      }

      return coords.Distinct().Count();
    }

    private List<Coord> GetTailMoves(char direction, int amount, Coord[] knots)
    {
      List<Coord> coords = new();
      for (int i = 0; i < amount; i++)
      {
        knots[0] = knots[0] + GetChangeByDirection(direction);
        for (int j = 0; j < knots.Length - 1; j++)
        {
          if (!knots[j + 1].IsNextToOther(knots[j]))
          {
            knots[j + 1] = knots[j + 1].MoveTo(knots[j]);

            if ((j + 1) == (knots.Length - 1))
            {
              coords.Add(knots[j + 1]);
            }
          }
        }
      }
      return coords;
    }

    private Coord GetChangeByDirection(char direction)
      => direction switch
      {
        'U' => new(0, 1),
        'D' => new(0, -1),
        'R' => new(1, 0),
        'L' => new(-1, 0),
        _ => throw new Exception("😏 not good"),
      };

    protected override int PartTwo(string[] input)
    {
      List<Coord> coords = new();
      Coord[] knots = new Coord[10];
      Array.Fill(knots, new(0, 0));
      coords.Add(knots.First());

      foreach (string line in input)
      {
        string[] lineSplit = line.Split(" ");
        coords.AddRange(GetTailMoves(char.Parse(lineSplit[0]), int.Parse(lineSplit[1]), knots));
      }

      return coords.Distinct().Count();
    }

    protected override string[] GetInput()
      => File.ReadAllLines(@"2022\Day09\input.txt");
  }
}