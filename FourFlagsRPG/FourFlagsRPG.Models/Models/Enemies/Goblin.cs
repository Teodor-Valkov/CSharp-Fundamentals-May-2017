namespace FourFlagsRPG.Models.Models.Enemies
{
    using FourFlagsRPG.Models.Contracts.Enemies;

    public class Goblin : Enemy, IEnemy
    {
        public Goblin(int id)
            : base(id)
        {
        }
    }
}