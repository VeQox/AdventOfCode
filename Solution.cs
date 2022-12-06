namespace AdventOfCode
{
    public abstract class Solution<T>
    {
        public void Run()
        {
            Console.WriteLine($"PartOne: {PartOne(GetInput())}");
            Console.WriteLine($"PartTwo: {PartTwo(GetInput())}");
        }

        protected abstract T PartOne(string[] input);
        protected abstract T PartTwo(string[] input);

        protected abstract string[] GetInput();
    }
}
