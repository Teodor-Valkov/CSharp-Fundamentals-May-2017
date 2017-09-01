using System;

public class StartUp
{
    public static void Main()
    {
        PrimitiveCalculator calculator = new PrimitiveCalculator();

        string input = string.Empty;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] inputArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (inputArgs[0] == "mode")
            {
                switch (inputArgs[1])
                {
                    case "+":
                        IStrategy additionStrategy = new AdditionStrategy();
                        calculator.ChangeStrategy(additionStrategy);
                        break;

                    case "-":
                        IStrategy subtractionStrategy = new SubtractionStrategy();
                        calculator.ChangeStrategy(subtractionStrategy);
                        break;

                    case "/":
                        IStrategy divisionStrategy = new DivisionStrategy();
                        calculator.ChangeStrategy(divisionStrategy);
                        break;

                    case "*":
                        IStrategy multiplicationStrategy = new MultiplicationStrategy();
                        calculator.ChangeStrategy(multiplicationStrategy);
                        break;

                    default:
                        throw new InvalidOperationException("Invalid operator!");
                }
            }
            else
            {
                int firstOperand = int.Parse(inputArgs[0]);
                int secondOperand = int.Parse(inputArgs[1]);
                int result = calculator.PerformCalculation(firstOperand, secondOperand);

                Console.WriteLine(result);
            }
        }
    }
}