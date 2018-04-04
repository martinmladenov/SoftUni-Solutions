namespace TirePressureMonitoringSystem.Tests
{
    using Moq;
    using NUnit.Framework;

    public class AlarmTests
    {
        [Test]
        public void AlarmOn_NoCheck_WorksCorrectly()
        {
            Alarm alarm = new Alarm();

            bool expectedResult = false;
            bool actualResult = alarm.AlarmOn;

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void AlarmOn_CheckInRange_WorksCorrectly()
        {
            Mock<ISensor> sensorMock = new Mock<ISensor>();
            sensorMock.Setup(s => s.PopNextPressurePsiValue()).Returns(19D);

            Alarm alarm = new Alarm(sensorMock.Object);

            alarm.Check();

            bool expectedResult = false;
            bool actualResult = alarm.AlarmOn;

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(16.99)]
        [TestCase(21.01)]
        public void AlarmOn_CheckOutOfRange_WorksCorrectly(double pressure)
        {
            Mock<ISensor> sensorMock = new Mock<ISensor>();
            sensorMock.Setup(s => s.PopNextPressurePsiValue()).Returns(pressure);

            Alarm alarm = new Alarm(sensorMock.Object);

            alarm.Check();

            bool expectedResult = true;
            bool actualResult = alarm.AlarmOn;

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void AlarmOn_CheckOutOfRangeThenInRange_StaysOn()
        {
            Mock<ISensor> sensorMock = new Mock<ISensor>();
            sensorMock.Setup(s => s.PopNextPressurePsiValue()).Returns(25D);

            Alarm alarm = new Alarm(sensorMock.Object);

            alarm.Check();

            sensorMock.Setup(s => s.PopNextPressurePsiValue()).Returns(20D);

            alarm.Check();

            bool expectedResult = true;
            bool actualResult = alarm.AlarmOn;

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

    }
}
