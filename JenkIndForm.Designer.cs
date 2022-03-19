namespace gta5refactor
{
    partial class JenkIndForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ScriptFolderBrowseButton = new System.Windows.Forms.Button();
            this.ScriptFolderTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.JenkIndFolderBrowseButton = new System.Windows.Forms.Button();
            this.JenkIndFolderTextBox = new System.Windows.Forms.TextBox();
            this.SignedCheckBox = new System.Windows.Forms.CheckBox();
            this.HexCheckBox = new System.Windows.Forms.CheckBox();
            this.BeginButton = new System.Windows.Forms.Button();
            this.FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.AbortButton = new System.Windows.Forms.Button();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.UniqueHashesTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.UniqueScriptHashesLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TotalScriptHashesLabel = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.label8 = new System.Windows.Forms.Label();
            this.UniqueHashMatchesLabel = new System.Windows.Forms.Label();
            this.HashMatchesTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TotalHashMatchesLabel = new System.Windows.Forms.Label();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.HashCollisionsTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.HashCollisionsLabel = new System.Windows.Forms.Label();
            this.TotalMissesLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ScriptChangesTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.FilesModifiedLabel = new System.Windows.Forms.Label();
            this.TotalChangesLabel = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.ProblemsTextBox = new System.Windows.Forms.TextBox();
            this.MinLengthUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.UnsignedCheckBox = new System.Windows.Forms.CheckBox();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.UpdateFormatComboBox = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.InsertBeforeRadioButton = new System.Windows.Forms.RadioButton();
            this.InsertAfterRadioButton = new System.Windows.Forms.RadioButton();
            this.label12 = new System.Windows.Forms.Label();
            this.ThresholdUpDown = new System.Windows.Forms.NumericUpDown();
            this.UpdateScriptsButton = new System.Windows.Forms.Button();
            this.ReplaceRadioButton = new System.Windows.Forms.RadioButton();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MinLengthUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ThresholdUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // ScriptFolderBrowseButton
            // 
            this.ScriptFolderBrowseButton.Location = new System.Drawing.Point(323, 10);
            this.ScriptFolderBrowseButton.Name = "ScriptFolderBrowseButton";
            this.ScriptFolderBrowseButton.Size = new System.Drawing.Size(27, 23);
            this.ScriptFolderBrowseButton.TabIndex = 1;
            this.ScriptFolderBrowseButton.Text = "...";
            this.ScriptFolderBrowseButton.UseVisualStyleBackColor = true;
            this.ScriptFolderBrowseButton.Click += new System.EventHandler(this.ScriptFolderBrowseButton_Click);
            // 
            // ScriptFolderTextBox
            // 
            this.ScriptFolderTextBox.Location = new System.Drawing.Point(66, 12);
            this.ScriptFolderTextBox.Name = "ScriptFolderTextBox";
            this.ScriptFolderTextBox.Size = new System.Drawing.Size(251, 20);
            this.ScriptFolderTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Scripts:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "JenkInd:";
            // 
            // JenkIndFolderBrowseButton
            // 
            this.JenkIndFolderBrowseButton.Location = new System.Drawing.Point(323, 36);
            this.JenkIndFolderBrowseButton.Name = "JenkIndFolderBrowseButton";
            this.JenkIndFolderBrowseButton.Size = new System.Drawing.Size(27, 23);
            this.JenkIndFolderBrowseButton.TabIndex = 3;
            this.JenkIndFolderBrowseButton.Text = "...";
            this.JenkIndFolderBrowseButton.UseVisualStyleBackColor = true;
            this.JenkIndFolderBrowseButton.Click += new System.EventHandler(this.JenkIndFolderBrowseButton_Click);
            // 
            // JenkIndFolderTextBox
            // 
            this.JenkIndFolderTextBox.Location = new System.Drawing.Point(66, 38);
            this.JenkIndFolderTextBox.Name = "JenkIndFolderTextBox";
            this.JenkIndFolderTextBox.Size = new System.Drawing.Size(251, 20);
            this.JenkIndFolderTextBox.TabIndex = 2;
            this.JenkIndFolderTextBox.TextChanged += new System.EventHandler(this.JenkIndFolderTextBox_TextChanged);
            // 
            // SignedCheckBox
            // 
            this.SignedCheckBox.AutoSize = true;
            this.SignedCheckBox.Checked = true;
            this.SignedCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SignedCheckBox.Location = new System.Drawing.Point(449, 40);
            this.SignedCheckBox.Name = "SignedCheckBox";
            this.SignedCheckBox.Size = new System.Drawing.Size(59, 17);
            this.SignedCheckBox.TabIndex = 5;
            this.SignedCheckBox.Text = "Signed";
            this.SignedCheckBox.UseVisualStyleBackColor = true;
            // 
            // HexCheckBox
            // 
            this.HexCheckBox.AutoSize = true;
            this.HexCheckBox.Checked = true;
            this.HexCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.HexCheckBox.Location = new System.Drawing.Point(514, 40);
            this.HexCheckBox.Name = "HexCheckBox";
            this.HexCheckBox.Size = new System.Drawing.Size(45, 17);
            this.HexCheckBox.TabIndex = 6;
            this.HexCheckBox.Text = "Hex";
            this.HexCheckBox.UseVisualStyleBackColor = true;
            // 
            // BeginButton
            // 
            this.BeginButton.Location = new System.Drawing.Point(412, 10);
            this.BeginButton.Name = "BeginButton";
            this.BeginButton.Size = new System.Drawing.Size(75, 23);
            this.BeginButton.TabIndex = 9;
            this.BeginButton.Text = "Begin";
            this.BeginButton.UseVisualStyleBackColor = true;
            this.BeginButton.Click += new System.EventHandler(this.BeginButton_Click);
            // 
            // AbortButton
            // 
            this.AbortButton.Location = new System.Drawing.Point(493, 10);
            this.AbortButton.Name = "AbortButton";
            this.AbortButton.Size = new System.Drawing.Size(75, 23);
            this.AbortButton.TabIndex = 10;
            this.AbortButton.Text = "Abort";
            this.AbortButton.UseVisualStyleBackColor = true;
            this.AbortButton.Click += new System.EventHandler(this.AbortButton_Click);
            // 
            // StatusLabel
            // 
            this.StatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StatusLabel.AutoEllipsis = true;
            this.StatusLabel.Location = new System.Drawing.Point(15, 73);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(782, 15);
            this.StatusLabel.TabIndex = 15;
            this.StatusLabel.Text = "Ready to begin";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.UniqueHashesTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.UniqueScriptHashesLabel);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.TotalScriptHashesLabel);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(897, 460);
            this.splitContainer1.SplitterDistance = 207;
            this.splitContainer1.TabIndex = 17;
            // 
            // UniqueHashesTextBox
            // 
            this.UniqueHashesTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UniqueHashesTextBox.Location = new System.Drawing.Point(3, 37);
            this.UniqueHashesTextBox.Multiline = true;
            this.UniqueHashesTextBox.Name = "UniqueHashesTextBox";
            this.UniqueHashesTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.UniqueHashesTextBox.Size = new System.Drawing.Size(201, 423);
            this.UniqueHashesTextBox.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Unique script hashes:";
            // 
            // UniqueScriptHashesLabel
            // 
            this.UniqueScriptHashesLabel.AutoSize = true;
            this.UniqueScriptHashesLabel.Location = new System.Drawing.Point(118, 21);
            this.UniqueScriptHashesLabel.Name = "UniqueScriptHashesLabel";
            this.UniqueScriptHashesLabel.Size = new System.Drawing.Size(10, 13);
            this.UniqueScriptHashesLabel.TabIndex = 3;
            this.UniqueScriptHashesLabel.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Total script hashes:";
            // 
            // TotalScriptHashesLabel
            // 
            this.TotalScriptHashesLabel.AutoSize = true;
            this.TotalScriptHashesLabel.Location = new System.Drawing.Point(118, 3);
            this.TotalScriptHashesLabel.Name = "TotalScriptHashesLabel";
            this.TotalScriptHashesLabel.Size = new System.Drawing.Size(10, 13);
            this.TotalScriptHashesLabel.TabIndex = 1;
            this.TotalScriptHashesLabel.Text = "-";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.label8);
            this.splitContainer2.Panel1.Controls.Add(this.UniqueHashMatchesLabel);
            this.splitContainer2.Panel1.Controls.Add(this.HashMatchesTextBox);
            this.splitContainer2.Panel1.Controls.Add(this.label6);
            this.splitContainer2.Panel1.Controls.Add(this.TotalHashMatchesLabel);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer2.Size = new System.Drawing.Size(683, 457);
            this.splitContainer2.SplitterDistance = 220;
            this.splitContainer2.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "Unique hash matches:";
            // 
            // UniqueHashMatchesLabel
            // 
            this.UniqueHashMatchesLabel.AutoSize = true;
            this.UniqueHashMatchesLabel.Location = new System.Drawing.Point(122, 18);
            this.UniqueHashMatchesLabel.Name = "UniqueHashMatchesLabel";
            this.UniqueHashMatchesLabel.Size = new System.Drawing.Size(10, 13);
            this.UniqueHashMatchesLabel.TabIndex = 24;
            this.UniqueHashMatchesLabel.Text = "-";
            // 
            // HashMatchesTextBox
            // 
            this.HashMatchesTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HashMatchesTextBox.Location = new System.Drawing.Point(0, 34);
            this.HashMatchesTextBox.Multiline = true;
            this.HashMatchesTextBox.Name = "HashMatchesTextBox";
            this.HashMatchesTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.HashMatchesTextBox.Size = new System.Drawing.Size(217, 423);
            this.HashMatchesTextBox.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Total hash matches:";
            // 
            // TotalHashMatchesLabel
            // 
            this.TotalHashMatchesLabel.AutoSize = true;
            this.TotalHashMatchesLabel.Location = new System.Drawing.Point(122, 0);
            this.TotalHashMatchesLabel.Name = "TotalHashMatchesLabel";
            this.TotalHashMatchesLabel.Size = new System.Drawing.Size(10, 13);
            this.TotalHashMatchesLabel.TabIndex = 22;
            this.TotalHashMatchesLabel.Text = "-";
            // 
            // splitContainer4
            // 
            this.splitContainer4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer4.Location = new System.Drawing.Point(3, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.HashCollisionsTextBox);
            this.splitContainer4.Panel1.Controls.Add(this.label9);
            this.splitContainer4.Panel1.Controls.Add(this.HashCollisionsLabel);
            this.splitContainer4.Panel1.Controls.Add(this.TotalMissesLabel);
            this.splitContainer4.Panel1.Controls.Add(this.label7);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.ScriptChangesTextBox);
            this.splitContainer4.Panel2.Controls.Add(this.label11);
            this.splitContainer4.Panel2.Controls.Add(this.FilesModifiedLabel);
            this.splitContainer4.Panel2.Controls.Add(this.TotalChangesLabel);
            this.splitContainer4.Panel2.Controls.Add(this.label14);
            this.splitContainer4.Size = new System.Drawing.Size(456, 457);
            this.splitContainer4.SplitterDistance = 218;
            this.splitContainer4.TabIndex = 21;
            // 
            // HashCollisionsTextBox
            // 
            this.HashCollisionsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HashCollisionsTextBox.Location = new System.Drawing.Point(0, 34);
            this.HashCollisionsTextBox.Multiline = true;
            this.HashCollisionsTextBox.Name = "HashCollisionsTextBox";
            this.HashCollisionsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.HashCollisionsTextBox.Size = new System.Drawing.Size(215, 423);
            this.HashCollisionsTextBox.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "Total misses:";
            // 
            // HashCollisionsLabel
            // 
            this.HashCollisionsLabel.AutoSize = true;
            this.HashCollisionsLabel.Location = new System.Drawing.Point(86, 18);
            this.HashCollisionsLabel.Name = "HashCollisionsLabel";
            this.HashCollisionsLabel.Size = new System.Drawing.Size(10, 13);
            this.HashCollisionsLabel.TabIndex = 24;
            this.HashCollisionsLabel.Text = "-";
            // 
            // TotalMissesLabel
            // 
            this.TotalMissesLabel.AutoSize = true;
            this.TotalMissesLabel.Location = new System.Drawing.Point(86, 0);
            this.TotalMissesLabel.Name = "TotalMissesLabel";
            this.TotalMissesLabel.Size = new System.Drawing.Size(10, 13);
            this.TotalMissesLabel.TabIndex = 26;
            this.TotalMissesLabel.Text = "-";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(0, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Hash collisions:";
            // 
            // ScriptChangesTextBox
            // 
            this.ScriptChangesTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ScriptChangesTextBox.Location = new System.Drawing.Point(3, 34);
            this.ScriptChangesTextBox.Multiline = true;
            this.ScriptChangesTextBox.Name = "ScriptChangesTextBox";
            this.ScriptChangesTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ScriptChangesTextBox.Size = new System.Drawing.Size(227, 423);
            this.ScriptChangesTextBox.TabIndex = 22;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 13);
            this.label11.TabIndex = 32;
            this.label11.Text = "Total changes:";
            // 
            // FilesModifiedLabel
            // 
            this.FilesModifiedLabel.AutoSize = true;
            this.FilesModifiedLabel.Location = new System.Drawing.Point(89, 18);
            this.FilesModifiedLabel.Name = "FilesModifiedLabel";
            this.FilesModifiedLabel.Size = new System.Drawing.Size(10, 13);
            this.FilesModifiedLabel.TabIndex = 29;
            this.FilesModifiedLabel.Text = "-";
            // 
            // TotalChangesLabel
            // 
            this.TotalChangesLabel.AutoSize = true;
            this.TotalChangesLabel.Location = new System.Drawing.Point(89, 0);
            this.TotalChangesLabel.Name = "TotalChangesLabel";
            this.TotalChangesLabel.Size = new System.Drawing.Size(10, 13);
            this.TotalChangesLabel.TabIndex = 31;
            this.TotalChangesLabel.Text = "-";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(3, 18);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(73, 13);
            this.label14.TabIndex = 30;
            this.label14.Text = "Files modified:";
            // 
            // ProblemsTextBox
            // 
            this.ProblemsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProblemsTextBox.Location = new System.Drawing.Point(3, 3);
            this.ProblemsTextBox.Multiline = true;
            this.ProblemsTextBox.Name = "ProblemsTextBox";
            this.ProblemsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ProblemsTextBox.Size = new System.Drawing.Size(891, 85);
            this.ProblemsTextBox.TabIndex = 24;
            // 
            // MinLengthUpDown
            // 
            this.MinLengthUpDown.Location = new System.Drawing.Point(639, 13);
            this.MinLengthUpDown.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.MinLengthUpDown.Name = "MinLengthUpDown";
            this.MinLengthUpDown.Size = new System.Drawing.Size(37, 20);
            this.MinLengthUpDown.TabIndex = 7;
            this.MinLengthUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(574, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Min length:";
            // 
            // UnsignedCheckBox
            // 
            this.UnsignedCheckBox.AutoSize = true;
            this.UnsignedCheckBox.Checked = true;
            this.UnsignedCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.UnsignedCheckBox.Location = new System.Drawing.Point(372, 40);
            this.UnsignedCheckBox.Name = "UnsignedCheckBox";
            this.UnsignedCheckBox.Size = new System.Drawing.Size(71, 17);
            this.UnsignedCheckBox.TabIndex = 4;
            this.UnsignedCheckBox.Text = "Unsigned";
            this.UnsignedCheckBox.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer3.Location = new System.Drawing.Point(12, 109);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.ProblemsTextBox);
            this.splitContainer3.Size = new System.Drawing.Size(897, 558);
            this.splitContainer3.SplitterDistance = 463;
            this.splitContainer3.TabIndex = 23;
            // 
            // UpdateFormatComboBox
            // 
            this.UpdateFormatComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UpdateFormatComboBox.FormattingEnabled = true;
            this.UpdateFormatComboBox.Items.AddRange(new object[] {
            " /* {0} */",
            "\"{0}\" ",
            "${{{0}}}",
            "joaat(\"{0}\")"});
            this.UpdateFormatComboBox.Location = new System.Drawing.Point(824, 12);
            this.UpdateFormatComboBox.Name = "UpdateFormatComboBox";
            this.UpdateFormatComboBox.Size = new System.Drawing.Size(85, 21);
            this.UpdateFormatComboBox.TabIndex = 11;
            this.UpdateFormatComboBox.Text = " /* {0} */ ";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(776, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 13);
            this.label10.TabIndex = 30;
            this.label10.Text = "Format:";
            // 
            // InsertBeforeRadioButton
            // 
            this.InsertBeforeRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.InsertBeforeRadioButton.AutoSize = true;
            this.InsertBeforeRadioButton.Location = new System.Drawing.Point(834, 60);
            this.InsertBeforeRadioButton.Name = "InsertBeforeRadioButton";
            this.InsertBeforeRadioButton.Size = new System.Drawing.Size(84, 17);
            this.InsertBeforeRadioButton.TabIndex = 13;
            this.InsertBeforeRadioButton.Text = "Insert before";
            this.InsertBeforeRadioButton.UseVisualStyleBackColor = true;
            // 
            // InsertAfterRadioButton
            // 
            this.InsertAfterRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.InsertAfterRadioButton.AutoSize = true;
            this.InsertAfterRadioButton.Checked = true;
            this.InsertAfterRadioButton.Location = new System.Drawing.Point(834, 39);
            this.InsertAfterRadioButton.Name = "InsertAfterRadioButton";
            this.InsertAfterRadioButton.Size = new System.Drawing.Size(75, 17);
            this.InsertAfterRadioButton.TabIndex = 12;
            this.InsertAfterRadioButton.TabStop = true;
            this.InsertAfterRadioButton.Text = "Insert after";
            this.InsertAfterRadioButton.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(569, 41);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 13);
            this.label12.TabIndex = 34;
            this.label12.Text = "Threshold:";
            // 
            // ThresholdUpDown
            // 
            this.ThresholdUpDown.DecimalPlaces = 2;
            this.ThresholdUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.ThresholdUpDown.Location = new System.Drawing.Point(632, 39);
            this.ThresholdUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ThresholdUpDown.Name = "ThresholdUpDown";
            this.ThresholdUpDown.Size = new System.Drawing.Size(44, 20);
            this.ThresholdUpDown.TabIndex = 8;
            this.ThresholdUpDown.Value = new decimal(new int[] {
            98,
            0,
            0,
            131072});
            // 
            // UpdateScriptsButton
            // 
            this.UpdateScriptsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UpdateScriptsButton.Location = new System.Drawing.Point(728, 36);
            this.UpdateScriptsButton.Name = "UpdateScriptsButton";
            this.UpdateScriptsButton.Size = new System.Drawing.Size(90, 23);
            this.UpdateScriptsButton.TabIndex = 15;
            this.UpdateScriptsButton.Text = "Update scripts";
            this.UpdateScriptsButton.UseVisualStyleBackColor = true;
            this.UpdateScriptsButton.Click += new System.EventHandler(this.UpdateScriptsButton_Click);
            // 
            // ReplaceRadioButton
            // 
            this.ReplaceRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ReplaceRadioButton.AutoSize = true;
            this.ReplaceRadioButton.Location = new System.Drawing.Point(834, 81);
            this.ReplaceRadioButton.Name = "ReplaceRadioButton";
            this.ReplaceRadioButton.Size = new System.Drawing.Size(65, 17);
            this.ReplaceRadioButton.TabIndex = 14;
            this.ReplaceRadioButton.Text = "Replace";
            this.ReplaceRadioButton.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(362, 15);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 13);
            this.label13.TabIndex = 37;
            this.label13.Text = "Search:";
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(710, 15);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(50, 13);
            this.label15.TabIndex = 38;
            this.label15.Text = "Replace:";
            // 
            // JenkIndForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 679);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.ReplaceRadioButton);
            this.Controls.Add(this.UpdateScriptsButton);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.ThresholdUpDown);
            this.Controls.Add(this.InsertAfterRadioButton);
            this.Controls.Add(this.InsertBeforeRadioButton);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.UpdateFormatComboBox);
            this.Controls.Add(this.splitContainer3);
            this.Controls.Add(this.UnsignedCheckBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.MinLengthUpDown);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.AbortButton);
            this.Controls.Add(this.BeginButton);
            this.Controls.Add(this.HexCheckBox);
            this.Controls.Add(this.SignedCheckBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.JenkIndFolderBrowseButton);
            this.Controls.Add(this.JenkIndFolderTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ScriptFolderBrowseButton);
            this.Controls.Add(this.ScriptFolderTextBox);
            this.MinimumSize = new System.Drawing.Size(937, 718);
            this.Name = "JenkIndForm";
            this.Text = "JenkIndex Matcher - GTA V Refactor by dexyfex";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.PerformLayout();
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MinLengthUpDown)).EndInit();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ThresholdUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ScriptFolderBrowseButton;
        private System.Windows.Forms.TextBox ScriptFolderTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button JenkIndFolderBrowseButton;
        private System.Windows.Forms.TextBox JenkIndFolderTextBox;
        private System.Windows.Forms.CheckBox SignedCheckBox;
        private System.Windows.Forms.CheckBox HexCheckBox;
        private System.Windows.Forms.Button BeginButton;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog;
        private System.Windows.Forms.Button AbortButton;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.NumericUpDown MinLengthUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox UnsignedCheckBox;
        private System.Windows.Forms.TextBox UniqueHashesTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label UniqueScriptHashesLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label TotalScriptHashesLabel;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TextBox HashMatchesTextBox;
        private System.Windows.Forms.TextBox ProblemsTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label TotalHashMatchesLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label HashCollisionsLabel;
        private System.Windows.Forms.TextBox HashCollisionsTextBox;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label UniqueHashMatchesLabel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label TotalMissesLabel;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.ComboBox UpdateFormatComboBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RadioButton InsertBeforeRadioButton;
        private System.Windows.Forms.RadioButton InsertAfterRadioButton;
        private System.Windows.Forms.TextBox ScriptChangesTextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label FilesModifiedLabel;
        private System.Windows.Forms.Label TotalChangesLabel;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown ThresholdUpDown;
        private System.Windows.Forms.Button UpdateScriptsButton;
        private System.Windows.Forms.RadioButton ReplaceRadioButton;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
    }
}