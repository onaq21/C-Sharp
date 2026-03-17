using System;

namespace Task_1;

class Program
{
  static void Main()
  {
    while (true)
    {
      Console.Write("Enter your number: ");
      string? numberStr = Console.ReadLine();

      if (!int.TryParse(numberStr, out int number))
      {
        Console.WriteLine("Invalid input, please enter a number");
        continue;
      }

      string result = Math.Abs(number % 10) == 7 ? "Ends with 7" : "Doesn't end with 7";

      Console.WriteLine($"Your number {number} {result}");

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