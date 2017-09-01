namespace BashSoft.Repository
{
    using BashSoft.Contracts;
    using IO;
    using StaticData;
    using System.Collections.Generic;
    using System.Linq;

    public class RepositorySorter : IDataSorter
    {
        public void OrderAndTake(Dictionary<string, double> studentsWithMarks, string comparison, int studentsToTake)
        {
            if (comparison.ToLower() == "ascending")
            {
                this.PrintStudents(studentsWithMarks
                    .OrderBy(pair => pair.Value)
                    .Take(studentsToTake)
                    .ToDictionary(pair => pair.Key, pair => pair.Value));
            }
            else if (comparison.ToLower() == "descending")
            {
                this.PrintStudents(studentsWithMarks
                    .OrderByDescending(pair => pair.Value)
                    .Take(studentsToTake)
                    .ToDictionary(pair => pair.Key, pair => pair.Value));
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidComparisonQuery);
            }
        }

        private void PrintStudents(Dictionary<string, double> studentsWithMarks)
        {
            foreach (KeyValuePair<string, double> student in studentsWithMarks)
            {
                OutputWriter.PrintStudent(student);
            }
        }
    }
}