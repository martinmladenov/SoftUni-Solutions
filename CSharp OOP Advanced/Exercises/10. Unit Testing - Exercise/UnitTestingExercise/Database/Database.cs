namespace UnitTestingExercise.Database
{
    using System;
    using System.Linq;

    public class Database
    {
        private int[] data;
        private int currIndex;

        public Database(params int[] initialIntegers)
        {
            if (initialIntegers.Length > 16)
            {
                throw new InvalidOperationException("Database can store at most 16 integers.");
            }

            data = new int[16];
            currIndex = initialIntegers.Length - 1;

            Array.Copy(initialIntegers, data, initialIntegers.Length);
        }

        public void Add(int element)
        {
            if (currIndex == 15)
            {
                throw new InvalidOperationException("Database can store at most 16 integers.");
            }

            data[++currIndex] = element;
        }

        public int Remove()
        {
            if (currIndex == -1)
            {
                throw new InvalidOperationException("Database is empty.");
            }

            return data[currIndex--];
        }

        public int[] Fetch()
        {
            return data.Take(currIndex + 1).Reverse().ToArray();
        }
    }
}
