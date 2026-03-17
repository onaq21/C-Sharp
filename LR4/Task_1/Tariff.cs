namespace Task_1;

class Tariff
{
  private decimal monthlyFee;
  public decimal MonthlyFee
  {
    get { return monthlyFee; }
    set
    {
      if (value < 0) throw new ArgumentOutOfRangeException(nameof(value));
      monthlyFee = value;
    }
  }
  
  public Tariff(decimal monthlyFee)
  {
    MonthlyFee = monthlyFee;
  }

  public void IncreaseFee(decimal amount)
  {
    if (amount < 0) throw new ArgumentOutOfRangeException(nameof(amount), "Increase amount cannot be negative");
    monthlyFee += amount;
  }
  public void IncreaseFee(int percent)
  {
    if (percent < 0) throw new ArgumentOutOfRangeException(nameof(percent), "Increase percent cannot be negative");
    monthlyFee += monthlyFee * percent / 100;
  }
  public bool DecreaseFee(decimal amount)
  {
    decimal newFee = MonthlyFee - amount;

    if (newFee < 0)
    {
      MonthlyFee = 0;
      return false;
    }

    MonthlyFee = newFee;
    return true;
  }
  public bool DecreaseFee(int percent)
  {
    decimal newFee = MonthlyFee - MonthlyFee * percent / 100;

    if (newFee < 0)
    {
      MonthlyFee = 0;
      return false;
    }

    MonthlyFee = newFee;
    return true;
  }
}