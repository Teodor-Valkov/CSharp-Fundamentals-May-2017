using System.Collections.Generic;

public class BookComparator : IComparer<Book>
{
    public int Compare(Book firstBook, Book secondBook)
    {
        if (firstBook.Title.CompareTo(secondBook.Title) != 0)
        {
            return firstBook.Title.CompareTo(secondBook.Title);
        }

        return secondBook.Year.CompareTo(firstBook.Year);
    }
}