using System;

namespace _554504_Kudritsky;

class Program
{
  static void Main()
  {
    Console.WriteLine("Enter two numbers to divide:");
    int firstNum;
    while (true)
    {
      Console.Write("First number: ");
      string? firstStr = Console.ReadLine();
      if (int.TryParse(firstStr, out firstNum))
        break;
      Console.WriteLine("Invalid input, please enter an integer.");
    }

    int secondNum;
    while (true)
    {
      Console.Write("Second number: ");
      string? secondStr = Console.ReadLine();
      if (!int.TryParse(secondStr, out secondNum))
        Console.WriteLine("Invalid input, please enter an integer.");
      else if (secondNum == 0)
        Console.WriteLine("Division by zero is not allowed, please enter a non-zero integer.");
      else
        break;
    }

    float result = (float)firstNum / secondNum;
    Console.WriteLine($"{firstNum} divided by {secondNum} = {result}");
  }
}