using SimpleProgrammingLanguage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleProgrammingLanguage.Commands.Shapes
{
    /// <summary>
    /// A command to draw a circle on the canvas.
    /// </summary>
    public class Circle : ShapesParser
    {
        /// <summary>
        /// A boolean to represent as to whether or not an error has occured.
        /// </summary>
        public bool error;

        /// <summary>
        /// Executes the 'circle' command, drawing a circle on the canvas with the given radius value.
        /// </summary>
        /// <param name="graphics">A graphics object that is used to draw the circle.</param>
        /// <param name="args">A command argument which gets the radius for the circle.</param>
        /// <param name="canvas">The canvas which the circle is drawn on.</param>
        public override void ExecuteCommand(Graphics graphics, string[] args, Canvas canvas)
        {
            Point penPosition = canvas.PenPosition;
            Pen pen = canvas.DrawPen;
            TextBox commandBox = canvas.CommandBox;

            if (args.Length >= 1)
            {
                if (int.TryParse(args[0], out int circleRadius))
                {
                    // Calculates and X and Y position of the pen so that the circle radius is drawn from the center
                    int x = penPosition.X - circleRadius;
                    int y = penPosition.Y - circleRadius;

                    // Checks if the filling option has been enabled or disabled (disabled by default)
                    if (!canvas.Filling)
                    {
                        // Draws the circle without any fill
                        graphics.DrawEllipse(pen, x, y, 2 * circleRadius, 2 * circleRadius);
                    }
                    else
                    {
                        // Draws the circle with a solid fill
                        using (SolidBrush brush = new SolidBrush(canvas.FillColour))
                        {
                            graphics.FillEllipse(brush, x, y, 2 * circleRadius, 2 * circleRadius);
                        }
                    }

                    // Clears the command text box
                    commandBox.Clear();
                    error = false;
                }
                else
                {
                    // Throws an error message if a valid radius value is not entered
                    MessageBox.Show("An error occurred when parsing arguments for the 'CIRCLE' command. You must enter a valid radius value.", "Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    error = true;
                }
            }
        }
    }
}
