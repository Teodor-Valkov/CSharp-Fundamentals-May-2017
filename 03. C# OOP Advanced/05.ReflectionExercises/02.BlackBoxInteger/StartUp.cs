using System;
using System.Reflection;

public class StartUp
{
    public static void Main()
    {
        Type blackBoxIntType = typeof(BlackBoxInt);
        //Type blackBoxIntType = Type.GetType("BlackBoxInt");

        ConstructorInfo classConstructor = blackBoxIntType.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, Type.DefaultBinder, Type.EmptyTypes, null);

        //BlackBoxInt blackBoxIntInstance = (BlackBoxInt)classConstructor.Invoke(new object[] { });
        //BlackBoxInt blackBoxIntInstance = (BlackBoxInt)classConstructor.Invoke(new Type[] { });
        //BlackBoxInt blackBoxIntInstance = (BlackBoxInt)classConstructor.Invoke(null);
        BlackBoxInt blackBoxIntInstance = (BlackBoxInt)Activator.CreateInstance(blackBoxIntType, true);

        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            string[] inputArgs = input.Split(new[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
            string action = inputArgs[0];
            int number = int.Parse(inputArgs[1]);

            MethodInfo method = blackBoxIntType.GetMethod(action, BindingFlags.Instance | BindingFlags.NonPublic);
            method.Invoke(blackBoxIntInstance, new object[] { number });

            FieldInfo field = blackBoxIntType.GetField("innerValue", BindingFlags.Instance | BindingFlags.NonPublic);
            //object field = blackBoxIntType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).First().GetValue(blackBoxIntInstance);

            Console.WriteLine(field.GetValue(blackBoxIntInstance));
        }
    }
}