namespace Task_1;

public static class InputHandler
{
  public static int ReadInt(string message)
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

  public static decimal ReadDecimal(string message)
  {
    while(true)
    {
      Console.Write(message);
      string? input = Console.ReadLine();

      if (decimal.TryParse(input, out decimal value))
        return value;

      Console.WriteLine("Invalid value, please try again");
    }
  }

  public static string ReadStr(string message)
  {
    while(true)
    {
      Console.Write(message);
      string? input = Console.ReadLine();

      if (!string.IsNullOrWhiteSpace(input))
        return input;

      Console.WriteLine("Invalid value, please try again");
    }
  }
}