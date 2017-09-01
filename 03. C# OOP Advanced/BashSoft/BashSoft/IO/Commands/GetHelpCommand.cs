namespace BashSoft.IO.Commands
{
    using BashSoft.Attibutes;
    using BashSoft.Contracts;
    using Exceptions;
    using System.Text;

    [Alias("help")]
    public class GetHelpCommand : Command, IExecutable
    {
        public GetHelpCommand(string input, string[] data)
            : base(input, data)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 1)
            {
                throw new InvalidCommandException(this.Input);
            }

            this.DisplayHelp();
        }

        private void DisplayHelp()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{new string('_', 100)}");
            sb.AppendLine($"|{"1. open file - open 'path' ",-98}|");
            sb.AppendLine($"|{"2. make directory - mkdir 'path' ",-98}|");
            sb.AppendLine($"|{"3. traverse directory - ls 'depth' ",-98}|");
            sb.AppendLine($"|{"4. comparing files - cmp 'path1 path2'",-98}|");
            sb.AppendLine($"|{"5. change directory - cdRel 'relative path'",-98}|");
            sb.AppendLine($"|{"6. change directory - cdAbs 'absolute path'",-98}|");
            sb.AppendLine($"|{"7. read students database - readDb 'path'",-98}|");
            sb.AppendLine($"|{"8. drop database if it is created - dropDb",-98}|");
            sb.AppendLine($"|{"9. show {courseName} students information - show 'course name'",-98}|");
            sb.AppendLine($"|{"10. filter {courseName} {excelent}/{average}/{poor} take {number}/{all} students - filterExcelent",-98}|");
            sb.AppendLine($"|{"11. order increasing students - order {courseName} {ascending}/{descending} take {number}/{all}",-98}|");
            sb.AppendLine($"|{"12. get help – help",-98}|");
            sb.AppendLine($"|{"13. display data entities - display {students}/{courses} {asceding}/{descending}",-98}|");
            sb.AppendLine($"{new string('_', 100)}");

            OutputWriter.WriteMessage(sb.ToString());
        }
    }
}