namespace EqualityLogic
{
    using System;
    public class Person : IComparable<Person>
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; }
        public int Age { get; }

        public int CompareTo(Person other)
        {
            return GetHashCode().CompareTo(other.GetHashCode());
        }

        public override bool Equals(object obj)
        {
            if (obj is Person other)
            {
                return Name == other.Name && Age == other.Age;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return (Name.GetHashCode() * 397) ^ Age;
        }

        public override string ToString()
        {
            return $"{Name} {Age}";
        }
    }
}
