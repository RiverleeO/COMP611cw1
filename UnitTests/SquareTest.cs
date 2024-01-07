using SimpleProgrammingLanguage;
using SimpleProgrammingLanguage.Commands.Shapes;
using System.Drawing;

namespace UnitTests
{
    /// <summary>
    /// A test class to test the Square command class.
    /// </summary>
    [TestClass]
    public class DrawSquareTest
    {
        /// <summary>
        /// A test method to verify that the execution of the Square command with an invalid side length produces an error message.
        /// </summary>
        [TestMethod]
        public void Execute_DrawSquare_WithInvalidSideLength()
        {
            // Arrange
            var canvas = new Canvas();
            var squareCmd = new Square();
            string[] args = new string[] { "invalidSideLength" }; // Invalid side length
            var graphics = Graphics.FromImage(new Bitmap(150, 150));

            // Act
            squareCmd.ExecuteCommand(graphics, args, canvas);

            // Assert
            Assert.IsTrue(squareCmd.error);
        }

        /// <summary>
        /// A test method to verify that the execution of the Square command with a valid radius successfuly draws a square.
        /// </summary>
        [TestMethod]
        public void Execute_DrawSquare_WithValidSideLength()
        {
            // Arrange
            var canvas = new Canvas();
            var squareCmd = new Square();
            string[] args = new string[] { "75" }; // Valid side length of 75
            var graphics = Graphics.FromImage(new Bitmap(150, 150));

            // Act
            squareCmd.ExecuteCommand(graphics, args, canvas);

            // Assert
            Assert.IsTrue(string.IsNullOrEmpty(canvas.CommandBox.Text));
            Console.WriteLine(squareCmd.error);
            Assert.IsFalse(squareCmd.error);
        }
    }
}
