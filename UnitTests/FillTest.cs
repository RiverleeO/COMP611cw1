using SimpleProgrammingLanguage;
using SimpleProgrammingLanguage.Commands;

namespace UnitTests
{
    /// <summary>
    /// A test class to test the Fill command class.
    /// </summary>
    [TestClass]
    public class FillTest
    {
        /// <summary>
        /// A test method to verify that the execution of the Fill command results in toggling the fill mode off.
        /// </summary>
        [TestMethod]
        public void Execute_ToggleFillModeOff()
        {
            // Arrange
            var canvas = new Canvas();
            var fillCmd = new Fill();
            string[] args = { "off" };

            // Act
            fillCmd.ExecuteCommand(canvas, args);

            // Assert
            Assert.IsFalse(canvas.Filling);
        }

        /// <summary>
        /// A test method to verify that the execution of the Fill command results in toggling the fill mode on.
        /// </summary>
        [TestMethod]
        public void Execute_ToggleFillModeOn()
        {
            // Arrange
            var canvas = new Canvas();
            var fillCmd = new Fill();
            string[] args = { "on" };

            // Act
            fillCmd.ExecuteCommand(canvas, args);

            // Assert
            Assert.IsTrue(canvas.Filling);
        }
    }
}
