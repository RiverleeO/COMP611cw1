namespace SimpleProgrammingLanguage;

partial class Form1
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
        btnImportProg = new Button();
        btnSyntax = new Button();
        pbCanvas = new PictureBox();
        btnColour = new Button();
        btnRunCmd = new Button();
        btnRunProg = new Button();
        btnSingleCmd = new Button();
        btnClearProg = new Button();
        btnClearCmd = new Button();
        lbCmdView = new ListBox();
        ((System.ComponentModel.ISupportInitialize)pbCanvas).BeginInit();
        SuspendLayout();
        // 
        // txtCmd
        // 
        txtCmd.Location = new Point(41, 386);
        txtCmd.Name = "txtCmd";
        txtCmd.Size = new Size(321, 23);
        txtCmd.TabIndex = 0;
        // 
        // btnImportProg
        // 
        btnImportProg.Location = new Point(365, 109);
        btnImportProg.Name = "btnImportProg";
        btnImportProg.Size = new Size(159, 23);
        btnImportProg.TabIndex = 1;
        btnImportProg.Text = "Import Program";
        btnImportProg.UseVisualStyleBackColor = true;
        btnImportProg.Click += button1_Click;
        // 
        // btnSyntax
        // 
        btnSyntax.Location = new Point(365, 138);
        btnSyntax.Name = "btnSyntax";
        btnSyntax.Size = new Size(159, 23);
        btnSyntax.TabIndex = 2;
        btnSyntax.Text = "Check Syntax";
        btnSyntax.UseVisualStyleBackColor = true;
        // 
        // pbCanvas
        // 
        pbCanvas.Location = new Point(578, 109);
        pbCanvas.Name = "pbCanvas";
        pbCanvas.Size = new Size(288, 271);
        pbCanvas.TabIndex = 4;
        pbCanvas.TabStop = false;
        // 
        // btnColour
        // 
        btnColour.Location = new Point(578, 386);
        btnColour.Name = "btnColour";
        btnColour.Size = new Size(97, 23);
        btnColour.TabIndex = 5;
        btnColour.Text = "Change Colour";
        btnColour.UseVisualStyleBackColor = true;
        // 
        // btnRunCmd
        // 
        btnRunCmd.Location = new Point(368, 386);
        btnRunCmd.Name = "btnRunCmd";
        btnRunCmd.Size = new Size(99, 23);
        btnRunCmd.TabIndex = 6;
        btnRunCmd.Text = "Run Command";
        btnRunCmd.UseVisualStyleBackColor = true;
        // 
        // btnRunProg
        // 
        btnRunProg.Location = new Point(368, 177);
        btnRunProg.Name = "btnRunProg";
        btnRunProg.Size = new Size(156, 23);
        btnRunProg.TabIndex = 7;
        btnRunProg.Text = "Run Program";
        btnRunProg.UseVisualStyleBackColor = true;
        // 
        // btnSingleCmd
        // 
        btnSingleCmd.Location = new Point(368, 206);
        btnSingleCmd.Name = "btnSingleCmd";
        btnSingleCmd.Size = new Size(156, 23);
        btnSingleCmd.TabIndex = 8;
        btnSingleCmd.Text = "Run Single Command";
        btnSingleCmd.UseVisualStyleBackColor = true;
        // 
        // btnClearProg
        // 
        btnClearProg.Location = new Point(368, 248);
        btnClearProg.Name = "btnClearProg";
        btnClearProg.Size = new Size(156, 23);
        btnClearProg.TabIndex = 9;
        btnClearProg.Text = "Clear Program";
        btnClearProg.UseVisualStyleBackColor = true;
        // 
        // btnClearCmd
        // 
        btnClearCmd.Location = new Point(368, 277);
        btnClearCmd.Name = "btnClearCmd";
        btnClearCmd.Size = new Size(156, 23);
        btnClearCmd.TabIndex = 10;
        btnClearCmd.Text = "Clear Command";
        btnClearCmd.UseVisualStyleBackColor = true;
        // 
        // lbCmdView
        // 
        lbCmdView.FormattingEnabled = true;
        lbCmdView.ItemHeight = 15;
        lbCmdView.Location = new Point(41, 109);
        lbCmdView.Name = "lbCmdView";
        lbCmdView.Size = new Size(318, 274);
        lbCmdView.TabIndex = 11;
        lbCmdView.SelectedIndexChanged += lbCmdView_SelectedIndexChanged;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(916, 450);
        Controls.Add(lbCmdView);
        Controls.Add(btnClearCmd);
        Controls.Add(btnClearProg);
        Controls.Add(btnSingleCmd);
        Controls.Add(btnRunProg);
        Controls.Add(btnRunCmd);
        Controls.Add(btnColour);
        Controls.Add(pbCanvas);
        Controls.Add(btnSyntax);
        Controls.Add(btnImportProg);
        Controls.Add(txtCmd);
        Name = "Form1";
        Text = "#'#'";
        ((System.ComponentModel.ISupportInitialize)pbCanvas).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private TextBox txtCmd;
    private Button btnImportProg;
    private Button btnSyntax;
    private PictureBox pbCanvas;
    private Button btnColour;
    private Button btnRunCmd;
    private Button btnRunProg;
    private Button btnSingleCmd;
    private Button btnClearProg;
    private Button btnClearCmd;
    private ListBox lbCmdView;
}
