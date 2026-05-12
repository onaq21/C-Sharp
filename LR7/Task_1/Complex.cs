namespace Task_1;

class Complex
{
  public double Real { get; }
  public double Imaginary { get; }

  public Complex()
  {
    Real = 0;
    Imaginary = 0;
  }

  public Complex(double real, double imaginary)
  {
    if (double.IsNaN(real) || double.IsInfinity(real))
      throw new ArgumentException("Invalid real part");

    if (double.IsNaN(imaginary) || double.IsInfinity(imaginary))
      throw new ArgumentException("Invalid imaginary part");

    Real = real;
    Imaginary = imaginary;
  }

  public double Module()
  {
    return Math.Sqrt(Real * Real + Imaginary * Imaginary);
  }

  public static Complex operator +(Complex a, Complex b)
  {
    return new Complex(a.Real + b.Real, a.Imaginary + b.Imaginary);
  }

  public static Complex operator -(Complex a, Complex b)
  {
    return new Complex(a.Real - b.Real, a.Imaginary - b.Imaginary);
  }

  public static Complex operator *(Complex a, Complex b)
  {
    return new Complex(
      a.Real * b.Real - a.Imaginary * b.Imaginary,
      a.Real * b.Imaginary + a.Imaginary * b.Real
    );
  }

  public static Complex operator /(Complex a, Complex b)
  {
    double denom = b.Real * b.Real + b.Imaginary * b.Imaginary;

    return new Complex(
      (a.Real * b.Real + a.Imaginary * b.Imaginary) / denom,
      (a.Imaginary * b.Real - a.Real * b.Imaginary) / denom
    );
  }

  public static Complex operator ++(Complex a)
  {
    return new Complex(a.Real + 1, a.Imaginary + 1);
  }

  public static Complex operator --(Complex a)
  {
    return new Complex(a.Real - 1, a.Imaginary - 1);
  }

  public static bool operator ==(Complex a, Complex b)
  {
    return a.Module() == b.Module();
  }

  public static bool operator !=(Complex a, Complex b)
  {
    return a.Module() != b.Module();
  }

  public static bool operator <(Complex a, Complex b)
  {
    return a.Module() < b.Module();
  }

  public static bool operator >(Complex a, Complex b)
  {
    return a.Module() > b.Module();
  }

  public static bool operator true(Complex a)
  {
    return a.Real != 0 || a.Imaginary != 0;
  }

  public static bool operator false(Complex a)
  {
    return a.Real == 0 && a.Imaginary == 0;
  }

  public static explicit operator double(Complex a)
  {
    return a.Module();
  }

  public static implicit operator Complex(double a)
  {
      return new Complex(a, 0);
  }

  public double this[int index]
  {
    get
    {
      return index switch
      {
        0 => Real,
        1 => Imaginary,
        _ => throw new IndexOutOfRangeException()
      };
    }
  }

  public override string ToString()
  {
    if (Imaginary >= 0)
      return $"{Real} + {Imaginary}i";

    return $"{Real} - {-Imaginary}i";
  }
}