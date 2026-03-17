using System;
namespace Task_3;

class Program
{
  static void Main()
  {
    while (true)
    {
      Console.Write("What do you want to do?\n1) Get day in your date\n2) Get difference between your date and today\nYour choice: ");
      string? answer = Console.ReadLine();

      if (!int.TryParse(answer, out int method))
      {
        Console.WriteLine("Invalid input, please try again");
        continue;
      }

      switch (method)
      {
        case 1:
          while (true)
          {
            Console.Write("Enter your date (format: 2006-01-02): ");
            string? date = Console.ReadLine();

            try
            {
              Console.WriteLine($"Your day is {DateService.GetDay(date)}");
              break;
            }
            catch (ArgumentException e)
            {
              Console.WriteLine(e.Message);
            }
          }
          break;
        case 2:
          while (true)
          {
            int day = ReadInt("Enter day: ");
            int month = ReadInt("Enter month: ");
            int year = ReadInt("Enter year: ");

            try {
              DateTime targetDate = new DateTime(year, month, day);
              int difference = DateService.GetDaysSpan(day, month, year);
              Console.WriteLine($"Difference between {targetDate:yyyy-MM-dd} and {DateTime.Today:yyyy-MM-dd} is {difference} days");
              break;
            }
            catch (ArgumentException e)
            {
              Console.WriteLine(e.Message);
            }
          }
          break;
        default:
          Console.WriteLine("Invalid input, please try again");
          break;
      }

      while (true)
      {
        Console.Write("Do you want to continue? (y/n): ");
        answer = Console.ReadLine()?.Trim().ToLower();

        if (answer == "y")
            break;
        if (answer == "n")
            return;

        Console.WriteLine("Invalid input, please enter y or n");
      }
    }
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
