namespace BashSoft.Exceptions
{
    using System;

    public class InvalidNumberOfScoresException : Exception
    {
        public const string InvalidNumberOfTasksOnExam = "The number of scores for the given course is greater than the possible!";

        public InvalidNumberOfScoresException()
            : base(InvalidNumberOfTasksOnExam)
        {
        }

        public InvalidNumberOfScoresException(string message)
            : base(message)
        {
        }
    }
}