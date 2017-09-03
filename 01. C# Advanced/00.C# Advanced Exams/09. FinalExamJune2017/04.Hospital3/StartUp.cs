namespace _04.Hospital3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Patient
    {
        public string Name { get; set; }
        public string Doctor { get; set; }
        public string Department { get; set; }
        public int Room { get; set; }
    }

    public class StartUp
    {
        public static void Main()
        {
            Dictionary<string, Dictionary<int, int>> departments = new Dictionary<string, Dictionary<int, int>>();
            List<Patient> patients = new List<Patient>();

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
                    departments[department] = new Dictionary<int, int>();

                    // Add all 20 rooms of the department
                    for (int i = 1; i <= 20; i++)
                    {
                        departments[department][i] = 0;
                    }
                }

                // Add the patient in the first free room or ignore him
                foreach (KeyValuePair<int, int> room in departments[department])
                {
                    if (room.Value < 3)
                    {
                        departments[department][room.Key]++;

                        Patient currentPatient = new Patient
                        {
                            Name = patient,
                            Doctor = doctor,
                            Department = department,
                            Room = room.Key
                        };

                        patients.Add(currentPatient);

                        break;
                    }
                }
            }

            string result = string.Empty;
            while ((result = Console.ReadLine()) != "End")
            {
                string[] resultArgs = result.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (resultArgs.Length == 1)
                {
                    // Print department, rooms and patients
                    string department = resultArgs[0];

                    if (departments.ContainsKey(department))
                    {
                        List<Patient> patientsToPrint = patients
                            .Where(patient => patient.Department == department)
                            .ToList();

                        foreach (Patient patient in patientsToPrint)
                        {
                            Console.WriteLine(patient.Name);
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

                        List<Patient> patientsToPrint = patients
                            .Where(patient => patient.Room == room && patient.Department == department)
                            .OrderBy(patient => patient.Name)
                            .ToList();

                        foreach (Patient patient in patientsToPrint)
                        {
                            Console.WriteLine(patient.Name);
                        }
                    }
                    else
                    {
                        // Print doctor and patients
                        string doctor = resultArgs[0] + " " + resultArgs[1];

                        List<Patient> patientsToPrint = patients
                            .Where(patient => patient.Doctor == doctor)
                            .OrderBy(patient => patient.Name)
                            .ToList();

                        foreach (Patient patient in patientsToPrint)
                        {
                            Console.WriteLine(patient.Name);
                        }
                    }
                }
            }
        }
    }
}