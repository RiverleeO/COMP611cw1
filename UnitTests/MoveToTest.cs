using SimpleProgrammingLanguage;
using SimpleProgrammingLanguage.Commands;
using System.Drawing;

namespace UnitTests
{
    /// <summary>
    /// A test class to test the MoveTo command class.
    /// </summary>
    [TestClass]
    public class MoveToTest
    {
        /// <summary>
        /// A test method to verify that the execution of the MoveTo command with invalid coordinates produces an error message.
        /// </summary>
        [TestMethod]
        public void Execute_MoveTo_WithInvalidCoords()
        {
            // Arrange
            var canvas = new Canvas();
            var moveToCmd = new MoveTo();
            string[] args = { "75", "invalidYCoord" }; // Invalid Y coordinate

            // Act
            moveToCmd.ExecuteCommand(canvas, args);

            // Assert
            Assert.IsTrue(moveToCmd.error);
        }

        /// <summary>
        /// A test method to verify that the execution of the MoveTo command with valid coordinates is successful.
        /// </summary>
        [TestMethod]
        public void Execute_MoveTo_WithValidCoords()
        {
            // Arrange
            var canvas = new Canvas();
            var moveToCmd = new MoveTo();
            string[] args = { "45", "75" };

            // Act
            moveToCmd.ExecuteCommand(canvas, args);

            // Assert
            Assert.AreEqual(new Point(45, 75), canvas.PenPosition);
            Assert.IsFalse(moveToCmd.error);
        }
    }
}

