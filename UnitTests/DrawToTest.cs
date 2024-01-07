using SimpleProgrammingLanguage;
using SimpleProgrammingLanguage.Commands;
using System.Drawing;

namespace UnitTests
{
    /// <summary>
    /// A test class to test the DrawTo command class.
    /// </summary>
    [TestClass]
    public class DrawToTest
    {
        /// <summary>
        /// A test method to verify that the DrawTo command throws an error message when invalid coordinates are provided.
        /// </summary>
        [TestMethod]
        public void Execute_DrawTo_WithInvalidCoords()
        {
            // Arrange
            var canvas = new Canvas();
            var drawToCmd = new DrawTo();
            string[] args = { "45", "invalidYCoord" };

            // Act
            drawToCmd.ExecuteCommand(canvas, args);

            // Assert
            Assert.IsTrue(drawToCmd.error);
        }

        /// <summary>
        /// A test method to verify that the DrawTo command executes successfully when valid coordinates are provided.
        /// </summary>
        [TestMethod]
        public void Execute_DrawTo_WithValidCoords()
        {
            // Arrange
            var canvas = new Canvas();
            var drawToCmd = new DrawTo();
            string[] args = { "45", "75" };

            // Act
            drawToCmd.ExecuteCommand(canvas, args);

            //Assert
            Assert.AreEqual(new Point(45, 75), canvas.PenPosition);
            Assert.IsFalse(drawToCmd.error);
        }
    }
}
