using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        string[] lights = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        List<TrafficLight> trafficLights = new List<TrafficLight>();

        int commands = int.Parse(Console.ReadLine());

        for (int i = 0; i < lights.Length; i++)
        {
            Light light = (Light)Enum.Parse(typeof(Light), lights[i]);
            TrafficLight trafficLight = new TrafficLight(light);

            trafficLights.Add(trafficLight);
        }

        for (int i = 0; i < commands; i++)
        {
            foreach (TrafficLight trafficLight in trafficLights)
            {
                trafficLight.ChangeState();
            }

            Console.WriteLine(string.Join(" ", trafficLights));
        }
    }
}