using System;
namespace Task_2;

class Program
{
  static void Main()
  {
    double n = ReadDouble("Enter n: ");
    double k = ReadDouble("Enter k: ");
    double m = ReadDouble("Enter m (> 0): ");
    double z = ReadDouble("Enter z: ");

    try
    {
      MyClass.Calculate(n, k, m, z);
    }
    catch (ArgumentException ex)
    {
      Console.WriteLine("Input error: " + ex.Message);
    }
  }

  static double ReadDouble(string message)
  {
    while(true)
    {
      Console.Write(message);
      string? input = Console.ReadLine();

      if (double.TryParse(input, out double value))
        return value;

      Console.WriteLine("Invalid value, please try again");
    }
  }
}
