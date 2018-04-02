 namespace P01_HarvestingFields
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            Type type = typeof(HarvestingFields);

            string input;
            while ((input = Console.ReadLine()) != "HARVEST")
            {
                IEnumerable<FieldInfo> fields;
                switch (input)
                {
                    case "public":
                        fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public);
                        break;
                    case "protected":
                        fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                            .Where(field => field.IsFamily);
                        break;
                    case "private":
                        fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                            .Where(field => field.IsPrivate);
                        break;
                    case "all":
                        fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                        break;
                    default:
                        fields = null;
                        break;
                }

                foreach (var fieldInfo in fields)
                {
                    string access = fieldInfo.Attributes.ToString().ToLower();
                    if (access == "family")
                        access = "protected";
                    Console.WriteLine($"{access} {fieldInfo.FieldType.Name} {fieldInfo.Name}");
                }
            }
        }
    }
}
