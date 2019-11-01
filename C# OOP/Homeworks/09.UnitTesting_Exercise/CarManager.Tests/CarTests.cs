//using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        private Car car;

        [SetUp]
        public void Setup()
        {
            car = new Car("Opel", "Corsa", 0.5, 40);
        }

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            Assert.AreEqual("Opel", this.car.Make);
            Assert.AreEqual("Corsa", this.car.Model);
            Assert.AreEqual(0.5, this.car.FuelConsumption);
            Assert.AreEqual(40, this.car.FuelCapacity);
            Assert.AreEqual(0, this.car.FuelAmount);
        }

        [Test]
        public void TestMake()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Car(null, "Corsa", 0.5, 40);
            });
        }

        [Test]
        public void TestModel()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Car("Opel", null, 0.5, 40);
            });
        }

        [Test]
        public void TestFuelConsumption()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Car("Opel", "Corsa", -5, 40);
            });
        }

        [Test]
        public void TestFuelCapacity()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Car("Opel", "Corsa", 0.5, 0);
            });
        }

        [Test]
        public void Test_Refuel_Exception()
        {
            Assert.Throws<ArgumentException>(() => this.car.Refuel(0));
        }

        [Test]
        public void Test_Refuel()
        {
            this.car.Refuel(1);
            Assert.AreEqual(1, this.car.FuelAmount);
        }

        [Test]
        public void Test_Refuel_If_Statement()
        {
            this.car.Refuel(100);
            Assert.AreEqual(40, this.car.FuelAmount);
        }

        [Test]
        public void Test_Drive_Exception()
        {
            Assert.Throws<InvalidOperationException>(() => this.car.Drive(1000));
        }

        [Test]
        public void Test_Drive()
        {
            this.car.Refuel(40);
            this.car.Drive(100);

            Assert.AreEqual(39.5, this.car.FuelAmount);
        }
    }
}