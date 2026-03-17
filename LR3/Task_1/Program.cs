using System;
namespace Task_1;

class Program
{
  static void Main()
  {
    int x = ReadInt("Enter x: ");
    int y = ReadInt("Enter y: ");

    int result = MyClass.Min(x, 2 * y + x) - MyClass.Min(7 * x + 2 * y, y);
    Console.WriteLine($"Result is {result}");
  }

  static int ReadInt(string message)
  {
    while(true)
    {
      Console.Write(message);
      string? input = Console.ReadLine();

      if (int.TryParse(input, out int value))
        return value;

      Console.WriteLine("Invalid value, please try again");
    }
  }
}
