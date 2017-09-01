namespace _01.RecyclingStation.Attributes
{
    using _01.RecyclingStation.WasteDisposal.Attributes;
    using System;

    public class StorableStrategyAttribute : DisposableAttribute
    {
        public StorableStrategyAttribute(Type correspondingStrategyType)
            : base(correspondingStrategyType)
        {
        }
    }
}