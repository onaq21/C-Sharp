namespace Task_3;

class DateService
{
  public static DayOfWeek GetDay(string? date)
  {
    if (string.IsNullOrWhiteSpace(date) || !DateTime.TryParse(date, out DateTime parsedDate))
      throw new ArgumentException("Invalid date");

    return parsedDate.DayOfWeek;
  }

  public static int GetDaysSpan(int day, int month, int year)
  {
    DateTime targetDate;
    try
    {
      targetDate = new DateTime(year, month, day);
    }
    catch (ArgumentOutOfRangeException)
    {
      throw new ArgumentException("Invalid date");
    }

    DateTime today = DateTime.Today;
    TimeSpan difference = targetDate - today;
    return Math.Abs((int)difference.TotalDays);
  }
}