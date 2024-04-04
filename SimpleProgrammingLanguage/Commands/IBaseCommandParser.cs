using SimpleProgrammingLanguage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace SimpleProgrammingLanguage.Commands
{
    /// <summary>
    /// A class that represents the command parser which is responsible for executing commands and arguments.
    /// </summary>
    public interface IBaseCommandParser
    {
        /// <summary>
        /// A method that executes given commands and arguments.
        /// </summary>
        /// <param name="canvas">The canvas on which the command is executed against.</param>
        /// <param name="args">The arguments that accompany the command (if any).</param>
        abstract public void ExecuteCommand(Canvas canvas, string[] args);
    }
}
