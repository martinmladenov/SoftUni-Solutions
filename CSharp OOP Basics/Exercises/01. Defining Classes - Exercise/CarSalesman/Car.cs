// ReSharper disable CheckNamespace
public class Car
{
    public string Model { get; }
    public Engine Engine { get; }
    public int? Weight { get; }
    public string Color { get; }

    public Car(string model, Engine engine, int? weight, string color)
    {
        Model = model;
        Engine = engine;
        Weight = weight;
        Color = color;
    }

    public override string ToString() =>
               $"{Model}:\r\n" +
               $"{Engine}\r\n" +
               $"  Weight: {(Weight == null ? "n/a" : Weight.ToString())}\r\n" +
               $"  Color: {Color ?? "n/a"}";
}
