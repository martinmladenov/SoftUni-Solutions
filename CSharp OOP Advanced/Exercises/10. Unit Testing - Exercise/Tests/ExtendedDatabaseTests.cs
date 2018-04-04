namespace Tests
{
    using System;
    using System.Linq;
    using NUnit.Framework;
    using UnitTestingExercise.Database;

    public class ExtendedDatabaseTests
    {
        [Test]
        [TestCase(0)]
        [TestCase(5)]
        [TestCase(16)]
        public void Constructor_ShouldWorkCorrectly(int amount)
        {
            var arr = new Person[amount];

            for (int i = 0; i < amount; i++)
            {
                arr[i] = new Person(i, i.ToString());
            }

            ExtendedDatabase db = new ExtendedDatabase(arr);

            for (int i = amount - 1; i > 0; i--)
            {
                var actualResult = db.Remove();

                Assert.That(actualResult, Is.EqualTo(arr[i]));
            }
        }

        [Test]
        public void Constructor_MoreThan16Elements_ShouldThrowException()
        {
            var arr = new Person[17];

            Assert.Throws<InvalidOperationException>(() => new ExtendedDatabase(arr));
        }

        [Test]
        [TestCase(5)]
        [TestCase(16)]
        public void AddRemove_ShouldWorkCorrectly(int amount)
        {
            ExtendedDatabase db = new ExtendedDatabase();

            var arr = new Person[amount];

            for (int i = 0; i < amount; i++)
            {
                var person = new Person(i, i.ToString());
                arr[i] = person;

                db.Add(person);
            }

            for (int i = amount - 1; i > 0; i--)
            {
                var actualResult = db.Remove();

                Assert.That(actualResult, Is.EqualTo(arr[i]));
            }
        }

        [Test]
        public void Add_MoreThan16Elements_ShouldThrowException()
        {
            ExtendedDatabase db = new ExtendedDatabase();

            for (int i = 0; i < 16; i++)
            {
                db.Add(new Person(i, i.ToString()));

            }

            Assert.Throws<InvalidOperationException>(() => db.Add(new Person(16, "16")));
        }

        [Test]
        public void Remove_Empty_ShouldThrowException()
        {
            ExtendedDatabase db = new ExtendedDatabase();

            Assert.Throws<InvalidOperationException>(() => db.Remove());
        }

        [Test]
        [TestCase(0)]
        [TestCase(5)]
        [TestCase(16)]
        public void Fetch_ShouldWorkCorrectly(int amount)
        {
            var arr = new Person[amount];

            for (int i = 0; i < amount; i++)
            {
                arr[i] = new Person(i, i.ToString());
            }

            ExtendedDatabase db = new ExtendedDatabase(arr);

            var expectedResult = arr.Reverse().ToArray();

            var actualResult = db.Fetch();

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Add_SameUsername_ShouldThrowException()
        {
            ExtendedDatabase db = new ExtendedDatabase();

            db.Add(new Person(1, "a"));

            Assert.Throws<InvalidOperationException>(() => db.Add(new Person(2, "a")));
        }

        [Test]
        public void Add_SameId_ShouldThrowException()
        {
            ExtendedDatabase db = new ExtendedDatabase();

            db.Add(new Person(1, "a"));

            Assert.Throws<InvalidOperationException>(() => db.Add(new Person(1, "b")));
        }

        [Test]
        public void FindByUsername_WorksCorrectly()
        {
            ExtendedDatabase db = new ExtendedDatabase();

            Person expectedResult = new Person(1, "a");

            db.Add(new Person(2, "b"));
            db.Add(new Person(3, "c"));
            db.Add(expectedResult);
            db.Add(new Person(4, "d"));

            Person actualResult = db.FindByUsername(expectedResult.Username);

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void FindById_UsernameNull_ThrowsException()
        {
            ExtendedDatabase db = new ExtendedDatabase();

            Assert.Throws<ArgumentNullException>(() => db.FindByUsername(null));
        }

        [Test]
        public void FindByUsername_NoUserWithUsername_ThrowsException()
        {
            ExtendedDatabase db = new ExtendedDatabase();

            db.Add(new Person(1, "a"));
            db.Add(new Person(2, "b"));
            db.Add(new Person(3, "c"));
            db.Add(new Person(4, "d"));

            Assert.Throws<InvalidOperationException>(() => db.FindByUsername("aa"));
        }

        [Test]
        public void FindById_WorksCorrectly()
        {
            ExtendedDatabase db = new ExtendedDatabase();

            Person expectedResult = new Person(1, "a");

            db.Add(new Person(2, "b"));
            db.Add(new Person(3, "c"));
            db.Add(expectedResult);
            db.Add(new Person(4, "d"));

            Person actualResult = db.FindById(expectedResult.Id);

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void FindById_NegativeId_ThrowsException()
        {
            ExtendedDatabase db = new ExtendedDatabase();

            Assert.Throws<ArgumentOutOfRangeException>(() => db.FindById(-1));
        }

        [Test]
        public void FindById_NoUserWithId_ThrowsException()
        {
            ExtendedDatabase db = new ExtendedDatabase();

            db.Add(new Person(1, "a"));
            db.Add(new Person(2, "b"));
            db.Add(new Person(3, "c"));
            db.Add(new Person(4, "d"));

            Assert.Throws<InvalidOperationException>(() => db.FindById(11));
        }
    }
}
