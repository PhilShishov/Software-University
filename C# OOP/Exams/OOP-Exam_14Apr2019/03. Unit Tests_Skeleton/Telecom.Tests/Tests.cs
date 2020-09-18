namespace Telecom.Tests
{
    using System;

    using NUnit.Framework;

    [TestFixture]
    public class Tests
    {
        private Phone phone;

        [SetUp]
        public void SetUp()
        {
            this.phone = new Phone("SAMSUNG", "G900V");
        }

        [Test]
        public void Test_PhoneConstructor()
        {
            Assert.AreEqual("SAMSUNG", this.phone.Make);
            Assert.AreEqual("G900V", this.phone.Model);
        }

        [Test]
        public void Test_InvalidPhoneMake()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Phone(null, "G900V");
            });
        }

        [Test]
        public void Test_InvalidPhoneModel()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Phone("SAMSUNG", null);
            });
        }

        [Test]
        public void Test_AddContact()
        {
            this.phone.AddContact("Peter", "12345");

            Assert.AreEqual(1, this.phone.Count);
        }

        [Test]
        public void Test_AddExistingContact()
        {
            this.phone.AddContact("Peter", "12345");

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.phone.AddContact("Peter", "12345");
            });
        }

        [Test]
        public void Test_Call()
        {
            this.phone.AddContact("Peter", "12345");

            string expected = $"Calling Peter - 12345...";
            string actual = this.phone.Call("Peter");

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_CallInvalidContact()
        {
            this.phone.AddContact("Peter", "12345");

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.phone.Call("Ivan");
            });
        }


    }
}