namespace _01.RecyclingStation.Attributes
{
    using _01.RecyclingStation.WasteDisposal.Attributes;
    using System;

    public class RecyclableStrategyAttribute : DisposableAttribute
    {
        public RecyclableStrategyAttribute(Type correspondingStrategyType)
            : base(correspondingStrategyType)
        {
        }
    }
}