using SimpleProgrammingLanguage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleProgrammingLanguage
{
    /// <summary>
    /// A class that represents the Program Editor form, which is used to open, save, edit and run program code.
    /// </summary>
    public partial class ProgramEditor : Form
    {
        private Canvas canvas; // the canvas object

        private bool progSaveState; // defines the save state of the program code file
        private string progName; // defines the name of the saved program code file

        /// <summary>
        /// Initialises a new instance of the ProgramEditor class and references the canvas object.
        /// </summary>
        /// <param name="canvas">The canvas object that is drawn on.</param>
        public ProgramEditor(Canvas canvas)
        {
            InitializeComponent();
            this.canvas = canvas;
        }

        /// <summary>
        /// The event handler that listens for the load event of the ProgramEditor form.
        /// </summary>
        private void ProgramEditor_Load(object sender, EventArgs e)
        {
            progSaveState = false; // sets the save state of the program code file to false
            progName = ""; // sets the name of the program code file to a blank string
        }

        /// <summary>
        /// The event handler that listens for a click event of the 'New' button within the 'File' tool strip menu.
        /// </summary>
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (progSaveState == false) // if the save state is false, the user is warned that recent changes haven't been saved and whether they wish to continue
            {
                DialogResult dialogResult = MessageBox.Show("You have not saved recent changes. Are you sure you want to close the current program?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes) // if yes, the editor is cleared
                {
                    saveToolStripMenuItem.Enabled = false;
                    rtbProgText.Clear();
                }
            }
            else // if save state is true, then the editor is cleared
            {
                saveToolStripMenuItem.Enabled = false;
                rtbProgText.Clear();
            }
        }

        /// <summary>
        /// The event handler that listens for a click event of the 'Open' button within the 'File' tool strip menu.
        /// </summary>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openDialog = new OpenFileDialog())
            {
                openDialog.Filter = "Pen Program|*.prog";
                openDialog.Title = "Open Program File";

                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    progName = openDialog.FileName;

                    try
                    {
                        string progCont = File.ReadAllText(progName);
                        rtbProgText.Text = progCont;
                        saveToolStripMenuItem.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occured while attempting to open the program file. /nException: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// The event haandler that listens for a click event of the 'Save' button within the 'File' tool strip menu.
        /// </summary>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                File.WriteAllText(progName, rtbProgText.Text);
                progSaveState = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occured while saving the file. \nException: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// The event handler that listens for a click event of the 'Save As' button within the 'File' tool strip menu.
        /// </summary>
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveAsDialog = new SaveFileDialog())
            {
                saveAsDialog.Filter = "Pen Program|*.prog";
                saveAsDialog.Title = "Save Script File";

                if (saveAsDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = saveAsDialog.FileName;
                    try
                    {
                        File.WriteAllText(fileName, rtbProgText.Text);
                        MessageBox.Show("Program saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        progSaveState = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occured while saving the file. \nException: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// The event handler that listens for a click event of the 'Exit' button within the 'File' tool strip menu.
        /// </summary>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (progSaveState == false)
            {
                DialogResult dialogResult = MessageBox.Show("You have not saved recent changes. Are you sure you want to close the editor?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    saveToolStripMenuItem.Enabled = false;
                    this.Close();
                }
            }
            else
            {
                saveToolStripMenuItem.Enabled = false;
                this.Close();
            }
        }

        /// <summary>
        /// The event handler that listens for a click event of the 'Run' button within the 'Program' tool strip menu
        /// </summary>
        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string progCont = rtbProgText.Text;

            ProgramHandler programHandler = new ProgramHandler(canvas);
            programHandler.ExecuteProgram(progCont);
        }

        /// <summary>
        /// The event handler that listens for a KeyDown event within the RichTextBox editor.
        /// </summary>
        private void rtbProgText_KeyDown(object sender, KeyEventArgs e)
        {
            progSaveState = false;
            Console.WriteLine(e.KeyData);
        }
    }
}