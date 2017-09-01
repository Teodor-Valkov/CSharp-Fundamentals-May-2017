namespace _03.Ferrari
{
    using Contracts;
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string driver = Console.ReadLine();
            ICar ferrari = new Models.Ferrari(driver);

            bool isCreated = typeof(ICar).IsInterface;
            if (!isCreated)
            {
                throw new Exception("No interface ICar was created!");
            }

            Console.WriteLine(ferrari);
        }
    }
}