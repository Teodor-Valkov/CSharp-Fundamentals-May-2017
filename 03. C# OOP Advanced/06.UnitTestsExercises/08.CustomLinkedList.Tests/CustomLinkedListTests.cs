using NUnit.Framework;
using System;

namespace _08.CustomLinkedList.Tests
{
    [TestFixture]
    public class CustomLinkedListTests
    {
        private CustomLinkedList<int> collection;

        [SetUp]
        public void Initiliaze()
        {
            this.collection = new CustomLinkedList<int>();
            this.collection.Add(10);
            this.collection.Add(20);
            this.collection.Add(30);
            this.collection.Add(40);
            this.collection.Add(50);
        }

        [Test]
        public void CreateEmptyCustomLinkedList()
        {
            //Arrange
            CustomLinkedList<int> collection = new CustomLinkedList<int>();

            //Assert
            Assert.AreEqual(0, collection.Count);
        }

        [Test]
        public void AddElementToTheCustomLinkedList()
        {
            //Act
            this.collection.Add(100);

            //Assert
            Assert.AreEqual(6, this.collection.Count);
        }

        [Test]
        public void CheckElementAtGivenIndex()
        {
            //Assert
            Assert.AreEqual(30, this.collection[2]);
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void RemoveElementAtGivenIndex(int index)
        {
            //Arrange
            int expectedRemovedElement = this.collection[index];

            //Act
            int actualRemovedElement = this.collection.RemoveAt(index);

            //Assert
            Assert.AreEqual(expectedRemovedElement, actualRemovedElement);
        }

        [Test]
        [TestCase(10)]
        [TestCase(20)]
        [TestCase(30)]
        public void RemoveElementAtInvalidIndex(int index)
        {
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => this.collection.RemoveAt(index));
        }

        [Test]
        public void RemoveElementByGivenValueAndGetItsIndex()
        {
            //Assert
            Assert.AreEqual(2, this.collection.Remove(30));
        }

        [Test]
        [TestCase(10)]
        [TestCase(20)]
        [TestCase(30)]
        public void ReturnIndexByGivenValidElementValue(int value)
        {
            //Arrange
            int expectedIndex = value / 10 - 1;

            //Assert
            Assert.AreEqual(expectedIndex, this.collection.IndexOf(value));
        }

        [Test]
        [TestCase(100)]
        [TestCase(200)]
        [TestCase(300)]
        public void ReturnIndexByGivenInvalidElementValue(int value)
        {
            //Assert
            Assert.AreEqual(-1, this.collection.IndexOf(value));
        }

        [Test]
        [TestCase(10)]
        [TestCase(20)]
        [TestCase(30)]
        public void ReturnTrueForElementsSearchedByGivenValidElementValue(int value)
        {
            Assert.IsTrue(this.collection.Contains(value));
        }

        [Test]
        [TestCase(100)]
        [TestCase(200)]
        [TestCase(300)]
        public void ReturnFalseForElementsSearchedByGivenValidElementValue(int value)
        {
            Assert.IsFalse(this.collection.Contains(value));
        }
    }
}