using NUnit.Framework;
using System;

namespace _06.Twitter.Tests
{
    [TestFixture]
    public class TwitterTests
    {
        private IClient client;

        [SetUp]
        public void Initialize()
        {
            this.client = new Client();
        }

        [Test]
        public void TweetNullMessage()
        {
            //Assert
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => this.client.Tweet(new Tweet(null)));
            Assert.AreEqual("Message cannot be empty!", exception.ParamName);
        }

        [Test]
        public void TweetEmptyMessage()
        {
            //Assert
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => this.client.Tweet(new Tweet(string.Empty)));
            Assert.AreEqual("Message cannot be empty!", exception.ParamName);
        }

        [Test]
        public void TweetValidMessage()
        {
            //Act
            this.client.Tweet(new Tweet("Tweet"));

            //Assert
            Assert.Pass("Message is valid!");
        }

        [Test]
        public void TweetInvalidMessage()
        {
            //Asert
            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(() => this.client.Tweet(new Tweet(new string('T', 500))));
            Assert.AreEqual("Message cannot be more than 255 symbols long!", exception.ParamName);
        }

        [Test]
        public void TestNumbersOfMessagesAfterAddingNewTweet()
        {
            //Arrange
            int expected = this.client.Tweets.Count + 1;

            //Act
            this.client.Tweet(new Tweet("Add new tweet!"));
            int actual = this.client.Tweets.Count;

            //Asert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestNumbersOfMessagesAfterAddingSeveralTweets()
        {
            //Arrange
            int expected = this.client.Tweets.Count + 3;

            //Act
            this.client.Tweet(new Tweet("Add new tweet!"));
            this.client.Tweet(new Tweet("Add new tweet!"));
            this.client.Tweet(new Tweet("Add new tweet!"));
            int actual = this.client.Tweets.Count;

            //Asert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestAddingMessageAndGetLastOne()
        {
            //Act
            string lastTweet = this.client.Tweet(new Tweet("Add new tweet!"));

            //Assert
            Assert.AreEqual("Add new tweet!", lastTweet);
        }

        [Test]
        public void TestAddingSeveralMessagesAndGetLastOne()
        {
            this.client.Tweet(new Tweet("1"));
            this.client.Tweet(new Tweet("2"));
            this.client.Tweet(new Tweet("3"));

            string lastTweet = this.client.ShowLastTweet();

            Assert.AreEqual("3", lastTweet);
        }

        [Test]
        public void TestGetLastMessageWhenThereAreNoTweets()
        {
            //Assert
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => this.client.ShowLastTweet());
            Assert.AreEqual("There are no tweets!", exception.Message);
        }
    }
}