using System;

public class StartUp
{
    public static void Main()
    {
        string input = string.Empty;
        while ((input = Console.ReadLine()) != "END")
        {
            string[] inputArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string action = inputArgs[0];

            switch (action)
            {
                case "Pizza":
                    CalculatePizzaCalories(inputArgs);
                    break;

                case "Dough":
                    CalculateDoughCalories(inputArgs);
                    break;

                case "Topping":
                    CalculateToppingCalories(inputArgs);
                    break;
            }
        }
    }

    private static void CalculatePizzaCalories(string[] inputArgs)
    {
        string name = inputArgs[1];
        int numberOfToppings = int.Parse(inputArgs[2]);

        Pizza pizza = null;

        try
        {
            pizza = new Pizza(name, numberOfToppings);
        }
        catch (ArgumentException exception)
        {
            Console.WriteLine(exception.Message);
            Environment.Exit(0);
        }

        string[] doughArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        string flourType = doughArgs[1];
        string bakingTechnique = doughArgs[2];
        int doughWeight = int.Parse(doughArgs[3]);

        try
        {
            Dough dough = new Dough(flourType, bakingTechnique, doughWeight);
            pizza.Dough = dough;
        }
        catch (ArgumentException exception)
        {
            Console.WriteLine(exception.Message);
            Environment.Exit(0);
        }

        for (int i = 0; i < numberOfToppings; i++)
        {
            string[] toppingArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string toppingType = toppingArgs[1];
            int toppingWeight = int.Parse(toppingArgs[2]);

            try
            {
                Topping topping = new Topping(toppingType, toppingWeight);
                pizza.AddTopping(topping);
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
                Environment.Exit(0);
            }
        }

        Console.WriteLine($"{pizza.Name} - {pizza.CalculateCalories():F2} Calories.");
    }

    private static void CalculateDoughCalories(string[] inputArgs)
    {
        string flourType = inputArgs[1];
        string bakingTechnique = inputArgs[2];
        int doughWeight = int.Parse(inputArgs[3]);

        try
        {
            Dough dough = new Dough(flourType, bakingTechnique, doughWeight);
            Console.WriteLine($"{dough.CalculateCalories():F2}");
        }
        catch (ArgumentException exception)
        {
            Console.WriteLine(exception.Message);
            Environment.Exit(0);
        }
    }

    private static void CalculateToppingCalories(string[] inputArgs)
    {
        string toppingType = inputArgs[1];
        int toppingWeight = int.Parse(inputArgs[2]);

        try
        {
            Topping topping = new Topping(toppingType, toppingWeight);
            Console.WriteLine($"{topping.CalculateCalories():F2}");
        }
        catch (ArgumentException exception)
        {
            Console.WriteLine(exception.Message);
            Environment.Exit(0);
        }
    }
}