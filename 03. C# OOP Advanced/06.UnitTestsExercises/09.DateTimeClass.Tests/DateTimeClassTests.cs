using Moq;
using NUnit.Framework;
using System;

namespace _09.DateTimeClass.Tests
{
    [TestFixture]
    public class DateTimeClassTests
    {
        private Mock<IClock> clock;

        [SetUp]
        public void Initialize()
        {
            clock = new Mock<IClock>();
        }

        [Test]
        public void GetCurrentTime()
        {
            //Arrange
            this.clock.SetupProperty(x => x.Now, DateTime.Now);

            //Or the same with SetupGet()
            //this.clock.SetupGet(x => x.Now).Returns(DateTime.Now);

            //Assert
            Assert.AreEqual(DateTime.Now.ToShortTimeString(), clock.Object.Now.ToShortTimeString());
        }

        [Test]
        public void AddDayInTheMiddleOfTheMonth()
        {
            //Arrange
            this.clock.SetupProperty(x => x.Now, new DateTime(2017, 08, 15));

            //Or the same with SetupGet()
            //this.clock.SetupGet(x => x.Now).Returns(new DateTime(2017, 08, 15));

            //Act
            DateTime dateTime = this.clock.Object.Now.AddDays(1);

            //Assert
            Assert.AreEqual(16, dateTime.Day);
        }

        [Test]
        public void AddDayAndChangeMonth()
        {
            //Arrange
            this.clock.SetupProperty(x => x.Now, new DateTime(2017, 08, 31));

            //Act
            DateTime dateTime = this.clock.Object.Now.AddDays(1);

            //Assert
            Assert.AreEqual(1, dateTime.Day);
            Assert.AreEqual(9, dateTime.Month);
        }

        [Test]
        public void AddNegativeDays()
        {
            //Arrange
            this.clock.SetupProperty(x => x.Now, new DateTime(2017, 08, 15));

            //Act
            DateTime dateTime = this.clock.Object.Now.AddDays(-5);

            //Assert
            Assert.AreEqual(8, dateTime.Month);
            Assert.AreEqual(10, dateTime.Day);
        }

        [Test]
        public void AddNegativeDaysAndChangeMonth()
        {
            //Arrange
            this.clock.SetupProperty(x => x.Now, new DateTime(2017, 08, 01));

            //Act
            DateTime dateTime = this.clock.Object.Now.AddDays(-1);

            //Assert
            Assert.AreEqual(31, dateTime.Day);
            Assert.AreEqual(7, dateTime.Month);
        }

        [Test]
        public void AddDayToLeapYearFebruary()
        {
            //Arrange
            this.clock.SetupProperty(x => x.Now, new DateTime(2016, 02, 28));

            //Act
            DateTime dateTime = this.clock.Object.Now.AddDays(1);

            //Assert
            Assert.AreEqual(29, dateTime.Day);
            Assert.AreEqual(2, dateTime.Month);
        }

        [Test]
        public void AddDayToNonLeapYearFebruary()
        {
            //Arrange
            this.clock.SetupProperty(x => x.Now, new DateTime(2017, 02, 28));

            //Act
            DateTime dateTime = this.clock.Object.Now.AddDays(1);

            //Assert
            Assert.AreEqual(1, dateTime.Day);
            Assert.AreEqual(3, dateTime.Month);
        }

        [Test]
        public void AddDayToDateTimeMinValue()
        {
            //Arrange
            this.clock.SetupProperty(x => x.Now, DateTime.MinValue);

            //Assert
            Assert.DoesNotThrow(() => this.clock.Object.Now.AddDays(1));
        }

        [Test]
        public void SubtractDayToDateTimeMinValue()
        {
            //Arrange
            this.clock.SetupProperty(x => x.Now, DateTime.MinValue);

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => this.clock.Object.Now.AddDays(-1));
        }

        [Test]
        public void AddDayToDateTimeMaxValue()
        {
            //Arrange
            this.clock.SetupProperty(x => x.Now, DateTime.MaxValue);

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => this.clock.Object.Now.AddDays(1));
        }

        [Test]
        public void SubtractDayToDateTimeMaxValue()
        {
            //Arrange
            this.clock.SetupProperty(x => x.Now, DateTime.MaxValue);

            //Assert
            Assert.DoesNotThrow(() => this.clock.Object.Now.AddDays(-1));
        }
    }
}