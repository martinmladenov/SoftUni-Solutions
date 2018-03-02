public class Citizen : IIdetifiable
{
    public Citizen(string name, int age, string id)
    {
        Name = name;
        Age = age;
        Id = id;
    }

    public string Name { get; }
    public int Age { get; }
    public string Id { get; }
}