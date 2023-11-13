using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleProgrammingLanguage.Commands
{
    /// <summary>
    /// A command that clears the canvas.
    /// </summary>
    internal class Clear : CommandBase
    {
        /// <summary>
        /// Executes the 'clear' command which removes all drawings from the canvas.
        /// </summary>
        /// <param name="canvas">The canvas which the rectangle is drawn on.</param>
        /// <param name="args">No arguments are required for this command.</param>
        public override void ExecuteCommand(Canvas canvas, string[] args)
        {
            canvas.CanvasBox.Invalidate();
        }
    }
}