using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var soldiers = new Dictionary<int, Soldier>();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            var split = input.Split();

            Soldier soldier = null;

            int id = int.Parse(split[1]);
            string firstName = split[2];
            string lastName = split[3];

            switch (split[0])
            {
                case "Private":
                    {
                        double salary = double.Parse(split[4]);
                        soldier = new Private(id, firstName, lastName, salary);
                        break;
                    }
                case "LeutenantGeneral":
                    {
                        double salary = double.Parse(split[4]);
                        List<Private> privates = split.Skip(5).Select(pid => (Private)soldiers[int.Parse(pid)]).ToList();
                        soldier = new LeutenantGeneral(id, firstName, lastName, salary, privates);
                        break;
                    }
                case "Engineer":
                    {
                        double salary = double.Parse(split[4]);
                        if (!Enum.TryParse<Corps>(split[5], out Corps corps))
                        {
                            continue;
                        }

                        List<Repair> repairs = new List<Repair>();
                        for (int i = 6; i < split.Length - 1; i += 2)
                        {
                            repairs.Add(new Repair(split[i], int.Parse(split[i + 1])));
                        }
                        soldier = new Engineer(id, firstName, lastName, salary, corps, repairs);
                        break;
                    }
                case "Commando":
                    {
                        double salary = double.Parse(split[4]);
                        Corps corps = Enum.Parse<Corps>(split[5]);
                        List<Mission> missions = new List<Mission>();
                        for (int i = 6; i < split.Length - 1; i += 2)
                        {
                            if (!Enum.TryParse<MissionState>(split[i + 1], out MissionState state))
                            {
                                continue;
                            }

                            missions.Add(new Mission(split[i], state));
                        }
                        soldier = new Commando(id, firstName, lastName, salary, corps, missions);
                        break;
                    }
                case "Spy":
                    {
                        int codeNumber = int.Parse(split[4]);
                        soldier = new Spy(id, firstName, lastName, codeNumber);
                        break;
                    }
            }

            soldiers.Add(id, soldier);
        }

        foreach (var soldier in soldiers.Values)
        {
            Console.WriteLine(soldier);
        }
    }
}
