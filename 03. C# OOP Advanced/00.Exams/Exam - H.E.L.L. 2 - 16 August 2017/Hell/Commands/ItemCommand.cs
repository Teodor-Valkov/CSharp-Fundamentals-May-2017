using System.Collections.Generic;

public class ItemCommand : Command
{
    [Inject]
    private IFactory factory;

    [Inject]
    private IRepository repository;

    public ItemCommand(IList<string> tokens)
        : base(tokens)
    {
    }

    public override string Execute()
    {
        string itemName = this.Tokens[0];
        string heroName = this.Tokens[1];
        this.Tokens.RemoveAt(1);

        IItem item = this.factory.CreateObject<IItem>("CommonItem", this.Tokens);
        this.repository.AddItem(heroName, item);

        return string.Format(Constants.ItemCreateMessage, itemName, heroName);
    }
}