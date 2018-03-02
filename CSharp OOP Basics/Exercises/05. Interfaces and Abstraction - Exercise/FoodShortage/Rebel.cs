public class Rebel : INameable, IAgeable, IBuyer
{
    public Rebel(string name, int age, string group)
    {
        Name = name;
        Age = age;
        Group = group;
    }

    public string Name { get; }
    public int Age { get; }
    public string Group { get; }
    public int Food { get; private set; }

    public void BuyFood()
    {
        Food += 5;
    }
}