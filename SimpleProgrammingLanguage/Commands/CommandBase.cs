using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace SimpleProgrammingLanguage.Commands
{
    abstract public class CommandBase
    {
        abstract public void ExecuteCommand(Canvas canvas, string[] args);
    }
}
