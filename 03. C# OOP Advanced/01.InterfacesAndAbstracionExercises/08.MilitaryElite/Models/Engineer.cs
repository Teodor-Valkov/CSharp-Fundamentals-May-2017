namespace _08.MilitaryElite.Models
{
    using Contracts;
    using System.Collections.Generic;
    using System.Text;

    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(string id, string firstName, string lastName, double salary, string corps, IList<IPart> parts)
            : base(id, firstName, lastName, salary, corps)
        {
            this.Parts = parts;
        }

        public IList<IPart> Parts { get; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine("Repairs:");
            foreach (IPart part in this.Parts)
            {
                sb.AppendLine($"  {part}");
            }

            return sb.ToString().Trim();
        }
    }
}