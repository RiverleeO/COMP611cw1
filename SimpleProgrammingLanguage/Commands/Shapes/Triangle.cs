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
    /// A command to draw a triangle on the canvas.
    /// </summary>
    public class Triangle : ShapesParser
    {
        /// <summary>
        /// A boolean to represent as to whether or not an error has occured.
        /// </summary>
        public bool error;

        /// <summary>
        /// Executes the 'triangle' command, drawing a triangle on the canvas with the given side length value.
        /// </summary>
        /// <param name="graphics">A graphics object that is used to draw the triangle.</param>
        /// <param name="args">A command argument which gets side length value of the triangle.</param>
        /// <param name="canvas">The canvas which the triangle is drawn on.</param>
        public override void ExecuteCommand(Graphics graphics, string[] args, Canvas canvas)
        {
            Point penPosition = canvas.PenPosition;
            Pen drawPen = canvas.DrawPen;
            TextBox commandBox = canvas.CommandBox;

            if (args.Length >= 1)
            {
                if (int.TryParse(args[0], out int sLength))
                {
                    // Calculates the vertices of the triangle
                    int x1 = penPosition.X;
                    int y1 = penPosition.Y;
                    int x2 = x1 + sLength;
                    int y2 = y1;
                    int x3 = x1 + sLength / 2;
                    int y3 = y1 - (int)(Math.Sqrt(3) * sLength / 2);

                    Point[] points = { new Point(x1, y1), new Point(x2, y2), new Point(x3, y3) };

                    // Checks if the filling option has been enabled or disabled (disabled by default)
                    if (!canvas.Filling)
                    {
                        // Draws the triangle without any fill
                        graphics.DrawPolygon(drawPen, points);
                    }
                    else
                    {
                        // Draws the triangle with a solid fill
                        using (SolidBrush brush = new SolidBrush(canvas.FillColour))
                        {
                            graphics.FillPolygon(brush, points);
                        }
                    }

                    // Clears the command text box
                    commandBox.Clear();
                    error = false;
                }
                else
                {
                    MessageBox.Show("An error occurred when parsing arguments for the 'TRIANGLE' command. You must enter a valid side length.", "Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    error = true;
                }
            }
            else
            {
                MessageBox.Show("An error occurred when parsing arguments for the 'TRIANGLE' command. You must enter a valid side length.", "Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                error = true;
            }
        }
    }
}

