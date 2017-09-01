using NUnit.Framework;
using System;

namespace _04.BubbleSort.Tests
{
    [TestFixture]
    public class BubbleSortTests
    {
        private BubbleSortClass<int> bubbleSort;

        [Test]
        public void TestBubbleSortSortingMethodWithNull()
        {
            //Arrange
            this.bubbleSort = new BubbleSortClass<int>(null);

            //Assert
            Assert.Throws<NullReferenceException>(() => this.bubbleSort.Sort());
        }

        [Test]
        public void TestBubbleSortSortingMethodWithZeroElements()
        {
            //Arrange
            int[] numbers = new int[] { };
            this.bubbleSort = new BubbleSortClass<int>(numbers);

            //Act
            this.bubbleSort.Sort();

            //Assert
            Assert.AreEqual(string.Empty, string.Join(", ", this.bubbleSort.Elements));
        }

        [Test]
        public void TestBubbleSortSortingMethodWithOneElements()
        {
            //Arrange
            int[] numbers = new int[] { 1 };
            this.bubbleSort = new BubbleSortClass<int>(numbers);

            //Act
            this.bubbleSort.Sort();

            //Assert
            Assert.AreEqual(string.Join(", ", numbers), string.Join(", ", this.bubbleSort.Elements));
        }

        [Test]
        public void TestBubbleSortSortingMethodWithFiveElements()
        {
            //Arrange
            int[] numbers = new int[] { 5, 3, 4, 1, 2 };
            this.bubbleSort = new BubbleSortClass<int>(numbers);

            //Act
            this.bubbleSort.Sort();

            //Assert
            Assert.AreEqual(string.Join(", ", numbers), string.Join(", ", this.bubbleSort.Elements));
        }

        [Test]
        public void TestBubbleSortSortingMethodWithSixElements()
        {
            //Arrange
            int[] numbers = new int[] { 11, 872, 673, 1, 2, 158 };
            this.bubbleSort = new BubbleSortClass<int>(numbers);

            //Act
            this.bubbleSort.Sort();

            //Assert
            Assert.AreEqual(string.Join(", ", numbers), string.Join(", ", this.bubbleSort.Elements));
        }

        [Test]
        public void TestBubbleSortSortingMethodWithSevenElements()
        {
            //Arrange
            int[] numbers = new int[] { 11, 52, 43, 12, 1, 6, 28 };
            this.bubbleSort = new BubbleSortClass<int>(numbers);

            //Act
            this.bubbleSort.Sort();

            //Assert
            Assert.AreEqual(string.Join(", ", numbers), string.Join(", ", this.bubbleSort.Elements));
        }
    }
}