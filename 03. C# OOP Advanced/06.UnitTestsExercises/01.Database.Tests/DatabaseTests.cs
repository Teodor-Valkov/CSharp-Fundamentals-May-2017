using NUnit.Framework;
using System;

namespace _01.Database.Tests
{
    [TestFixture]
    public class DatabaseTests
    {
        [Test]
        public void TestConstructorsValidParameters()
        {
            //Arrange
            int[] numbers = new int[] { 10, 20, 30 };
            DatabaseClass<int> database = new DatabaseClass<int>(numbers);

            //Assert
            Assert.AreEqual(numbers, database.Elements, "Constructor parameters are not working correctly!");
        }

        [Test]
        public void TestConstructorsWithLessThanValidParameters()
        {
            //Arrange
            DatabaseClass<int> database;

            //Act
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => database = new DatabaseClass<int>(new int[] { }));

            //Assert
            Assert.AreEqual("The amount of elements is less/greater than required!", exception.Message);
        }

        [Test]
        public void TestConstructorsWithGreaterThanValidParameters()
        {
            //Arrange
            DatabaseClass<int> database;
            int[] numbers = new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120, 130, 140, 150, 160, 17, 18, 19, 20 };

            //Act
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => database = new DatabaseClass<int>(numbers));

            //Assert
            Assert.AreEqual("The amount of elements is less/greater than required!", exception.Message);
        }

        [Test]
        public void TestDatabaseCount()
        {
            //Arrange
            int[] numbers = new int[] { 10, 20, 30 };
            DatabaseClass<int> database = new DatabaseClass<int>(numbers);

            //Assert
            Assert.AreEqual(numbers.Length, database.Count, "Database capacity is not 16!");
        }

        [Test]
        public void TestDatabaseCapacity()
        {
            //Arrange
            DatabaseClass<int> database = new DatabaseClass<int>(new int[] { 10, 20, 30 });

            //Assert
            Assert.AreEqual(16, database.Capacity, "Database capacity is not 16!");
        }

        [Test]
        public void TestAddingElement()
        {
            //Arrange
            DatabaseClass<int> database = new DatabaseClass<int>(new int[] { 10, 20, 30 });

            //Act
            database.Add(1);

            //Assert
            Assert.AreEqual(4, database.Count, "Add method doesn't add correctly next element!");
        }

        [Test]
        public void TestAddingSeveralElement()
        {
            //Arrange
            DatabaseClass<int> database = new DatabaseClass<int>(new int[] { 10, 20, 30 });

            //Act
            database.Add(1);
            database.Add(2);
            database.Add(3);

            //Assert
            Assert.AreEqual(6, database.Count, "Add method doesn't add correctly range of elements!");
        }

        [Test]
        public void TestAddingMoreThanCapacityElements()
        {
            //Arrange
            DatabaseClass<int> database = new DatabaseClass<int>(new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120, 130, 140, 150, 160 });

            //Act
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => database.Add(17));

            //Assert
            Assert.AreEqual("There are already 16 numbers in the database!", exception.Message);
        }

        [Test]
        public void TestRemovingElement()
        {
            //Arrange
            DatabaseClass<int> database = new DatabaseClass<int>(new int[] { 10, 20, 30 });

            //Act
            database.Remove();

            //Assert
            Assert.AreEqual(2, database.Count, "Remove method doesn't remove correctly last element!");
        }

        [Test]
        public void TestRemovingSeveralElement()
        {
            //Arrange
            DatabaseClass<int> database = new DatabaseClass<int>(new int[] { 10, 20, 30 });

            //Act
            database.Remove();
            database.Remove();
            database.Remove();

            //Assert
            Assert.AreEqual(0, database.Count, "Remove method doesn't remove correctly range of element!");
        }

        [Test]
        public void TestRemovingElementWhenTheDatabaseIsEmpty()
        {
            //Arrange
            DatabaseClass<int> database = new DatabaseClass<int>(new int[] { 10, 20, 30 });

            //Act
            database.Remove();
            database.Remove();
            database.Remove();

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => database.Remove());

            //Assert
            Assert.AreEqual("There are 0 numbers in the database!", exception.Message);
        }

        [Test]
        public void TestGetMethodReturnsValidElements()
        {
            //Arrange
            int[] temp = new int[] { 10, 20, 30, 40, 50, 60, 70, 80 };
            DatabaseClass<int> database = new DatabaseClass<int>(new int[] { 10, 20, 30, 40, 50, 60, 70, 80 });

            //Assert
            CollectionAssert.AreEqual(temp, database.Elements, "Get method doesn't returning the elements!");
        }
    }
}