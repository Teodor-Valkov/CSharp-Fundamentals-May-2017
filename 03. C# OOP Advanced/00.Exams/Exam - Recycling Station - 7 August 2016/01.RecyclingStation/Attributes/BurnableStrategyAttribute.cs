namespace _01.RecyclingStation.Attributes
{
    using _01.RecyclingStation.WasteDisposal.Attributes;
    using System;

    public class BurnableStrategyAttribute : DisposableAttribute
    {
        public BurnableStrategyAttribute(Type correspondingStrategyType)
            : base(correspondingStrategyType)
        {
        }
    }
}