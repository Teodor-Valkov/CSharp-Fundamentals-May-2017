using NUnit.Framework;
using System;

namespace _02.Database.Tests
{
    [TestFixture]
    public class TestClass
    {
        private DatabaseClass database;

        [SetUp]
        public void Initialize()
        {
            this.database = new DatabaseClass() { new Person(1, "Ivan") };
        }

        [Test]
        public void TestAddingPerson()
        {
            //Act
            this.database.Add(new Person(2, "ivan"));

            //Assert
            Assert.AreEqual(2, this.database.GetPeopleCount());
        }

        [Test]
        public void TestAddingSeveralPersons()
        {
            //Arrange

            //Act
            this.database.Add(new Person(2, "ivan"));
            this.database.Add(new Person(3, "iban"));
            this.database.Add(new Person(4, "iran"));

            //Assert
            Assert.AreEqual(4, this.database.GetPeopleCount());
        }

        [Test]
        public void TestAddingPersonWithExistingId()
        {
            //Act
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => this.database.Add(new Person(1, "Dragan")));

            //Assert
            Assert.AreEqual("This person is already added!", exception.Message);
        }

        [Test]
        public void TestAddingPersonWithExistingUsername()
        {
            //Act
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => this.database.Add(new Person(2, "Ivan")));

            //Assert
            Assert.AreEqual("This person is already added!", exception.Message);
        }

        [Test]
        public void TestRemovingPersonById()
        {
            //Arrange
            long id = 1;

            //Act
            this.database.Remove(id);

            //Assert
            Assert.AreEqual(0, this.database.GetPeopleCount(), "Person wasn't removed!");
        }

        [Test]
        public void TestRemovingPersonByUsername()
        {
            //Arrange
            string username = "Ivan";

            //Act
            this.database.Remove(username);

            //Assert
            Assert.AreEqual(0, this.database.GetPeopleCount(), "Person wasn't removed!");
        }

        [Test]
        public void TestRemovingUnexistingPersonByUsername()
        {
            //Arrange
            string username = "ivan";

            //Act
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => this.database.Remove(username));

            //Assert
            Assert.AreEqual("There is no person with this username!", exception.Message);
        }

        [Test]
        public void TestRemovingUnexistingPersonByNullUsername()
        {
            //Arrange
            string username = null;

            //Act
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => this.database.Remove(username));

            //Assert
            Assert.AreEqual("Username is null!", exception.ParamName);
        }

        [Test]
        public void TestRemovingUnexistingPersonById()
        {
            //Arrange
            long id = 2;

            //Act
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => this.database.Remove(id));

            //Assert
            Assert.AreEqual("There is no person with this id!", exception.Message);
        }

        [Test]
        public void TestRemovingUnexistingPersonByNegativeId()
        {
            //Arrange
            long id = -1;

            //Act
            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(() => this.database.Remove(id));

            //Assert
            Assert.AreEqual("Id is negative!", exception.ParamName);
        }
    }
}