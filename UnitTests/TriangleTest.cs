using SimpleProgrammingLanguage;
using SimpleProgrammingLanguage.Commands.Shapes;
using System.Drawing;

namespace UnitTests
{
    /// <summary>
    /// A test class to test the Triangle command class.
    /// </summary>
    [TestClass]
    public class DrawTriangleTest
    {
        /// <summary>
        /// A test method to verify that the execution of the Triangle command with an invalid side length produces an error message.
        /// </summary>
        [TestMethod]
        public void Execute_DrawTriangle_WithInvalidSideLength()
        {
            // Arrange
            var canvas = new Canvas();
            var triangleCmd = new Triangle();
            string[] args = new string[] { "invalidSideLength" }; // Invalid side length
            var graphics = Graphics.FromImage(new Bitmap(150, 150));

            // Act
            triangleCmd.ExecuteCommand(graphics, args, canvas);

            // Assert
            Assert.IsTrue(triangleCmd.error);
        }

        /// <summary>
        /// A test method to verify that the execution of the Triangle command with a valid radius successfuly draws a triangle.
        /// </summary>
        [TestMethod]
        public void Execute_DrawTriangle_WithValidSideLength()
        {
            // Arrange
            var canvas = new Canvas();
            var triangleCmd = new Triangle();
            string[] args = new string[] { "75" }; // Valid side length of 75
            var graphics = Graphics.FromImage(new Bitmap(150, 150));

            // Act
            triangleCmd.ExecuteCommand(graphics, args, canvas);

            // Assert
            Assert.IsTrue(string.IsNullOrEmpty(canvas.CommandBox.Text));
            Assert.IsFalse(triangleCmd.error);
        }
    }
}