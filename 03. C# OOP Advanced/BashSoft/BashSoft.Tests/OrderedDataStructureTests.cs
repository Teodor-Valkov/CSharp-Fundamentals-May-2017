using BashSoft.Contracts;
using BashSoft.DataStructures;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BashSoft.Tests
{
    [TestFixture]
    public class OrderedDataStructureTests
    {
        private ISimpleOrderedBag<string> names;

        [SetUp]
        public void SetUp()
        {
            this.names = new SimpleSortedList<string>();
        }

        [Test]
        public void TestEmptyConstructor()
        {
            //Arrange
            this.names = new SimpleSortedList<string>();

            //Assert
            Assert.AreEqual(this.names.Size, 0);
            Assert.AreEqual(this.names.Capacity, 16);
        }

        [Test]
        public void TestConstructorWithInitialCapacity()
        {
            //Arrange
            this.names = new SimpleSortedList<string>(20);

            //Assert
            Assert.AreEqual(this.names.Size, 0);
            Assert.AreEqual(this.names.Capacity, 20);
        }

        [Test]
        public void TestConstructorWithAllParameters()
        {
            //Arrange
            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase, 20);

            //Assert
            Assert.AreEqual(this.names.Size, 0);
            Assert.AreEqual(this.names.Capacity, 20);
        }

        [Test]
        public void TestConstructorWithInitialComparer()
        {
            //Arrange
            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase);

            //Assert
            Assert.AreEqual(this.names.Size, 0);
            Assert.AreEqual(this.names.Capacity, 16);
        }

        [Test]
        public void TestAddIncreaseSize()
        {
            //Arrange
            this.names.Add("Ivan");

            //Assert
            Assert.AreEqual(1, this.names.Size);
        }

        [Test]
        public void TestAddNullThrowsException()
        {
            //Assert
            Assert.Throws<ArgumentNullException>(() => this.names.Add(null));
        }

        [Test]
        public void TestAddUnsortedDataIsHeldSorted()
        {
            //Arrange
            this.names.Add("Rosen");
            this.names.Add("Georgi");
            this.names.Add("Balkan");

            //Assert
            CollectionAssert.AreEqual(this.names, new string[] { "Balkan", "Georgi", "Rosen" });
        }

        [Test]
        public void TestAddingMoreThanInitialCapacity()
        {
            //Arrange
            for (int i = 0; i < 17; i++)
            {
                this.names.Add(i.ToString());
            }

            //Assert
            Assert.AreNotEqual(this.names.Capacity, 16);
            Assert.AreEqual(this.names.Size, 17);
        }

        [Test]
        public void TestAddingAllFromCollectionIncreasesSize()
        {
            //Arrange
            List<string> list = new List<string>(new string[] { "first", "second" });
            this.names.AddAll(list);

            //Assert
            Assert.AreEqual(this.names.Size, 2);
        }

        [Test]
        public void TestAddingAllFromNullThrowsException()
        {
            //Assert
            Assert.Throws<ArgumentNullException>(() => this.names.AddAll(null));
        }

        [Test]
        public void TestAddAllKeepsSorted()
        {
            //Arrange
            this.names.AddAll(new string[] { "Rosen", "Georgi", "Balkan" });

            //Assert
            CollectionAssert.AreEqual(this.names, new string[] { "Balkan", "Georgi", "Rosen" });
        }

        [Test]
        public void TestRemoveValidElementDecreasesSize()
        {
            //Arrange
            this.names.Add("first");

            //Act
            this.names.Remove("first");

            //Assert
            Assert.AreEqual(0, this.names.Size);
        }

        [Test]
        public void TestRemoveValidElementRemovesSelectedOne()
        {
            //Arrange
            this.names.Add("first");
            this.names.Add("second");

            //Act
            this.names.Remove("first");

            //Assert
            Assert.That(this.names, Has.No.Member("first"));
        }

        [Test]
        public void TestRemovingNullThrowsException()
        {
            //Assert
            Assert.Throws<ArgumentNullException>(() => this.names.Remove(null));
        }

        [Test]
        public void TestJoinWithNull()
        {
            //Arrange
            this.names.Add("first");
            this.names.Add("second");

            //Assert
            Assert.Throws<ArgumentNullException>(() => this.names.JoinWith(null));
        }

        [Test]
        public void TestJoinWorksFine()
        {
            //Arrange
            this.names.Add("first");
            this.names.Add("second");

            string expected = "first, second";
            string actual = this.names.JoinWith(", ");

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}