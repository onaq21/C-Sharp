namespace Task_1;

class Triangle : Figure
{
  public int Length { get; private set; }

  public Triangle (string name, int length) : base(name)
  {
    if (length <= 0)
      throw new ArgumentException("Length must be positive", nameof(length));
    Length = length;
  }

  public override double Area()
  {
    return Length * Length * Math.Sqrt(3) / 4;
  }
  public override double Perimeter()
  {
    return 3 * Length;
  }
  public new void Print()
  {
    base.Print();
    Console.WriteLine($"Length: {Length}");
  }
}