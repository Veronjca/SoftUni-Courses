using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] arguments = args.Split();
            string[] argsToExecute = arguments.Skip(1).ToArray();
            string commandName = arguments[0] + "Command";

            Type type = Assembly.GetCallingAssembly().GetTypes().Where(t => t.Name == commandName).First();
            ICommand currentCommand = Activator.CreateInstance(type) as ICommand;

            return currentCommand.Execute(argsToExecute);
        }
    }
}
