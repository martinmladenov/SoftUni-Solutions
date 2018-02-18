// ReSharper disable CheckNamespace
public class SiameseCat : Cat
{
    public int EarSize { get; }

    public SiameseCat(string name, int earSize) : base(name)
    {
        EarSize = earSize;
    }

    public override string ToString() =>
        $"Siamese {Name} {EarSize}";
}
