using System;
using System.Linq;
using System.Reflection;

public class StartUp
{
    public static void Main()
    {
        Type classType = typeof(HarvestingFields);
        FieldInfo[] fields = classType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

        FieldInfo[] filteredFields;
        string input;
        while ((input = Console.ReadLine()) != "HARVEST")
        {
            switch (input)
            {
                case "private":
                    filteredFields = fields.Where(f => f.IsPrivate).ToArray();
                    break;

                case "protected":
                    filteredFields = fields.Where(f => f.IsFamily).ToArray();
                    break;

                case "public":
                    filteredFields = fields.Where(f => f.IsPublic).ToArray();
                    break;

                case "all":
                    filteredFields = fields;
                    break;

                default:
                    throw new InvalidOperationException("Invalid input!");
            }

            string[] result = filteredFields.Select(f => $"{f.Attributes.ToString().ToLower()} {f.FieldType.Name} {f.Name}").ToArray();

            foreach (string line in result)
            {
                Console.WriteLine(line.Replace("family", "protected"));
            }
        }
    }
}