namespace BlueOrigin.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class SpaceshipTests
    {
        private Astronaut astronaut1;
        private Astronaut astronaut2;
        private Astronaut astronaut3;
        private Spaceship spaceship;

        [SetUp]
        public void SetUp()
        {
            this.astronaut1 = new Astronaut("Name1", 10);
            this.astronaut2 = new Astronaut("Name2", 20);
            this.astronaut3 = new Astronaut("Name3", 30);
            this.spaceship = new Spaceship("Ship", 2);
        }

        //[Test]
        //public void Test_AstronautConstructor()
        //{
        //    Assert.AreEqual("Name1", this.astronaut1.Name);
        //    Assert.AreEqual(10, this.astronaut1.OxygenInPercentage);
        //}

        [Test]
        public void Test_SpaceshipConstructor()
        {
            Assert.AreEqual("Ship", this.spaceship.Name);
            Assert.AreEqual(2, this.spaceship.Capacity);
            Assert.AreEqual(0, this.spaceship.Count);
        }


        [Test]
        public void Test_SpaceshipName()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new Spaceship(null, 10);
            });
        }

        [Test]
        public void Test_SpaceshipCapacity()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Spaceship("Name", -10);
            });
        }

        [Test]
        public void Test_AddCount()
        {
            this.spaceship.Add(this.astronaut1);
            this.spaceship.Add(this.astronaut2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.spaceship.Add(this.astronaut3);
            });
        }

        [Test]
        public void Test_AddExistingAstronaut()
        {
            this.spaceship.Add(this.astronaut1);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.spaceship.Add(this.astronaut1);
            });
        }

        //[Test]
        //public void Test_Add()
        //{
        //    this.spaceship.Add(this.astronaut1);
        //    this.spaceship.Add(this.astronaut2);

        //    Assert.AreEqual(2, this.spaceship.Count);
        //}

        [Test]
        public void Test_RemoveTrue()
        {
            this.spaceship.Add(this.astronaut1);
            this.spaceship.Add(this.astronaut2);

            Assert.AreEqual(true, this.spaceship.Remove(this.astronaut1.Name));
        }

        //[Test]
        //public void Test_RemoveFalse()
        //{
        //    this.spaceship.Add(this.astronaut1);
        //    this.spaceship.Add(this.astronaut2);

        //    Assert.AreEqual(false, this.spaceship.Remove("Name4"));
        //}

        //[Test]
        //public void Test_Remove()
        //{
        //    this.spaceship.Add(this.astronaut1);
        //    this.spaceship.Add(this.astronaut2);

        //    this.spaceship.Remove(this.astronaut1.Name);

        //    Assert.AreEqual(1, this.spaceship.Count);
        //}
    }
}