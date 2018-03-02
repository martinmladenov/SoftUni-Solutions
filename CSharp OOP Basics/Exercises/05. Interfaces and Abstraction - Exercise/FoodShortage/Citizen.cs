public class Citizen : INameable, IAgeable, IIdetifiable, IBirthable, IBuyer
{
    public Citizen(string name, int age, string id, string birthdate)
    {
        Name = name;
        Age = age;
        Id = id;
        Birthdate = birthdate;
    }

    public string Name { get; }
    public int Age { get; }
    public string Id { get; }
    public string Birthdate { get; }
    public int Food { get; private set; }

    public void BuyFood()
    {
        Food += 10;
    }
}