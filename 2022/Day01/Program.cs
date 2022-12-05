class Program{
  const string INPUT_PATH = "input.txt";
  static void Main() {
    Console.WriteLine($"PartOne: {PartOne(GetInput())}");
    Console.WriteLine($"PartTwo: {PartTwo(GetInput())}");
  }

  static int PartTwo(string[] input){
    List<int> calories = new();

    int elfSum = 0;

    foreach(string line in input){
      if(line != ""){
        elfSum += int.Parse(line);
      }
      else{
        calories.Add(elfSum);
        elfSum = 0;
      }
    }

    return calories.AsEnumerable().OrderByDescending(calorie => calorie).Take(3).Sum();
  }

  static int PartOne(string[] input){
    int maxCalories = 0;
    int elfSum = 0;

    foreach(string line in input){
      if(line != ""){
        elfSum += int.Parse(line);
      }
      else{
        maxCalories = elfSum > maxCalories ? elfSum : maxCalories;
        elfSum = 0;
      }
    }

    return maxCalories;
  }

  static string[] GetInput()
    => File.ReadAllLines(INPUT_PATH);
}