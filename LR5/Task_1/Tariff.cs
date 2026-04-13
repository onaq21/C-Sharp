namespace Task_1;

public class Tariff
{
  public City City { get; private set; }
  public decimal PricePerMinute { get; private set; }

  public Tariff(City city, decimal pricePerMinute)
  {
    if (pricePerMinute <= 0)
      throw new ArgumentException("Price must be positive", nameof(pricePerMinute));
    City = city;
    PricePerMinute = pricePerMinute;
  }
}