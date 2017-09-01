namespace _13.OfficeStuff3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Order
    {
        public string CompanyName;
        public string ProductName;
        public int Amount;
    }

    internal class StartUp
    {
        private static void Main()
        {
            int ordersCount = int.Parse(Console.ReadLine());

            List<Order> orders = new List<Order>();

            for (int i = 0; i < ordersCount; i++)
            {
                string[] inputArgs = Console.ReadLine().Trim('|').Split('-').Select(x => x.Trim()).ToArray();

                Order order = new Order
                {
                    CompanyName = inputArgs[0],
                    ProductName = inputArgs[2],
                    Amount = int.Parse(inputArgs[1])
                };

                orders.Add(order);
            }

            // Solution I - one LINQ with two group-by expressions
            //
            orders
             .GroupBy(or => or.CompanyName)
             .OrderBy(gr => gr.Key)
             .Select(gr => gr.GroupBy(pr => pr.ProductName)
                 .Select(prg => new
                 {
                     CompanyName = gr.Key,
                     ProdName = prg.Key,
                     Amount = prg.Sum(x => x.Amount)
                 })
             )
             .ToList()
             .ForEach(line =>
                Console.WriteLine($"{line.Select(x => x.CompanyName).First()}: {string.Join(", ", line.Select(x => $"{x.ProdName}-{x.Amount}"))}"));

            // Solution II - foreach loop on the first LINQ group-by expression and implementing second group-by expression in the loop
            //
            //foreach (var company in groupedOrders)
            //{
            //    Console.Write($"{company.Key}: ");
            //
            //    var products = company
            //         .GroupBy(pr => pr.ProductName)
            //         .Select(gr => new
            //         {
            //             ProductName = gr.Key,
            //             Amount = gr.Sum(x => x.Amount)
            //         });
            //
            //    Console.WriteLine(string.Join(", ", products.Select(x => $"{x.ProductName}-{x.Amount}")));
            //}
        }
    }
}