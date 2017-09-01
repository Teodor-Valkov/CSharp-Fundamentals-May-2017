﻿namespace _01.SystemSplit.Core.Commands
{
    using Data;
    using Factories;

    public class Analyze : Command
    {
        public Analyze(string[] input, Repository repository, HardwareFactory hardwareFactory, SoftwareFactory softwareFactory)
            : base(input, repository, hardwareFactory, softwareFactory)
        {
        }

        public override void Execute()
        {
            this.Repository.PrintAnalyze();
        }
    }
}