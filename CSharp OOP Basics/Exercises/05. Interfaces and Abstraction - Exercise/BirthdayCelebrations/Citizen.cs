public class Citizen : IBirthable
{
    public Citizen(string name, int age, string birthdate)
    {
        Name = name;
        Age = age;
        Birthdate = birthdate;
    }

    public string Name { get; }
    public int Age { get; }
    public string Birthdate { get; }
}