using System.Collections.Generic;

public interface IClient
{
    IList<ITweet> Tweets { get; }

    string Tweet(ITweet tweet);

    string ShowLastTweet();
}