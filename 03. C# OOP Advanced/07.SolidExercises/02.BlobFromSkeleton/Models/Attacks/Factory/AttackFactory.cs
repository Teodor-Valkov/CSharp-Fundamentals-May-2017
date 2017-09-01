namespace _02.BlobFromSkeleton.Models.Attacks.Factory
{
    using Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class AttackFactory
    {
        private const string BehvaiorNameSuffix = "Attack";

        public IAttack CreateAttack(string behaviourTypeAsString)
        {
            string behaviourCompleteName = behaviourTypeAsString + BehvaiorNameSuffix;

            Type behaviourType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .First(t => t.Name == behaviourCompleteName);

            return (IAttack)Activator.CreateInstance(behaviourType);
        }
    }
}