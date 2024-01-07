using SimpleProgrammingLanguage;
using SimpleProgrammingLanguage.Commands.Shapes;
using System.Drawing;


namespace UnitTests
{
    /// <summary>
    /// A test class to test the Circle command class.
    /// </summary>
    [TestClass]
    public class DrawCircleTest
    {
        /// <summary>
        /// A test method to verify that the execution of the Circle command with an invalid radius produces an error message.
        /// </summary>
        [TestMethod]
        public void Execute_DrawCircle_WithInvalidRadius()
        {
            // Arrange
            var canvas = new Canvas();
            var circleCmd = new Circle();
            string[] args = { "thisIsAnInvalidRadius" }; // Invalid radius
            var draw = Graphics.FromImage(new Bitmap(150, 150));

            // Act
            circleCmd.ExecuteCommand(draw, args, canvas);

            // Assert
            Assert.IsTrue(circleCmd.error);
        }

        /// <summary>
        /// A test method to verify that the execution of the Circle command with a valid radius successfuly draws a circle.
        /// </summary>
        [TestMethod]
        public void Execute_DrawCircle_WithValidRadius()
        {
            // Arrange
            var canvas = new Canvas();
            var circleCmd = new Circle();
            string[] args = { "75" }; // Circle radius of 75
            var draw = Graphics.FromImage(new Bitmap(150, 150));

            // Act
            circleCmd.ExecuteCommand(draw, args, canvas);

            // Assert
            Assert.IsTrue(string.IsNullOrEmpty(canvas.CommandBox.Text));
            Assert.IsFalse(circleCmd.error);
        }
    }
}