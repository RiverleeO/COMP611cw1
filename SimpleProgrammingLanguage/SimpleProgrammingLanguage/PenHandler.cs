using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleProgrammingLanguage.Commands;

namespace SimpleProgrammingLanguage
{
    public class PenHandler
    {
        private Canvas canvas;

        public PenHandler(Canvas canvas)
        {
            this.canvas = canvas;
        }

        private Dictionary<string, CommandBase> commandBase = new Dictionary<string, CommandBase>
        {
            { "PEN", new PenCmd() },
            { "DRAWTO", new DrawTo() },
            { "MOVETO", new MoveTo() },
            { "FILL", new Fill() },
            { "CLEAR", new Clear() },
            { "RESET", new Reset() }
        };

        private Dictionary<string, Commands.Shapes.ShapesBase> shapesBase = new Dictionary<string, Commands.Shapes.ShapesBase>
        {
            { "CIRCLE", new Commands.Shapes.Circle() },
            { "RECTANGLE", new Commands.Shapes.Rectangle() },
            { "SQUARE", new Commands.Shapes.Square() },
            { "TRIANGLE", new Commands.Shapes.Triangle() }
        };

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
                        commandBase[parser.Cmd.ToUpper()].ExecuteCommand(canvas, parser.Args);
                        break;
                    case "CIRCLE":
                    case "RECTANGLE":
                    case "SQUARE":
                    case "TRIANGLE":
                        shapesBase[parser.Cmd.ToUpper()].ExecuteCommand(graphics, parser.Args, canvas);
                        break;
                    default:
                        MessageBox.Show("The command '" + parser.Cmd + "' could not be found. Please try again.", "Command Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
        }
    }
}
