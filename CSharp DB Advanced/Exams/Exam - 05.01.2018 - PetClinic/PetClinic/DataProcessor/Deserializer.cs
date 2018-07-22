namespace PetClinic.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using AutoMapper;
    using Data;
    using Dtos.Import;
    using Models;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        public static string ImportAnimalAids(PetClinicContext context, string jsonString)
        {
            var animalAids = JsonConvert.DeserializeObject<AnimalAid[]>(jsonString);

            var validAnimalAids = new List<AnimalAid>();

            StringBuilder sb = new StringBuilder();

            foreach (var animalAid in animalAids)
            {
                bool exists = validAnimalAids.Any(a => a.Name == animalAid.Name);
                if (IsValid(animalAid) && !exists)
                {
                    sb.AppendLine($"Record {animalAid.Name} successfully imported.");
                    validAnimalAids.Add(animalAid);
                }
                else
                {
                    sb.AppendLine("Error: Invalid data.");
                }
            }

            context.AnimalAids.AddRange(validAnimalAids);
            context.SaveChanges();

            return sb.ToString();
        }

        public static string ImportAnimals(PetClinicContext context, string jsonString)
        {
            var animals = JsonConvert.DeserializeObject<AnimalDto[]>(jsonString);

            var validAnimals = new List<Animal>();

            var sb = new StringBuilder();

            foreach (var animalDto in animals)
            {
                bool passportExists = validAnimals.Any(a => a.PassportSerialNumber == animalDto.Passport.SerialNumber);
                if (!IsValid(animalDto) || !IsValid(animalDto.Passport) || passportExists)
                {
                    sb.AppendLine("Error: Invalid data.");
                    continue;
                }

                var animal = Mapper.Map<Animal>(animalDto);

                validAnimals.Add(animal);

                sb.AppendLine($"Record {animal.Name} Passport №: {animal.PassportSerialNumber} successfully imported.");
            }

            context.Animals.AddRange(validAnimals);
            context.SaveChanges();

            return sb.ToString();
        }

        public static string ImportVets(PetClinicContext context, string xmlString)
        {
            var serialize = new XmlSerializer(typeof(VetDto[]),
                new XmlRootAttribute("Vets"));

            var vets = (VetDto[])serialize.Deserialize(
                new MemoryStream(Encoding.UTF8.GetBytes(xmlString)));

            List<Vet> validVets = new List<Vet>();

            StringBuilder sb = new StringBuilder();

            foreach (var vetDto in vets)
            {
                if (!IsValid(vetDto)
                    || validVets.Any(v => v.PhoneNumber == vetDto.PhoneNumber))
                {
                    sb.AppendLine("Error: Invalid data.");
                    continue;
                }

                var vet = Mapper.Map<Vet>(vetDto);

                validVets.Add(vet);

                sb.AppendLine($"Record {vet.Name} successfully imported.");
            }

            context.Vets.AddRange(validVets);
            context.SaveChanges();

            return sb.ToString();
        }

        public static string ImportProcedures(PetClinicContext context, string xmlString)
        {
            var serialize = new XmlSerializer(typeof(ProcedureDto[]),
                new XmlRootAttribute("Procedures"));

            var procedures = (ProcedureDto[])serialize.Deserialize(
                new MemoryStream(Encoding.UTF8.GetBytes(xmlString)));

            var validProcedures = new List<Procedure>();

            var sb = new StringBuilder();

            foreach (var procedureDto in procedures)
            {
                if (!IsValid(procedureDto))
                {
                    sb.AppendLine("Error: Invalid data.");
                    continue;
                }

                var vet = context.Vets
                    .SingleOrDefault(v => v.Name == procedureDto.Vet);

                var animal = context.Animals
                    .SingleOrDefault(a => a.PassportSerialNumber == procedureDto.Animal);

                var dateTime = DateTime.ParseExact(procedureDto.DateTime,
                    "dd-MM-yyyy", CultureInfo.InvariantCulture);

                bool animalAidsInvalid = false;

                var procedureAnimalAids = new List<ProcedureAnimalAid>();

                foreach (var animalAidDto in procedureDto.AnimalAids)
                {
                    var animalAid = context.AnimalAids
                        .SingleOrDefault(a => a.Name == animalAidDto.Name);

                    if (animalAid == null
                        || procedureAnimalAids.Any(p => p.AnimalAid == animalAid))
                    {
                        animalAidsInvalid = true;
                        break;
                    }

                    var procedureAnimalAid = new ProcedureAnimalAid
                    {
                        AnimalAid = animalAid
                    };

                    procedureAnimalAids.Add(procedureAnimalAid);
                }

                if (vet == null || animal == null || animalAidsInvalid)
                {
                    sb.AppendLine("Error: Invalid data.");
                    continue;
                }

                var procedure = new Procedure
                {
                    Animal = animal,
                    DateTime = dateTime,
                    Vet = vet,
                    ProcedureAnimalAids = procedureAnimalAids
                };

                validProcedures.Add(procedure);
                sb.AppendLine("Record successfully imported.");
            }

            context.Procedures.AddRange(validProcedures);
            context.SaveChanges();

            return sb.ToString();
        }

        private static bool IsValid(object obj)
        {
            return Validator.TryValidateObject(obj, new ValidationContext(obj), new List<ValidationResult>(), true);
        }
    }
}
