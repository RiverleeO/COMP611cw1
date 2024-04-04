using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleProgrammingLanguage.Commands;
using SimpleProgrammingLanguage.Commands.Shapes;
using SimpleProgrammingLanguage;

namespace SimpleProgrammingLanguage
{
    /// <summary>
    /// A class that represents the Pen Handler, responsible for executing commands on a specific canvas.
    /// </summary>
    public class PenHandler
    {
        private Canvas canvas;

        /// <summary>
        /// Initialises a new instance of the PenHandler class with the specified canvas.
        /// </summary>
        /// <param name="canvas">The canvas that is being drawn on.</param>
        public PenHandler(Canvas canvas)
        {
            this.canvas = canvas;
        }

        /// <summary>
        /// A collection of pen and canvas commands.
        /// </summary>
        private Dictionary<string, Commands.IBaseCommandParser> commandParser = new Dictionary<string, Commands.IBaseCommandParser>
        {
            { "PEN", new PenCmd() },
            { "DRAWTO", new DrawTo() },
            { "MOVETO", new MoveTo() },
            { "FILL", new Fill() },
            { "CLEAR", new Clear() },
            { "RESET", new Reset() }
        };

        /// <summary>
        /// A collection of shape commands.
        /// </summary>
        private Dictionary<string, Commands.Shapes.ShapesParser> shapesParser = new Dictionary<string, Commands.Shapes.ShapesParser>
        {
            { "CIRCLE", new Commands.Shapes.Circle() },
            { "RECTANGLE", new Commands.Shapes.Rectangle() },
            { "SQUARE", new Commands.Shapes.Square() },
            { "TRIANGLE", new Commands.Shapes.Triangle() }
        };

        /// <summary>
        /// A method that executes the pen and canvas commands, which are parsed by the command parser.
        /// </summary>
        /// <param name="parser"></param>
        public void ExecPenDrawing(CommandParser parser)
        {
            using (Graphics graphics = canvas.CanvasBox.CreateGraphics())
            {
                switch (parser.Cmd.ToUpper())
                {
                    case "PEN":
                    case "DRAWTO":
                    case "MOVETO":
                    case "FILL":
                    case "CLEAR":
                    case "RESET":
                        commandParser[parser.Cmd.ToUpper()].ExecuteCommand(canvas, parser.Args);
                        break;
                    case "CIRCLE":
                    case "RECTANGLE":
                    case "SQUARE":
                    case "TRIANGLE":
                        shapesParser[parser.Cmd.ToUpper()].ExecuteCommand(graphics, parser.Args, canvas);
                        break;
                    default:
                        MessageBox.Show("The command '" + parser.Cmd + "' could not be found. Please try again.", "Command Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
        }
    }
}
