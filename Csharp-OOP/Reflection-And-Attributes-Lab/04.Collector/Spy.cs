using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {

        public string GetMethods(string className)
        {
            Type classType = Type.GetType(className);
            var methods = classType.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            StringBuilder result = new StringBuilder();

            foreach (var method in methods)
            {
                if (method.Name.Contains("get"))
                {
                    result.AppendLine($"{method.Name} will return {method.ReturnType}");
                }
            }

            foreach (var method in methods)
            {
                int index = method.Name.IndexOf('_');
                string propertyName = method.Name.Substring(index+1);
                var property = classType.GetProperty(propertyName, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

                if (method.Name.Contains("set"))
                {
                    result.AppendLine($"{method.Name} will set field of {property.PropertyType}");
                }
            }
            return result.ToString().TrimEnd();
        }
    }

}
