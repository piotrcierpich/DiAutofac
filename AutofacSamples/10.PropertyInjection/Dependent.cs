namespace AutofacSamples.PropertyInjection
{
  class Dependent
  {
    public override string ToString()
    {
      return Dependee.ToString();
    }

    public Dependee Dependee { get; set; }
  }

  internal class Dependee
  {
    public override string ToString()
    {
      return "hello from dependee";
    }
  }
}
