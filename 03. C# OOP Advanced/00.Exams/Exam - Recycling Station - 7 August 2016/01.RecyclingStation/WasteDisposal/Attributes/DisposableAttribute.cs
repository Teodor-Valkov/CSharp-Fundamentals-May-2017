namespace _01.RecyclingStation.WasteDisposal.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Class)]
    public class DisposableAttribute : Attribute
    {
        public DisposableAttribute(Type correspondingStrategyType)
        {
            this.CorrespondingStrategyType = correspondingStrategyType;
        }

        public Type CorrespondingStrategyType { get; private set; }
    }
}