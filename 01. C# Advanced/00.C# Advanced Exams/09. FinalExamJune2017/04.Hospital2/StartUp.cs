namespace _04.Hospital2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Patient
    {
        public string Name { get; set; }
        public string Doctor { get; set; }
        public string Department { get; set; }
    }

    internal class StartUp
    {
        private static void Main()
        {
            List<Patient> patients = new List<Patient>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Output")
            {
                string[] inputArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string department = inputArgs[0];
                string doctor = inputArgs[1] + inputArgs[2];
                string patient = inputArgs[3];

                // Add the patient to patients
                Patient currentPatient = new Patient
                {
                    Department = department,
                    Doctor = doctor,
                    Name = patient
                };

                patients.Add(currentPatient);
            }

            string result = string.Empty;
            while ((result = Console.ReadLine()) != "End")
            {
                string[] resultArgs = result.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                // Print department, rooms and patients
                if (resultArgs.Length == 1)
                {
                    string department = resultArgs[0];

                    foreach (Patient patient in patients.Where(patient => patient.Department == department))
                    {
                        Console.WriteLine(patient.Name);
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

                        foreach (Patient patient in patients.Where(patient => patient.Department == department)
                            .Skip((room - 1) * 3).Take(3).ToList().OrderBy(patient => patient.Name))
                        {
                            Console.WriteLine(patient.Name);
                        }
                    }
                    else
                    {
                        // Print doctor and patients
                        string doctor = resultArgs[0] + " " + resultArgs[1];

                        foreach (Patient patient in patients.Where(patient => patient.Doctor == doctor)
                            .OrderBy(patient => patient.Name))
                        {
                            Console.WriteLine(patient.Name);
                        }
                    }
                }
            }
        }
    }
}