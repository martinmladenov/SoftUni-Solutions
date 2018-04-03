namespace Tests
{
    using System;
    using NUnit.Framework;

    class AxeTests
    {
        [Test]
        public void Attack_LosesDurability()
        {
            int expectedResult = 4;

            Axe axe = new Axe(5, expectedResult + 1);
            Dummy dummy = new Dummy(5, 5);

            axe.Attack(dummy);

            int actualResult = axe.DurabilityPoints;

            Assert.That(actualResult, Is.EqualTo(expectedResult),
                "Axe does not lose durability after attack.");
        }

        [Test]
        public void Attack_Broken_ThrowsInvalidOperationException()
        {
            Axe axe = new Axe(5, 0);
            Dummy dummy = new Dummy(5, 5);

            Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy),
                "Axe does not throw InvalidOperationException when attacking with 0 Durability.");
        }
    }
}
