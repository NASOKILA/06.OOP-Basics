using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class Program
    {
        public static void Main()
        {
            Dictionary<string, List<string>> doktors = new Dictionary<string, List<string>>();
            Dictionary<string, List<List<string>>> departments = new Dictionary<string, List<List<string>>>();

            string command = Console.ReadLine();

            FillDoctorsAndDepartments(doktors, departments, command);

            command = Console.ReadLine();

            PrintPatients(doktors, departments, command);
        }

        private static void PrintPatients(Dictionary<string, List<string>> doktors, Dictionary<string, List<List<string>>> departments, string command)
        {
            while (command != "End")
            {
                string[] args = command.Split();

                CheckCommandAndPrint(doktors, departments, args);

                command = Console.ReadLine();
            }

        }

        private static void CheckCommandAndPrint(Dictionary<string, List<string>> doktors, Dictionary<string, List<List<string>>> departments, string[] args)
        {
            if (args.Length == 1)
            {
                Console.WriteLine(string.Join("\n", departments[args[0]].Where(x => x.Count > 0).SelectMany(x => x)));
            }
            else if (args.Length == 2 && int.TryParse(args[1], out int staq))
            {
                Console.WriteLine(string.Join("\n", departments[args[0]][staq - 1].OrderBy(x => x)));
            }
            else
            {
                Console.WriteLine(string.Join("\n", doktors[args[0] + ' ' + args[1]].OrderBy(x => x)));
            }
        }

        private static void FillDoctorsAndDepartments(Dictionary<string, List<string>> doktors, Dictionary<string, List<List<string>>> departments, string command)
        {
            while (command != "Output")
            {
                string departament, firstName, lastName, pacient, fullName;

                ParseCommand(command, out departament, out firstName, out lastName, out pacient, out fullName);
                CreateDoctor(doktors, firstName, lastName, fullName);
                CreateDepartment(departments, departament);
                CheckRoomSpace(doktors, departments, departament, pacient, fullName);

                command = Console.ReadLine();
            }

        }

        private static void ParseCommand(string command, out string departament, out string firstName, out string lastName, out string pacient, out string fullName)
        {
            string[] tokens = command.Split();
            departament = tokens[0];
            firstName = tokens[1];
            lastName = tokens[2];
            pacient = tokens[3];
            fullName = firstName + ' ' + lastName;
        }

        private static void CheckRoomSpace(Dictionary<string, List<string>> doktors, Dictionary<string, List<List<string>>> departments, string departament, string pacient, string fullName)
        {
            bool IsFree = departments[departament].SelectMany(x => x).Count() < 60;

            if (IsFree)
            {
                SignUpPatientWithADoctor(doktors, pacient, fullName);

                AccomodatePatient(departments, departament, pacient);
            }
        }

        private static void SignUpPatientWithADoctor(Dictionary<string, List<string>> doktors, string pacient, string fullName)
        {
            doktors[fullName].Add(pacient);
        }

        private static void AccomodatePatient(Dictionary<string, List<List<string>>> departments, string departament, string pacient)
        {
            int room = 0;
            for (int index = 0; index < departments[departament].Count; index++)
            {
                if (departments[departament][index].Count < 3)
                {
                    room = index;
                    break;
                }
            }
            departments[departament][room].Add(pacient);
        }

        private static void CreateDepartment(Dictionary<string, List<List<string>>> departments, string departament)
        {
            if (!departments.ContainsKey(departament))
            {
                departments[departament] = new List<List<string>>();
                for (int rooms = 0; rooms < 20; rooms++)
                {
                    departments[departament].Add(new List<string>());
                }
            }
        }

        private static void CreateDoctor(Dictionary<string, List<string>> doktors, string firstName, string lastName, string fullName)
        {
            if (!doktors.ContainsKey(firstName + ' ' + lastName))
            {
                doktors[fullName] = new List<string>();
            }
        }
    }
}
