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
    string line = input[0];
    for(int i = 0; i < line.Length - 14; i++){
        char[] currentRange = line[i..(i+14)].ToCharArray();
        if(AreAllDifferent(currentRange)){
            return i + 14;
        }
    }
    return 0;
  }

  static int PartOne(string[] input)
  {
    string line = input[0];
    for(int i = 0; i < line.Length - 14; i++){
        char[] currentRange = line[i..(i+4)].ToCharArray();
        if(AreAllDifferent(currentRange)){
            return i + 4;
        }
    }
    return 0;
  }

  static bool AreAllDifferent(char[] range)
    => range.Distinct().ToArray().Length == range.Length;

  static string[] GetInput()
    => File.ReadAllLines(INPUT_PATH);
}