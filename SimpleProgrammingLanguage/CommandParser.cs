using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleProgrammingLanguage
{
    /// <summary>
    /// 
    /// </summary>
    public class CommandParser
    {
        /// <summary>
        /// Creates (initialises) a new instance of the CommandParser class
        /// </summary>
        /// <param name="command"></param>
        public CommandParser(string command)
        {
            ParseCommand(command);
        }

        /// <summary>
        /// Gets the parsed command.
        /// </summary>
        public string Cmd { get; private set; } = "";

        /// <summary>
        /// Gets the parsed aguments of the command.
        /// </summary>
        public string[] Args { get; private set; } = Array.Empty<string>();

        /// <summary>
        /// Splits the command string into the command and argument(s).
        /// </summary>
        /// <param name="command">The command string that is parsed.</param>
        public void ParseCommand(string command)
        {
            string[] commandArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (!commandArgs.Any())
            {
                Cmd = "";
                Args = Array.Empty<string>();
                return;
            }
            else if (commandArgs.Length > 1)
            {
                Cmd = commandArgs[0];
                Args = ParseArguments(commandArgs, 1);
            }
            else
            {
                Cmd = commandArgs[0];
                Args = Array.Empty<string>();
            }
        }

        /// <summary>
        /// Parses the arguments from the command.
        /// </summary>
        /// <param name="commandArgs">The array of command arguments.</param>
        /// <param name="index">The index for parsing arguments.</param>
        /// <returns></returns>
        private string[] ParseArguments(string[] commandArgs, int index)
        {
            List<string> args = new List<string>();

            for (int i = index; i < commandArgs.Length; i++)
            {
                args.Add(commandArgs[i]);
            }

            return args.ToArray();
        }
    }
}
