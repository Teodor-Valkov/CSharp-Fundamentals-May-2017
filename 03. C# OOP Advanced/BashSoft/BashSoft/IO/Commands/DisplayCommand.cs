namespace BashSoft.IO.Commands
{
    using BashSoft.Attibutes;
    using BashSoft.Contracts;
    using Exceptions;
    using System;
    using System.Collections.Generic;

    [Alias("display")]
    public class DisplayCommand : Command, IExecutable
    {
        [Inject]
        private IDatabase studentsRepository;

        public DisplayCommand(string input, string[] data)
            : base(input, data)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 3)
            {
                throw new InvalidCommandException(this.Input);
            }

            string entityToDisplay = this.Data[1];
            string sortType = this.Data[2];

            switch (entityToDisplay.ToLower())
            {
                case "students":
                    IComparer<IStudent> studentComparer = this.CreateStudentComparer(sortType);
                    ISimpleOrderedBag<IStudent> sortedStudentsList = this.studentsRepository.GetAllStudentsSorted(studentComparer);
                    OutputWriter.WriteMessageOnNewLine(sortedStudentsList.JoinWith(Environment.NewLine));
                    break;

                case "courses":
                    IComparer<ICourse> courseComparer = this.CreateCourseComparer(sortType);
                    ISimpleOrderedBag<ICourse> sortedCoursesList = this.studentsRepository.GetAllCoursesSorted(courseComparer);
                    OutputWriter.WriteMessageOnNewLine(sortedCoursesList.JoinWith(Environment.NewLine));
                    break;

                default:
                    throw new InvalidCommandException(this.Input);
            }
        }

        private IComparer<IStudent> CreateStudentComparer(string sortType)
        {
            switch (sortType)
            {
                case "ascending":
                    return Comparer<IStudent>.Create((firstStudent, secondStudent) => firstStudent.CompareTo(secondStudent));

                case "descending":
                    return Comparer<IStudent>.Create((firstStudent, secondStudent) => secondStudent.CompareTo(firstStudent));

                default:
                    throw new InvalidCommandException(this.Input);
            }
        }

        private IComparer<ICourse> CreateCourseComparer(string sortType)
        {
            switch (sortType)
            {
                case "ascending":
                    return Comparer<ICourse>.Create((firstCourse, secondCourse) => firstCourse.CompareTo(secondCourse));

                case "descending":
                    return Comparer<ICourse>.Create((firstCourse, secondCourse) => secondCourse.CompareTo(firstCourse));

                default:
                    throw new InvalidCommandException(this.Input);
            }
        }
    }
}