namespace gta5refactor
{
    partial class FindForm
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
            this.FolderBrowseButton = new System.Windows.Forms.Button();
            this.ScriptFolderTextBox = new System.Windows.Forms.TextBox();
            this.FindTextBox = new System.Windows.Forms.TextBox();
            this.ReplaceTextBox = new System.Windows.Forms.TextBox();
            this.FindButton = new System.Windows.Forms.Button();
            this.ReplaceButton = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.MatchesListView = new System.Windows.Forms.ListView();
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FunctionTextBox = new System.Windows.Forms.TextBox();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.AbortButton = new System.Windows.Forms.Button();
            this.FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.CaseSensitiveCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // FolderBrowseButton
            // 
            this.FolderBrowseButton.Location = new System.Drawing.Point(269, 10);
            this.FolderBrowseButton.Name = "FolderBrowseButton";
            this.FolderBrowseButton.Size = new System.Drawing.Size(27, 23);
            this.FolderBrowseButton.TabIndex = 9;
            this.FolderBrowseButton.Text = "...";
            this.FolderBrowseButton.UseVisualStyleBackColor = true;
            this.FolderBrowseButton.Click += new System.EventHandler(this.FolderBrowseButton_Click);
            // 
            // ScriptFolderTextBox
            // 
            this.ScriptFolderTextBox.Location = new System.Drawing.Point(12, 12);
            this.ScriptFolderTextBox.Name = "ScriptFolderTextBox";
            this.ScriptFolderTextBox.Size = new System.Drawing.Size(251, 20);
            this.ScriptFolderTextBox.TabIndex = 8;
            // 
            // FindTextBox
            // 
            this.FindTextBox.Location = new System.Drawing.Point(12, 41);
            this.FindTextBox.Name = "FindTextBox";
            this.FindTextBox.Size = new System.Drawing.Size(251, 20);
            this.FindTextBox.TabIndex = 0;
            // 
            // ReplaceTextBox
            // 
            this.ReplaceTextBox.Location = new System.Drawing.Point(369, 41);
            this.ReplaceTextBox.Name = "ReplaceTextBox";
            this.ReplaceTextBox.Size = new System.Drawing.Size(251, 20);
            this.ReplaceTextBox.TabIndex = 2;
            // 
            // FindButton
            // 
            this.FindButton.Location = new System.Drawing.Point(269, 39);
            this.FindButton.Name = "FindButton";
            this.FindButton.Size = new System.Drawing.Size(75, 23);
            this.FindButton.TabIndex = 1;
            this.FindButton.Text = "Find";
            this.FindButton.UseVisualStyleBackColor = true;
            this.FindButton.Click += new System.EventHandler(this.FindButton_Click);
            // 
            // ReplaceButton
            // 
            this.ReplaceButton.Location = new System.Drawing.Point(626, 39);
            this.ReplaceButton.Name = "ReplaceButton";
            this.ReplaceButton.Size = new System.Drawing.Size(75, 23);
            this.ReplaceButton.TabIndex = 3;
            this.ReplaceButton.Text = "Replace";
            this.ReplaceButton.UseVisualStyleBackColor = true;
            this.ReplaceButton.Click += new System.EventHandler(this.ReplaceButton_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 68);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.MatchesListView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.FunctionTextBox);
            this.splitContainer1.Panel2.Controls.Add(this.StatusLabel);
            this.splitContainer1.Size = new System.Drawing.Size(787, 355);
            this.splitContainer1.SplitterDistance = 269;
            this.splitContainer1.TabIndex = 6;
            // 
            // MatchesListView
            // 
            this.MatchesListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MatchesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11});
            this.MatchesListView.FullRowSelect = true;
            this.MatchesListView.HideSelection = false;
            this.MatchesListView.Location = new System.Drawing.Point(0, 0);
            this.MatchesListView.MultiSelect = false;
            this.MatchesListView.Name = "MatchesListView";
            this.MatchesListView.Size = new System.Drawing.Size(266, 355);
            this.MatchesListView.TabIndex = 5;
            this.MatchesListView.UseCompatibleStateImageBehavior = false;
            this.MatchesListView.View = System.Windows.Forms.View.Details;
            this.MatchesListView.SelectedIndexChanged += new System.EventHandler(this.MatchesListView_SelectedIndexChanged);
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "File";
            this.columnHeader9.Width = 132;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Line";
            this.columnHeader10.Width = 58;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Char";
            this.columnHeader11.Width = 41;
            // 
            // FunctionTextBox
            // 
            this.FunctionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FunctionTextBox.HideSelection = false;
            this.FunctionTextBox.Location = new System.Drawing.Point(3, 31);
            this.FunctionTextBox.Multiline = true;
            this.FunctionTextBox.Name = "FunctionTextBox";
            this.FunctionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.FunctionTextBox.Size = new System.Drawing.Size(511, 324);
            this.FunctionTextBox.TabIndex = 7;
            this.FunctionTextBox.WordWrap = false;
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(3, 9);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(38, 13);
            this.StatusLabel.TabIndex = 0;
            this.StatusLabel.Text = "Ready";
            // 
            // AbortButton
            // 
            this.AbortButton.Location = new System.Drawing.Point(724, 39);
            this.AbortButton.Name = "AbortButton";
            this.AbortButton.Size = new System.Drawing.Size(75, 23);
            this.AbortButton.TabIndex = 4;
            this.AbortButton.Text = "Abort";
            this.AbortButton.UseVisualStyleBackColor = true;
            this.AbortButton.Click += new System.EventHandler(this.AbortButton_Click);
            // 
            // CaseSensitiveCheckBox
            // 
            this.CaseSensitiveCheckBox.AutoSize = true;
            this.CaseSensitiveCheckBox.Location = new System.Drawing.Point(369, 14);
            this.CaseSensitiveCheckBox.Name = "CaseSensitiveCheckBox";
            this.CaseSensitiveCheckBox.Size = new System.Drawing.Size(94, 17);
            this.CaseSensitiveCheckBox.TabIndex = 9;
            this.CaseSensitiveCheckBox.Text = "Case sensitive";
            this.CaseSensitiveCheckBox.UseVisualStyleBackColor = true;
            // 
            // FindForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 435);
            this.Controls.Add(this.CaseSensitiveCheckBox);
            this.Controls.Add(this.AbortButton);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.ReplaceButton);
            this.Controls.Add(this.FindButton);
            this.Controls.Add(this.ReplaceTextBox);
            this.Controls.Add(this.FindTextBox);
            this.Controls.Add(this.FolderBrowseButton);
            this.Controls.Add(this.ScriptFolderTextBox);
            this.Name = "FindForm";
            this.Text = "Find/Replace - GTA V Refactor by dexyfex";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button FolderBrowseButton;
        private System.Windows.Forms.TextBox ScriptFolderTextBox;
        private System.Windows.Forms.TextBox FindTextBox;
        private System.Windows.Forms.TextBox ReplaceTextBox;
        private System.Windows.Forms.Button FindButton;
        private System.Windows.Forms.Button ReplaceButton;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView MatchesListView;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Button AbortButton;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog;
        private System.Windows.Forms.TextBox FunctionTextBox;
        private System.Windows.Forms.CheckBox CaseSensitiveCheckBox;
    }
}