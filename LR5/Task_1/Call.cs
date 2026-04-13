namespace Task_1;

public class Call
{
  public City City { get; private set; }
  public int Duration { get; private set; }

  public Call(City city, int duration)
  {
    if (duration <= 0)
      throw new ArgumentException("Duration must be positive", nameof(duration));
    City = city;
    Duration = duration;
  }
}