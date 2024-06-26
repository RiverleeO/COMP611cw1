﻿using SimpleProgrammingLanguage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleProgrammingLanguage.Commands.Shapes
{
    /// <summary>
    /// A command to draw a square on the canvas.
    /// </summary>
    public class Square : IShapesParser
    {
        /// <summary>
        /// A boolean to represent as to whether or not an error has occured.
        /// </summary>
        public bool error = false;

        /// <summary>
        /// Executes the 'square' command, drawing a square on the canvas with the given side length value.
        /// </summary>
        /// <param name="graphics">A graphics object that is used to draw the square.</param>
        /// <param name="args">A command argument which gets the width and height values of the square.</param>
        /// <param name="canvas">The canvas which the square is drawn on.</param>
        public void ExecuteCommand(Graphics graphics, string[] args, Canvas canvas)
        {
            Point penPosition = canvas.PenPosition;
            Pen drawPen = canvas.DrawPen;
            TextBox commandBox = canvas.CommandBox;

            if (args.Length >= 1)
            {
                if (int.TryParse(args[0], out int width) && int.TryParse(args[0], out int height))
                {
                    // The square is drawn from the pen's "moveTo" position
                    int x = penPosition.X;
                    int y = penPosition.Y;

                    // Checks if the filling option has been enabled or disabled (disabled by default)
                    if (!canvas.Filling)
                    {
                        // Draws the square without any fill
                        graphics.DrawRectangle(drawPen, x, y, width, height);
                    }
                    else
                    {
                        // Draws the square with a solid fill
                        using (SolidBrush brush = new SolidBrush(canvas.FillColour))
                        {
                            graphics.FillRectangle(brush, x, y, width, height);
                        }
                    }

                    // Clears the command text box
                    commandBox.Clear();
                }
                else
                {
                    // Shows an error message if the width and height entered are not valid integers
                    MessageBox.Show("An error occurred when parsing arguments for the 'SQUARE' command. You must enter a valid side length.", "Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    error = true;
                }
            }
            else
            {
                // Shows an error message if there are no arguments, or only one
                MessageBox.Show("An error occurred when parsing arguments for the 'SQUARE' command. You must enter a valid side length.", "Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                error = true;
            }
        }
    }
}
