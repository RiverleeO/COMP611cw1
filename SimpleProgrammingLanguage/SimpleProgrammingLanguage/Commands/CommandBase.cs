using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleProgrammingLanguage.Commands
{
    abstract public class CommandBase
    {
        abstract public void ExecuteCommand(Canvas canvas, string[] args);
    }
}
