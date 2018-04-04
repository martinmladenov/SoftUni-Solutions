namespace Tests
{
    using System;
    using NUnit.Framework;

    public class DateTimeTests
    {
        [Test]
        public void Now_WorksConsistently()
        {
            string expectedResult = DateTime.Now.ToString("R");
            string actualResult = DateTime.Now.ToString("R");

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void AddDays_SameMonth_WorksCorrectly()
        {
            DateTime dt = new DateTime(2018,06,16);

            DateTime expectedResult = new DateTime(2018, 06, 17);
            DateTime actualResult = dt.Add(new TimeSpan(1, 0, 0, 0));

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void AddDays_ToNextMonth_WorksCorrectly()
        {
            DateTime dt = new DateTime(2018,07,31);

            DateTime expectedResult = new DateTime(2018, 08, 01);
            DateTime actualResult = dt.Add(new TimeSpan(1, 0, 0, 0));

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void AddDays_NegativeAmountSameMonth_WorksCorrectly()
        {
            DateTime dt = new DateTime(2018, 07, 30);

            DateTime expectedResult = new DateTime(2018, 07, 25);
            DateTime actualResult = dt.Add(new TimeSpan(-5, 0, 0, 0));

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void AddDays_NegativeAmountPrevMonth_WorksCorrectly()
        {
            DateTime dt = new DateTime(2018, 08, 02);

            DateTime expectedResult = new DateTime(2018, 07, 28);
            DateTime actualResult = dt.Add(new TimeSpan(-5, 0, 0, 0));

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void AddDays_LeapYear_WorksCorrectly()
        {
            DateTime dt = new DateTime(2008, 02, 28);

            DateTime expectedResult = new DateTime(2008, 02, 29);
            DateTime actualResult = dt.Add(new TimeSpan(1, 0, 0, 0));

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void AddDays_NonLeapYear_WorksCorrectly()
        {
            DateTime dt = new DateTime(2018, 02, 28);

            DateTime expectedResult = new DateTime(2018, 03, 01);
            DateTime actualResult = dt.Add(new TimeSpan(1, 0, 0, 0));

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }


    }
}
