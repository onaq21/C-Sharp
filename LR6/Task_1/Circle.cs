namespace Task_1;

sealed class Circle : Figure
{
  public int Radius { get; private set; }

  public Circle(string name, int radius) : base(name)
  {
    if (radius <= 0)
      throw new ArgumentException("Radius must be positive", nameof(radius));
    Radius = radius;  
  }

  public override double Area()
  {
    return Math.PI * Radius * Radius;
  }
  public override double Perimeter()
  {
    return 2 * Math.PI * Radius;
  }
  public override void Print()
  {
    base.Print();
    Console.WriteLine($"Radius: {Radius}");
  }
}