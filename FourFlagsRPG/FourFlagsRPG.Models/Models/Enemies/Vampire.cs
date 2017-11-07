namespace FourFlagsRPG.Models.Models.Enemies
{
    using FourFlagsRPG.Models.Contracts.Enemies;

    public class Vampire : Enemy, IEnemy
    {
        public Vampire(int id)
            : base(id)
        {
        }
    }
}