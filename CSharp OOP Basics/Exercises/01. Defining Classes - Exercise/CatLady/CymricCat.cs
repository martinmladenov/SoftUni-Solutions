// ReSharper disable CheckNamespace
public class CymricCat : Cat
{
    public double FurLength { get; }

    public CymricCat(string name, double furLength) : base(name)
    {
        FurLength = furLength;
    }

    public override string ToString() =>
        $"Cymric {Name} {FurLength:f2}";
}
