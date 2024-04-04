using SimpleProgrammingLanguage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleProgrammingLanguage.Commands
{
    /// <summary>
    /// A command that draws a line from the pen's current position to a specified destination.
    /// </summary>
    public class DrawTo : IBaseCommandParser
    {
        /// <summary>
        /// A boolean to represent as to whether or not an error has occured.
        /// </summary>
        public bool error;

        /// <summary>
        /// Executes the 'drawTo' command using the X Y coordinate arguments.
        /// </summary>
        /// <param name="canvas">The canvas which the line is drawn on.</param>
        /// <param name="args">The X Y arguments from the command.</param>
        public void ExecuteCommand(Canvas canvas, string[] args)
        {
            if (args.Length >= 2)
            {
                if (int.TryParse(args[0], out int x) && int.TryParse(args[1], out int y))
                {
                    Point point = new Point(x, y);

                    using (Graphics graphics = canvas.CanvasBox.CreateGraphics())
                    {
                        graphics.DrawLine(canvas.DrawPen, canvas.PenPosition, point);
                    }

                    canvas.PenPosition = point;
                    canvas.CommandBox.Clear();
                    error = false;
                }
                else
                {
                    MessageBox.Show("An error occurred when parsing arguments for the 'DRAWTO' command. Please input valid coordinates.", "Argument Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    error = true;
                }
            }
            else
            {
                MessageBox.Show("An error occurred when parsing the 'DRAWTO' command. Please try again.", "Argument Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                error = true;
            }
        }
    }
}
