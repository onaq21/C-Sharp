namespace Task_1;

class Program
{
  static void Main()
  {
    ATC atc = new ATC();

    atc.AddTariff(new Tariff(City.Moscow, 5));
    atc.AddTariff(new Tariff(City.London, 15));
    atc.AddTariff(new Tariff(City.Paris, 12));

    atc.AddClient(new Client("Bob"));
    atc.AddClient(new Client("Alice"));

    atc.RegisterCall("Bob", new Call(City.Moscow, 10));
    atc.RegisterCall("Bob", new Call(City.London, 5));
    atc.RegisterCall("Alice", new Call(City.Paris, 20));

    bool registered = atc.RegisterCall("UnknownPerson", new Call(City.Berlin, 7));
    if (!registered)
    {
      Console.WriteLine("Warning: call not registered — client not found");
    }

    CalculationResult resultBob = atc.CalculateClientCost("Bob", out decimal totalBob);
    switch (resultBob)
    {
      case CalculationResult.Success:
        Console.WriteLine($"Total cost for Bob: {totalBob} $");
        break;
      case CalculationResult.ClientNotFound:
        Console.WriteLine("Error: client Bob not found");
        break;
      case CalculationResult.TariffNotFound:
        Console.WriteLine("Warning: some calls for Bob have no tariff defined");
        Console.WriteLine($"Partial total cost (for calls with tariff): {totalBob} $");
        break;
    }

    CalculationResult resultSidor = atc.CalculateClientCost("Charlie", out decimal totalCharlie);
    if (resultSidor == CalculationResult.ClientNotFound)
    {
      Console.WriteLine("Error: client Charlie not found");
    }

    CalculationResult resultTotal = atc.CalculateTotalCost(out decimal totalAtc);
    if (resultTotal == CalculationResult.Success)
      Console.WriteLine($"Total cost for all calls: {totalAtc} $");
    else if (resultTotal == CalculationResult.TariffNotFound)
    {
      Console.WriteLine($"Total cost (with missing tariffs ignored): {totalAtc} $");
      Console.WriteLine("Warning: some calls have no tariff defined");
    }
  }
}