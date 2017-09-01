namespace BashSoft.Exceptions
{
    using System;

    public class CourseNotFoundException : Exception
    {
        public const string NotEnrolledInCourse = "Course with given name does not exist!";

        public CourseNotFoundException()
            : base(NotEnrolledInCourse)
        {
        }

        public CourseNotFoundException(string message)
            : base(message)
        {
        }
    }
}