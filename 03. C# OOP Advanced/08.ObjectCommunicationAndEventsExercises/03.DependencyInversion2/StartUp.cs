using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main(string[] args)
    {
        Dictionary<char, IStrategy> strategies = new Dictionary<char, IStrategy>()
        {
            { '+', new AdditionStrategy()},
            { '-', new SubtractionStrategy()},
            { '*', new MultiplicationStrategy()},
            { '/', new DivisionStrategy()},
            };

        PrimitiveCalculator calculator = new PrimitiveCalculator(strategies['+'], strategies);

        string input = string.Empty;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] inputArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string command = inputArgs[0];

            if (command == "mode")
            {
                calculator.ChangeStrategy(char.Parse(inputArgs[1]));
            }
            else
            {
                Console.WriteLine(calculator.PerformCalculation(int.Parse(inputArgs[0]), int.Parse(inputArgs[1])));
            }
        }
    }
}