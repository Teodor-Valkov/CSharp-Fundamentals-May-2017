public class Rectangle
{
    private string id;
    private double width;
    private double height;
    private double x;
    private double y;

    public Rectangle(string id, double width, double height, double x, double y)
    {
        this.Id = id;
        this.Width = width;
        this.Height = height;
        this.X = x;
        this.Y = y;
    }

    public string Id
    {
        get
        {
            return this.id;
        }
        private set
        {
            this.id = value;
        }
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

    public double X
    {
        get
        {
            return this.x;
        }
        private set
        {
            this.x = value;
        }
    }

    public double Y
    {
        get
        {
            return this.y;
        }
        private set
        {
            this.y = value;
        }
    }

    // Solution I
    //
    public bool Intersect(Rectangle rectangle)
    {
        if ((rectangle.X <= this.X && rectangle.X + rectangle.width >= this.X &&
             rectangle.Y >= this.Y && rectangle.Y - rectangle.height <= this.Y) ||

            (rectangle.X >= this.X && rectangle.X <= this.X + this.width &&
             rectangle.Y >= this.Y && rectangle.Y - rectangle.height <= this.Y) ||

            (rectangle.X <= this.X && rectangle.X + rectangle.width >= this.X &&
             rectangle.Y <= this.Y && rectangle.Y >= this.Y - this.height) ||

            (rectangle.X >= this.X && rectangle.X <= this.X + this.width &&
             rectangle.Y <= this.Y && rectangle.Y >= this.Y - this.height))
        {
            return true;
        }

        return false;
    }

    // Solution II
    //
    private bool valueInRange(double value, double min, double max)
    {
        return value >= min && value <= max;
    }

    public bool Intersects(Rectangle rectangle)
    {
        bool xOverlap = valueInRange(this.X, rectangle.X, rectangle.X + rectangle.width) ||
                        valueInRange(rectangle.X, this.X, this.X + this.width);

        bool yOverlap = valueInRange(this.Y, rectangle.Y, rectangle.Y + rectangle.height) ||
                        valueInRange(rectangle.Y, this.Y, this.Y + this.height);

        return xOverlap && yOverlap;
    }
}