namespace AdventOfCode.Y2022
{
  public struct Coord
  {
    public Coord(int x, int y)
    {
      this.x = x;
      this.y = y;
    }
    public int x;
    public int y;

    public static Coord operator +(Coord a, Coord b)
      => new Coord(a.x + b.x, a.y + b.y);


    public override string ToString()
     => $"x:{x} y:{y}";

    public Coord GetDistanceTo(Coord o)
      => new Coord(Math.Abs(x - o.x),
                   Math.Abs(y - o.y));

    public bool IsNextToOther(Coord o)
    {
      Coord distance = GetDistanceTo(o);
      return (distance.x < 2 && distance.y < 2);
    }

    public Coord MoveTo(Coord o)
    {
      int dX = o.x - x;
      int dY = o.y - y;
      int absY = Math.Abs(dY);
      int absX = Math.Abs(dX);

      if (absX == 0 && absY == 2)
        return new(x, y + dY / 2);
      if (absY == 0 && absX == 2)
        return new(x + dX / 2, y);

      if (absX == 1 && absY == 2)
        return new(x + dX, y + dY / 2);
      if (absY == 1 && absX == 2)
        return new(x + dX / 2, y + dY);

      if (absX == 2 && absY == 2)
        return new(x + dX / 2, y + dY / 2);
      if (absY == 2 && absX == 2)
        return new(x + dX / 2, y + dY / 2);

      return new Coord(x, y);
    }
  }
}