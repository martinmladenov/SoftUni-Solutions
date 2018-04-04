namespace Tests
{
    using System;
    using System.Linq;
    using NUnit.Framework;
    using UnitTestingExercise.ListIterator;

    public class ListIteratorTests
    {
        [Test]
        [TestCase(0)]
        [TestCase(15)]
        public void ConstructorAndMove_WorkCorrectly(int amount)
        {
            string[] arr = new string[amount];
            for (int i = 0; i < amount; i++)
            {
                arr[i] = i.ToString();
            }

            ListIterator iterator = new ListIterator(arr);

            for (int i = 0; i < amount - 1; i++)
            {
                Assert.True(iterator.Move());
            }

            Assert.False(iterator.Move());
        }

        [Test]
        public void Constructor_NullArgument_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => new ListIterator(null));
        }

        [Test]
        [TestCase(0)]
        [TestCase(15)]
        public void HasNext_WorksCorrectly(int amount)
        {
            string[] arr = new string[amount];
            for (int i = 0; i < amount; i++)
            {
                arr[i] = i.ToString();
            }

            ListIterator iterator = new ListIterator(arr);

            for (int i = 0; i < amount - 1; i++)
            {
                Assert.True(iterator.HasNext());
                iterator.Move();
            }

            Assert.False(iterator.HasNext());
        }

        [Test]
        public void Print_WithElements_DoesNotThrowException()
        {
            string[] arr = new string[10];
            for (int i = 0; i < 10; i++)
            {
                arr[i] = i.ToString();
            }

            ListIterator iterator = new ListIterator(arr);

            for (int i = 0; i < 10; i++)
            {
                Assert.DoesNotThrow(() => iterator.Print());
                iterator.Move();
            }
        }

        [Test]
        public void Print_NoElements_ThrowsException()
        {
            ListIterator iterator = new ListIterator(Enumerable.Empty<string>());

            Assert.Throws<InvalidOperationException>(() => iterator.Print());
        }
    }
}
