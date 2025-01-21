namespace NatsBus;

internal sealed class Context
{
  private readonly Dictionary<string, object?> _values = [];

  public TValue? Get<TValue>()
  {
    return (TValue?)_values[typeof(TValue).FullName!];
  }

  public void Set<TValue>(TValue value)
  {
    _values[typeof(TValue).FullName!] = value;
  }
}
