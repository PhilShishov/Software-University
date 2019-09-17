
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
}

