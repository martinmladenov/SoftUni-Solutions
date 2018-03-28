namespace PetClinics
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var clinics = new Dictionary<string, Clinic>();
            var pets = new Dictionary<string, Pet>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] split = Console.ReadLine().Split();

                string command = split[0];

                try
                {
                    if (command == "Create")
                    {
                        string typeToCreate = split[1];
                        if (typeToCreate == "Pet")
                        {
                            pets.Add(split[2], new Pet(split[2], int.Parse(split[3]), split[4]));
                        }
                        else if (typeToCreate == "Clinic")
                        {
                            clinics.Add(split[2], new Clinic(int.Parse(split[3])));
                        }
                    }
                    else if (command == "Add")
                    {
                        Console.WriteLine(clinics[split[2]].AddPet(pets[split[1]]));
                    }
                    else if (command == "Release")
                    {
                        Console.WriteLine(clinics[split[1]].ReleasePet());
                    }
                    else if (command == "HasEmptyRooms")
                    {
                        Console.WriteLine(clinics[split[1]].HasEmptyRooms);
                    }
                    else if (command == "Print")
                    {
                        Clinic clinic = clinics[split[1]];
                        if (split.Length == 3)
                        {
                            clinic.Print(int.Parse(split[2]) - 1);
                        }
                        else
                        {
                            clinic.Print();
                        }
                    }
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
