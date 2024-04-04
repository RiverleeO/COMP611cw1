using SimpleProgrammingLanguage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleProgrammingLanguage.Commands
{
    /// <summary>
    /// A command that resets the pen position to the default value on the canvas.
    /// </summary>
    public class Reset : IBaseCommandParser
    {
        /// <summary>
        /// Executes the 'reset' command which resets the pen position.
        /// </summary>
        /// <param name="canvas">The canvas on which the pen is reset to the default position.</param>
        /// <param name="args">No arguments are required for this command.</param>
        public void ExecuteCommand(Canvas canvas, string[] args)
        {
            canvas.PenPosition = new Point(50, 50);
        }
    }
}
