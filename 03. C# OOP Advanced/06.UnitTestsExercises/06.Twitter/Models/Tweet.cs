using System;

public class Tweet : ITweet
{
    private string message;

    public Tweet(string message)
    {
        this.Message = message;
    }

    public string Message
    {
        get { return this.message; }
        private set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Message cannot be empty!");
            }

            if (value.Length > 255)
            {
                throw new ArgumentOutOfRangeException("Message cannot be more than 255 symbols long!");
            }

            this.message = value;
        }
    }
}