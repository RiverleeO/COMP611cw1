using SimpleProgrammingLanguage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnitTests
{
    /// <summary>
    /// A test class to test running a command set (list of commands and arguments).
    /// </summary>
    [TestClass]
    public class RunCommandSetTest
    {
        /// <summary>
        /// A test method to verify that programs (which are a list of commands and arguments in order) execute successfully.
        /// </summary>
        [TestMethod]
        public void ExecuteCommandSet()
        {
            // Arrange
            var canvas = new Canvas();
            string[] fileContents = { "MOVETO 250 250", "SQUARE 100", "MOVETO 275 250", "RECTANGLE 50 25", "MOVETO 250 250", "TRIANGLE 100" };
            List<string> cmdList = new List<string>();

            // Act
            foreach (string progLine in fileContents)
            {
                cmdList.Add(progLine);
            }

            foreach (string cmdLine in cmdList)
            {
                CommandParser commandParser = new CommandParser(cmdLine);
                canvas.penHandler.ExecPenDrawing(commandParser);
            }

            // Assert
            Assert.IsTrue(cmdList.SequenceEqual(fileContents));
        }
    }
}