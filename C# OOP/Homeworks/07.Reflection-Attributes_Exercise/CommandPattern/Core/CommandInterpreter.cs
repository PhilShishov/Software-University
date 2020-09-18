namespace CommandPattern.Core
{
    using System;
    using System.Linq;
    using System.Reflection;

    using CommandPattern.Core.Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        private const string COMMAND_POSTFIX = "Command";

        public string Read(string inputLine)
        {
            var cmdTokens = inputLine.Split();
            string commandName = cmdTokens[0] + COMMAND_POSTFIX;
            var commandArguments = cmdTokens.Skip(1).ToArray();

            Assembly assembly = Assembly.GetCallingAssembly();
            Type[] types = assembly.GetTypes();
            Type typeToCreate = types.FirstOrDefault(t => t.Name == commandName);

            //if (typeToCreate == null)
            //{
            //    throw new InvalidOperationException("Invalid Command Type");
            //}

            Object instance = Activator.CreateInstance(typeToCreate);
            ICommand command = (ICommand)instance;

            string result = command.Execute(commandArguments);

            return result;
        }
    }
}
