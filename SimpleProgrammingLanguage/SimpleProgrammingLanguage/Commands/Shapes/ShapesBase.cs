using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleProgrammingLanguage.Commands.Shapes
{
    abstract public class ShapesBase
    {
        abstract public void ExecuteCommand(Graphics graphics, string[] args, Canvas canvas);
    }
}
