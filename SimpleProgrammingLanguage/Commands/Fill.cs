using SimpleProgrammingLanguage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleProgrammingLanguage.Commands
{
    /// <summary>
    /// A command to enable or disable the fill mode option.
    /// </summary>
    public class Fill : IBaseCommandParser
    {
        /// <summary>
        /// Executes the 'fill' command.
        /// </summary>
        /// <param name="canvas">The canvas which fill mode is toggled.</param>
        /// <param name="args">A command argument which gets the selected value (on or off) to toggle the fill option.</param>
        public void ExecuteCommand(Canvas canvas, string[] args)
        {
            TextBox commandBox = canvas.CommandBox;

            if (args.Length >= 1)
            {
                string fillMode = args[0].ToUpper();

                switch (fillMode)
                {
                    // Disables filling
                    case "OFF":
                        canvas.Filling = false;
                        break;
                    // Enables filling with the selected pen colour
                    case "ON":
                        canvas.Filling = true;
                        canvas.FillColour = canvas.DrawPen.Color;
                        break;
                    default:
                        // Throw error if the argument is not "ON" or "OFF" and exit method
                        MessageBox.Show("An error occurred whilst selecting the fill mode. Valid fill modes include 'ON' or 'OFF'.", "Fill Mode Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                }
            }
            else
            {
                // Throw error if the command does not contain any arguments and exit method
                MessageBox.Show("An error occurred whilst selecting the fill mode. Valid fill modes include 'ON' or 'OFF'.", "Fill Mode Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Clears the command text box
            commandBox.Clear();
        }
    }
}