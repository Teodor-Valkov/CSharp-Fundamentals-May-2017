﻿namespace _02.GraphicEditor
{
    using Contracts;
    using System;

    public class Circle : IShape
    {
        public void Draw(IShape shape)
        {
            Console.WriteLine($"I'm a {shape.GetType().Name}");
        }
    }
}