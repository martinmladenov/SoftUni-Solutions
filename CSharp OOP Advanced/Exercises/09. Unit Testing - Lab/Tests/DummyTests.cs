namespace Tests
{
    using System;
    using NUnit.Framework;

    class DummyTests
    {
        [Test]
        public void AxeAttack_DummyLosesHealth()
        {
            int expectedResult = 3;

            Dummy dummy = new Dummy(5, expectedResult+2);
            Axe axe = new Axe(2, 5);

            axe.Attack(dummy);

            int actualResult = dummy.Health;

            Assert.That(actualResult, Is.EqualTo(expectedResult),
                "Dummy does not lose health after attack.");
        }

        [Test]
        public void AxeAttack_DeadDummy_ThrowsInvalidOperationException()
        {
            Dummy dummy = new Dummy(0, 5);
            Axe axe = new Axe(5, 5);

            Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy),
                "Dead Dummy does not throw InvalidOperationException when attacked.");
        }

        [Test]
        public void GiveExperience_Dead_GivesCorrectAmount()
        {
            int expectedResult = 5;

            Dummy dummy = new Dummy(0, expectedResult);

            int actualResult = dummy.GiveExperience();

            Assert.That(actualResult, Is.EqualTo(expectedResult),
                "Dead Dummy does not give correct amount of XP.");
        }

        [Test]
        public void GiveExperience_Alive_ThrowsInvalidOperationException()
        {
            Dummy dummy = new Dummy(5, 5);

            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience(),
                "Alive Dummy can give XP.");
        }
    }
}
