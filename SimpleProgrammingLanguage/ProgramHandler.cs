using SimpleProgrammingLanguage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SimpleProgrammingLanguage
{
    /// <summary>
    /// A class which represents the handling of program operations.
    /// </summary>
    public class ProgramHandler
    {
        private Canvas canvas; // the canvas object

        /// <summary>
        /// Initialises a new instance of the ProgramHandler class and references the canvas object
        /// </summary>
        /// <param name="canvas"></param>
        public ProgramHandler(Canvas canvas)
        {
            this.canvas = canvas;
        }

        /// <summary>
        /// Executes the program.
        /// </summary>
        /// <param name="progCont">The content of the program.</param>
        public void ExecuteProgram(string progCont)
        {
            int currLine = 0;
            var progVars = new Dictionary<string, int>();
            string[] progLines = progCont.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            while (currLine < progLines.Length)
            {
                string progLine = progLines[currLine].Trim();

                if (IsVar(progLine))
                {
                    VariableHandler(progLine, progVars);
                    currLine++;
                    continue;
                }

                if (IsWhileLoop(progLine))
                {
                    currLine = WhileLoop(progLines, currLine, progVars);
                    continue;
                }

                if (IsIfStatement(progLine))
                {
                    currLine = IfStatement(progLines, currLine, progVars);
                    continue;
                }

                if (IsElseStatement(progLine))
                {
                    currLine = ElseStatement(progLines, currLine, progVars);
                }

                if (IsEndIfStatement(progLine))
                {
                    currLine++;
                    continue;
                }

                if (IsEndElseStatement(progLine))
                {
                    currLine++;
                    continue;
                }

                if (IsValidCommand(progLine))
                {
                    CommandParser parser = new CommandParser(progLine);
                    canvas.penHandler.ExecPenDrawing(parser);
                }
            }

        }

        /// <summary>
        /// Checks to see if the command is valid.
        /// </summary>
        /// <param name="progLine">The line which is being checked to contained the command.</param>
        /// <returns></returns>
        private bool IsValidCommand(string progLine)
        {
            string cmd = progLine.Split(' ')[0].ToUpper();
            var validCmds = new HashSet<string>
            {
                "PEN",
                "DRAWTO",
                "MOVETO",
                "FILL",
                "CLEAR",
                "RESET",
                "CIRCLE",
                "RECTANGLE",
                "SQUARE",
                "TRIANGLE",
                "ROTATEDRECTANGLE",
                "ROTATEDTRIANGLE"
            };

            return validCmds.Contains(cmd);
        }

        /// <summary>
        /// Checks to see if the line contains a condition.
        /// </summary>
        /// <param name="condition">The condition which is being checked.</param>
        /// <param name="progVars">The variable that is being checked.</param>
        /// <returns></returns>
        private bool IsCondition(string condition, Dictionary<string, int> progVars)
        {
            string[] condSplit = condition.Split(new[] { '!', '=', '<', '>' }, 2);

            if (condSplit.Length == 2)
            {
                string varName = condSplit[0].Trim();
                string varSplitValue = condSplit[1].Trim();

                if (progVars.TryGetValue(varName, out int varValue))
                {
                    if (int.TryParse(varSplitValue, out int condValue))
                    {
                        switch (condition) // check which condition is being used
                        {
                            case string i when i.Contains("=="): return varValue == condValue;
                            case string i when i.Contains("!="): return varValue != condValue;
                            case string i when i.Contains("<"): return varValue < condValue;
                            case string i when i.Contains(">"): return varValue > condValue;
                            case string i when i.Contains("<="): return varValue <= condValue;
                            case string i when i.Contains(">="): return varValue >= condValue;
                        }
                    }

                    else
                    {
                        MessageBox.Show($"Warning! Expected int in condition {varSplitValue}.", "Syntax Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                else
                {
                    MessageBox.Show($"Warning! Variable {varName} is not defined.", "Syntax Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            else
            {
                MessageBox.Show($"Warning! {condition} is not an expected condition.", "Syntax Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return false;
        }

        /// <summary>
        /// Checks if the line is defining a variable.
        /// </summary>
        /// <param name="progLine">The line which is being checked to contain the variable.</param>
        /// <returns></returns>
        private bool IsVar(string progLine)
        {
            return progLine.Contains("="); // if the line contains an equals, it is indicative of setting a variable, so return true
        }

        /// <summary>
        /// Checks if the line starts with "While", indicating the start of a While loop block.
        /// </summary>
        /// <param name="progLine">The line that is being checked to contain a While loop.</param>
        /// <returns></returns>
        private bool IsWhileLoop(string progLine)
        {
            return progLine.StartsWith("While");
        }

        /// <summary>
        /// Checks if the line starts with "If", indicating the start of an If statement block.
        /// </summary>
        /// <param name="progLine">The line that is being checked to contain an If statement.</param>
        /// <returns></returns>
        private bool IsIfStatement(string progLine)
        {
            return progLine.StartsWith("If");
        }

        /// <summary>
        /// Checks if the line equals "Else", indicating the start of an Else clause block.
        /// </summary>
        /// <param name="progLine">The line that is being checked to contain an Else clause.</param>
        /// <returns></returns>
        private bool IsElseStatement(string progLine)
        {
            return progLine == "Else";
        }

        /// <summary>
        /// Checks if the line equals "EndIf", indiating the end of an If statement block.
        /// </summary>
        /// <param name="progLine">The line that is being checked to contain the EndIf keyword.</param>
        /// <returns></returns>
        private bool IsEndIfStatement(string progLine)
        {
            return progLine == "EndIf";
        }

        /// <summary>
        /// Checks if the line equals "EndElse", indicating the end of an Else clause block.
        /// </summary>
        /// <param name="progLine">The current line.</param>
        /// <returns></returns>
        private bool IsEndElseStatement(string progLine)
        {
            return progLine == "EndElse";
        }

        /// <summary>
        /// Finds the line which contains "EndWhile", which indicated the end of a While loop block.
        /// </summary>
        /// <param name="progLines">A string array of lines from the program.</param>
        /// <param name="progStartLine">The first line of the While loop block.</param>
        /// <returns></returns>
        private int EndWhileLoopLine(string[] progLines, int progStartLine)
        {
            try
            {
                for (int i = progStartLine + 1; i < progLines.Length; i++)
                {
                    if (progLines[i].Trim() == "EndWhile")
                    {
                        return i;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Warning! Expected \"EndWhile\" statement at line {progStartLine}.", "Syntax Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Console.WriteLine(ex);
            }

            return -1;
        }

        /// <summary>
        /// Finds if the line equals "EndIf", indiating the end of an If statement block.
        /// </summary>
        /// <param name="progLines">A string array of lines from the program.</param>
        /// <param name="progStartLine">The first line of the If statement block.</param>
        /// <returns></returns>
        private int EndIfStatementLine(string[] progLines, int progStartLine)
        {
            try
            {
                for (int i = progStartLine + 1; i < progLines.Length; i++)
                {
                    if (progLines[i].Trim() == "EndIf")
                    {
                        return i;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Warning! Expected \"EndIf\" statement at line {progStartLine}.", "Syntax Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Console.WriteLine(ex);
            }

            return -1;
        }

        /// <summary>
        /// Finds if the line equals "EndElse", indicating the end of an Else clause block.
        /// </summary>
        /// <param name="progLines">A string array of lines from the program.</param>
        /// <param name="progStartLine">The first line of the Else clause block.</param>
        /// <returns></returns>
        private int EndElseStatement(string[] progLines, int progStartLine)
        {
            try
            {
                for (int i = progStartLine + 1; i < progLines.Length; i++)
                {
                    if (progLines[i].Trim() == "EndElse")
                    {
                        return i;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured. Expected \"EndElse\" statement at line " + progStartLine + ".");
                Console.WriteLine(ex);
            }

            return -1;
        }

        /// <summary>
        /// Handles the variables within a program.
        /// </summary>
        /// <param name="progLine">The content of the line.</param>
        /// <param name="progVars">The dictionary of program variables.</param>
        private void VariableHandler(string progLine, Dictionary<string, int> progVars)
        {
            string[] varSplit = progLine.Split("=");

            if (varSplit.Length == 2)
            {
                string varName = varSplit[0].Trim();

                if (int.TryParse(varSplit[1].Trim(), out int varValue))
                {
                    progVars[varName] = varValue;
                }

                else
                {
                    MessageBox.Show($"Warning! Expected int variable assignment at line {progLine}.", "Syntax Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            else
            {
                MessageBox.Show($"Warning! Invalid syntax at line {progLine}.", "Syntax Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Handles the execution of program while loops.
        /// </summary>
        /// <param name="progLines"></param>
        /// <param name="progStartLine"></param>
        /// <param name="loopVars"></param>
        /// <returns></returns>
        private int WhileLoop(string[] progLines, int progStartLine, Dictionary<string, int> loopVars)
        {
            int endLine = EndWhileLoopLine(progLines, progStartLine);
            int currLine = progStartLine + 1;
            string loopCondition = progLines[progStartLine].Substring(6);
            string loopLine = progLines[currLine].Trim();

            while (IsCondition(loopCondition, loopVars))
            {
                while (currLine < endLine)
                {
                    if (IsValidCommand(loopLine))
                    {
                        CommandParser parser = new CommandParser(loopLine);
                        canvas.penHandler.ExecPenDrawing(parser);
                    }

                    currLine++;
                }

                currLine = progStartLine + 1;
            }

            return endLine + 1;
        }

        /// <summary>
        /// Handles the execution of program if statements.
        /// </summary>
        /// <param name="progLines"></param>
        /// <param name="progStartLine"></param>
        /// <param name="ifVars"></param>
        /// <returns></returns>
        private int IfStatement(string[] progLines, int progStartLine, Dictionary<string, int> ifVars)
        {
            int endLine = EndIfStatementLine(progLines, progStartLine);
            string ifCondition = progLines[progStartLine].Substring(2).Trim();

            if (IsCondition(ifCondition, ifVars))
            {
                int currLine = progStartLine + 1;
                while (currLine < endLine)
                {
                    string ifLine = progLines[currLine].Trim();

                    if (IsValidCommand(ifLine))
                    {
                        CommandParser parser = new CommandParser(ifLine);
                        canvas.penHandler.ExecPenDrawing(parser);
                    }

                    else if (IsVar(ifLine))
                    {
                        VariableHandler(ifLine, ifVars);
                    }

                    currLine++;
                }
            }

            return endLine + 1;
        }

        /// <summary>
        /// Handles the execution of program else clauses.
        /// </summary>
        /// <param name="progLines"></param>
        /// <param name="progStartLine"></param>
        /// <param name="ifVars"></param>
        /// <returns></returns>
        private int ElseStatement(string[] progLines, int progStartLine, Dictionary<string, int> ifVars)
        {
            int endLine = EndElseStatement(progLines, progStartLine);

            int currLine = progStartLine + 1;
            while (currLine < endLine)
            {
                string elseLine = progLines[currLine].Trim();

                if (IsValidCommand(elseLine))
                {
                    CommandParser parser = new CommandParser(elseLine);
                    canvas.penHandler.ExecPenDrawing(parser);
                }

                else if (IsVar(elseLine))
                {
                    VariableHandler(elseLine, ifVars);
                }

                currLine++;
            }

            return endLine + 1;
        }
    }
}