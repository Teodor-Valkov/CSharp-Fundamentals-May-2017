using NUnit.Framework;
using System;

namespace _03.Iterator.Tests
{
    [TestFixture]
    public class TestClass
    {
        private ListIterator<string> collection;

        [Test]
        public void TestConstructorWithNull()
        {
            //Assert
            Assert.Throws<ArgumentNullException>(() => this.collection = new ListIterator<string>(null));
        }

        [Test]
        public void TestConstructorWithZeroParameters()
        {
            //Arrange
            string[] expected = new string[] { };
            this.collection = new ListIterator<string>(expected);

            //Assert
            Assert.AreEqual(expected.Length, this.collection.Elements.Count, "Constructor doesn't add the array!");
        }

        [Test]
        public void TestConstructorWithValidParameters()
        {
            //Arrange
            string[] expected = new string[] { "1", "2", "3" };
            this.collection = new ListIterator<string>(expected);

            //Assert
            Assert.AreEqual(expected, this.collection.Elements, "Constructor doesn't add the expected array!");
        }

        [Test]
        public void TestMoveMethodWithEmptyList()
        {
            //Arrange
            string[] array = new string[] { };
            this.collection = new ListIterator<string>(array);

            //Assert
            Assert.AreEqual(false, this.collection.Move());
        }

        [Test]
        public void TestMoveMethodTwoTimesAndReturnsTrue()
        {
            //Arrange
            string[] array = new string[] { "1", "2", "3" };
            this.collection = new ListIterator<string>(array);

            //Act
            this.collection.Move();

            //Assert
            Assert.AreEqual(true, this.collection.Move(), "Index wasn't updated!");
        }

        [Test]
        public void TestMoveMethodThreeTimesToReturnFalse()
        {
            //Arrange
            string[] array = new string[] { "1", "2", "3" };
            this.collection = new ListIterator<string>(array);

            //Act
            this.collection.Move();
            this.collection.Move();

            //Assert
            Assert.AreEqual(false, this.collection.Move(), "Index was updated when it was not supposed to!");
        }

        [Test]
        public void TestHasNextMethodToReturnTrueAfterOneMove()
        {
            //Arrange
            string[] array = new string[] { "1", "2", "3" };
            this.collection = new ListIterator<string>(array);

            //Act
            this.collection.Move();

            //Assert
            Assert.AreEqual(true, this.collection.HasNext(), "Index wasn't updated!");
        }

        [Test]
        public void TestHasNextMethodToReturnFalseAfterTwoMoves()
        {
            //Arrange
            string[] array = new string[] { "1", "2", "3" };
            this.collection = new ListIterator<string>(array);

            //Act
            collection.Move();
            collection.Move();

            //Assert
            Assert.AreEqual(false, this.collection.HasNext(), "Index was updated when it is not supposed not to!");
        }

        [Test]
        public void TestPrintMethodToPrintTheSecondElementAfterOneMove()
        {
            //Arrange
            string[] array = new string[] { "1", "2", "3" };
            this.collection = new ListIterator<string>(array);

            //Act
            this.collection.Move();

            //Assert
            Assert.AreEqual("2", this.collection.Print(), "Printing method doesn't return correct value!");
        }

        [Test]
        public void TestPrintMethodToPrintAnElementFromAnEmptyCollection()
        {
            //Arrange
            string[] array = new string[] { };
            this.collection = new ListIterator<string>(array);

            //Act
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => this.collection.Print());

            //Assert
            Assert.AreEqual("Invalid operation!", exception.Message);
        }
    }
}