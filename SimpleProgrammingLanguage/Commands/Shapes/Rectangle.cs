using SimpleProgrammingLanguage;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleProgrammingLanguage.Commands.Shapes
{
    /// <summary>
    /// A command to draw a rectangle on the canvas.
    /// </summary>
    public class Rectangle : IShapesParser
    {
        /// <summary>
        /// A boolean to represent as to whether or not an error has occured.
        /// </summary>
        public bool error;

        /// <summary>
        /// Executes the 'rectangle' command, drawing a rectangle on the canvas with the given width and height values.
        /// </summary>
        /// <param name="graphics">A graphics object that is used to draw the rectangle.</param>
        /// <param name="args">A command argument which gets the width and height values of the rectangle.</param>
        /// <param name="canvas">The canvas which the rectangle is drawn on.</param>
        public void ExecuteCommand(Graphics graphics, string[] args, Canvas canvas)
        {
            Point penPosition = canvas.PenPosition;
            Pen drawPen = canvas.DrawPen;
            TextBox commandBox = canvas.CommandBox;

            if (args.Length >= 2)
            {
                if (int.TryParse(args[0], out int width) && int.TryParse(args[1], out int height))
                {
                    // The rectangle is drawn from the pen's "moveTo" position
                    int x = penPosition.X;
                    int y = penPosition.Y;

                    // Checks if the filling option has been enabled or disabled (disabled by default)
                    if (!canvas.Filling)
                    {
                        // Draws the rectangle without any fill
                        graphics.DrawRectangle(drawPen, x, y, width, height);
                    }
                    else
                    {
                        // Draws the rectangle with a solid fill
                        using (SolidBrush brush = new SolidBrush(canvas.FillColour))
                        {
                            graphics.FillRectangle(brush, x, y, width, height);
                        }
                    }

                    // Clears the command text box
                    commandBox.Clear();
                    error = false;
                }
                else
                {
                    // Shows an error message if the width and height entered are not valid integers
                    MessageBox.Show("An error occurred when parsing arguments for the 'RECTANGLE' command. You must enter a valid width and height.", "Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    error = true;
                }
            }
            else
            {
                // Shows an error message if there are no arguments, or only one
                MessageBox.Show("An error occurred when parsing arguments for the 'RECTANGLE' command. You must enter a valid width and height.", "Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                error = true;
            }
        }
    }
}

