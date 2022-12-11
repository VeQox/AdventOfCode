namespace AdventOfCode.Y2022
{
  public class Monkey
  {
    public Queue<long> Items { get; }
    public long Test { get; }
    public int MonkeyT { get; }
    public int MonkeyF { get; }
    public int InspectionCount { get; private set; }
    private char Operation { get; }
    private long OperationAmount { get; set; }
    private bool IsSpecial { get; }

    public Monkey(Queue<long> items, long test, int monkeyT, int monkeyF, char operation, long amount, bool isSpecial)
    {
      Items = items;
      Test = test;
      MonkeyT = monkeyT;
      MonkeyF = monkeyF;
      Operation = operation;
      OperationAmount = amount;
      IsSpecial = isSpecial;
    }

    public long InspectItem(bool partTwo)
    {
      long item = Items.Dequeue();
      if (IsSpecial) OperationAmount = item;
      if (!partTwo) item = (long)Math.Floor(IncreaseByOperation(item) / 3.0);
      else item = IncreaseByOperation(item);
      //if (item < 0) Console.WriteLine(item);
      InspectionCount++;
      return item;
    }

    private long IncreaseByOperation(long item)
      => Operation switch
      {
        '+' => item += OperationAmount,
        '-' => item -= OperationAmount,
        '*' => item *= OperationAmount,
        '/' => item /= OperationAmount,
        _ => throw new Exception("not good"),
      };

    public void ThrowItem(long item, Monkey t, Monkey f)
    {
      if (item % Test == 0)
        t.Items.Enqueue(item);
      else
        f.Items.Enqueue(item);
    }

    public override string ToString()
      => $"{string.Join(" ,", InspectionCount)}";
  }
}