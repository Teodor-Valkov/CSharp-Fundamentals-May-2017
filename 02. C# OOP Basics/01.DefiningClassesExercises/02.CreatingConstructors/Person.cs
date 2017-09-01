public class Person
{
    public string name;
    public int age;

    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public Person(int age)
        : this("No name", age)
    {
    }

    public Person()
        : this("No name", 1)
    {
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        private set
        {
            this.name = value;
        }
    }

    public int Age
    {
        get
        {
            return this.age;
        }
        private set
        {
            this.age = value;
        }
    }
}