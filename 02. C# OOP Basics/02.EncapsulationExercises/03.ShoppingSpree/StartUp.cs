using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        string[] peopleArgs = Console.ReadLine().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        List<Person> people = new List<Person>();
        FillPeopleList(peopleArgs, people);

        string[] productsArgs = Console.ReadLine().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        List<Product> products = new List<Product>();
        FillProductsList(productsArgs, products);

        string input = string.Empty;
        while ((input = Console.ReadLine()) != "END")
        {
            string[] inputArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string personName = inputArgs[0];
            string productName = inputArgs[1];

            Person person = people.First(p => p.Name == personName);
            Product product = products.First(p => p.Name == productName);

            // Person tries to buy the product
            try
            {
                person.AddProductToBag(product);
                Console.WriteLine($"{person.Name} bought {product.Name}");
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        foreach (Person person in people)
        {
            Console.WriteLine(person.BagOfProducts.Any()
                ? $"{person.Name} - {string.Join(", ", person.BagOfProducts.Select(product => product.Name))}"
                : $"{person.Name} - Nothing bought");
        }
    }

    private static void FillPeopleList(string[] peopleArgs, List<Person> people)
    {
        foreach (string personArgs in peopleArgs)
        {
            string[] args = personArgs.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
            string name = args[0];
            decimal money = decimal.Parse(args[1]);

            // Try to add person if property validations are correct
            try
            {
                Person person = new Person(name, money);
                people.Add(person);
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
                Environment.Exit(0);
            }
        }
    }

    private static void FillProductsList(string[] productsArgs, List<Product> products)
    {
        foreach (string productArgs in productsArgs)
        {
            string[] args = productArgs.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
            string name = args[0];
            decimal cost = decimal.Parse(args[1]);

            // Try to add product if property validations are correct
            try
            {
                Product product = new Product(name, cost);
                products.Add(product);
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
                Environment.Exit(0);
            }
        }
    }
}