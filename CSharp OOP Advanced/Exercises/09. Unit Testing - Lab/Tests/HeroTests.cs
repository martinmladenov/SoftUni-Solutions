namespace Tests
{
    using Moq;
    using NUnit.Framework;

    class HeroTests
    {
        [Test]
        public void Attack_IfTargetDies_GainsExperience()
        {
            int expectedAmount = 5;

            Mock<ITarget> target = new Mock<ITarget>();
            target.Setup(t => t.Health).Returns(0);
            target.Setup(t => t.GiveExperience()).Returns(expectedAmount);
            target.Setup(t => t.IsDead()).Returns(true);

            Mock<IWeapon> weapon = new Mock<IWeapon>();

            Hero hero = new Hero("hero", weapon.Object);

            hero.Attack(target.Object);

            int actualAmount = hero.Experience;

            Assert.That(actualAmount, Is.EqualTo(expectedAmount));
        }

        //[Test]
        //public void Attack_IfTargetDies_GainsExperience()
        //{
        //    int expectedAmount = 5;

        //    ITarget target = new FakeTarget();
        //    IWeapon weapon = new FakeWeapon();
        //    Hero hero = new Hero("hero", weapon);

        //    hero.Attack(target);

        //    int actualAmount = hero.Experience;

        //    Assert.That(actualAmount, Is.EqualTo(expectedAmount));
        //}

        //class FakeTarget : ITarget
        //{
        //    public int Health => 0;

        //    public int GiveExperience() => 5;

        //    public bool IsDead() => true;

        //    public void TakeAttack(int attackPoints)
        //    {
        //    }
        //}

        //class FakeWeapon : IWeapon
        //{
        //    public int AttackPoints => 5;

        //    public int DurabilityPoints => 5;

        //    public void Attack(ITarget target)
        //    {
        //    }
        //}
    }
}
