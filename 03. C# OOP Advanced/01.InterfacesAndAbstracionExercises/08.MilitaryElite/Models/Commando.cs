namespace _08.MilitaryElite.Models
{
    using Contracts;
    using System.Collections.Generic;
    using System.Text;

    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(string id, string firstName, string lastName, double salary, string corps, IList<IMission> missions)
            : base(id, firstName, lastName, salary, corps)
        {
            this.Missions = missions;
        }

        public IList<IMission> Missions { get; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine("Missions:");
            foreach (IMission mission in this.Missions)
            {
                sb.AppendLine($"  {mission}");
            }

            return sb.ToString().Trim();
        }
    }
}