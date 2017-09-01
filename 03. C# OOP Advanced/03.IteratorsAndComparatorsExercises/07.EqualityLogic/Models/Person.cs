using System;

public class Person : IComparable<Person>
{
    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public string Name { get; private set; }

    public int Age { get; private set; }

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

        return 0;
    }

    public override bool Equals(object otherObject)
    {
        Person otherPerson = otherObject as Person;

        if (otherPerson == null)
        {
            return false;
        }

        return this.Name.Equals(otherPerson.Name) && this.Age.Equals(otherPerson.Age);
    }

    public override int GetHashCode()
    {
        int hash = 13;

        hash = (hash * 7) + this.Name.GetHashCode();
        hash = (hash * 7) + this.Age.GetHashCode();

        return hash;
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Age}";
    }
}