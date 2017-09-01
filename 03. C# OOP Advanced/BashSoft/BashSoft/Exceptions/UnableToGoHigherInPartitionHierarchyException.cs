namespace BashSoft.Exceptions
{
    using System;

    public class UnableToGoHigherInPartitionHierarchyException : Exception
    {
        public const string UnableToGoHigherInHierarchy = "You are trying to access inexisting directory!";

        public UnableToGoHigherInPartitionHierarchyException()
            : base(UnableToGoHigherInHierarchy)
        {
        }

        public UnableToGoHigherInPartitionHierarchyException(string message)
            : base(message)
        {
        }
    }
}