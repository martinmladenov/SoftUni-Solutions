namespace StrategyPattern
{ 
    public class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; }
        public int Age { get; }

        public override string ToString()
        {
            return $"{Name} {Age}";
        }
    }
}
