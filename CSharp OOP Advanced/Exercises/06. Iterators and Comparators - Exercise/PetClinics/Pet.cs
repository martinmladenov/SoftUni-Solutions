namespace PetClinics
{
    public class Pet
    {
        public Pet(string name, int age, string kind)
        {
            Name = name;
            Age = age;
            Kind = kind;
        }

        public string Name { get; }
        public int Age { get; }
        public string Kind { get; }

        public override string ToString()
        {
            return $"{Name} {Age} {Kind}";
        }
    }
}
