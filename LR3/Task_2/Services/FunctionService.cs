namespace Task_2;

class MyClass
{
  public static void Calculate(double n, double k, double m, double z)
  {
    if (m <= 0)
      throw new ArgumentException("m must be positive");

    if (z > 700)
      throw new ArgumentOutOfRangeException(nameof(z), "z cannot exceed 700");

    double x = (z > 1) ? Math.Exp(z) + z : z * z + 1;
    int branch = (z > 1) ? 1 : 2;

    double result = Math.Sin(n * x) + Math.Cos(k * x) + Math.Log(m * x);

    Console.WriteLine($"Branch {branch}, result is {result:F4}");
  }
}