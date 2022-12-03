class Program {
    const string INPUT_PATH = "input.txt";

    static void Main(){
        Console.WriteLine($"PartOne: {PartOne(GetInput())}");
        Console.WriteLine($"PartTwo: {PartTwo(GetInput())}");
    }

    static string[] GetInput()
        => File.ReadAllLines(INPUT_PATH);

    static int PartOne(string[] input){
        int sumOfPrios = 0;

        foreach(string backback in input)
            sumOfPrios += GetPriority(GetDuplicate(backback.Substring(0, backback.Length/2), backback.Substring(backback.Length/2))[0]);

        return sumOfPrios;
    }

    static int GetPriority(char item){
        if(char.IsUpper(item)){
            return item - 'A' + 27;
        }
        return item - 'a' + 1;
    }

    static char[] GetDuplicate(string first, string second){
        return first.ToCharArray().Intersect(second.ToCharArray()).ToArray();
    }

    static int PartTwo(string[] input){
        int sumOfPrios = 0;

        for(int i = 0; i < input.Length; i+=3)
            sumOfPrios += GetPriority(GetDuplicate(input[i],input[i+1],input[i+2])[0]);
 
        return sumOfPrios;
    }

    static char[] GetDuplicate(string first, string second, string third){
        return GetDuplicate(first, second).Intersect(third).ToArray();
    }
}