
namespace TheRace.Tests
{
    using System;

    using NUnit.Framework;
    
    [TestFixture]
    public class RaceEntryTests
    {
        private UnitMotorcycle motorcycle1;
        private UnitMotorcycle motorcycle2;
        private UnitRider rider1;
        private UnitRider rider2;
        private RaceEntry race;

        [SetUp]
        public void SetUp()
        {
            this.motorcycle1 = new UnitMotorcycle("Model", 100, 10);
            this.motorcycle2 = new UnitMotorcycle("Model2", 100, 10);
            this.rider1 = new UnitRider("Rider", this.motorcycle1);
            this.rider2 = new UnitRider("Rider2", this.motorcycle2);
            this.race = new RaceEntry();
        }

        [Test]
        public void Test_MotorCycleConstructor()
        {
            Assert.AreEqual("Model", this.motorcycle1.Model);
            Assert.AreEqual(100, this.motorcycle1.HorsePower);
            Assert.AreEqual(10, this.motorcycle1.CubicCentimeters);
        }

        [Test]
        public void Test_RiderName()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new UnitRider(null, this.motorcycle1);
            });
        }

        [Test]
        public void Test_RaceConstructor()
        {
            Assert.AreEqual(0, this.race.Counter);
        }


        [Test]
        public void Test_RaceAddNullRider()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.race.AddRider(null);
            });
        }

        [Test]
        public void Test_RaceAddExistingRider()
        {
            this.race.AddRider(this.rider1);
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.race.AddRider(this.rider1);
            });
        }

        [Test]
        public void Test_RaceAddRider()
        {
            string actual = this.race.AddRider(this.rider1);

            Assert.AreEqual("Rider Rider added in race.", actual);

        }

        [Test]
        public void Test_CalculateAverageHorsePowerException()
        {
            this.race.AddRider(this.rider1);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.race.CalculateAverageHorsePower();
            });
        }

        [Test]
        public void Test_CalculateAverageHorsePower()
        {
            this.race.AddRider(this.rider1);
            this.race.AddRider(this.rider2);

            double actual = this.race.CalculateAverageHorsePower();

            Assert.AreEqual(100, actual);
        }

    }
}