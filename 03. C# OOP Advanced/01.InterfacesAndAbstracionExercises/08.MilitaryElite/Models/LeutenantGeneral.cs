namespace _08.MilitaryElite.Models
{
    using Contracts;
    using System.Collections.Generic;
    using System.Text;

    public class LeutenantGeneral : Private, ILeutenantGeneral
    {
        public LeutenantGeneral(string id, string firstName, string lastName, double salary, IList<ISoldier> privates)
            : base(id, firstName, lastName, salary)
        {
            this.Privates = privates;
        }

        public IList<ISoldier> Privates { get; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine("Privates:");
            foreach (IPrivate privateSoldier in this.Privates)
            {
                sb.AppendLine($"  {privateSoldier}");
            }

            return sb.ToString().Trim();
        }
    }
}