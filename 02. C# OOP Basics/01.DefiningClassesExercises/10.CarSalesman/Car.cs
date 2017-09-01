using System.Text;

public class Car
{
    private string model;
    private int weight;
    private string color;
    private Engine engine;

    public Car(string model, Engine engine)
    {
        this.Model = model;
        this.Engine = engine;
        this.Weight = 0;
        this.Color = string.Empty;
    }

    public Car(string model, Engine engine, int weight)
        : this(model, engine)
    {
        this.Weight = weight;
    }

    public Car(string model, Engine engine, string color)
        : this(model, engine)
    {
        this.Color = color;
    }

    public Car(string model, Engine engine, int weight, string color)
        : this(model, engine)
    {
        this.Weight = weight;
        this.Color = color;
    }

    public string Model
    {
        get
        {
            return this.model;
        }
        private set
        {
            this.model = value;
        }
    }

    public int Weight
    {
        get
        {
            return this.weight;
        }
        private set
        {
            this.weight = value;
        }
    }

    public string Color
    {
        get
        {
            return this.color;
        }
        private set
        {
            this.color = value;
        }
    }

    public Engine Engine
    {
        get
        {
            return this.engine;
        }
        private set
        {
            this.engine = value;
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"{this.Model}:");
        sb.AppendLine($"  {this.Engine.Model}:");
        sb.AppendLine($"    Power: {this.Engine.Power}");
        sb.AppendLine(this.Engine.Displacement == 0
            ? "    Displacement: n/a"
            : $"    Displacement: {this.Engine.Displacement}");
        sb.AppendLine(this.Engine.Efficiency == string.Empty
            ? "    Efficiency: n/a"
            : $"    Efficiency: {this.engine.Efficiency}");
        sb.AppendLine(this.Weight == 0
            ? "  Weight: n/a"
            : $"  Weight: {this.Weight}");
        sb.Append(this.Color == string.Empty
            ? "  Color: n/a"
            : $"  Color: {this.Color}");

        return sb.ToString();
    }
}