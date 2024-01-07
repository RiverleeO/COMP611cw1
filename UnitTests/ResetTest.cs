using SimpleProgrammingLanguage;
using SimpleProgrammingLanguage.Commands;
using System.Drawing;

namespace UnitTests
{
    /// <summary>
    /// A test class to test the Reset command class.
    /// </summary>
    [TestClass]
    public class ResetTest
    {
        /// <summary>
        /// A test method to verify that the execution of the Reset command successfully resets the pen position to the default value on the canvas.
        /// </summary>
        [TestMethod]
        public void Execute_Reset()
        {
            // Arrange
            var canvas = new Canvas();
            var resetCmd = new Reset();

            // Act
            resetCmd.ExecuteCommand(canvas, null);

            // Assert
            Assert.AreEqual(new Point(50, 50), canvas.PenPosition);
        }
    }
}
