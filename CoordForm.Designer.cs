namespace gta5refactor
{
    partial class CoordForm
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
            this.FindButton = new System.Windows.Forms.Button();
            this.FolderBrowseButton = new System.Windows.Forms.Button();
            this.ScriptFolderTextBox = new System.Windows.Forms.TextBox();
            this.FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.PositionTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.RangeUpDown = new System.Windows.Forms.NumericUpDown();
            this.IgnoreSignCheckBox = new System.Windows.Forms.CheckBox();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.ResultTextBox = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.Use3dDistCheckBox = new System.Windows.Forms.CheckBox();
            this.DeduplicateCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.RangeUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // FindButton
            // 
            this.FindButton.Location = new System.Drawing.Point(367, 41);
            this.FindButton.Name = "FindButton";
            this.FindButton.Size = new System.Drawing.Size(75, 23);
            this.FindButton.TabIndex = 10;
            this.FindButton.Text = "Find";
            this.FindButton.UseVisualStyleBackColor = true;
            this.FindButton.Click += new System.EventHandler(this.FindButton_Click);
            // 
            // FolderBrowseButton
            // 
            this.FolderBrowseButton.Location = new System.Drawing.Point(269, 10);
            this.FolderBrowseButton.Name = "FolderBrowseButton";
            this.FolderBrowseButton.Size = new System.Drawing.Size(27, 23);
            this.FolderBrowseButton.TabIndex = 12;
            this.FolderBrowseButton.Text = "...";
            this.FolderBrowseButton.UseVisualStyleBackColor = true;
            this.FolderBrowseButton.Click += new System.EventHandler(this.FolderBrowseButton_Click);
            // 
            // ScriptFolderTextBox
            // 
            this.ScriptFolderTextBox.Location = new System.Drawing.Point(12, 12);
            this.ScriptFolderTextBox.Name = "ScriptFolderTextBox";
            this.ScriptFolderTextBox.Size = new System.Drawing.Size(251, 20);
            this.ScriptFolderTextBox.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "x, y, z";
            // 
            // PositionTextBox
            // 
            this.PositionTextBox.Location = new System.Drawing.Point(52, 43);
            this.PositionTextBox.Name = "PositionTextBox";
            this.PositionTextBox.Size = new System.Drawing.Size(244, 20);
            this.PositionTextBox.TabIndex = 14;
            this.PositionTextBox.Text = "0, 0, 0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(327, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "within";
            // 
            // RangeUpDown
            // 
            this.RangeUpDown.DecimalPlaces = 1;
            this.RangeUpDown.Location = new System.Drawing.Point(367, 13);
            this.RangeUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.RangeUpDown.Name = "RangeUpDown";
            this.RangeUpDown.Size = new System.Drawing.Size(90, 20);
            this.RangeUpDown.TabIndex = 16;
            this.RangeUpDown.Value = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            // 
            // IgnoreSignCheckBox
            // 
            this.IgnoreSignCheckBox.AutoSize = true;
            this.IgnoreSignCheckBox.Location = new System.Drawing.Point(480, 45);
            this.IgnoreSignCheckBox.Name = "IgnoreSignCheckBox";
            this.IgnoreSignCheckBox.Size = new System.Drawing.Size(78, 17);
            this.IgnoreSignCheckBox.TabIndex = 17;
            this.IgnoreSignCheckBox.Text = "Ignore sign";
            this.IgnoreSignCheckBox.UseVisualStyleBackColor = true;
            // 
            // StatusLabel
            // 
            this.StatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StatusLabel.AutoEllipsis = true;
            this.StatusLabel.Location = new System.Drawing.Point(12, 72);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(693, 18);
            this.StatusLabel.TabIndex = 18;
            this.StatusLabel.Text = "Ready";
            // 
            // ResultTextBox
            // 
            this.ResultTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ResultTextBox.Location = new System.Drawing.Point(3, 0);
            this.ResultTextBox.Multiline = true;
            this.ResultTextBox.Name = "ResultTextBox";
            this.ResultTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ResultTextBox.Size = new System.Drawing.Size(659, 346);
            this.ResultTextBox.TabIndex = 20;
            this.ResultTextBox.WordWrap = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 96);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ResultTextBox);
            this.splitContainer1.Size = new System.Drawing.Size(693, 346);
            this.splitContainer1.SplitterDistance = 27;
            this.splitContainer1.TabIndex = 21;
            // 
            // Use3dDistCheckBox
            // 
            this.Use3dDistCheckBox.AutoSize = true;
            this.Use3dDistCheckBox.Checked = true;
            this.Use3dDistCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Use3dDistCheckBox.Location = new System.Drawing.Point(480, 14);
            this.Use3dDistCheckBox.Name = "Use3dDistCheckBox";
            this.Use3dDistCheckBox.Size = new System.Drawing.Size(105, 17);
            this.Use3dDistCheckBox.TabIndex = 22;
            this.Use3dDistCheckBox.Text = "Use 3D distance";
            this.Use3dDistCheckBox.UseVisualStyleBackColor = true;
            // 
            // DeduplicateCheckBox
            // 
            this.DeduplicateCheckBox.AutoSize = true;
            this.DeduplicateCheckBox.Checked = true;
            this.DeduplicateCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DeduplicateCheckBox.Location = new System.Drawing.Point(597, 45);
            this.DeduplicateCheckBox.Name = "DeduplicateCheckBox";
            this.DeduplicateCheckBox.Size = new System.Drawing.Size(83, 17);
            this.DeduplicateCheckBox.TabIndex = 23;
            this.DeduplicateCheckBox.Text = "Deduplicate";
            this.DeduplicateCheckBox.UseVisualStyleBackColor = true;
            // 
            // CoordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 454);
            this.Controls.Add(this.DeduplicateCheckBox);
            this.Controls.Add(this.Use3dDistCheckBox);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.IgnoreSignCheckBox);
            this.Controls.Add(this.RangeUpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PositionTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FindButton);
            this.Controls.Add(this.FolderBrowseButton);
            this.Controls.Add(this.ScriptFolderTextBox);
            this.Name = "CoordForm";
            this.Text = "Find Coordinates - GTA V Refactor by dexyfex";
            ((System.ComponentModel.ISupportInitialize)(this.RangeUpDown)).EndInit();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button FindButton;
        private System.Windows.Forms.Button FolderBrowseButton;
        private System.Windows.Forms.TextBox ScriptFolderTextBox;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PositionTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown RangeUpDown;
        private System.Windows.Forms.CheckBox IgnoreSignCheckBox;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.TextBox ResultTextBox;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.CheckBox Use3dDistCheckBox;
        private System.Windows.Forms.CheckBox DeduplicateCheckBox;
    }
}