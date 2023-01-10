internal struct IntegralValue
{
    public IntegralValue(int value)
    {
        Value = value;
    }

    public int Value { get; }

    public override string ToString()
        => Value.ToString();
}