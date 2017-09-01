using System.Collections.Generic;

public class PetFactory
{
    public static Pet CreatePet(List<string> inputArgs)
    {
        string name = inputArgs[0];
        int age = int.Parse(inputArgs[1]);
        string kind = inputArgs[2];

        return new Pet(name, age, kind);
    }
}