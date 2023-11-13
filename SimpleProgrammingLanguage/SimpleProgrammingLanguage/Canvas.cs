using SimpleProgrammingLanguage;
using System.Diagnostics;
using System.Windows.Forms;

namespace SimpleProgrammingLanguage
{
    public partial class Canvas : Form
    {
        private CommandParser commandParser;
        private Point penPosition = new Point(40, 40);
        private Pen drawPen = new Pen(Color.Black);
        //private int penWidth = 2;
        private bool filling = false;
        private Color fillColour = Color.Black;

        public PenHandler penHandler;

        public Canvas()
        {
            InitializeComponent();
            commandParser = new CommandParser("");
            penHandler = new PenHandler(this);
        }

        public bool Filling
        {
            get { return filling; }
            set { filling = value; }
        }

        public PictureBox CanvasBox
        {
            get { return pbCanvas; }
        }

        public TextBox CommandBox
        {
            get { return txtCmd; }
        }

        public Point PenPosition
        {
            get { return penPosition; }
            set { penPosition = value; }
        }

        public Pen DrawPen
        {
            get { return drawPen; }
            set { drawPen = value; }
        }

        public Color FillColour
        {
            get { return fillColour; }
            set { fillColour = value; }
        }

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

        private void btnRunCmd_Click(object sender, EventArgs e)
        {
            string cmd = txtCmd.Text;
            //lbCmdView.Items.Add(cmd);
            CommandParser commandParser = new CommandParser(cmd);
            penHandler.ExecPenDrawing(commandParser);
            Debug.WriteLine("Executing " + cmd);
        }

        private void btnColour_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                //colour = colorDialog1.Color;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Canvas_Load(object sender, EventArgs e) { }

        private void lblCmdList_Click(object sender, EventArgs e)
        {

        }

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
    }
}