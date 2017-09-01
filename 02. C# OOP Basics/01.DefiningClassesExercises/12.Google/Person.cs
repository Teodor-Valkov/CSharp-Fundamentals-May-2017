using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Person
{
    private string name;
    private Company company;
    private Car car;
    private List<Pokemon> pokemons;
    private List<Parent> parents;
    private List<Child> children;

    public Person(string name)
    {
        this.Name = name;
        this.Pokemons = new List<Pokemon>();
        this.Parents = new List<Parent>();
        this.Children = new List<Child>();
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

    public Company Company
    {
        get
        {
            return this.company;
        }
        set
        {
            this.company = value;
        }
    }

    public Car Car
    {
        get
        {
            return this.car;
        }
        set
        {
            this.car = value;
        }
    }

    public List<Pokemon> Pokemons
    {
        get
        {
            return this.pokemons;
        }
        private set
        {
            this.pokemons = value;
        }
    }

    public List<Parent> Parents
    {
        get
        {
            return this.parents;
        }
        private set
        {
            this.parents = value;
        }
    }

    public List<Child> Children
    {
        get
        {
            return this.children;
        }
        private set
        {
            this.children = value;
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"{this.Name}");
        sb.AppendLine(this.Company == null
            ? "Company:"
            : $"Company:{Environment.NewLine}{this.Company.Name} {this.Company.Department} {this.Company.Salary:F2}");
        sb.AppendLine(this.Car == null
            ? "Car:"
            : $"Car:{Environment.NewLine}{this.Car.Model} {this.Car.Speed}");
        sb.AppendLine(!this.Pokemons.Any()
            ? "Pokemon:"
            : $"Pokemon:{Environment.NewLine}{string.Join(Environment.NewLine, this.Pokemons.Select(pokemon => $"{pokemon.Name} {pokemon.Type}"))}");
        sb.AppendLine(!this.Parents.Any()
            ? "Parents:"
            : $"Parents:{Environment.NewLine}{string.Join(Environment.NewLine, this.Parents.Select(parent => $"{parent.Name} {parent.Birthday:dd/MM/yyyy}"))}");
        sb.Append(!this.Children.Any()
            ? "Children:"
            : $"Children:{Environment.NewLine}{string.Join(Environment.NewLine, this.Children.Select(child => $"{child.Name} {child.Birthday:dd/MM/yyyy}"))}");

        return sb.ToString();
    }
}