using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleProgrammingLanguage.Commands
{
    /// <summary>
    /// A command to change the current position of the pen on the canvas.
    /// </summary>
    internal class MoveTo : CommandBase
    {
        /// <summary>
        /// Executes the 'moveTo' command with the specificed X Y coordinate arguments.
        /// </summary>
        /// <param name="canvas">The canvas which the pen is moved on.</param>
        /// <param name="args">The arguments that specify the X Y coordinate values of the pen.</param>
        public override void ExecuteCommand(Canvas canvas, string[] args)
        {
            if (args.Length >= 2)
            {
                if (int.TryParse(args[0], out int x) && int.TryParse(args[1], out int y))
                {
                    Point point = new Point(x, y);

                    canvas.PenPosition = point;
                    canvas.CommandBox.Clear();
                }
                else
                {
                    MessageBox.Show("An error occurred when parsing arguments for the 'MOVETO' command. Please input valid coordinates.", "Argument Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("An error occurred when parsing the 'MOVETO' command. Please try again.", "Argument Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
