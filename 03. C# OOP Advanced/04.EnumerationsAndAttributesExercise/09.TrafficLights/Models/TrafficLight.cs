public class TrafficLight
{
    private Light state;

    public TrafficLight(Light light)
    {
        this.state = light;
    }

    public void ChangeState()
    {
        switch (this.state)
        {
            case Light.Red:
                this.state = Light.Green;
                break;

            case Light.Green:
                this.state = Light.Yellow;
                break;

            case Light.Yellow:
                this.state = Light.Red;
                break;
        }

        //this.state = (Light)(((int)this.state + 1) % Enum.GetNames(typeof(Light)).Length);
    }

    public override string ToString()
    {
        return this.state.ToString();
    }
}