using System;

namespace SoftUniInjector.Repositories
{
    public class DefaultNeshtoRepo : INeshtoSiInterface
    {
        public void Print()
        {
            Console.WriteLine("Neshto si here!");
        }
    }
}