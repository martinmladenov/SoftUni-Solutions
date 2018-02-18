// ReSharper disable CheckNamespace
public class StreetExtraordinaireCat : Cat
{
    public int DecibelsOfMeows { get; }

    public StreetExtraordinaireCat(string name, int decibelsOfMeows) : base(name)
    {
        DecibelsOfMeows = decibelsOfMeows;
    }

    public override string ToString() =>
        $"StreetExtraordinaire {Name} {DecibelsOfMeows}";
}
