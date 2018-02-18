// ReSharper disable CheckNamespace
public class Person
{
    private string name;
    private int age;

    public string Name => this.name;
    public int Age => this.age;

    public Person() : this(1)
    {
    }

    public Person(int age) : this("No name", age)
    {
    }

    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    public override string ToString()
    {
        return $"{this.name} {this.age}";
    }
}
