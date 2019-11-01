namespace Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void CheckIfDummyLosesHealthAfterAttack()
        {
            // Arrange
            Dummy dummy = new Dummy(20, 10);

            // Act
            dummy.TakeAttack(5);

            // Assert
            Assert.That(dummy.Health,
            Is.EqualTo(15));
        }

        [Test]
        public void CheckIfDeadDummyCantTakeAttack()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(5, 10);

            dummy.TakeAttack(axe.AttackPoints);

            Assert.That(() => dummy.TakeAttack(axe.AttackPoints),
            Throws.InvalidOperationException
            .With.Message.EqualTo("Dummy is dead."));
        }

        [Test]
        public void CheckIfDeadDummyCanGiveExp()
        {
            Dummy dummy = new Dummy(0, 10);

            int exp = dummy.GiveExperience();

            Assert.That(exp, Is.EqualTo(10));
        }

        [Test]
        public void CheckIfAliveDummyCantGiveXP()
        {
            Dummy dummy = new Dummy(10, 10);

            dummy.TakeAttack(3);

            Assert.That(() => dummy.GiveExperience(),
                Throws.InvalidOperationException
                .With.Message.EqualTo("Target is not dead."));
        }
    }
}
