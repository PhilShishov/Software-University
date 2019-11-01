namespace Tests
{
    //using ExtendedDatabase;
    using NUnit.Framework;
    using System;

    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase database;
        private Person person1;
        private Person person2;
        private Person person3;
        private Person personExistingName;
        private Person personExistingId;

        [SetUp]
        public void Setup()
        {
            this.person1 = new Person(100, "Pesho");
            this.person2 = new Person(101, "Gosho");
            this.person3 = new Person(102, "Mariq");
            this.personExistingName = new Person(104, "Pesho");
            this.personExistingId = new Person(100, "Ivan");
            this.database = new ExtendedDatabase(this.person1, this.person2);
        }

        [Test]
        public void TestIfPersonConstructorWorksCorrectly()
        {
            Assert.AreEqual(100, this.person1.Id);
            Assert.AreEqual("Pesho", this.person1.UserName);
        }

        [Test]
        public void TestIfDatabaseConstructorWorksCorrectly()
        {
            int expectedCount = 2;

            Assert.AreEqual(expectedCount, this.database.Count);
        }

        [Test]
        public void TestAddRangeException()
        {
            Person[] people = new Person[17];

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i, $"Name{i}");
            }

            Assert.Throws<ArgumentException>(() =>
                    this.database = new ExtendedDatabase(people));
        }

        [Test]
        public void TestAddRangeExceptionWithEmptyPeople()
        {
            Person[] people = new Person[17];

            Assert.Throws<ArgumentException>(() =>
                    this.database = new ExtendedDatabase(people));
        }

        [Test]
        public void TestAddNullPeople()
        {
            Person[] people = new Person[5];

            Assert.Throws<NullReferenceException>(() =>
                    this.database = new ExtendedDatabase(people));
        }
        
        [Test]
        public void TestAddPersonCorrectly()
        {
            int expectedCount = 3;

            this.database.Add(person3);

            Assert.AreEqual(expectedCount, this.database.Count);
        }

        [Test]
        public void TestAddPersonWithExistingUsername()
        {
            Assert.Throws<InvalidOperationException>(() => this.database.Add(personExistingName));
        }

        [Test]
        public void TestAddPersonWithExistingId()
        {
            Assert.Throws<InvalidOperationException>(() => this.database.Add(personExistingId));
        }

        [Test]
        public void Test_Add_Person_In_Full_Database()
        {
            Person[] people = new Person[16];

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i, $"Name{i}");
            }

            this.database = new ExtendedDatabase(people);

            Assert.Throws<InvalidOperationException>(() => this.database.Add(person3));
        }

        [Test]
        public void TestRemovingCorrectly()
        {
            int expectedCount = 1;

            this.database.Remove();

            Assert.AreEqual(expectedCount, this.database.Count);
        }

        [Test]
        public void TestRemovingWhenEmpty()
        {
            for (int i = 0; i < 2; i++)
            {
                this.database.Remove();
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.Remove();
            });
        }

        [Test]
        public void TestFindByNullUsername()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                this.database.FindByUsername(null);
            });
        }

        [Test]
        public void TestFindByNoUsername()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.FindByUsername(this.person3.UserName);
            });
        }

        [Test]
        public void TestFindByUsername()
        {
            var person = this.database.FindByUsername(this.person1.UserName);
            Assert.AreEqual(person, this.person1);
        }

        [Test]
        public void TestFindByNegativeId()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                this.database.FindById(-10);
            });
        }

        [Test]
        public void TestFindByNoId()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.FindById(99);
            });
        }


        [Test]
        public void TestFindById()
        {
            var person = this.database.FindById(this.person1.Id);
            Assert.AreEqual(person, this.person1);
        }
    }
}