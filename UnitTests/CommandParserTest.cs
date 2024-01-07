using SimpleProgrammingLanguage;

namespace UnitTests
{
    /// <summary>
    /// A test class to test the CommandParser class.
    /// </summary>
    [TestClass]
    public class CommandParserTest
    {
        /// <summary>
        /// A test method to verify that commands with no arguments parse successfully.
        /// </summary>
        [TestMethod]
        public void ParseCommand_CommandWithEmptyArgument()
        {
            // Arrange
            string cmd = "CLEAR";

            // Act
            var cmdParser = new CommandParser(cmd);

            // Assert
            Assert.AreEqual("CLEAR", cmdParser.Cmd); // Expects the 'CLEAR' command
            CollectionAssert.AreEqual(new string[0], cmdParser.Args); // Expects empty args
        }

        /// <summary>
        /// A test method to verify that the parser correctly throws a warning when no command or arguments are parsed.
        /// </summary>
        [TestMethod]
        public void ParseCommand_WithEmptyCommandAndArgument()
        {
            // Arrange
            string cmd = "";

            // Act
            var cmdParser = new CommandParser(cmd);

            // Assert
            Assert.AreEqual("", cmdParser.Cmd); // Expects empty command
            CollectionAssert.AreEqual(new string[0], cmdParser.Args); // Expects empty args
        }

        /// <summary>
        /// A test method to verify that the parser correctly parses commands with a single argument.
        /// </summary>
        [TestMethod]
        public void ParseCommand_CommandWithSingleArgument()
        {
            // Arrange
            string cmd = "PEN BLUE";

            // Act
            var cmdParser = new CommandParser(cmd);

            // Assert
            Assert.AreEqual("PEN", cmdParser.Cmd);
        }

        /// <summary>
        /// A test method to verify that the parser correctly parses commands with multiple arguments.
        /// </summary>
        [TestMethod]
        public void ParseCommandAndArgs()
        {
            // Arrange
            string cmd = "DRAW 45 75";

            // Act
            var cmdParser = new CommandParser(cmd);

            // Assert
            Assert.AreEqual("DRAW", cmdParser.Cmd); // Expects the 'DRAW' command
            CollectionAssert.AreEqual(new string[] { "45", "75" }, cmdParser.Args); // Expects arguments with XY coords of 45 and 75
        }
    }
}
