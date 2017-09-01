using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string investigatedClassName, params string[] requestedFieldsNames)
    {
        Type classType = Type.GetType(investigatedClassName);

        //Hacker classInstance = Activator.CreateInstance<Hacker>();
        //Object classInstance = Activator.CreateInstance(classType);
        Object classInstance = Activator.CreateInstance(classType, new object[] { });

        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Class under investigation: {investigatedClassName}");

        FieldInfo[] fields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

        foreach (FieldInfo field in fields.Where(f => requestedFieldsNames.Contains(f.Name)))
        {
            sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
        }

        return sb.ToString().Trim();
    }
}