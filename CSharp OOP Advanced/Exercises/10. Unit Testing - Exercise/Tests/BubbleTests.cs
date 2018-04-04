namespace Tests
{
    using NUnit.Framework;
    using UnitTestingExercise.BubbleSort;

    public class BubbleTests
    {
        [Test]
        public void BubbleSort_5Numbers_WorksCorrectly()
        {
            int[] arr = { 1, 3, 2, 8, 6 };

            int[] expectedResult = { 1, 2, 3, 6, 8 };

            Bubble.BubbleSort(arr);

            int[] actualResult = arr;

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void BubbleSort_ReverseOrder_WorksCorrectly()
        {
            int[] arr = { 5, 4, 3, 2, 1 };

            int[] expectedResult = { 1, 2, 3, 4, 5 };

            Bubble.BubbleSort(arr);

            int[] actualResult = arr;

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void BubbleSort_AlreadySorted_WorksCorrectly()
        {
            int[] arr = { 1, 2, 3, 4, 5 };

            int[] expectedResult = { 1, 2, 3, 4, 5 };

            Bubble.BubbleSort(arr);

            int[] actualResult = arr;

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void BubbleSort_2NumbersUnsorted_WorksCorrectly()
        {
            int[] arr = { 2, 1 };

            int[] expectedResult = { 1, 2 };

            Bubble.BubbleSort(arr);

            int[] actualResult = arr;

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void BubbleSort_2NumbersSorted_WorksCorrectly()
        {
            int[] arr = { 1, 2 };

            int[] expectedResult = { 1, 2 };

            Bubble.BubbleSort(arr);

            int[] actualResult = arr;

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void BubbleSort_SingleNumber_WorksCorrectly()
        {
            int[] arr = { 1 };

            int[] expectedResult = { 1 };

            Bubble.BubbleSort(arr);

            int[] actualResult = arr;

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void BubbleSort_SingleRepeatingNumber_WorksCorrectly()
        {
            int[] arr = { 1, 1, 1, 1, 1 };

            int[] expectedResult = { 1, 1, 1, 1, 1 };

            Bubble.BubbleSort(arr);

            int[] actualResult = arr;

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void BubbleSort_EmptyArray_WorksCorrectly()
        {
            int[] arr = { };

            int[] expectedResult = { };

            Bubble.BubbleSort(arr);

            int[] actualResult = arr;

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void BubbleSort_NegativeNumbers_WorksCorrectly()
        {
            int[] arr = { 2, -3, -8, 1232, -678, 0 };

            int[] expectedResult = { -678, -8, -3, 0, 2, 1232 };

            Bubble.BubbleSort(arr);

            int[] actualResult = arr;

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }


    }
}
