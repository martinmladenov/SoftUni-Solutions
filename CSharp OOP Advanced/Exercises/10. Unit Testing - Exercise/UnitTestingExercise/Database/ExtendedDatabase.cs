namespace UnitTestingExercise.Database
{
    using System;
    using System.Linq;

    public partial class ExtendedDatabase
    {
        private Person[] data;
        private int currIndex;

        public ExtendedDatabase(params Person[] initialPeople)
        {
            if (initialPeople.Length > 16)
            {
                throw new InvalidOperationException("Database can store at most 16 people.");
            }

            data = new Person[16];
            currIndex = initialPeople.Length - 1;

            Array.Copy(initialPeople, data, initialPeople.Length);
        }

        public void Add(Person newPerson)
        {
            if (currIndex == 15)
            {
                throw new InvalidOperationException("Database can store at most 16 people.");
            }

            if (data.Take(currIndex + 1).Any(p => p.Id == newPerson.Id ||
                                p.Username == newPerson.Username))
            {
                throw new InvalidOperationException("Person with the same id or username already exists.");
            }

            data[++currIndex] = newPerson;
        }

        public Person Remove()
        {
            if (currIndex == -1)
            {
                throw new InvalidOperationException("Database is empty.");
            }

            Person removed = data[currIndex];

            data[currIndex--] = null;

            return removed;
        }

        public Person[] Fetch()
        {
            return data.Take(currIndex + 1).Reverse().ToArray();
        }

        public Person FindByUsername(string username)
        {
            if (username == null)
            {
                throw new ArgumentNullException();
            }

            Person person = data.Take(currIndex + 1).FirstOrDefault(p => p.Username == username);

            if (person == null)
            {
                throw new InvalidOperationException("Person with this username not present.");
            }

            return person;
        }

        public Person FindById(int id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            Person person = data.Take(currIndex + 1).FirstOrDefault(p => p.Id == id);

            if (person == null)
            {
                throw new InvalidOperationException("Person with this id not present.");
            }

            return person;
        }
    }
}
