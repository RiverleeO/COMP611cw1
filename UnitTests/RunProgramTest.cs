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
    /// A test class to test running custom program code.
    /// </summary>
    [TestClass]
    public class RunProgramTest
    {
        /// <summary>
        /// A test method to verify that custom program code run successfully.
        /// </summary>
        [TestMethod]
        public void ExecuteProgram()
        {
            // Arrange
            var canvas = new Canvas();

            RichTextBox progContents = new RichTextBox();

            progContents.Text = @"count = 2
                If count < 3
                moveto 20 20
                rectangle 30 30
                moveto 100 100
                circle 50
                EndIf";

            // Act
            ProgramHandler programHandler = new ProgramHandler(canvas);
            programHandler.ExecuteProgram(progContents.Text);

            // Assert
            Assert.IsTrue(progContents.Text.StartsWith("count"));
        }
    }
}
