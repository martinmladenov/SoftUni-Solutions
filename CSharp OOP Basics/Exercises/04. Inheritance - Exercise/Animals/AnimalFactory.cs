namespace Animals
{
    using Animals;

    public static class AnimalFactory
    {
        public static Animal MakeAnimal(string animalName, string[] animalData)
        {
            string name = string.Empty;
            int age = -1;
            string gender = string.Empty;

            if (animalData.Length >= 1)
                name = animalData[0];

            if (animalData.Length >= 2)
                age = int.Parse(animalData[1]);

            if (animalData.Length >= 3)
                gender = animalData[2];

            switch (animalName.ToLower())
            {
                case "dog":
                    return new Dog(name, age, gender);
                case "frog":
                    return new Frog(name, age, gender);
                case "cat":
                    return new Cat(name, age, gender);
                case "kitten":
                    return new Kitten(name, age);
                case "tomcat":
                    return new Tomcat(name, age);
                default:
                    throw new AnimalArgumentException();
            }
        }
    }
}
