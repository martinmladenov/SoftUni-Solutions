// ReSharper disable CheckNamespace
public class Pokemon
{
    public string Name { get; }
    public string Element { get; }
    public int Health { get; set; }

    public Pokemon(string name, string element, int health)
    {
        Name = name;
        Element = element;
        Health = health;
    }
}
