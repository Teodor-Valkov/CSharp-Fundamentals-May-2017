namespace BashSoft.Repository
{
    using BashSoft.Contracts;
    using IO;
    using StaticData;
    using System;
    using System.Collections.Generic;

    public class RepositoryFilter : IDataFilter
    {
        public void FilterAndTake(Dictionary<string, double> studentsWithMarks, string wantedFilter, int studentsToTake)
        {
            if (wantedFilter == "excellent")
            {
                this.FilterAndTake(studentsWithMarks, x => x >= 5.0, studentsToTake);
            }
            else if (wantedFilter == "average")
            {
                this.FilterAndTake(studentsWithMarks, x => x >= 3.5 && x < 5.0, studentsToTake);
            }
            else if (wantedFilter == "poor")
            {
                this.FilterAndTake(studentsWithMarks, x => x < 3.5, studentsToTake);
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidStudentsFilter);
            }
        }

        private void FilterAndTake(Dictionary<string, double> studentsWithMarks, Predicate<double> givenFilter, int studentsToTake)
        {
            int counterForPrintedStudents = 0;

            foreach (KeyValuePair<string, double> studentWithMark in studentsWithMarks)
            {
                if (counterForPrintedStudents == studentsToTake)
                {
                    break;
                }

                if (givenFilter(studentWithMark.Value))
                {
                    OutputWriter.PrintStudent(studentWithMark);
                    counterForPrintedStudents++;
                }
            }
        }
    }
}