namespace Task_1;

public class Client
{
  public string LastName { get; private set; }

  private List<Call> calls;

  public Client(string lastName)
  {
      if (string.IsNullOrWhiteSpace(lastName))
        throw new ArgumentException("Last name cannot be empty", nameof(lastName));
      LastName = lastName;
      calls = new List<Call>();
  }

  public void RegisterCall(Call call)
  {
    calls.Add(call);
  }

  public IReadOnlyList<Call> GetCalls()
  {
    return calls.ToList();
  }
}