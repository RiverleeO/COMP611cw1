using SimpleProgrammingLanguage;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleProgrammingLanguage.Commands
{
    /// <summary>
    /// A command which allows the changing of the pen colour.
    /// </summary>
    public class PenCmd : BaseCommandParser
    {
        /// <summary>
        /// A boolean to represent as to whether or not an error has occured.
        /// </summary>
        public bool error = false;

        /// <summary>
        /// Executes the 'pen' command with the string argument.
        /// </summary>
        /// <param name="canvas">The canvas on which the pen colour is changed.</param>
        /// <param name="args">The aguments for the pen colour.</param>
        public override void ExecuteCommand(Canvas canvas, string[] args)
        {
            TextBox commandBox = canvas.CommandBox;
            Pen drawPen = canvas.DrawPen;

            if (args.Length >= 1)
            {
                Color colour;
                string colourArgs = args[0].ToUpper();

                switch (colourArgs)
                {
                    case "BLACK":
                        colour = Color.Black;
                        break;
                    case "RED":
                        colour = Color.Red;
                        break;
                    case "GREEN":
                        colour = Color.Green;
                        break;
                    case "BLUE":
                        colour = Color.Blue;
                        break;
                    case "PURPLE":
                        colour = Color.Purple;
                        break;
                    case "YELLOW":
                        colour = Color.Yellow;
                        break;
                    case "ORANGE":
                        colour = Color.Orange;
                        break;
                    default:
                        MessageBox.Show("An error occurred. '" + colourArgs + "' is not a valid colour. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        error = true;
                        return;
                }

                canvas.DrawPen = new Pen(colour);
                canvas.FillColour = colour;
            }
            else
            {
                MessageBox.Show("An error occurred whilst selecting a colour. Please select a valid colour.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                error = true;
                return;
            }
            commandBox.Clear();
        }
    }
}