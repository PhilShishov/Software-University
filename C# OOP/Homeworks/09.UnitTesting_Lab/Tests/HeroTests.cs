namespace Tests
{
    using Moq;
    using NUnit.Framework;
    using Skeleton.Contracts;

    [TestFixture]
    public class HeroTests
    {
        private const string name = "Pesho";

        [Test]
        public void CheckIfHeroGainsExperienceWhenTargetDies()
        {
            Mock<ITarget> fakeTarget = new Mock<ITarget>();

            fakeTarget.Setup(x => x.GiveExperience()).Returns(() => 20);
            fakeTarget.Setup(x => x.Health).Returns(0);
            fakeTarget.Setup(x => x.IsDead()).Returns(true);

            Mock<IWeapon> fakeWeapon = new Mock<IWeapon>();
            fakeWeapon.Setup(x => x.Attack(fakeTarget.Object));

            Hero hero = new Hero(name, fakeWeapon.Object);

            hero.Attack(fakeTarget.Object);

            Assert.That(hero.Experience, Is.EqualTo(20));
        }

    }
}
