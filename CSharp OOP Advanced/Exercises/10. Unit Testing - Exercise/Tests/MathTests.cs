namespace Tests
{
    using System;
    using NUnit.Framework;

    public class MathTests
    {
        [Test]
        public void Abs_PositiveInteger_WorksCorrectly()
        {
            int expectedResult = 5;
            int actualResult = Math.Abs(5);

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Abs_NegativeInteger_WorksCorrectly()
        {
            int expectedResult = 5;
            int actualResult = Math.Abs(-5);

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Abs_PositiveDouble_WorksCorrectly()
        {
            double expectedResult = 5.2;
            double actualResult = Math.Abs(5.2);

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Abs_NegativeDouble_WorksCorrectly()
        {
            double expectedResult = 5.2;
            double actualResult = Math.Abs(-5.2);

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }


[Test]
        public void Floor_PositiveWholeNumber_WorksCorrectly()
        {
            double expectedResult = 5.0;
            double actualResult = Math.Floor(5.0);

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Floor_NegativeWholeNumber_WorksCorrectly()
        {
            double expectedResult = -5.0;
            double actualResult = Math.Floor(-5.0);

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Floor_PositiveDouble_WorksCorrectly()
        {
            double expectedResult = 5.0;
            double actualResult = Math.Floor(5.2);

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Floor_NegativeDouble_WorksCorrectly()
        {
            double expectedResult = -6.0;
            double actualResult = Math.Floor(-5.2);

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }


    }
}
