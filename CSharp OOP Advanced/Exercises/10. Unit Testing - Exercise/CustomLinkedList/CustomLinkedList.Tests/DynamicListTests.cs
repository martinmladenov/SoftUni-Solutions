namespace CustomLinkedList.Tests
{
    using System;
    using NUnit.Framework;

    public class DynamicListTests
    {
        [Test]
        [TestCase(0)]
        [TestCase(5)]
        public void Count_WorksCorrectly(int amount)
        {
            DynamicList<int> list = new DynamicList<int>();

            for (int i = 0; i < amount; i++)
            {
                list.Add(i);
            }

            Assert.That(list.Count, Is.EqualTo(amount), "Incorrect count.");
        }

        [Test]
        public void Get_WorksCorrectly()
        {
            DynamicList<int> list = new DynamicList<int>();

            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
            }

            for (int i = 0; i < 10; i++)
            {
                Assert.That(list[i], Is.EqualTo(i), "Get does not return correct value.");
            }
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(-1, 0)]
        [TestCase(5, 5)]
        [TestCase(-1, 5)]
        [TestCase(10, 5)]
        public void Get_InvalidIndex_ThrowsException(int index, int elements)
        {
            DynamicList<int> list = new DynamicList<int>();

            for (int i = 0; i < elements; i++)
            {
                list.Add(i);
            }

            int a;
            Assert.Throws<ArgumentOutOfRangeException>(() => a = list[index], "List does not throw exception.");
        }

        [Test]
        public void Set_WorksCorrectly()
        {
            DynamicList<int> list = new DynamicList<int>();

            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
            }

            for (int i = 0; i < 10; i++)
            {
                list[i] = 20 + i;
            }

            for (int i = 0; i < 10; i++)
            {
                Assert.That(list[i], Is.EqualTo(20 + i), "Set does not set correct value.");
            }
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(-1, 0)]
        [TestCase(5, 5)]
        [TestCase(-1, 5)]
        [TestCase(10, 5)]
        public void Set_InvalidIndex_ThrowsException(int index, int elements)
        {
            DynamicList<int> list = new DynamicList<int>();

            for (int i = 0; i < elements; i++)
            {
                list.Add(i);
            }

            Assert.Throws<ArgumentOutOfRangeException>(() => list[index] = 0, "List does not throw exception.");
        }

        [Test]
        [TestCase(0)]
        [TestCase(5)]
        [TestCase(9)]
        public void RemoveAt_WorksCorrectly(int index)
        {
            DynamicList<int> list = new DynamicList<int>();

            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
            }

            int expectedResult = index;
            int actualResult = list.RemoveAt(index);
            Assert.That(actualResult, Is.EqualTo(expectedResult), "Incorrect number returned.");

            for (int i = 0; i < list.Count; i++)
            {
                Assert.That(list[i], Is.EqualTo(i + (i >= index ? 1 : 0)), "Other elements of list are incorrect after removing an element.");
            }
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(-1, 0)]
        [TestCase(5, 5)]
        [TestCase(-1, 5)]
        [TestCase(10, 5)]
        public void RemoveAt_InvalidIndex_ThrowsException(int index, int elements)
        {
            DynamicList<int> list = new DynamicList<int>();

            for (int i = 0; i < elements; i++)
            {
                list.Add(i);
            }

            Assert.Throws<ArgumentOutOfRangeException>(() => list.RemoveAt(index), "List does not throw exception.");
        }

        [Test]
        [TestCase(0)]
        [TestCase(5)]
        [TestCase(9)]
        public void Remove_WorksCorrectly(int num)
        {
            DynamicList<int> list = new DynamicList<int>();

            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
            }

            int expectedResult = num;
            int actualResult = list.Remove(num);
            Assert.That(actualResult, Is.EqualTo(expectedResult), "Incorrect index returned.");

            for (int i = 0; i < list.Count; i++)
            {
                Assert.That(list[i], Is.EqualTo(i + (i >= num ? 1 : 0)), "Other elements of list are incorrect after removing an element.");
            }
        }

        [Test]
        public void Remove_NonExistantElement_WorksCorrectly()
        {
            DynamicList<int> list = new DynamicList<int>();

            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
            }

            int actualResult = list.Remove(15);
            int expectedResult = -1;

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Remove_EmptyList_WorksCorrectly()
        {
            DynamicList<int> list = new DynamicList<int>();

            int actualResult = list.Remove(15);
            int expectedResult = -1;

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(0)]
        [TestCase(5)]
        [TestCase(9)]
        public void IndexOf_WorksCorrectly(int num)
        {
            DynamicList<int> list = new DynamicList<int>();

            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
            }

            int expectedResult = num;
            int actualResult = list.IndexOf(num);
            Assert.That(actualResult, Is.EqualTo(expectedResult), "Incorrect index returned.");
        }

        [Test]
        public void IndexOf_NonExistantElement_WorksCorrectly()
        {
            DynamicList<int> list = new DynamicList<int>();

            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
            }

            int actualResult = list.Remove(15);
            int expectedResult = -1;

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void IndexOf_EmptyList_WorksCorrectly()
        {
            DynamicList<int> list = new DynamicList<int>();

            int actualResult = list.Remove(15);
            int expectedResult = -1;

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(0)]
        [TestCase(5)]
        [TestCase(9)]
        public void Contains_WorksCorrectly(int num)
        {
            DynamicList<int> list = new DynamicList<int>();

            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
            }

            bool expectedResult = true;
            bool actualResult = list.Contains(num);
            Assert.That(actualResult, Is.EqualTo(expectedResult), "Incorrect value returned.");
        }

        [Test]
        public void Contains_NonExistantElement_WorksCorrectly()
        {
            DynamicList<int> list = new DynamicList<int>();

            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
            }


            bool expectedResult = false;
            bool actualResult = list.Contains(15);

            Assert.That(actualResult, Is.EqualTo(expectedResult), "Incorrect value returned.");
        }

        [Test]
        public void Contains_EmptyList_WorksCorrectly()
        {
            DynamicList<int> list = new DynamicList<int>();


            bool expectedResult = false;
            bool actualResult = list.Contains(15);

            Assert.That(actualResult, Is.EqualTo(expectedResult), "Incorrect value returned.");
        }
    }
}
