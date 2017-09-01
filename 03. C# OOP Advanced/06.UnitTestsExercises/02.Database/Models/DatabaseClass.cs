using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class DatabaseClass : IEnumerable<Person>
{
    private IList<Person> people;

    public DatabaseClass()
    {
        this.people = new List<Person>();
    }

    public void Add(Person person)
    {
        if (this.people.Any(p => p.Id == person.Id || p.Username == person.Username))
        {
            throw new InvalidOperationException("This person is already added!");
        }

        this.people.Add(person);
    }

    public void Remove(string username)
    {
        Person person = this.FindByUsername(username);
        this.people.Remove(person);
    }

    public void Remove(long id)
    {
        Person person = this.FindById(id);
        this.people.Remove(person);
    }

    public Person FindByUsername(string username)
    {
        if (string.IsNullOrEmpty(username))
        {
            throw new ArgumentNullException("Username is null!");
        }

        Person person = this.people.FirstOrDefault(p => p.Username == username);

        if (person == null)
        {
            throw new InvalidOperationException("There is no person with this username!");
        }

        return person;
    }

    public Person FindById(long id)
    {
        Person person = this.people.FirstOrDefault(p => p.Id == id);

        if (id < 0)
        {
            throw new ArgumentOutOfRangeException("Id is negative!");
        }

        if (person == null)
        {
            throw new InvalidOperationException("There is no person with this id!");
        }

        return person;
    }

    public int GetPeopleCount()
    {
        return this.people.Count;
    }

    IEnumerator<Person> IEnumerable<Person>.GetEnumerator()
    {
        for (int i = 0; i < this.people.Count; i++)
        {
            yield return this.people[i];
        }
    }

    public IEnumerator GetEnumerator()
    {
        return this.GetEnumerator();
    }
}