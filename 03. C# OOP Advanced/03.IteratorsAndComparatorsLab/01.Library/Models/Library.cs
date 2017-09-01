﻿using System.Collections;
using System.Collections.Generic;

public class Library : IEnumerable<Book>
{
    public Library(params Book[] books)
    {
        this.Books = new List<Book>(books);
    }

    public IReadOnlyList<Book> Books { get; private set; }

    public IEnumerator<Book> GetEnumerator()
    {
        return this.Books.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}