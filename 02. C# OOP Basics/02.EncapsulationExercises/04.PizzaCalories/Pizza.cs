using System;
using System.Collections.Generic;
using System.Linq;

public class Pizza
{
    private string name;
    private Dough dough;
    private int numberOfToppings;
    private List<Topping> toppings;

    public Pizza(string name, int numberOfToppings)
    {
        this.Name = name;
        this.NumberOfToppings = numberOfToppings;
        this.toppings = new List<Topping>();
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            if (string.IsNullOrEmpty(value) || value.Length < 1 || value.Length > 15)
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }
            this.name = value;
        }
    }

    public Dough Dough
    {
        get
        {
            return this.dough;
        }
        set
        {
            this.dough = value;
        }
    }

    public int NumberOfToppings
    {
        get
        {
            return this.numberOfToppings;
        }
        set
        {
            if (value < 1 || value > 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            this.numberOfToppings = value;
        }
    }

    public void AddTopping(Topping topping)
    {
        if (this.toppings.Count == 10)
        {
            throw new ArgumentException("Number of toppings should be in range [0..10].");
        }
        this.toppings.Add(topping);
    }

    public double CalculateCalories()
    {
        return this.Dough.CalculateCalories() + this.toppings.Sum(topping => topping.CalculateCalories());
    }
}