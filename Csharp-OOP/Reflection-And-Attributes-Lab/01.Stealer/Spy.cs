using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string className, params string []  fieldsToInvestigate)
        {
            Hacker hacker = new Hacker();
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Class under investigation: {className}");

            foreach (var field in hacker.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static))
            {
                if (fieldsToInvestigate.ToList().Contains(field.Name))
                {
                    result.AppendLine($"{field.Name} = {field.GetValue(hacker)}");
                }
                
            }

            return result.ToString().TrimEnd();

        }
    }
}
