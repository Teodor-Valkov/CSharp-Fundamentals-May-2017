namespace BashSoft.IO.Commands
{
    using BashSoft.Attibutes;
    using BashSoft.Contracts;
    using Exceptions;

    [Alias("show")]
    public class ShowCourseCommand : Command, IExecutable
    {
        [Inject]
        private IDatabase studentsRepository;

        public ShowCourseCommand(string input, string[] data)
            : base(input, data)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length == 2)
            {
                string course = this.Data[1];
                this.studentsRepository.GetAllStudentsFromCourse(course);
            }
            else if (this.Data.Length == 3)
            {
                string course = this.Data[1];
                string username = this.Data[2];
                this.studentsRepository.GetStudentScoresFromCourse(course, username);
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }
    }
}