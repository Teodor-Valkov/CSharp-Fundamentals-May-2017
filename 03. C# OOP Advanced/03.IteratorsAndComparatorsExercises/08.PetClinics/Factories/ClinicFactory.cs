using System.Collections.Generic;

public class ClinicFactory
{
    public static Clinic CreateClinic(List<string> inputArgs)
    {
        string name = inputArgs[0];
        int numberOfRooms = int.Parse(inputArgs[1]);

        return new Clinic(name, numberOfRooms);
    }
}