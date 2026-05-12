namespace Task_1;

class Program
{
  static void Main()
  {
    Complex a = ReadComplex("A");
    Complex b = ReadComplex("B");

    while (true)
    {
      Console.WriteLine("\n===== MENU =====");
      Console.WriteLine("1) Show objects");
      Console.WriteLine("2) Change A");
      Console.WriteLine("3) Change B");
      Console.WriteLine("4) Show ToString()");
      Console.WriteLine("5) Show indexer");
      Console.WriteLine("6) Arithmetic (+ - * /)");
      Console.WriteLine("7) ++ / --");
      Console.WriteLine("8) Comparisons");
      Console.WriteLine("9) true / false");
      Console.WriteLine("10) Type conversion");
      Console.WriteLine("0) Exit");

      int choice = ReadInt("Your choice: ");

      try
      {
        switch (choice)
        {
          case 1:
            Console.WriteLine($"A = {a}");
            Console.WriteLine($"B = {b}");
            break;

          case 2:
            a = ReadComplex("A (new value)");
            break;

          case 3:
            b = ReadComplex("B (new value)");
            break;

          case 4:
            Console.WriteLine($"A.ToString() = {a}");
            Console.WriteLine($"B.ToString() = {b}");
            break;

          case 5:
            Console.WriteLine($"A[0] = {a[0]}, A[1] = {a[1]}");
            Console.WriteLine($"B[0] = {b[0]}, B[1] = {b[1]}");
            break;

          case 6:
            Console.WriteLine($"A + B = {a + b}");
            Console.WriteLine($"A - B = {a - b}");
            Console.WriteLine($"A * B = {a * b}");
            Console.WriteLine($"A / B = {a / b}");
            break;

          case 7:
          {
            Complex x = new Complex(a.Real, a.Imaginary);

            Console.WriteLine($"x = {x}");
            Console.WriteLine($"x++ = {x++}");
            Console.WriteLine($"after ++ = {x}");
            Console.WriteLine($"x-- = {x--}");
            Console.WriteLine($"after -- = {x}");
            break;
          }

          case 8:
            Console.WriteLine($"A == B -> {a == b}");
            Console.WriteLine($"A != B -> {a != b}");
            Console.WriteLine($"A < B -> {a < b}");
            Console.WriteLine($"A > B -> {a > b}");
            break;

          case 9:
          {
            Complex zero = new Complex(0, 0);

            Console.WriteLine($"A is {(a ? "true" : "false")}");
            Console.WriteLine($"zero is {(zero ? "true" : "false")}");
            break;
          }

          case 10:
          {
            double mod = (double)a;
            Console.WriteLine($"(double)A = {mod}");

            Complex fromDouble = ReadDoubleAsComplex();
            Console.WriteLine($"Complex from double = {fromDouble}");
            break;
          }

          case 0:
            return;

          default:
            Console.WriteLine("Invalid choice.");
            break;
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Error: {ex.Message}");
      }
    }
  }

  static Complex ReadComplex(string name)
  {
    Console.WriteLine($"\nEnter complex number {name}:");

    double real = ReadFiniteDouble("Real: ");
    double imag = ReadFiniteDouble("Imaginary: ");

    return new Complex(real, imag);
  }

  static Complex ReadDoubleAsComplex()
  {
    double value = ReadFiniteDouble("Enter double (will become Complex): ");
    return value;
  }

  static double ReadFiniteDouble(string message)
  {
    while (true)
    {
      Console.Write(message);
      string? input = Console.ReadLine();

      if (double.TryParse(input, out double value) &&
          !double.IsNaN(value) &&
          !double.IsInfinity(value))
      {
        return value;
      }

      Console.WriteLine("Invalid number.");
    }
  }

  static int ReadInt(string message)
  {
    while (true)
    {
      Console.Write(message);

      if (int.TryParse(Console.ReadLine(), out int value))
        return value;

      Console.WriteLine("Invalid integer.");
    }
  }
}