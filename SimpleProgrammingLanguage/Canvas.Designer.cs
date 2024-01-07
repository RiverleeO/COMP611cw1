using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SimpleProgrammingLanguage
{
    partial class Canvas
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtCmd = new TextBox();
            btnRunCmd = new Button();
            btnSyntax = new Button();
            btnImportProg = new Button();
            pbCanvas = new PictureBox();
            btnRunProg = new Button();
            lbCmdView = new ListBox();
            colorDialog1 = new ColorDialog();
            btnRunSingleCmd = new Button();
            btnClearProg = new Button();
            btnClearCmd = new Button();
            label1 = new Label();
            lblCmdList = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            btnClearCanvas = new Button();
            ((System.ComponentModel.ISupportInitialize)pbCanvas).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // txtCmd
            // 
            txtCmd.Location = new Point(36, 568);
            txtCmd.Name = "txtCmd";
            txtCmd.Size = new Size(348, 23);
            txtCmd.TabIndex = 0;
            // 
            // btnRunCmd
            // 
            btnRunCmd.BackColor = Color.Gainsboro;
            btnRunCmd.Location = new Point(390, 568);
            btnRunCmd.Name = "btnRunCmd";
            btnRunCmd.Size = new Size(132, 23);
            btnRunCmd.TabIndex = 1;
            btnRunCmd.Text = "Run Command";
            btnRunCmd.UseVisualStyleBackColor = false;
            btnRunCmd.Click += btnRunCmd_Click;
            // 
            // btnSyntax
            // 
            btnSyntax.BackColor = Color.Gainsboro;
            btnSyntax.Location = new Point(389, 117);
            btnSyntax.Name = "btnSyntax";
            btnSyntax.Size = new Size(132, 23);
            btnSyntax.TabIndex = 2;
            btnSyntax.Text = "Check Syntax";
            btnSyntax.UseVisualStyleBackColor = false;
            // 
            // btnImportProg
            // 
            btnImportProg.BackColor = Color.Gainsboro;
            btnImportProg.Location = new Point(389, 88);
            btnImportProg.Name = "btnImportProg";
            btnImportProg.Size = new Size(132, 23);
            btnImportProg.TabIndex = 3;
            btnImportProg.Text = "Import Program";
            btnImportProg.UseVisualStyleBackColor = false;
            btnImportProg.Click += btnImportProg_Click;
            // 
            // pbCanvas
            // 
            pbCanvas.BackColor = Color.White;
            pbCanvas.BorderStyle = BorderStyle.FixedSingle;
            pbCanvas.Location = new Point(566, 88);
            pbCanvas.Name = "pbCanvas";
            pbCanvas.Size = new Size(1000, 550);
            pbCanvas.TabIndex = 5;
            pbCanvas.TabStop = false;
            // 
            // btnRunProg
            // 
            btnRunProg.BackColor = Color.Gainsboro;
            btnRunProg.Location = new Point(389, 162);
            btnRunProg.Name = "btnRunProg";
            btnRunProg.Size = new Size(132, 23);
            btnRunProg.TabIndex = 7;
            btnRunProg.Text = "Run Program";
            btnRunProg.UseVisualStyleBackColor = false;
            btnRunProg.Click += btnRunProg_Click;
            // 
            // lbCmdView
            // 
            lbCmdView.FormattingEnabled = true;
            lbCmdView.ItemHeight = 15;
            lbCmdView.Location = new Point(35, 88);
            lbCmdView.Name = "lbCmdView";
            lbCmdView.Size = new Size(348, 514);
            lbCmdView.TabIndex = 8;
            lbCmdView.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // btnRunSingleCmd
            // 
            btnRunSingleCmd.BackColor = Color.Gainsboro;
            btnRunSingleCmd.Location = new Point(389, 191);
            btnRunSingleCmd.Name = "btnRunSingleCmd";
            btnRunSingleCmd.Size = new Size(132, 23);
            btnRunSingleCmd.TabIndex = 9;
            btnRunSingleCmd.Text = "Run Single Command";
            btnRunSingleCmd.UseVisualStyleBackColor = false;
            btnRunSingleCmd.Click += btnRunSingleCmd_Click;
            // 
            // btnClearProg
            // 
            btnClearProg.BackColor = Color.Gainsboro;
            btnClearProg.Location = new Point(389, 236);
            btnClearProg.Name = "btnClearProg";
            btnClearProg.Size = new Size(132, 23);
            btnClearProg.TabIndex = 10;
            btnClearProg.Text = "Clear Program";
            btnClearProg.UseVisualStyleBackColor = false;
            // 
            // btnClearCmd
            // 
            btnClearCmd.BackColor = Color.Gainsboro;
            btnClearCmd.Location = new Point(389, 265);
            btnClearCmd.Name = "btnClearCmd";
            btnClearCmd.Size = new Size(132, 23);
            btnClearCmd.TabIndex = 11;
            btnClearCmd.Text = "Clear Command";
            btnClearCmd.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Turquoise;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(30, 14);
            label1.Name = "label1";
            label1.Size = new Size(241, 25);
            label1.TabIndex = 12;
            label1.Text = "Command Canvas Drawer";
            label1.Click += label1_Click;
            // 
            // lblCmdList
            // 
            lblCmdList.AutoSize = true;
            lblCmdList.BackColor = Color.Gainsboro;
            lblCmdList.Location = new Point(34, 67);
            lblCmdList.Name = "lblCmdList";
            lblCmdList.Size = new Size(85, 15);
            lblCmdList.TabIndex = 13;
            lblCmdList.Text = "Command List";
            lblCmdList.Click += lblCmdList_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Turquoise;
            panel1.Location = new Point(-2, -2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1608, 50);
            panel1.TabIndex = 14;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Gainsboro;
            panel2.Controls.Add(btnClearCanvas);
            panel2.Controls.Add(btnRunCmd);
            panel2.Controls.Add(txtCmd);
            panel2.Location = new Point(-1, 47);
            panel2.Name = "panel2";
            panel2.Size = new Size(532, 676);
            panel2.TabIndex = 15;
            // 
            // btnClearCanvas
            // 
            btnClearCanvas.Location = new Point(390, 533);
            btnClearCanvas.Name = "btnClearCanvas";
            btnClearCanvas.Size = new Size(132, 23);
            btnClearCanvas.TabIndex = 16;
            btnClearCanvas.Text = "Clear Canvas";
            btnClearCanvas.UseVisualStyleBackColor = true;
            // 
            // Canvas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1343, 710);
            Controls.Add(lblCmdList);
            Controls.Add(label1);
            Controls.Add(btnClearCmd);
            Controls.Add(btnClearProg);
            Controls.Add(btnRunSingleCmd);
            Controls.Add(lbCmdView);
            Controls.Add(btnRunProg);
            Controls.Add(pbCanvas);
            Controls.Add(btnImportProg);
            Controls.Add(btnSyntax);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Name = "Canvas";
            Text = "Canvas Drawer";
            Load += Canvas_Load;
            ((System.ComponentModel.ISupportInitialize)pbCanvas).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtCmd;
        private Button btnRunCmd;
        private Button btnSyntax;
        private Button btnImportProg;
        private PictureBox pbCanvas;
        private Button btnRunProg;
        private ListBox lbCmdView;
        private ColorDialog colorDialog1;
        private Button btnRunSingleCmd;
        private Button btnClearProg;
        private Button btnClearCmd;
        private Label label1;
        private Label lblCmdList;
        private Panel panel1;
        private Panel panel2;
        private Button btnClearCanvas;
    }
}
