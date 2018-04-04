namespace Tests
{
    using System;
    using System.Linq;
    using NUnit.Framework;
    using UnitTestingExercise.Database;

    public class DatabaseTests
    {
        [Test]
        public void Constructor_ShouldWorkCorrectly()
        {
            Database db = new Database(1, 2, 3, 4, 5);

            for (int expectedResult = 5; expectedResult > 0; expectedResult--)
            {
                int actualResult = db.Remove();

                Assert.That(actualResult, Is.EqualTo(expectedResult));
            }
        }

        [Test]
        public void Constructor_MoreThan16Elements_ShouldThrowException()
        {
            int[] arr = new int[17];

            Assert.Throws<InvalidOperationException>(() => new Database(arr));
        }

        [Test]
        [TestCase(5)]
        [TestCase(16)]
        public void AddRemove_ShouldWorkCorrectly(int amount)
        {
            Database db = new Database();

            for (int i = 0; i < amount; i++)
            {
                db.Add(i);
            }

            for (int expectedResult = amount - 1; expectedResult >= 0; expectedResult--)
            {
                int actualResult = db.Remove();

                Assert.That(actualResult, Is.EqualTo(expectedResult));
            }
        }

        [Test]
        public void Add_MoreThan16Elements_ShouldThrowException()
        {
            Database db = new Database();

            for (int i = 0; i < 16; i++)
            {
                db.Add(i);
            }

            Assert.Throws<InvalidOperationException>(() => db.Add(0));
        }

        [Test]
        public void Remove_Empty_ShouldThrowException()
        {
            Database db = new Database();

            Assert.Throws<InvalidOperationException>(() => db.Remove());
        }

        [Test]
        [TestCase(0)]
        [TestCase(5)]
        [TestCase(16)]
        public void Fetch_ShouldWorkCorrectly(int amount)
        {
            int[] arr = new int[amount];

            for (int i = 0; i < amount; i++)
            {
                arr[i] = i;
            }

            Database db = new Database(arr);

            int[] expectedResult = arr.Reverse().ToArray();

            int[] actualResult = db.Fetch();

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
    }
}
