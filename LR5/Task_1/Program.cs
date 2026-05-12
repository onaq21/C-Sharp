using System;

namespace Task_1;

class Program
{
  static void Main()
  {
    ATC atc = new ATC();

    while (true)
    {
      Console.WriteLine("\n===== MENU =====");
      Console.WriteLine("1) Add tariff");
      Console.WriteLine("2) Add client");
      Console.WriteLine("3) Register call");
      Console.WriteLine("4) Calculate client cost");
      Console.WriteLine("5) Calculate total ATC cost");
      Console.WriteLine("6) Show all data");
      Console.WriteLine("7) Exit");

      int choice = ReadInt("Your choice: ");

      switch (choice)
      {
        case 1:
        {
          try
          {
            City city = ReadCity();
            decimal price = ReadDecimal("Enter price per minute: ");

            Tariff tariff = new Tariff(city, price);

            if (atc.AddTariff(tariff))
              Console.WriteLine("Tariff added successfully.");
            else
              Console.WriteLine("Tariff for this city already exists.");
          }
          catch (ArgumentException e)
          {
            Console.WriteLine(e.Message);
          }

          break;
        }

        case 2:
        {
          try
          {
            string lastName = ReadString("Enter client last name: ");

            Client client = new Client(lastName);

            if (atc.AddClient(client))
              Console.WriteLine("Client added successfully.");
            else
              Console.WriteLine("Client already exists.");
          }
          catch (ArgumentException e)
          {
            Console.WriteLine(e.Message);
          }

          break;
        }

        case 3:
        {
          try
          {
            string lastName = ReadString("Enter client last name: ");
            City city = ReadCity();
            int duration = ReadPositiveInt("Enter call duration: ");

            Call call = new Call(city, duration);

            if (atc.RegisterCall(lastName, call))
              Console.WriteLine("Call registered successfully.");
            else
              Console.WriteLine("Client not found.");
          }
          catch (ArgumentException e)
          {
            Console.WriteLine(e.Message);
          }

          break;
        }

        case 4:
        {
          string lastName = ReadString("Enter client last name: ");

          CalculationResult result =
            atc.CalculateClientCost(lastName, out decimal totalPrice);

          switch (result)
          {
            case CalculationResult.Success:
              Console.WriteLine($"Total client cost: {totalPrice:C}");
              break;

            case CalculationResult.ClientNotFound:
              Console.WriteLine("Client not found.");
              break;

            case CalculationResult.TariffNotFound:
              Console.WriteLine("Tariff not found for one or more calls.");
              break;
          }

          break;
        }

        case 5:
        {
          CalculationResult result =
            atc.CalculateTotalCost(out decimal totalPrice);

          switch (result)
          {
            case CalculationResult.Success:
              Console.WriteLine($"Total ATC cost: {totalPrice:C}");
              break;

            case CalculationResult.TariffNotFound:
              Console.WriteLine("Tariff not found for one or more calls.");
              Console.WriteLine($"Partial total: {totalPrice:C}");
              break;
          }

          break;
        }

        case 6:
        {
          ShowData(atc);
          break;
        }

        case 7:
          return;

        default:
          Console.WriteLine("Invalid input, please try again.");
          break;
      }
    }
  }

  static void ShowData(ATC atc)
  {
    Console.WriteLine("\n=== Tariffs ===");

    foreach (Tariff tariff in atc.GetTariffs())
    {
      Console.WriteLine(
        $"{tariff.City} - {tariff.PricePerMinute:C} per minute");
    }

    Console.WriteLine("\n=== Clients ===");

    foreach (Client client in atc.GetClients())
    {
      Console.WriteLine($"\nClient: {client.LastName}");

      IReadOnlyList<Call> calls = client.GetCalls();

      if (calls.Count == 0)
      {
        Console.WriteLine("No calls");
      }
      else
      {
        foreach (Call call in calls)
        {
          Console.WriteLine(
            $"City: {call.City}, Duration: {call.Duration} min");
        }
      }
    }
  }

  static City ReadCity()
  {
    while (true)
    {
      Console.WriteLine("\nChoose city:");
      Console.WriteLine("1) Moscow");
      Console.WriteLine("2) Minsk");
      Console.WriteLine("3) London");
      Console.WriteLine("4) Paris");
      Console.WriteLine("5) Berlin");

      int choice = ReadInt("Your choice: ");

      switch (choice)
      {
        case 1:
          return City.Moscow;

        case 2:
          return City.Minsk;

        case 3:
          return City.London;

        case 4:
          return City.Paris;

        case 5:
          return City.Berlin;

        default:
          Console.WriteLine("Invalid city.");
          break;
      }
    }
  }

  static string ReadString(string message)
  {
    while (true)
    {
      Console.Write(message);

      string? input = Console.ReadLine();

      if (!string.IsNullOrWhiteSpace(input))
        return input;

      Console.WriteLine("Invalid value.");
    }
  }

  static int ReadInt(string message)
  {
    while (true)
    {
      Console.Write(message);

      string? input = Console.ReadLine();

      if (int.TryParse(input, out int value))
        return value;

      Console.WriteLine("Invalid integer.");
    }
  }

  static int ReadPositiveInt(string message)
  {
    while (true)
    {
      int value = ReadInt(message);

      if (value > 0)
        return value;

      Console.WriteLine("Value must be positive.");
    }
  }

  static decimal ReadDecimal(string message)
  {
    while (true)
    {
      Console.Write(message);

      string? input = Console.ReadLine();

      if (decimal.TryParse(input, out decimal value))
      {
        if (value > 0)
          return value;
      }

      Console.WriteLine("Invalid decimal value.");
    }
  }
}