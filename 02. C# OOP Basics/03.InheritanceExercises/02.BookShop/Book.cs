using System;
using System.Linq;
using System.Text;

public class Book
{
    private string author;
    private string title;
    private decimal price;

    public Book(string author, string title, decimal price)
    {
        this.Author = author;
        this.Title = title;
        this.Price = price;
    }

    public string Author
    {
        get
        {
            return this.author;
        }
        protected set
        {
            string[] nameArgs = value.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (nameArgs.Length == 2)
            {
                string secondName = nameArgs[1];

                if (char.IsDigit(secondName.First()))
                {
                    throw new ArgumentException("Author not valid!");
                }
            }
            this.author = value;
        }
    }

    public string Title
    {
        get
        {
            return this.title;
        }
        protected set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Title not valid!");
            }
            this.title = value;
        }
    }

    public virtual decimal Price
    {
        get
        {
            return this.price;
        }
        protected set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Price not valid!");
            }
            this.price = value;
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"Type: {this.GetType().Name}");
        sb.AppendLine($"Title: {this.Title}");
        sb.AppendLine($"Author: {this.Author}");
        sb.AppendLine($"Price: {this.Price:F1}");

        return sb.ToString();
    }
}