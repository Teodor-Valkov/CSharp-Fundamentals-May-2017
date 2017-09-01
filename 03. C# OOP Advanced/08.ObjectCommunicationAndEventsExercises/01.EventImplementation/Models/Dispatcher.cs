public delegate void NameChangeEventHandler(object sender, NameChangeEventArgs args);

public class Dispatcher
{
    public string Name
    {
        get { return this.Name; }
        set
        {
            this.OnNameChange(new NameChangeEventArgs(value));
        }
    }

    public event NameChangeEventHandler NameChange;

    public void OnNameChange(NameChangeEventArgs eventArgs)
    {
        if (NameChange != null)
        {
            this.NameChange(this, eventArgs);
        }
    }
}