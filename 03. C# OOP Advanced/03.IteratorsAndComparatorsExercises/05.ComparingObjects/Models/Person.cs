using System;

public class Person : IComparable<Person>
{
    public Person(string name, int age, string address)
    {
        this.Name = name;
        this.Age = age;
        this.Address = address;
    }

    public string Name { get; private set; }

    public int Age { get; private set; }

    public string Address { get; private set; }

    public int CompareTo(Person otherPerson)
    {
        if (this.Name.CompareTo(otherPerson.Name) != 0)
        {
            return this.Name.CompareTo(otherPerson.Name);
        }

        if (this.Age.CompareTo(otherPerson.Age) != 0)
        {
            return this.Age.CompareTo(otherPerson.Age);
        }

        if (this.Address.CompareTo(otherPerson.Address) != 0)
        {
            return this.Address.CompareTo(otherPerson.Address);
        }

        return 0;
    }
}