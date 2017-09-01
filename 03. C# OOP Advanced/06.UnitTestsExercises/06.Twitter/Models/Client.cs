using System;
using System.Collections.Generic;
using System.Linq;

public class Client : IClient
{
    public Client()
    {
        this.Tweets = new List<ITweet>();
    }

    public IList<ITweet> Tweets { get; private set; }

    public string ShowLastTweet()
    {
        if (this.Tweets.Count == 0)
        {
            throw new InvalidOperationException("There are no tweets!");
        }

        return this.Tweets.Last().Message;
    }

    public string Tweet(ITweet tweet)
    {
        this.Tweets.Add(tweet);
        return this.ShowLastTweet();
    }
}