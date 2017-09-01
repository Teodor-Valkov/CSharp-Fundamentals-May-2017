using System;

namespace RecyclingStation.WasteDisposal.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class RecyclableGarbageStrategyAttribute : DisposableAttribute
    {
    }
}