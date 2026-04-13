namespace Task_1;

abstract class Figure
{
  public string Name { get; protected set; }
  public abstract double Area();
  public abstract double Perimeter();
  public virtual void Rename(string newName)
  {
    if (string.IsNullOrWhiteSpace(newName))
      throw new ArgumentException("Name cannot be empty", nameof(newName));
    Name = newName;
  }
  public virtual void Print()
  {
    Console.WriteLine($"Name: {Name}");
  }

  protected Figure(string name)
  {
    if (string.IsNullOrWhiteSpace(name))
      throw new ArgumentException("Name cannot be empty", nameof(name));
    Name = name;
    
    Console.WriteLine($"Figure constructor called for: {name}");
  }
}