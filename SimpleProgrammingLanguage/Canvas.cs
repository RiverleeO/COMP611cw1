using SimpleProgrammingLanguage.Commands;
using SimpleProgrammingLanguage;
using System.Diagnostics;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SimpleProgrammingLanguage
{
    /// <summary>
    /// The main class for the Canvas, whch is used for drawing
    /// </summary>
    public partial class Canvas : Form
    {
        private CommandParser commandParser;
        private Point penPosition = new Point(50, 50);
        private Pen drawPen = new Pen(Color.Black);
        private bool filling = false;
        private Color fillColour = Color.Black;

        public PenHandler penHandler;

        /// <summary>
        /// Initialises a new instance of the Canvas class.
        /// </summary>
        public Canvas()
        {
            InitializeComponent();
            commandParser = new CommandParser("");
            penHandler = new PenHandler(this);
        }

        /// <summary>
        /// Getter and setter to indidate whether or not filling mode is active.
        /// </summary>
        public bool Filling
        {
            get { return filling; }
            set { filling = value; }
        }

        /// <summary>
        /// Getter for the canvas picture box.
        /// </summary>
        public PictureBox CanvasBox
        {
            get { return pbCanvas; }
        }

        /// <summary>
        ///  Getter for the command text box.
        /// </summary>
        public TextBox CommandBox
        {
            get { return txtCmd; }
        }

        /// <summary>
        /// Getter and setter for the current position of the pen.
        /// </summary>
        public Point PenPosition
        {
            get { return penPosition; }
            set { penPosition = value; }
        }

        /// <summary>
        /// Getter and setter for the pen that is used to draw.
        /// </summary>
        public Pen DrawPen
        {
            get { return drawPen; }
            set { drawPen = value; }
        }

        /// <summary>
        /// Getter and setter for the fill colour for shapes.
        /// </summary>
        public Color FillColour
        {
            get { return fillColour; }
            set { fillColour = value; }
        }

        /// <summary>
        /// Represents the button click event that allows for importing programs or a series of commands by triggerig the Open File Dialog.
        /// </summary>
        private void btnImportProg_Click(object sender, EventArgs e)
        {
            OpenFileDialog importProgram;
            importProgram = new OpenFileDialog();
            if (importProgram.ShowDialog() == DialogResult.OK)
            {
                string[] progLines = File.ReadAllLines(importProgram.FileName);
                foreach (string progLine in progLines)
                {
                    lbCmdView.Items.Add(progLine);
                }
            }
        }

        /// <summary>
        /// Represents the button click event that executes the command in the command text box.
        /// </summary>
        private void btnRunCmd_Click(object sender, EventArgs e)
        {
            string cmd = txtCmd.Text;
            lbCmdView.Items.Add(cmd);
            CommandParser commandParser = new CommandParser(cmd);
            penHandler.ExecPenDrawing(commandParser);
            Debug.WriteLine("Executing " + cmd);
        }

        /// <summary>
        /// Represents the key up event that runs the run button click event when the Enter key is pressed.
        /// </summary>
        private void txtCmd_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnRunCmd_Click(sender, e);
            }
        }

        /// <summary>
        /// Represents the button click event that executes a single selected command from the listbox.
        /// </summary>
        private void btnRunSingleCmd_Click(object sender, EventArgs e)
        {
            if (lbCmdView.Items.Count > 0)
            {
                string selectedCmd = lbCmdView.GetItemText(lbCmdView.SelectedItem);

                if (selectedCmd != null)
                {
                    CommandParser commandParser = new CommandParser(selectedCmd);
                    penHandler.ExecPenDrawing(commandParser);
                }
                else
                {
                    MessageBox.Show("You must select a command before attempting to run. Select one from the imported program list.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        /// <summary>
        /// Represents the button click event that executes a program or series of commands in the listbox.
        /// </summary>
        private void btnRunProg_Click(object sender, EventArgs e)
        {
            if (lbCmdView.Items.Count > 0)
            {
                foreach (string cmdLine in lbCmdView.Items)
                {
                    CommandParser commandParser = new CommandParser(cmdLine);
                    penHandler.ExecPenDrawing(commandParser);
                }
            }
            else
            {
                MessageBox.Show("You must import a program before attempting to compile.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Represents the button click event that clears the command and program listbox.
        /// </summary>
        private void btnClearList_Click(object sender, EventArgs e)
        {
            if (lbCmdView.Items.Count > 0)
            {
                lbCmdView.Items.Clear();
            }
        }

        /// <summary>
        /// Represents the button click event that clears a selected command from the command and program listbox.
        /// </summary>
        private void btnClearCmd_Click(object sender, EventArgs e)
        {
            if (lbCmdView.Items.Count > 0)
            {
                string selectedCmd = lbCmdView.GetItemText(lbCmdView.SelectedItem);

                if (selectedCmd != null)
                {
                    lbCmdView.Items.Remove(selectedCmd);
                }
            }
        }

        /// <summary>
        /// Represents the button click event that executes the clear command to clear the canvas.
        /// </summary>
        private void btnClearCanvas_Click(object sender, EventArgs e)
        {
            var clearCmd = new Clear();
            clearCmd.ExecuteCommand(this, null);
        }

        /// <summary>
        /// Represents the load event that runs the canvas graphical interface.
        /// </summary>
        private void Canvas_Load(object sender, EventArgs e) { }
    }
}
