using System;

public class Rectangle : IDrawable
{
    public Rectangle(int width, int height)
    {
        this.Width = width;
        this.Height = height;
    }

    public int Width { get; private set; }
    public int Height { get; private set; }

    public void Draw()
    {
        for (int i = 0; i < this.Width; i++)
        {
            if (i == 0 || i == this.Width - 1)
            {
                Console.WriteLine(new string('*', this.Height));
            }
            else
            {
                Console.WriteLine($"*{new string(' ', this.Height - 2)}*");
            }
        }
    }
}