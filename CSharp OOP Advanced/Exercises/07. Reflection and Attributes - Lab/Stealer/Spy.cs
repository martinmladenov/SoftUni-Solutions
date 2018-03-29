using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string className, params string[] fieldNames)
    {
        StringBuilder sb = new StringBuilder();
        Type type = Type.GetType(className);
        object instance = Activator.CreateInstance(type, new object[0]);

        sb.AppendLine($"Class under investigation: {className}");
        FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Static |
                                            BindingFlags.Public | BindingFlags.NonPublic);

        foreach (var field in fields.Where(field => fieldNames.Contains(field.Name)))
        {
            sb.AppendLine($"{field.Name} = {field.GetValue(instance)}");
        }

        return sb.ToString().Trim();
    }

    public string AnalyzeAcessModifiers(string className) // Access
    {
        StringBuilder sb = new StringBuilder();

        Type type = Type.GetType(className);

        foreach (var field in type.GetFields(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public))
        {
            sb.AppendLine($"{field.Name} must be private!");
        }

        foreach (var method in type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(m => m.Name.StartsWith("get")))
        {
            sb.AppendLine($"{method.Name} have to be public!");
        }

        foreach (var method in type.GetMethods(BindingFlags.Public | BindingFlags.Instance).Where(m => m.Name.StartsWith("set")))
        {
            sb.AppendLine($"{method.Name} have to be private!");
        }

        return sb.ToString().Trim();
    }

    public string RevealPrivateMethods(string className)
    {
        StringBuilder sb = new StringBuilder();

        Type type = Type.GetType(className);

        sb.AppendLine($"All Private Methods of Class: {className}");
        sb.AppendLine($"Base Class: {type.BaseType.Name}");

        foreach (var method in type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic))
        {
            sb.AppendLine(method.Name);
        }

        return sb.ToString().Trim();
    }

    public string CollectGettersAndSetters(string className)
    {
        StringBuilder sb = new StringBuilder();

        Type type = Type.GetType(className);

        var allMethods = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

        foreach (var method in allMethods.Where(m => m.Name.StartsWith("get")))
        {
            sb.AppendLine($"{method.Name} will return {method.ReturnType}");
        }

        foreach (var method in allMethods.Where(m => m.Name.StartsWith("set")))
        {
            sb.AppendLine($"{method.Name} will set field of {method.GetParameters()[0].ParameterType}");
        }

        return sb.ToString().Trim();
    }
}