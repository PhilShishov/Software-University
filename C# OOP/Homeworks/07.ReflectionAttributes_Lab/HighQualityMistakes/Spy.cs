
using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string classToInvestigate, params string[] fielsToInvestigate)
    {
        Type classType = Type.GetType(classToInvestigate);
        FieldInfo[] fieldInfos = classType.GetFields(BindingFlags.Static |
            BindingFlags.NonPublic |
            BindingFlags.Public |
            BindingFlags.Instance);

        Object classInstance = Activator.CreateInstance(classType, new object[] { });

        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"Class under investigation: {classToInvestigate}");

        foreach (var field in fieldInfos.Where(f => fielsToInvestigate.Contains(f.Name)))
        {
            sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
        }

        return sb.ToString().TrimEnd();
    }

    public string AnalyzeAcessModifiers(string classToInvestigate)
    {
        Type classType = Type.GetType(classToInvestigate);
        FieldInfo[] fieldInfos = classType.GetFields(BindingFlags.Static |
            BindingFlags.Public |
            BindingFlags.Instance);

        MethodInfo[] classPublicMethods = classType.GetMethods(BindingFlags.Public |
            BindingFlags.Instance);
        MethodInfo[] classNonPublicMethods = classType.GetMethods(BindingFlags.NonPublic |
            BindingFlags.Instance);

        Object classInstance = Activator.CreateInstance(classType, new object[] { });

        StringBuilder sb = new StringBuilder();

        foreach (var field in fieldInfos)
        {
            sb.AppendLine($"{field.Name} must be private!");
        }

        foreach (var method in classNonPublicMethods.Where(m => m.Name.StartsWith("get")))
        {
            sb.AppendLine($"{method.Name} have to be public!");
        }

        foreach (var method in classPublicMethods.Where(m => m.Name.StartsWith("set")))
        {
            sb.AppendLine($"{method.Name} have to be private!");
        }

        return sb.ToString().TrimEnd();
    }
}

