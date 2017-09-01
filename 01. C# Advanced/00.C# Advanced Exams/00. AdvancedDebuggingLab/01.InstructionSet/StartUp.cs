namespace _01.InstructionSet
{
    using System;

    internal class StartUp
    {
        private static void Main()
        {
            string[] numbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            long firstNum = 0;
            long secondNum = 0;

            while (numbers[0] != "END")
            {
                switch (numbers[0])
                {
                    case "INC":
                        firstNum = Convert.ToInt64(numbers[1]);
                        Console.WriteLine(++firstNum);
                        break;

                    case "DEC":
                        firstNum = Convert.ToInt64(numbers[1]);
                        Console.WriteLine(--firstNum);
                        break;

                    case "ADD":
                        firstNum = Convert.ToInt64(numbers[1]);
                        secondNum = Convert.ToInt64(numbers[2]);
                        Console.WriteLine(firstNum + secondNum);
                        break;

                    case "MLA":
                        firstNum = Convert.ToInt64(numbers[1]);
                        secondNum = Convert.ToInt64(numbers[2]);
                        Console.WriteLine(firstNum * secondNum);
                        break;
                }

                numbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}