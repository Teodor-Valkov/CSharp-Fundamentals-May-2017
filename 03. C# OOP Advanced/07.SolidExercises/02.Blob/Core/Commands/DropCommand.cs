namespace _02.Blob.Core.Commands
{
    using Contracts;
    using System;

    public class DropCommand : Command, IExecutable
    {
        public DropCommand(string[] data)
            : base(data)
        {
        }

        public override void Execute()
        {
            Environment.Exit(0);
        }
    }
}