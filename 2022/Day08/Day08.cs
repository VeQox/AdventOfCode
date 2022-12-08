namespace AdventOfCode.Y2022
{
  public class Day08 : Solution<int>
  {
    protected override int PartOne(string[] input)
    {
      int visibleTrees = (input.Length + input[0].Length - 2) * 2;
      for (int y = 1; y < input.Length - 1; y++)
      {
        for (int x = 1; x < input[y].Length - 1; x++)
        {
          char currentTree = input[y][x];
          char maxRight = input[y][(x + 1)..].Max();
          char maxLeft = input[y][0..x].Max();
          char maxTop = GetVerticalRange(input, 0, y, x).Max();
          char maxBottom = GetVerticalRange(input, input.Length - 1, y, x).Max();

          if (maxLeft < currentTree
            || maxRight < currentTree
            || maxTop < currentTree
            || maxBottom < currentTree)
          {
            visibleTrees++;
          }
        }
      }
      return visibleTrees;
    }

    private char[] GetVerticalRange(string[] input, int from, int to, int col)
    {
      List<char> range = new();
      if (from < to)
      {
        for (int y = from; y < to; y++)
        {
          range.Add(input[y][col]);
        }
      }
      else
      {
        for (int y = from; y > to; y--)
        {
          range.Add(input[y][col]);
        }
      }
      range.Reverse();
      return range.ToArray();
    }

    protected override int PartTwo(string[] input)
    {
      int maxScore = 0;
      for (int y = 0; y < input.Length; y++)
      {
        for (int x = 0; x < input[y].Length; x++)
        {
          char currentTree = input[y][x];
          int visibleTreesEast = GetScoreOfDirection(input[y][(x + 1)..].ToCharArray(), currentTree);
          int visibleTreesWest = GetScoreOfDirection(input[y][0..x].Reverse().ToArray(), currentTree);
          int visibleTreesNorth = GetScoreOfDirection(GetVerticalRange(input, 0, y, x), currentTree);
          int visibleTreesSouth = GetScoreOfDirection(GetVerticalRange(input, input.Length - 1, y, x), currentTree);
          int score = visibleTreesEast * visibleTreesWest * visibleTreesNorth * visibleTreesSouth;
          if (score > maxScore)
          {
            maxScore = score;
          }
        }
      }
      return maxScore;
    }

    private int GetScoreOfDirection(char[] direction, char currentTree)
    {
      char[] filteredTrees = direction.TakeWhile(tree => currentTree > tree).ToArray();
      return filteredTrees.Length + filteredTrees.Length == direction.Length ? 0 : 1;
    }


    protected override string[] GetInput()
      => File.ReadAllLines(@"2022\Day08\input.txt");
  }
}