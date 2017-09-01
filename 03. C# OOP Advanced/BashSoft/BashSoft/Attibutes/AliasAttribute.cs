using System;

namespace BashSoft.Attibutes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class AliasAttribute : Attribute
    {
        private string name;

        public AliasAttribute(string aliasName)
        {
            this.name = aliasName;
        }

        public string Name
        {
            get { return this.name; }
        }

        public override bool Equals(object obj)
        {
            string otherAttributeName = obj.ToString();
            return this.name.Equals(otherAttributeName);
        }

        public override int GetHashCode()
        {
            int hash = 13;

            hash = (hash * 7) + this.Name.GetHashCode();

            return hash;
        }
    }
}