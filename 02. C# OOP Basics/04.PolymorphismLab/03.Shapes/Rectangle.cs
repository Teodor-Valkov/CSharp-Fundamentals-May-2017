public class Rectangle : Shape
{
    private double width;
    private double height;

    public Rectangle(double width, double height)
    {
        this.Width = width;
        this.Height = height;
    }

    public double Width
    {
        get
        {
            return this.width;
        }
        private set
        {
            this.width = value;
        }
    }

    public double Height
    {
        get
        {
            return this.height;
        }
        private set
        {
            this.height = value;
        }
    }

    public override double CalculatePerimeter()
    {
        return 2 * this.Width + 2 * this.Height;
    }

    public override double CalculateArea()
    {
        return this.Width * this.Height;
    }

    public override string Draw()
    {
        return base.Draw() + "Rectangle";
    }
}