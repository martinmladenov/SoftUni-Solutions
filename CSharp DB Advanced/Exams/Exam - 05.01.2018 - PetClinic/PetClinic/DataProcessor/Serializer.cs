namespace PetClinic.DataProcessor
{
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Dtos.Export;
    using Newtonsoft.Json;
    using Data;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportAnimalsByOwnerPhoneNumber(PetClinicContext context, string phoneNumber)
        {
            var animals = context.Passports
                .Where(p => p.OwnerPhoneNumber == phoneNumber)
                .Select(p => new
                {
                    p.OwnerName,
                    AnimalName = p.Animal.Name,
                    p.Animal.Age,
                    p.SerialNumber,
                    RegisteredOn = p.RegistrationDate.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture)
                })
                .OrderBy(a => a.Age)
                .ThenBy(a => a.SerialNumber)
                .ToArray();

            var json = JsonConvert.SerializeObject(animals, Formatting.Indented);

            return json;
        }

        public static string ExportAllProcedures(PetClinicContext context)
        {
            var procedures = context.Procedures
                .OrderBy(p => p.DateTime)
                .ThenBy(p => p.Animal.Passport.SerialNumber)
                .Select(p => new ProcedureDto
                {
                    Passport = p.Animal.Passport.SerialNumber,
                    OwnerNumber = p.Animal.Passport.OwnerPhoneNumber,
                    DateTime = p.DateTime.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture),
                    AnimalAids = p.ProcedureAnimalAids
                        .Select(a => new AnimalAidDto
                        {
                            Name = a.AnimalAid.Name,
                            Price = a.AnimalAid.Price
                        })
                        .ToArray(),
                    TotalPrice = p.ProcedureAnimalAids
                        .Sum(a => a.AnimalAid.Price)
                })
                .ToArray();

            var sb = new StringBuilder();

            var serializer = new XmlSerializer(procedures.GetType(), new XmlRootAttribute("Procedures"));

            serializer.Serialize(new StringWriter(sb), procedures, new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty }));

            return sb.ToString();
        }
    }
}
