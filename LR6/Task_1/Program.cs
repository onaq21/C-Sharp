namespace Task_1;
class Program
{
  static void Main()
  {
    Circle circle = new Circle("Circle", 5);
    Rectangle rectangle = new Rectangle("Rectangle", 4, 6);
    Triangle triangle = new Triangle("Triangle", 3);
    Console.WriteLine();

    Console.WriteLine("=== Circle.Print() (override) ===");
    circle.Print();

    Console.WriteLine("\n=== Rectangle.Print() (no override) ===");
    rectangle.Print();

    Console.WriteLine("\n=== Triangle.Print() via Triangle (new) ===");
    triangle.Print();

    Console.WriteLine("\n=== Triangle.Print() via Figure (hiding) ===");
    Figure f = triangle;
    f.Print();

    Console.WriteLine("\n=== Area / Perimeter ===");
    Console.WriteLine($"Circle area: {circle.Area():F2}");
    Console.WriteLine($"Circle perimeter: {circle.Perimeter():F2}");
    Console.WriteLine($"Rectangle area: {rectangle.Area():F2}");
    Console.WriteLine($"Rectangle perimeter: {rectangle.Perimeter():F2}");
    Console.WriteLine($"Triangle area: {triangle.Area():F2}");
    Console.WriteLine($"Triangle perimeter: {triangle.Perimeter():F2}");

    Console.WriteLine("\n=== Rename (virtual from Figure) ===");
    circle.Rename("New Circle");
    circle.Print();

    Console.WriteLine("\n=== Rename overload in Rectangle ===");
    rectangle.Rename("New Rectangle", "looks better");
    rectangle.Print();

    Console.WriteLine("\n=== Validation ===");
    try { new Circle("Bad", -1); }
    catch (ArgumentException e) { Console.WriteLine($"Circle: {e.Message}"); }
    try { new Rectangle("Bad", 0, 5); }
    catch (ArgumentException e) { Console.WriteLine($"Rectangle: {e.Message}"); }
    try { new Triangle("", 3); }
    catch (ArgumentException e) { Console.WriteLine($"Triangle: {e.Message}"); }
  }
}