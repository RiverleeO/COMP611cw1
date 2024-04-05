using SimpleProgrammingLanguage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleProgrammingLanguage.Commands.Shapes
{
    /// <summary>
    /// A class that represents the shapes command parser which is responsible for executing commands and arguments related to shapes.
    /// </summary>
    public interface IShapesParser
    {
        /// <summary>
        ///  A method that executes given commands and arguments specific to graphics.
        /// </summary>
        /// <param name="graphics">The graphics object which is used for drawing.</param>
        /// <param name="args">The arguments that accompany the command (if any).</param>
        /// <param name="canvas">The canvas on which the command is executed against.</param>
        abstract public void ExecuteCommand(Graphics graphics, string[] args, Canvas canvas);
    }
}
