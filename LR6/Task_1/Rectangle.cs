namespace Task_1;

class Rectangle : Figure
{
  public int High { get; private set; }
  public int Width { get; private set; }

  public Rectangle (string name, int high, int width) : base(name)
  {
    if (high <= 0)
      throw new ArgumentException("High must be positive", nameof(high));
    High = high;  

     if (width <= 0)
      throw new ArgumentException("Width must be positive", nameof(width));
    Width = width; 
  }

  public override double Area()
  {
    return High * Width;
  }
  public override double Perimeter()
  {
    return 2 * (High + Width);
  }

  public void Rename(string newName, string reason)
  {
    Rename(newName);
    Console.WriteLine($"Renamed because: {reason}");
  }
}