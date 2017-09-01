namespace _02.GraphicEditor
{
    using Contracts;

    public class GraphicEditor
    {
        public void Draw(IShape shape)
        {
            shape.Draw(shape);
        }
    }
}