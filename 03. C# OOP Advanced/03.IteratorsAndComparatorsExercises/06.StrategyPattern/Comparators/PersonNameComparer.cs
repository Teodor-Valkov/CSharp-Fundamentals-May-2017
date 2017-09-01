using System;
using System.Collections.Generic;

public class PersonNameComparer : IComparer<Person>
{
    public int Compare(Person firstPerson, Person secondPerson)
    {
        if (firstPerson.Name.Length.CompareTo(secondPerson.Name.Length) != 0)
        {
            return firstPerson.Name.Length.CompareTo(secondPerson.Name.Length);
        }

        //return firstPerson.Name.CompareTo(secondPerson.Name);
        return string.Compare(firstPerson.Name, secondPerson.Name, StringComparison.OrdinalIgnoreCase);
    }
}