using System.Collections.Generic;
using System.Linq;
using System.Text;

public class QuitCommand : Command
{
    [Inject]
    private IRepository repository;

    public QuitCommand(List<string> tokens)
        : base(tokens)
    {
    }

    public override string Execute()
    {
        StringBuilder sb = new StringBuilder();
        int counter = 1;

        foreach (IHero hero in this.repository.Heroes.OrderByDescending(h => h))
        {
            sb.AppendLine($"{counter++}. {hero.GetType().Name}: {hero.Name}");
            sb.AppendLine($"###HitPoints: {hero.HitPoints}");
            sb.AppendLine($"###Damage: {hero.Damage}");
            sb.AppendLine($"###Strength: {hero.Strength}");
            sb.AppendLine($"###Agility: {hero.Agility}");
            sb.AppendLine($"###Intelligence: {hero.Intelligence}");
            sb.AppendLine(hero.Items.Count == 0 ?
                $"###Items: None" :
                $"###Items: {string.Join(", ", hero.Items.Select(i => i.Name))}");
        }

        return sb.ToString().Trim();
    }
}