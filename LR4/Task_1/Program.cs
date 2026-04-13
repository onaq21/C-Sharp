using System;
namespace Task_1;

class Program
{
  static void Main()
  {
    ATC atc = ATC.GetInstance();

    while (true)
    {
      try
      {
        atc.StationAddress = InputHandler.ReadStr("Enter the address of the ATC station: ");
        break;
      }
      catch (ArgumentException e)
      {
        Console.WriteLine(e.Message);
      }
    }

    while (true)
    {
      try
      {
        atc.SubscribersCount = InputHandler.ReadInt("Enter the number of subscribers: ");
        break;
      }
      catch (ArgumentOutOfRangeException e)
      {
        Console.WriteLine(e.Message);
      }
    }

    while (true)
    {
      try
      {
        decimal monthlyFee = InputHandler.ReadDecimal("Enter the monthly fee for the tariff: ");
        Tariff tariff = new Tariff(monthlyFee);
        atc.CurrentTariff = tariff;
        break;
      }
      catch (ArgumentOutOfRangeException e)
      {
        Console.WriteLine(e.Message);
      }
      catch (ArgumentNullException e)
      {
        Console.WriteLine(e.Message);
      }
    }

    Console.WriteLine("\nATC data successfully set:");
    Console.WriteLine($"Station Address: {atc.StationAddress}");
    Console.WriteLine($"Subscribers Count: {atc.SubscribersCount}");
    Console.WriteLine($"Monthly Fee: {atc.CurrentTariff.MonthlyFee:C}");

    while (true)
    {
      Console.WriteLine("\nChoose an action:");
      Console.WriteLine("1)Calculate total subscription fee");
      Console.WriteLine("2)Increase tariff");
      Console.WriteLine("3)Decrease tariff");
      Console.WriteLine("4)Update ATC data (address or subscribers count)");
      Console.WriteLine("5)Exit");

      int choice = InputHandler.ReadInt("Your choice: ");

      switch (choice)
      {
        case 1:
          Console.WriteLine($"Total subscription fee is {atc.CalculateTotalFee():C}");
          break;
        case 2:
        {
          int method = InputHandler.ReadInt("Choose increase method: amount (1) or percent (2): ");
          switch (method)
          {
            case 1:
              decimal amount = InputHandler.ReadDecimal("Enter amount: ");
              try 
              {
                atc.CurrentTariff.IncreaseFee(amount);
              }
              catch (ArgumentOutOfRangeException e)
              {
                Console.WriteLine(e.Message);
              }
              Console.WriteLine($"New tariff: {atc.CurrentTariff.MonthlyFee:C}");
              break;
            case 2: 
              int percent = InputHandler.ReadInt("Enter percent: ");
              try
              {
                atc.CurrentTariff.IncreaseFee(percent);
              }
              catch (ArgumentOutOfRangeException e)
              {
                Console.WriteLine(e.Message);
              }
              Console.WriteLine($"New tariff: {atc.CurrentTariff.MonthlyFee:C}");
              break;
            default:
              Console.WriteLine("Invalid method.");
              break;
          }
          break;
        }
        case 3:
        {
          int method = InputHandler.ReadInt("Choose decrease method: amount (1) or percent (2): ");
          switch (method)
          {
            case 1:
              decimal amount = InputHandler.ReadDecimal("Enter amount: ");
              try
              {
                atc.CurrentTariff.DecreaseFee(amount);
                Console.WriteLine($"New tariff: {atc.CurrentTariff.MonthlyFee:C}");
              }
              catch (ArgumentOutOfRangeException e)
              {
                Console.WriteLine(e.Message);
              }
              break;
            case 2:
              int percent = InputHandler.ReadInt("Enter percent: ");
              try
              {
                atc.CurrentTariff.DecreaseFee(percent);
                Console.WriteLine($"New tariff: {atc.CurrentTariff.MonthlyFee:C}");
              }
              catch (ArgumentOutOfRangeException e)
              {
                Console.WriteLine(e.Message);
              }
              break;
            default:
              Console.WriteLine("Invalid method.");
              break;
          }
          break;
        }
        case 4:
        {
          while (true)
          {
            int method = InputHandler.ReadInt("What do you want to update?\n1) Address\n2) Subscribers count\n3) Back\nYour choice: ");

            switch (method)
            {
              case 1:
                string newAddress = InputHandler.ReadStr($"Enter new ATC station address (current: {atc.StationAddress}): ");
                try
                {
                  atc.StationAddress = newAddress;
                }
                catch (ArgumentException e)
                {
                  Console.WriteLine(e.Message);
                }
                break;
              case 2:
                int newCount = InputHandler.ReadInt($"Enter new subscribers count (current: {atc.SubscribersCount}): ");
                try
                {
                  atc.SubscribersCount = newCount;
                }
                catch (ArgumentOutOfRangeException e)
                {
                  Console.WriteLine(e.Message);
                }
                break;
              case 3:
                Console.WriteLine("Returning to main menu...");
                break;
              default:
                Console.WriteLine("Invalid option, try again.");
                continue;
            }

            if (method == 3)
              break;
          }
          break;
        }
        case 5:
          return;
        default:
          Console.WriteLine("Invalid input, please try again");
          break;
      }
    }
  }
}
