using SimpleProgrammingLanguage;
using SimpleProgrammingLanguage.Commands;
using System.Drawing;

namespace UnitTests
{
    /// <summary>
    /// A test class to test the Clear command class.
    /// </summary>
    [TestClass]
    public class ClearTest
    {
        /// <summary>
        /// A test method to verify that the execution of the Clear command results in the clearing the canvas.
        /// </summary>
        [TestMethod]
        public void Execute_ClearCanvas()
        {
            // Arrange
            var canvas = new Canvas();
            var rectangleCmd = new SimpleProgrammingLanguage.Commands.Shapes.Rectangle();
            var clearCmd = new Clear();
            string[] cmdArgs = { "45", "75" };
            var graphics = Graphics.FromImage(new Bitmap(150, 150));

            // Act
            rectangleCmd.ExecuteCommand(graphics, cmdArgs, canvas);
            clearCmd.ExecuteCommand(canvas, null);

            // Assert
            Assert.IsTrue(string.IsNullOrEmpty(canvas.CommandBox.Text));
            Assert.IsFalse(rectangleCmd.error);
        }
    }
}