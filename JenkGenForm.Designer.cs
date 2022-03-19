namespace gta5refactor
{
    partial class JenkGenForm
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
            this.InputTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.HashSignedTextBox = new System.Windows.Forms.TextBox();
            this.ASCIIRadioButton = new System.Windows.Forms.RadioButton();
            this.UTF8RadioButton = new System.Windows.Forms.RadioButton();
            this.HashUnsignedTextBox = new System.Windows.Forms.TextBox();
            this.HashHexTextBox = new System.Windows.Forms.TextBox();
            this.UniqueHashesTextBox = new System.Windows.Forms.TextBox();
            this.BuildScriptIndexButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.ScriptFolderBrowseButton = new System.Windows.Forms.Button();
            this.ScriptFolderTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ScriptMatchesLabel = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.ReplaceRadioButton = new System.Windows.Forms.RadioButton();
            this.UpdateScriptsButton = new System.Windows.Forms.Button();
            this.InsertAfterRadioButton = new System.Windows.Forms.RadioButton();
            this.InsertBeforeRadioButton = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.UpdateFormatComboBox = new System.Windows.Forms.ComboBox();
            this.UpdateScriptsGroupBox = new System.Windows.Forms.GroupBox();
            this.FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.ScriptHashesLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.MatchesListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UpdateScriptsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // InputTextBox
            // 
            this.InputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InputTextBox.Location = new System.Drawing.Point(52, 12);
            this.InputTextBox.Name = "InputTextBox";
            this.InputTextBox.Size = new System.Drawing.Size(411, 20);
            this.InputTextBox.TabIndex = 0;
            this.InputTextBox.TextChanged += new System.EventHandler(this.InputTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Input:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Hash:";
            // 
            // HashSignedTextBox
            // 
            this.HashSignedTextBox.Location = new System.Drawing.Point(53, 38);
            this.HashSignedTextBox.Name = "HashSignedTextBox";
            this.HashSignedTextBox.Size = new System.Drawing.Size(119, 20);
            this.HashSignedTextBox.TabIndex = 2;
            // 
            // ASCIIRadioButton
            // 
            this.ASCIIRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ASCIIRadioButton.AutoSize = true;
            this.ASCIIRadioButton.Location = new System.Drawing.Point(530, 13);
            this.ASCIIRadioButton.Name = "ASCIIRadioButton";
            this.ASCIIRadioButton.Size = new System.Drawing.Size(52, 17);
            this.ASCIIRadioButton.TabIndex = 4;
            this.ASCIIRadioButton.Text = "ASCII";
            this.ASCIIRadioButton.UseVisualStyleBackColor = true;
            this.ASCIIRadioButton.CheckedChanged += new System.EventHandler(this.ASCIIRadioButton_CheckedChanged);
            // 
            // UTF8RadioButton
            // 
            this.UTF8RadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UTF8RadioButton.AutoSize = true;
            this.UTF8RadioButton.Checked = true;
            this.UTF8RadioButton.Location = new System.Drawing.Point(469, 13);
            this.UTF8RadioButton.Name = "UTF8RadioButton";
            this.UTF8RadioButton.Size = new System.Drawing.Size(55, 17);
            this.UTF8RadioButton.TabIndex = 5;
            this.UTF8RadioButton.TabStop = true;
            this.UTF8RadioButton.Text = "UTF-8";
            this.UTF8RadioButton.UseVisualStyleBackColor = true;
            this.UTF8RadioButton.CheckedChanged += new System.EventHandler(this.UTF8RadioButton_CheckedChanged);
            // 
            // HashUnsignedTextBox
            // 
            this.HashUnsignedTextBox.Location = new System.Drawing.Point(178, 38);
            this.HashUnsignedTextBox.Name = "HashUnsignedTextBox";
            this.HashUnsignedTextBox.Size = new System.Drawing.Size(119, 20);
            this.HashUnsignedTextBox.TabIndex = 6;
            // 
            // HashHexTextBox
            // 
            this.HashHexTextBox.Location = new System.Drawing.Point(303, 38);
            this.HashHexTextBox.Name = "HashHexTextBox";
            this.HashHexTextBox.Size = new System.Drawing.Size(119, 20);
            this.HashHexTextBox.TabIndex = 7;
            // 
            // UniqueHashesTextBox
            // 
            this.UniqueHashesTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UniqueHashesTextBox.Location = new System.Drawing.Point(52, 139);
            this.UniqueHashesTextBox.Multiline = true;
            this.UniqueHashesTextBox.Name = "UniqueHashesTextBox";
            this.UniqueHashesTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.UniqueHashesTextBox.Size = new System.Drawing.Size(245, 230);
            this.UniqueHashesTextBox.TabIndex = 17;
            // 
            // BuildScriptIndexButton
            // 
            this.BuildScriptIndexButton.Location = new System.Drawing.Point(52, 110);
            this.BuildScriptIndexButton.Name = "BuildScriptIndexButton";
            this.BuildScriptIndexButton.Size = new System.Drawing.Size(107, 23);
            this.BuildScriptIndexButton.TabIndex = 19;
            this.BuildScriptIndexButton.Text = "Build script index";
            this.BuildScriptIndexButton.UseVisualStyleBackColor = true;
            this.BuildScriptIndexButton.Click += new System.EventHandler(this.BuildScriptIndexButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Scripts:";
            // 
            // ScriptFolderBrowseButton
            // 
            this.ScriptFolderBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ScriptFolderBrowseButton.Location = new System.Drawing.Point(270, 82);
            this.ScriptFolderBrowseButton.Name = "ScriptFolderBrowseButton";
            this.ScriptFolderBrowseButton.Size = new System.Drawing.Size(27, 23);
            this.ScriptFolderBrowseButton.TabIndex = 21;
            this.ScriptFolderBrowseButton.Text = "...";
            this.ScriptFolderBrowseButton.UseVisualStyleBackColor = true;
            this.ScriptFolderBrowseButton.Click += new System.EventHandler(this.ScriptFolderBrowseButton_Click);
            // 
            // ScriptFolderTextBox
            // 
            this.ScriptFolderTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ScriptFolderTextBox.Location = new System.Drawing.Point(53, 84);
            this.ScriptFolderTextBox.Name = "ScriptFolderTextBox";
            this.ScriptFolderTextBox.Size = new System.Drawing.Size(211, 20);
            this.ScriptFolderTextBox.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(342, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Script matches:";
            // 
            // ScriptMatchesLabel
            // 
            this.ScriptMatchesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ScriptMatchesLabel.AutoSize = true;
            this.ScriptMatchesLabel.Location = new System.Drawing.Point(428, 87);
            this.ScriptMatchesLabel.Name = "ScriptMatchesLabel";
            this.ScriptMatchesLabel.Size = new System.Drawing.Size(13, 13);
            this.ScriptMatchesLabel.TabIndex = 24;
            this.ScriptMatchesLabel.Text = "0";
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(22, 22);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(50, 13);
            this.label15.TabIndex = 45;
            this.label15.Text = "Replace:";
            // 
            // ReplaceRadioButton
            // 
            this.ReplaceRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ReplaceRadioButton.AutoSize = true;
            this.ReplaceRadioButton.Location = new System.Drawing.Point(137, 88);
            this.ReplaceRadioButton.Name = "ReplaceRadioButton";
            this.ReplaceRadioButton.Size = new System.Drawing.Size(65, 17);
            this.ReplaceRadioButton.TabIndex = 42;
            this.ReplaceRadioButton.Text = "Replace";
            this.ReplaceRadioButton.UseVisualStyleBackColor = true;
            // 
            // UpdateScriptsButton
            // 
            this.UpdateScriptsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UpdateScriptsButton.Location = new System.Drawing.Point(31, 43);
            this.UpdateScriptsButton.Name = "UpdateScriptsButton";
            this.UpdateScriptsButton.Size = new System.Drawing.Size(90, 23);
            this.UpdateScriptsButton.TabIndex = 43;
            this.UpdateScriptsButton.Text = "Update scripts";
            this.UpdateScriptsButton.UseVisualStyleBackColor = true;
            this.UpdateScriptsButton.Click += new System.EventHandler(this.UpdateScriptsButton_Click);
            // 
            // InsertAfterRadioButton
            // 
            this.InsertAfterRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.InsertAfterRadioButton.AutoSize = true;
            this.InsertAfterRadioButton.Checked = true;
            this.InsertAfterRadioButton.Location = new System.Drawing.Point(137, 46);
            this.InsertAfterRadioButton.Name = "InsertAfterRadioButton";
            this.InsertAfterRadioButton.Size = new System.Drawing.Size(75, 17);
            this.InsertAfterRadioButton.TabIndex = 40;
            this.InsertAfterRadioButton.TabStop = true;
            this.InsertAfterRadioButton.Text = "Insert after";
            this.InsertAfterRadioButton.UseVisualStyleBackColor = true;
            // 
            // InsertBeforeRadioButton
            // 
            this.InsertBeforeRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.InsertBeforeRadioButton.AutoSize = true;
            this.InsertBeforeRadioButton.Location = new System.Drawing.Point(137, 67);
            this.InsertBeforeRadioButton.Name = "InsertBeforeRadioButton";
            this.InsertBeforeRadioButton.Size = new System.Drawing.Size(84, 17);
            this.InsertBeforeRadioButton.TabIndex = 41;
            this.InsertBeforeRadioButton.Text = "Insert before";
            this.InsertBeforeRadioButton.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(79, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 13);
            this.label10.TabIndex = 44;
            this.label10.Text = "Format:";
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
            this.UpdateFormatComboBox.Location = new System.Drawing.Point(127, 19);
            this.UpdateFormatComboBox.Name = "UpdateFormatComboBox";
            this.UpdateFormatComboBox.Size = new System.Drawing.Size(85, 21);
            this.UpdateFormatComboBox.TabIndex = 39;
            this.UpdateFormatComboBox.Text = " /* {0} */ ";
            // 
            // UpdateScriptsGroupBox
            // 
            this.UpdateScriptsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.UpdateScriptsGroupBox.Controls.Add(this.UpdateScriptsButton);
            this.UpdateScriptsGroupBox.Controls.Add(this.label15);
            this.UpdateScriptsGroupBox.Controls.Add(this.UpdateFormatComboBox);
            this.UpdateScriptsGroupBox.Controls.Add(this.ReplaceRadioButton);
            this.UpdateScriptsGroupBox.Controls.Add(this.label10);
            this.UpdateScriptsGroupBox.Controls.Add(this.InsertBeforeRadioButton);
            this.UpdateScriptsGroupBox.Controls.Add(this.InsertAfterRadioButton);
            this.UpdateScriptsGroupBox.Enabled = false;
            this.UpdateScriptsGroupBox.Location = new System.Drawing.Point(332, 250);
            this.UpdateScriptsGroupBox.Name = "UpdateScriptsGroupBox";
            this.UpdateScriptsGroupBox.Size = new System.Drawing.Size(250, 119);
            this.UpdateScriptsGroupBox.TabIndex = 46;
            this.UpdateScriptsGroupBox.TabStop = false;
            this.UpdateScriptsGroupBox.Text = "Update scripts";
            // 
            // ScriptHashesLabel
            // 
            this.ScriptHashesLabel.AutoSize = true;
            this.ScriptHashesLabel.Location = new System.Drawing.Point(245, 115);
            this.ScriptHashesLabel.Name = "ScriptHashesLabel";
            this.ScriptHashesLabel.Size = new System.Drawing.Size(13, 13);
            this.ScriptHashesLabel.TabIndex = 48;
            this.ScriptHashesLabel.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(165, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 47;
            this.label6.Text = "Script hashes:";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StatusLabel.AutoEllipsis = true;
            this.StatusLabel.Location = new System.Drawing.Point(12, 372);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(570, 20);
            this.StatusLabel.TabIndex = 49;
            this.StatusLabel.Text = "Ready";
            // 
            // MatchesListView
            // 
            this.MatchesListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MatchesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.MatchesListView.FullRowSelect = true;
            this.MatchesListView.HideSelection = false;
            this.MatchesListView.Location = new System.Drawing.Point(332, 110);
            this.MatchesListView.MultiSelect = false;
            this.MatchesListView.Name = "MatchesListView";
            this.MatchesListView.Size = new System.Drawing.Size(250, 123);
            this.MatchesListView.TabIndex = 50;
            this.MatchesListView.UseCompatibleStateImageBehavior = false;
            this.MatchesListView.View = System.Windows.Forms.View.Details;
            this.MatchesListView.DoubleClick += new System.EventHandler(this.MatchesListView_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "File";
            this.columnHeader1.Width = 146;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Line";
            this.columnHeader2.Width = 73;
            // 
            // JenkGenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 392);
            this.Controls.Add(this.MatchesListView);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.ScriptHashesLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.UpdateScriptsGroupBox);
            this.Controls.Add(this.ScriptMatchesLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ScriptFolderBrowseButton);
            this.Controls.Add(this.ScriptFolderTextBox);
            this.Controls.Add(this.BuildScriptIndexButton);
            this.Controls.Add(this.UniqueHashesTextBox);
            this.Controls.Add(this.HashHexTextBox);
            this.Controls.Add(this.HashUnsignedTextBox);
            this.Controls.Add(this.UTF8RadioButton);
            this.Controls.Add(this.ASCIIRadioButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.HashSignedTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.InputTextBox);
            this.MinimumSize = new System.Drawing.Size(610, 431);
            this.Name = "JenkGenForm";
            this.Text = "Jenkins Hash Generator / Matcher - GTA V Refactor by dexyfex";
            this.UpdateScriptsGroupBox.ResumeLayout(false);
            this.UpdateScriptsGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox InputTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox HashSignedTextBox;
        private System.Windows.Forms.RadioButton ASCIIRadioButton;
        private System.Windows.Forms.RadioButton UTF8RadioButton;
        private System.Windows.Forms.TextBox HashUnsignedTextBox;
        private System.Windows.Forms.TextBox HashHexTextBox;
        private System.Windows.Forms.TextBox UniqueHashesTextBox;
        private System.Windows.Forms.Button BuildScriptIndexButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ScriptFolderBrowseButton;
        private System.Windows.Forms.TextBox ScriptFolderTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label ScriptMatchesLabel;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.RadioButton ReplaceRadioButton;
        private System.Windows.Forms.Button UpdateScriptsButton;
        private System.Windows.Forms.RadioButton InsertAfterRadioButton;
        private System.Windows.Forms.RadioButton InsertBeforeRadioButton;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox UpdateFormatComboBox;
        private System.Windows.Forms.GroupBox UpdateScriptsGroupBox;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog;
        private System.Windows.Forms.Label ScriptHashesLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.ListView MatchesListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}