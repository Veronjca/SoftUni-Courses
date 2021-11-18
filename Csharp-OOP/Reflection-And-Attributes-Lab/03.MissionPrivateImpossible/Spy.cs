using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        private StringBuilder result = new StringBuilder();

        public string RevealPrivateMethods(string className)
        {
            Type classType = Type.GetType(className);
            result.AppendLine($"All Private Methods of Class: {className}");
            result.AppendLine($"Base Class: {classType.BaseType.Name}");
            var methods = classType.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            foreach (var method in methods)
            {
                if (method.IsPrivate || method.IsFamily)
                {
                    result.AppendLine($"{method.Name}");
                }
            }
            return result.ToString().TrimEnd();
        }
    }

}
