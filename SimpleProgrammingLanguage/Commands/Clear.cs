using SimpleProgrammingLanguage.Commands;
using SimpleProgrammingLanguage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleProgrammingLanguage.Commands
{
    /// <summary>
    /// A class that represents the Clear command that clears the canvas.
    /// </summary>
    public class Clear : IBaseCommandParser
    {
        /// <summary>
        /// Executes the 'clear' command which removes all drawings from the canvas.
        /// </summary>
        /// <param name="canvas">The canvas which the rectangle is drawn on.</param>
        /// <param name="args">No arguments are required for this command.</param>
        public void ExecuteCommand(Canvas canvas, string[] args)
        {
            canvas.CanvasBox.Invalidate();
            TextBox commandBox = canvas.CommandBox;
            commandBox.Clear();
        }
    }
}