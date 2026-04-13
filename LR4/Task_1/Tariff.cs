namespace Task_1;

class Tariff
{
  private decimal monthlyFee;
  public decimal MonthlyFee
  {
    get { return monthlyFee; }
    set
    {
      if (value < 0) throw new ArgumentOutOfRangeException(nameof(value), "Monthly fee cannot be negative");
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

  public void DecreaseFee(decimal amount)
  {
    if (amount < 0) throw new ArgumentOutOfRangeException(nameof(amount), "Decrease amount cannot be negative");
    if (amount > MonthlyFee) throw new ArgumentOutOfRangeException(nameof(amount), "Cannot decrease by more than current monthly fee");
    monthlyFee -= amount;
  }

  public void DecreaseFee(int percent)
  {
    if (percent < 0) throw new ArgumentOutOfRangeException(nameof(percent), "Decrease percent cannot be negative");
    if (percent > 100) throw new ArgumentOutOfRangeException(nameof(percent), "Cannot decrease by more than 100%");
    monthlyFee -= monthlyFee * percent / 100;
  }
}