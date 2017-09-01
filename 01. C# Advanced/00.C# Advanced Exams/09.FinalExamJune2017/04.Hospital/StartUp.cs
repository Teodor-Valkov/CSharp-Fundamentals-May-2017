namespace _04.Hospital
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class StartUp
    {
        private static void Main()
        {
            Dictionary<string, Dictionary<int, List<string>>> departments = new Dictionary<string, Dictionary<int, List<string>>>();
            Dictionary<string, List<string>> doctorAndPatients = new Dictionary<string, List<string>>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Output")
            {
                string[] inputArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string department = inputArgs[0];
                string doctor = inputArgs[1] + " " + inputArgs[2];
                string patient = inputArgs[3];

                // Add new department
                if (!departments.ContainsKey(department))
                {
                    departments[department] = new Dictionary<int, List<string>>();
                    departments[department][1] = new List<string>();
                }

                // Find current room in the department
                int indexOfNextRoom = departments[department].Keys.Max();

                // Add new room in the department if current room is full
                if (departments[department][indexOfNextRoom].Count == 3)
                {
                    indexOfNextRoom++;

                    if (indexOfNextRoom == 21)
                    {
                        continue;
                    }

                    departments[department][indexOfNextRoom] = new List<string>();
                }

                //if (indexOfNextRoom > 20)
                //{
                //    continue;
                //}

                // Add the patient in the current room of the department
                departments[department][indexOfNextRoom].Add(patient);

                // Add new doctor
                if (!doctorAndPatients.ContainsKey(doctor))
                {
                    doctorAndPatients[doctor] = new List<string>();
                }

                // Add the patient to the doctor
                doctorAndPatients[doctor].Add(patient);
            }

            string result = string.Empty;
            while ((result = Console.ReadLine()) != "End")
            {
                string[] resultArgs = result.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                // Print department, rooms and patients
                if (resultArgs.Length == 1)
                {
                    string department = resultArgs[0];

                    if (departments.ContainsKey(department))
                    {
                        foreach (KeyValuePair<int, List<string>> pair in departments[department])
                        {
                            foreach (string patients in pair.Value)
                            {
                                Console.WriteLine(patients);
                            }
                        }
                    }
                }
                else if (resultArgs.Length == 2)
                {
                    // Print department, room and patients
                    bool isDigit = resultArgs[1].All(char.IsDigit);

                    if (isDigit)
                    {
                        string department = resultArgs[0];
                        int room = int.Parse(resultArgs[1]);

                        if (departments.ContainsKey(department))
                        {
                            if (departments[department].ContainsKey(room))
                            {
                                foreach (string patient in departments[department][room].OrderBy(p => p))
                                {
                                    Console.WriteLine(patient);
                                }
                            }
                        }
                    }
                    else
                    {
                        // Print doctor and patients
                        string doctor = resultArgs[0] + " " + resultArgs[1];

                        if (doctorAndPatients.ContainsKey(doctor))
                        {
                            foreach (string patient in doctorAndPatients[doctor].OrderBy(p => p))
                            {
                                Console.WriteLine(patient);
                            }
                        }
                    }
                }
            }
        }
    }
}