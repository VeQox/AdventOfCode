namespace AdventOfCode.Y2022
{
  public class Directory
  {
    public Directory(string name, Directory? parentDirectory)
    {
      Name = name;
      Files = new List<(int, string)>();
      Directories = new List<Directory>();
      ParentDirectory = parentDirectory;
    }
    public Directory? ParentDirectory { get; }
    public string Name { get; }
    public List<ValueTuple<int, string>> Files { get; }
    public List<Directory> Directories { get; }
    public int Size
    {
      get
      {
        int sumOfSize = 0;
        foreach ((int size, string name) in Files)
        {
          sumOfSize += size;
        }

        foreach (Directory dir in Directories)
        {
          sumOfSize += dir.Size;
        }

        return sumOfSize;
      }
    }

    public void AddFile(int size, string name)
    {
      Files.Add(new ValueTuple<int, string>(size, name));
    }
    public Directory AddDirectory(string name)
    {
      Directory directory = new Directory(name, this);
      Directories.Add(directory);
      return directory;
    }
    public Directory? GetDirectoryByName(string name)
    {
      foreach (Directory directory in Directories)
      {
        if (directory.Name == name) return directory;
      }
      return null;
    }
    public int GetPartOneSolution()
    {
      int sum = 0;
      List<Directory> allDirs = GetSubDirs();
      foreach (Directory dir in allDirs)
      {
        int size = dir.Size;
        sum += size <= 100_000 ? size : 0;
      }
      return sum;
    }

    public int GetPartTwoSolution()
    {
      int rootDirSize = Size;
      int freeSpace = 70_000_000 - rootDirSize;
      int currentDirSize = rootDirSize;
      foreach (Directory dir in GetSubDirs())
      {
        if (30_000_000 <= freeSpace + dir.Size && currentDirSize > dir.Size)
          currentDirSize = dir.Size;

      }
      return currentDirSize;
    }

    public List<Directory> GetSubDirs()
    {
      List<Directory> dirs = new List<Directory>();
      dirs.AddRange(Directories);
      foreach (Directory dir in Directories)
      {
        dirs.AddRange(dir.GetSubDirs());
      }
      return dirs;
    }

    public override string ToString()
    {
      return $"{Name} {Size}";
    }
  }
}