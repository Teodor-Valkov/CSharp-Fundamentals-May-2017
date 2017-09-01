namespace _13.OfficeStuff
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    internal class Company
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }

    internal class Product
    {
        public string Name { get; set; }
        public long Quantity { get; set; }
    }

    internal class StartUp
    {
        private static void Main()
        {
            int count = int.Parse(Console.ReadLine());

            List<Company> companies = new List<Company>();

            string pattern = @"(\w+)\s\-\s(\d+)\s\-\s(\w+)";
            Regex regex = new Regex(pattern);

            string input = string.Empty;
            for (int i = 0; i < count; i++)
            {
                input = Console.ReadLine();
                Match match = regex.Match(input);

                if (!match.Success)
                {
                    continue;
                }

                string companyName = match.Groups[1].Value;
                long quantity = long.Parse(match.Groups[2].Value);
                string productName = match.Groups[3].Value;

                Product tempProduct = new Product
                {
                    Name = productName,
                    Quantity = quantity
                };

                Company tempCompany = new Company
                {
                    Name = companyName,
                };

                if (companies.Any(c => c.Name == tempCompany.Name))
                {
                    Company company = companies.First(c => c.Name == tempCompany.Name);
                    int companyIndex = companies.IndexOf(company);

                    if (companies[companyIndex].Products.Any(product => product.Name == tempProduct.Name))
                    {
                        Product product = companies[companyIndex].Products.First(p => p.Name == tempProduct.Name);
                        int productIndex = companies[companyIndex].Products.IndexOf(product);

                        companies[companyIndex].Products[productIndex].Quantity += tempProduct.Quantity;
                    }
                    else
                    {
                        companies[companyIndex].Products.Add(tempProduct);
                    }
                }
                else
                {
                    tempCompany.Products = new List<Product> { tempProduct };

                    companies.Add(tempCompany);
                }
            }

            companies
             .OrderBy(company => company.Name)
             .ToList()
             .ForEach(company =>
               Console.WriteLine($"{company.Name}: {string.Join(", ", company.Products.Select(product => $"{product.Name}-{product.Quantity}"))}"));
        }
    }
}