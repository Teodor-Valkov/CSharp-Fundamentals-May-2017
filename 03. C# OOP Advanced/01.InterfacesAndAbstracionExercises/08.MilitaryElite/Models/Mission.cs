namespace _08.MilitaryElite.Models
{
    using Contracts;

    public class Mission : IMission
    {
        public Mission(string codeName, string state)
        {
            this.CodeName = codeName;
            this.State = state;
        }

        public string CodeName { get; private set; }

        public string State { get; private set; }

        public void CompleteMission()
        {
            this.State = "Finished";
        }

        public bool ValidateMission()
        {
            if (this.State == "inProgress" || this.State == "Finished")
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State}";
        }
    }
}