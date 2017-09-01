namespace RecyclingStation
{
    using RecyclingStation.Models.Station;
    using System;
    using System.Linq;

    public class RecyclingStationMain
    {
        public static void Main(string[] args)
        {
            RecyclingStationSystem station = new RecyclingStationSystem();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "TimeToRecycle")
            {
                string[] info = input.Split(new char[] { '|', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string command = info[0];

                info = info.Skip(1).ToArray();

                switch (command)
                {
                    case "ProcessGarbage":
                        Console.WriteLine(station.ProcessGarbage(info));
                        break;

                    case "Status":
                        Console.WriteLine(station.Status());
                        break;

                    case "ChangeManagementRequirement":
                        Console.WriteLine(station.ChangeManagmentRequirement(info));
                        break;
                }
            }
        }
    }
}