﻿using System;

public class Square : Figure
{
    private int size;

    public Square(int size)
    {
        this.Size = size;
    }

    public int Size
    {
        get
        {
            return this.size;
        }
        private set
        {
            this.size = value;
        }
    }

    public override void Draw()
    {
        Console.WriteLine($"|{new string('-', this.Size)}|");

        for (int i = 0; i < this.Size - 2; i++)
        {
            Console.WriteLine($"|{new string(' ', this.Size)}|");
        }

        Console.WriteLine($"|{new string('-', this.Size)}|");
    }
}