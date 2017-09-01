namespace Emergency.IO.Commands
{
    using Contracts.Core;
    using Contracts.IO;
    using System.Collections.Generic;

    public abstract class Command : IExecutable
    {
        protected Command(IManagementSystem managementSystem, IList<string> parameters)
        {
            this.ManagementSystem = managementSystem;
            this.Parameters = parameters;
        }

        public IList<string> Parameters { get; }

        public IManagementSystem ManagementSystem { get; }

        public abstract string Execute();
    }
}