using System;

namespace Task_2;

class Program
{
  static void Main()
  {
    const double rSmall2 = 15 * 15;
    const double rBig2 = 25 * 25;

    while (true)
    {
      Console.WriteLine("Enter your coordinates: ");

      Console.Write("x: ");
      string? xStr = Console.ReadLine();
      if (!double.TryParse(xStr, out double x))
      {
        Console.WriteLine("Invalid input, please enter a number");
        continue;
      }

      Console.Write("y: ");
      string? yStr = Console.ReadLine();
      if (!double.TryParse(yStr, out double y))
      {
        Console.WriteLine("Invalid input, please enter a number");
        continue;
      }

      double d2 = x * x + y * y;

      if (d2 < rSmall2|| d2 > rBig2) Console.WriteLine("Yes");
      else if (rSmall2 < d2 && d2 < rBig2) Console.WriteLine("No");
      else Console.WriteLine("On the border");

      Console.Write("Do you want to continue? (y/n): ");
      string? answer = Console.ReadLine()?.Trim().ToLower();

      switch (answer)
      {
        case "y": break;
        case "n": return;
        default:
          Console.WriteLine("Invalid input, continuing...");
          break;
      }
    }
  }
}