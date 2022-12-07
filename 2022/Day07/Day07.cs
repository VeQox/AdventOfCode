namespace AdventOfCode.Y2022
{
  public class Day07 : Solution<int>
  {
    protected override int PartOne(string[] input)
      => ParseDirectories(input).GetPartOneSolution();

    protected override int PartTwo(string[] input)
      => ParseDirectories(input).GetPartTwoSolution();

    private Directory ParseDirectories(string[] input)
    {
      Directory rootDir = new Directory("/", null);
      input = input[1..].ToArray();
      Directory currentDir = rootDir;

      for (int i = 0; i < input.Length; i++)
      {
        string line = input[i];
        string command = line.Split(" ")[1];
        if (command == "cd")
        {
          string option = line.Split(" ")[2];
          if (option == "..")
            currentDir = currentDir!.ParentDirectory!;
          else
            currentDir = currentDir.GetDirectoryByName(option)!;
        }
        else
        {
          string[] range = input[(i + 1)..].TakeWhile(line => !line.Contains("$")).ToArray();
          foreach (string lsLine in range)
          {
            if (lsLine.Contains("dir"))
              currentDir.AddDirectory(lsLine.Split(" ")[1]);
            else
              currentDir.AddFile(int.Parse(lsLine.Split(" ")[0]), lsLine.Split(" ")[1]);
          }
          i += range.Length;
        }
      }

      return rootDir;
    }

    protected override string[] GetInput()
      => File.ReadAllLines(@"2022\Day07\input.txt");
  }
}