namespace Task_1;

public class ATC
{
  private List<Tariff> tariffs;
  
  private List<Client> clients;
  
  public ATC()
  {
    tariffs = new List<Tariff>();
    clients = new List<Client>();
  }

  public bool AddTariff(Tariff tariff)
  {
    foreach (Tariff t in tariffs)
    {
      if (t.City == tariff.City)
      {
        return false;
      }
    }

    tariffs.Add(tariff);
    return true;
  }

  public bool AddClient(Client client)
  {
    foreach (Client c in clients)
    {
      if (c.LastName == client.LastName)
      {
        return false;
      }
    }

    clients.Add(client);
    return true;
  }

  public bool RegisterCall(string lastName, Call call)
  {
    foreach (Client c in clients)
    {
      if (c.LastName == lastName)
      {
        c.RegisterCall(call);
        return true;
      }
    }
    return false;
  }

  public CalculationResult CalculateClientCost(string lastName, out decimal totalPrice)
  {
    totalPrice = 0;

    foreach (Client c in clients)
    {
      if (c.LastName == lastName)
      {
        foreach (Call call in c.GetCalls())
        {
          bool tariffFound = false;

          foreach (Tariff tariff in tariffs)
          {
            if (tariff.City == call.City)
            {
              totalPrice += tariff.PricePerMinute * call.Duration;
              tariffFound = true;
              break;
            }
          }

          if (!tariffFound) 
            return CalculationResult.TariffNotFound;
        }
        return CalculationResult.Success;
      }
    }
    return CalculationResult.ClientNotFound;
  }

  public CalculationResult CalculateTotalCost(out decimal totalPrice)
  {
    totalPrice = 0;
    bool hasError = false;

    foreach (Client client in clients)
    {
      foreach (Call call in client.GetCalls())
      {
        bool tariffFound = false;

        foreach (Tariff tariff in tariffs)
        {
          if (tariff.City == call.City)
          {
            totalPrice += tariff.PricePerMinute * call.Duration;
            tariffFound = true;
            break;
          }
        }

        if (!tariffFound)
          hasError = true;
      }
    }

    return hasError ? CalculationResult.TariffNotFound : CalculationResult.Success;
  }
}