using System;
using System.Collections.Generic;

public class Person
{
    private string name;
    private decimal money;
    private List<Product> bagOfProducts;

    public Person(string name, decimal money)
    {
        this.Name = name;
        this.Money = money;
        this.bagOfProducts = new List<Product>();
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        private set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }
            this.name = value;
        }
    }

    public decimal Money
    {
        get
        {
            return this.money;
        }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
            this.money = value;
        }
    }

    public IReadOnlyCollection<Product> BagOfProducts
    {
        get
        {
            return this.bagOfProducts;
        }
    }

    public bool CanPersonBuyProduct(Product product)
    {
        if (this.Money >= product.Cost)
        {
            return true;
        }
        return false;
    }

    public void AddProductToBag(Product product)
    {
        if (this.CanPersonBuyProduct(product))
        {
            this.Money -= product.Cost;
            this.bagOfProducts.Add(product);
        }
        else
        {
            throw new ArgumentException($"{this.Name} can't afford {product.Name}");
        }
    }
}