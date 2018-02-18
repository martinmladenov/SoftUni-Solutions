// ReSharper disable CheckNamespace
public class Engine
{
    public string Model { get; }
    public int Power { get; }
    public int? Displacement { get; }
    public string Efficiency { get; }

    public Engine(string model, int power, int? displacement, string efficiency)
    {
        Model = model;
        Power = power;
        Displacement = displacement;
        Efficiency = efficiency;
    }

    public override string ToString() =>
               $"  {Model}:\r\n" +
               $"    Power: {Power}\r\n" +
               $"    Displacement: {(Displacement == null ? "n/a" : Displacement.ToString())}\r\n" +
               $"    Efficiency: {Efficiency ?? "n/a"}";
}
