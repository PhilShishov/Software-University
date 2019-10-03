namespace ParkingSystem.Tests
{
    using System;

    using NUnit.Framework;

    public class SoftParkTest
    {
        private SoftPark softPark;
        private Car car;

        [SetUp]
        public void Setup()
        {
            this.softPark = new SoftPark();
            this.car = new Car("Opel","1234");

        }

        [Test]
        public void Test_CarConstructor()
        {
            Assert.AreEqual("Opel", this.car.Make);
            Assert.AreEqual("1234", this.car.RegistrationNumber);
        }

        [Test]
        public void Test_SoftParkConstructor()
        {
            int count = this.softPark.Parking.Count;
            Assert.AreEqual(12, count);
        }

        [Test]
        public void Test_ParkCar()
        {
            string actual = this.softPark.ParkCar("B1", this.car);

            string expected = $"Car:1234 parked successfully!";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_MissingParkingSpot()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.softPark.ParkCar("B8", this.car);
            });
        }

        [Test]
        public void Test_ParkingSpotTaken()
        {
            this.softPark.ParkCar("B1", this.car);

            Assert.Throws<ArgumentException>(() =>
            {
                this.softPark.ParkCar("B1", this.car);
            });
        }

        [Test]
        public void Test_CarAlreadyParked()
        {
            this.softPark.ParkCar("B1", this.car);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.softPark.ParkCar("B2", this.car);
            });
        }

        [Test]
        public void Test_CarRemoved()
        {
            this.softPark.ParkCar("B1", this.car);
            string actual = this.softPark.RemoveCar("B1", this.car);

            string expected = "Remove car:1234 successfully!";

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_RemoveCarInvalidSpot()
        {
            this.softPark.ParkCar("B1", this.car);

            Assert.Throws<ArgumentException>(() =>
            {
                this.softPark.RemoveCar("B8", this.car);
            });
        }

        [Test]
        public void Test_Remove_Car_Invalid_Car()
        {
            Car newCar = new Car("Make1", "Number1");

            Assert
                .Throws<ArgumentException>(() => this.softPark.RemoveCar("A1", newCar));
        }

        [Test]
        public void Test_CarRemovedMessage()
        {
            this.softPark.ParkCar("B1", this.car);
            string actual = this.softPark.RemoveCar("B1", this.car);

            string expected = "Remove car:1234 successfully!";

            Assert.AreEqual(expected, actual);
        }

    }
}