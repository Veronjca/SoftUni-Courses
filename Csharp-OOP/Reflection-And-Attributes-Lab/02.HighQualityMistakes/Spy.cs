using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        private StringBuilder result = new StringBuilder();

        public string AnalyzeAccessModifiers(string className)
        {
            Type classType = Type.GetType(className);
            var fields = classType.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic);
            var methods = classType.GetMethods(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            foreach (var field in fields)
            {
                if (field.IsPublic)
                {
                    result.AppendLine($"{field.Name} must be private!");
                }
            }
            foreach (var method in methods)
            {
                if (method.Name.Contains("set") && method.IsPublic)
                {
                    result.AppendLine($"{method.Name} have to be private!");
                }
                if (method.Name.Contains("get") && method.IsPrivate)
                {
                    result.AppendLine($"{method.Name} have to be public!");
                }
            }

            return result.ToString().TrimEnd();
        }
    }
}
