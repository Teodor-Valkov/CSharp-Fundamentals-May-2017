using System.Collections.Generic;

public class PersonAgeComparer : IComparer<Person>
{
    public int Compare(Person firstPerson, Person secondPerson)
    {
        if (firstPerson.Age.CompareTo(secondPerson.Age) != 0)
        {
            return firstPerson.Age.CompareTo(secondPerson.Age);
        }

        return 0;
    }
}