namespace _02.BlobFromSkeleton.Models.Behaviours.Factory
{
    using Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class BehaviourFactory
    {
        private const string BehvaiourNameSuffix = "Behaviour";

        public IBehaviour CreateBehaviour(string behaviourTypeAsString)
        {
            string behaviourCompleteName = behaviourTypeAsString + BehvaiourNameSuffix;

            Type behaviourType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .First(t => t.Name == behaviourCompleteName);

            return (IBehaviour)Activator.CreateInstance(behaviourType);
        }
    }
}