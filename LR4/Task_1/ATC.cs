namespace Task_1;

class ATC
{
  private string? stationAddress;
  public string? StationAddress
  {
    get { return stationAddress; }
    set 
    {
      if (string.IsNullOrWhiteSpace(value))
        throw new ArgumentException("Address cannot be empty");
      stationAddress = value;
    }
  }

  private int subscribersCount;
  public int SubscribersCount
  {
    get { return subscribersCount; }
    set 
    { 
      if (value < 0)
        throw new ArgumentOutOfRangeException(nameof(value), "SubscribersCount cannot be negative");
      subscribersCount = value; 
    }
  }
  
  private Tariff? currentTariff;
  public Tariff? CurrentTariff
  {
    get { return currentTariff; }
    set 
    { 
      if (value == null) throw new ArgumentNullException(nameof(value));
      currentTariff = value;
    }
  }

  public decimal CalculateTotalFee()
  {
    if (currentTariff != null)
      return subscribersCount * currentTariff.MonthlyFee;
    return 0;
  }

  private ATC() {}
  private static ATC? instance;
  public static ATC GetInstance()
  {
    if (instance == null)
      instance = new ATC();
    return instance;
  }
}