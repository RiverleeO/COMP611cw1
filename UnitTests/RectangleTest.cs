using SimpleProgrammingLanguage;
using System.Drawing;

namespace UnitTests
{
    /// <summary>
    /// A test class to test the Rectangle command class.
    /// </summary>
    [TestClass]
    public class DrawRectangleTest
    {
        /// <summary>
        /// A test method to verify that the execution of the Rectangle command with an invalid width and height produces an error message.
        /// </summary>
        [TestMethod]
        public void Execute_DrawRectangle_WithInvalidWidth()
        {
            // Arrange
            var canvas = new Canvas();
            var rectangleCmd = new SimpleProgrammingLanguage.Commands.Shapes.Rectangle();
            string[] args = new string[] { "invalid", "45" }; // Invalid width
            var graphics = Graphics.FromImage(new Bitmap(150, 150));

            // Act
            rectangleCmd.ExecuteCommand(graphics, args, canvas);

            // Assert
            Assert.IsTrue(rectangleCmd.error);
        }

        /// <summary>
        /// A test method to verify that the execution of the Rectangle command with an invalid width and height produces an error message.
        /// </summary>
        [TestMethod]
        public void Execute_DrawRectangle_WithInvalidHeight()
        {
            // Arrange
            var canvas = new Canvas();
            var rectangleCmd = new SimpleProgrammingLanguage.Commands.Shapes.Rectangle();
            string[] args = new string[] { "75", "invalid" }; // Invalid height
            var graphics = Graphics.FromImage(new Bitmap(150, 150));

            // Act
            rectangleCmd.ExecuteCommand(graphics, args, canvas);

            // Assert
            Assert.IsTrue(string.IsNullOrEmpty(canvas.CommandBox.Text));
            Assert.IsTrue(rectangleCmd.error);
        }

        /// <summary>
        /// A test method to verify that the execution of the Rectangle command with a valid radius successfuly draws a rectangle.
        /// </summary>
        [TestMethod]
        public void Execute_DrawRectangle_WithValidWidthHeight()
        {
            // Arrange
            var canvas = new Canvas();
            var rectangleCmd = new SimpleProgrammingLanguage.Commands.Shapes.Rectangle();
            string[] args = new string[] { "75", "45" }; // Valid width and height of 75 and 45, respectively
            var graphics = Graphics.FromImage(new Bitmap(150, 150));

            // Act
            rectangleCmd.ExecuteCommand(graphics, args, canvas);

            // Assert
            Assert.IsTrue(string.IsNullOrEmpty(canvas.CommandBox.Text));
            Assert.IsFalse(rectangleCmd.error);
        }
    }
}
