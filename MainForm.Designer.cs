namespace gta5refactor
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.FolderTextBox = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.NavForwardButton = new System.Windows.Forms.Button();
            this.NavBackButton = new System.Windows.Forms.Button();
            this.FilesListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FilePanel = new System.Windows.Forms.Panel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.FunctionsListView = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FileLinesLabel = new System.Windows.Forms.Label();
            this.FileNameLabel = new System.Windows.Forms.Label();
            this.FunctionPanel = new System.Windows.Forms.Panel();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.FunctionAbortButton = new System.Windows.Forms.Button();
            this.FunctionStatusLabel = new System.Windows.Forms.Label();
            this.FunctionMatchesListView = new System.Windows.Forms.ListView();
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FunctionLabel = new System.Windows.Forms.Label();
            this.FunctionRefactorButton = new System.Windows.Forms.Button();
            this.FunctionMatchButton = new System.Windows.Forms.Button();
            this.FunctionRefactorNameTextBox = new System.Windows.Forms.TextBox();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.FunctionDependenciesListView = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FunctionReferencesListView = new System.Windows.Forms.ListView();
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FunctionTextBox = new System.Windows.Forms.TextBox();
            this.NavContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ScanFolderButton = new System.Windows.Forms.Button();
            this.FolderBrowseButton = new System.Windows.Forms.Button();
            this.FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.GlobalsFileNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ToolsButton = new System.Windows.Forms.Button();
            this.ToolsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolsMenuSyntaxCheck = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolsMenuFindReplace = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolsMenuAutoRefactor = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolsMenuJenkGen = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolsMenuJenkInd = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolsMenuFindCoordinates = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.FilePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.FunctionPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            this.ToolsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // FolderTextBox
            // 
            this.FolderTextBox.Location = new System.Drawing.Point(12, 12);
            this.FolderTextBox.Name = "FolderTextBox";
            this.FolderTextBox.Size = new System.Drawing.Size(251, 20);
            this.FolderTextBox.TabIndex = 0;
            this.FolderTextBox.TextChanged += new System.EventHandler(this.FolderTextBox_TextChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(12, 38);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.NavForwardButton);
            this.splitContainer1.Panel1.Controls.Add(this.NavBackButton);
            this.splitContainer1.Panel1.Controls.Add(this.FilesListView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.FilePanel);
            this.splitContainer1.Size = new System.Drawing.Size(962, 788);
            this.splitContainer1.SplitterDistance = 254;
            this.splitContainer1.TabIndex = 6;
            // 
            // NavForwardButton
            // 
            this.NavForwardButton.Enabled = false;
            this.NavForwardButton.Location = new System.Drawing.Point(36, 0);
            this.NavForwardButton.Name = "NavForwardButton";
            this.NavForwardButton.Size = new System.Drawing.Size(30, 23);
            this.NavForwardButton.TabIndex = 7;
            this.NavForwardButton.Text = ">";
            this.NavForwardButton.UseVisualStyleBackColor = true;
            this.NavForwardButton.Click += new System.EventHandler(this.NavForwardButton_Click);
            // 
            // NavBackButton
            // 
            this.NavBackButton.Enabled = false;
            this.NavBackButton.Location = new System.Drawing.Point(0, 0);
            this.NavBackButton.Name = "NavBackButton";
            this.NavBackButton.Size = new System.Drawing.Size(30, 23);
            this.NavBackButton.TabIndex = 6;
            this.NavBackButton.Text = "<";
            this.NavBackButton.UseVisualStyleBackColor = true;
            this.NavBackButton.Click += new System.EventHandler(this.NavBackButton_Click);
            // 
            // FilesListView
            // 
            this.FilesListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FilesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.FilesListView.FullRowSelect = true;
            this.FilesListView.HideSelection = false;
            this.FilesListView.Location = new System.Drawing.Point(0, 29);
            this.FilesListView.MultiSelect = false;
            this.FilesListView.Name = "FilesListView";
            this.FilesListView.Size = new System.Drawing.Size(251, 756);
            this.FilesListView.TabIndex = 5;
            this.FilesListView.UseCompatibleStateImageBehavior = false;
            this.FilesListView.View = System.Windows.Forms.View.Details;
            this.FilesListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.FilesListView_ColumnClick);
            this.FilesListView.SelectedIndexChanged += new System.EventHandler(this.FilesListView_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "File";
            this.columnHeader1.Width = 146;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Size";
            this.columnHeader2.Width = 73;
            // 
            // FilePanel
            // 
            this.FilePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FilePanel.Controls.Add(this.splitContainer2);
            this.FilePanel.Enabled = false;
            this.FilePanel.Location = new System.Drawing.Point(3, 3);
            this.FilePanel.Name = "FilePanel";
            this.FilePanel.Size = new System.Drawing.Size(698, 782);
            this.FilePanel.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.FunctionsListView);
            this.splitContainer2.Panel1.Controls.Add(this.FileLinesLabel);
            this.splitContainer2.Panel1.Controls.Add(this.FileNameLabel);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.FunctionPanel);
            this.splitContainer2.Size = new System.Drawing.Size(701, 785);
            this.splitContainer2.SplitterDistance = 289;
            this.splitContainer2.TabIndex = 8;
            // 
            // FunctionsListView
            // 
            this.FunctionsListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FunctionsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.FunctionsListView.FullRowSelect = true;
            this.FunctionsListView.HideSelection = false;
            this.FunctionsListView.Location = new System.Drawing.Point(0, 51);
            this.FunctionsListView.MultiSelect = false;
            this.FunctionsListView.Name = "FunctionsListView";
            this.FunctionsListView.Size = new System.Drawing.Size(286, 731);
            this.FunctionsListView.TabIndex = 7;
            this.FunctionsListView.UseCompatibleStateImageBehavior = false;
            this.FunctionsListView.View = System.Windows.Forms.View.Details;
            this.FunctionsListView.VirtualMode = true;
            this.FunctionsListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.FunctionsListView_ColumnClick);
            this.FunctionsListView.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.FunctionsListView_RetrieveVirtualItem);
            this.FunctionsListView.SelectedIndexChanged += new System.EventHandler(this.FunctionsListView_SelectedIndexChanged);
            this.FunctionsListView.DoubleClick += new System.EventHandler(this.FunctionsListView_DoubleClick);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Function";
            this.columnHeader3.Width = 126;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Type";
            this.columnHeader4.Width = 68;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Length";
            // 
            // FileLinesLabel
            // 
            this.FileLinesLabel.AutoSize = true;
            this.FileLinesLabel.Location = new System.Drawing.Point(3, 31);
            this.FileLinesLabel.Name = "FileLinesLabel";
            this.FileLinesLabel.Size = new System.Drawing.Size(87, 13);
            this.FileLinesLabel.TabIndex = 3;
            this.FileLinesLabel.Text = "Nothing selected";
            // 
            // FileNameLabel
            // 
            this.FileNameLabel.AutoSize = true;
            this.FileNameLabel.Location = new System.Drawing.Point(3, 8);
            this.FileNameLabel.Name = "FileNameLabel";
            this.FileNameLabel.Size = new System.Drawing.Size(87, 13);
            this.FileNameLabel.TabIndex = 0;
            this.FileNameLabel.Text = "Nothing selected";
            // 
            // FunctionPanel
            // 
            this.FunctionPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FunctionPanel.Controls.Add(this.splitContainer3);
            this.FunctionPanel.Enabled = false;
            this.FunctionPanel.Location = new System.Drawing.Point(3, 0);
            this.FunctionPanel.Name = "FunctionPanel";
            this.FunctionPanel.Size = new System.Drawing.Size(405, 785);
            this.FunctionPanel.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.splitContainer4);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.FunctionTextBox);
            this.splitContainer3.Size = new System.Drawing.Size(405, 785);
            this.splitContainer3.SplitterDistance = 495;
            this.splitContainer3.TabIndex = 18;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.label2);
            this.splitContainer4.Panel1.Controls.Add(this.FunctionAbortButton);
            this.splitContainer4.Panel1.Controls.Add(this.FunctionStatusLabel);
            this.splitContainer4.Panel1.Controls.Add(this.FunctionMatchesListView);
            this.splitContainer4.Panel1.Controls.Add(this.FunctionLabel);
            this.splitContainer4.Panel1.Controls.Add(this.FunctionRefactorButton);
            this.splitContainer4.Panel1.Controls.Add(this.FunctionMatchButton);
            this.splitContainer4.Panel1.Controls.Add(this.FunctionRefactorNameTextBox);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.splitContainer5);
            this.splitContainer4.Size = new System.Drawing.Size(405, 492);
            this.splitContainer4.SplitterDistance = 252;
            this.splitContainer4.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "New name:";
            // 
            // FunctionAbortButton
            // 
            this.FunctionAbortButton.Location = new System.Drawing.Point(81, 26);
            this.FunctionAbortButton.Name = "FunctionAbortButton";
            this.FunctionAbortButton.Size = new System.Drawing.Size(75, 23);
            this.FunctionAbortButton.TabIndex = 10;
            this.FunctionAbortButton.Text = "Abort";
            this.FunctionAbortButton.UseVisualStyleBackColor = true;
            this.FunctionAbortButton.Click += new System.EventHandler(this.FunctionAbortButton_Click);
            // 
            // FunctionStatusLabel
            // 
            this.FunctionStatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FunctionStatusLabel.AutoEllipsis = true;
            this.FunctionStatusLabel.Location = new System.Drawing.Point(162, 31);
            this.FunctionStatusLabel.Name = "FunctionStatusLabel";
            this.FunctionStatusLabel.Size = new System.Drawing.Size(240, 13);
            this.FunctionStatusLabel.TabIndex = 11;
            this.FunctionStatusLabel.Text = "Tip: Match and Refactor functions with no dependencies first";
            // 
            // FunctionMatchesListView
            // 
            this.FunctionMatchesListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FunctionMatchesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11});
            this.FunctionMatchesListView.FullRowSelect = true;
            this.FunctionMatchesListView.HideSelection = false;
            this.FunctionMatchesListView.Location = new System.Drawing.Point(0, 82);
            this.FunctionMatchesListView.MultiSelect = false;
            this.FunctionMatchesListView.Name = "FunctionMatchesListView";
            this.FunctionMatchesListView.Size = new System.Drawing.Size(402, 167);
            this.FunctionMatchesListView.TabIndex = 13;
            this.FunctionMatchesListView.UseCompatibleStateImageBehavior = false;
            this.FunctionMatchesListView.View = System.Windows.Forms.View.Details;
            this.FunctionMatchesListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.FunctionMatchesListView_ColumnClick);
            this.FunctionMatchesListView.DoubleClick += new System.EventHandler(this.FunctionMatchesListView_DoubleClick);
            this.FunctionMatchesListView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FunctionMatchesListView_MouseClick);
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "File";
            this.columnHeader9.Width = 150;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Name";
            this.columnHeader10.Width = 144;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Match %";
            // 
            // FunctionLabel
            // 
            this.FunctionLabel.AutoSize = true;
            this.FunctionLabel.Location = new System.Drawing.Point(3, 8);
            this.FunctionLabel.Name = "FunctionLabel";
            this.FunctionLabel.Size = new System.Drawing.Size(87, 13);
            this.FunctionLabel.TabIndex = 5;
            this.FunctionLabel.Text = "Nothing selected";
            // 
            // FunctionRefactorButton
            // 
            this.FunctionRefactorButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FunctionRefactorButton.Location = new System.Drawing.Point(327, 53);
            this.FunctionRefactorButton.Name = "FunctionRefactorButton";
            this.FunctionRefactorButton.Size = new System.Drawing.Size(75, 23);
            this.FunctionRefactorButton.TabIndex = 12;
            this.FunctionRefactorButton.Text = "Refactor";
            this.FunctionRefactorButton.UseVisualStyleBackColor = true;
            this.FunctionRefactorButton.Click += new System.EventHandler(this.FunctionRefactorButton_Click);
            // 
            // FunctionMatchButton
            // 
            this.FunctionMatchButton.Location = new System.Drawing.Point(0, 26);
            this.FunctionMatchButton.Name = "FunctionMatchButton";
            this.FunctionMatchButton.Size = new System.Drawing.Size(75, 23);
            this.FunctionMatchButton.TabIndex = 9;
            this.FunctionMatchButton.Text = "Match";
            this.FunctionMatchButton.UseVisualStyleBackColor = true;
            this.FunctionMatchButton.Click += new System.EventHandler(this.FunctionMatchButton_Click);
            // 
            // FunctionRefactorNameTextBox
            // 
            this.FunctionRefactorNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FunctionRefactorNameTextBox.Location = new System.Drawing.Point(70, 55);
            this.FunctionRefactorNameTextBox.Name = "FunctionRefactorNameTextBox";
            this.FunctionRefactorNameTextBox.Size = new System.Drawing.Size(248, 20);
            this.FunctionRefactorNameTextBox.TabIndex = 11;
            // 
            // splitContainer5
            // 
            this.splitContainer5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer5.Location = new System.Drawing.Point(0, 3);
            this.splitContainer5.Name = "splitContainer5";
            this.splitContainer5.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.FunctionDependenciesListView);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.FunctionReferencesListView);
            this.splitContainer5.Size = new System.Drawing.Size(405, 233);
            this.splitContainer5.SplitterDistance = 114;
            this.splitContainer5.TabIndex = 16;
            // 
            // FunctionDependenciesListView
            // 
            this.FunctionDependenciesListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FunctionDependenciesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.FunctionDependenciesListView.FullRowSelect = true;
            this.FunctionDependenciesListView.HideSelection = false;
            this.FunctionDependenciesListView.Location = new System.Drawing.Point(0, 0);
            this.FunctionDependenciesListView.MultiSelect = false;
            this.FunctionDependenciesListView.Name = "FunctionDependenciesListView";
            this.FunctionDependenciesListView.Size = new System.Drawing.Size(402, 111);
            this.FunctionDependenciesListView.TabIndex = 15;
            this.FunctionDependenciesListView.UseCompatibleStateImageBehavior = false;
            this.FunctionDependenciesListView.View = System.Windows.Forms.View.Details;
            this.FunctionDependenciesListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.FunctionDependenciesListView_ColumnClick);
            this.FunctionDependenciesListView.DoubleClick += new System.EventHandler(this.FunctionDependenciesListView_DoubleClick);
            this.FunctionDependenciesListView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FunctionDependenciesListView_MouseClick);
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Dependency";
            this.columnHeader6.Width = 140;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Parameters";
            this.columnHeader7.Width = 150;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Line";
            this.columnHeader8.Width = 80;
            // 
            // FunctionReferencesListView
            // 
            this.FunctionReferencesListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FunctionReferencesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14});
            this.FunctionReferencesListView.FullRowSelect = true;
            this.FunctionReferencesListView.HideSelection = false;
            this.FunctionReferencesListView.Location = new System.Drawing.Point(0, 3);
            this.FunctionReferencesListView.MultiSelect = false;
            this.FunctionReferencesListView.Name = "FunctionReferencesListView";
            this.FunctionReferencesListView.Size = new System.Drawing.Size(402, 112);
            this.FunctionReferencesListView.TabIndex = 17;
            this.FunctionReferencesListView.UseCompatibleStateImageBehavior = false;
            this.FunctionReferencesListView.View = System.Windows.Forms.View.Details;
            this.FunctionReferencesListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.FunctionReferencesListView_ColumnClick);
            this.FunctionReferencesListView.DoubleClick += new System.EventHandler(this.FunctionReferencesListView_DoubleClick);
            this.FunctionReferencesListView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FunctionReferencesListView_MouseClick);
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Referenced in";
            this.columnHeader12.Width = 140;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Parameters";
            this.columnHeader13.Width = 150;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Line";
            this.columnHeader14.Width = 80;
            // 
            // FunctionTextBox
            // 
            this.FunctionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FunctionTextBox.Location = new System.Drawing.Point(0, 3);
            this.FunctionTextBox.Multiline = true;
            this.FunctionTextBox.Name = "FunctionTextBox";
            this.FunctionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.FunctionTextBox.Size = new System.Drawing.Size(402, 280);
            this.FunctionTextBox.TabIndex = 19;
            this.FunctionTextBox.WordWrap = false;
            // 
            // NavContextMenu
            // 
            this.NavContextMenu.Name = "ContextMenu";
            this.NavContextMenu.Size = new System.Drawing.Size(61, 4);
            this.NavContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.NavContextMenu_Opening);
            this.NavContextMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.NavContextMenu_ItemClicked);
            // 
            // ScanFolderButton
            // 
            this.ScanFolderButton.Location = new System.Drawing.Point(302, 10);
            this.ScanFolderButton.Name = "ScanFolderButton";
            this.ScanFolderButton.Size = new System.Drawing.Size(75, 23);
            this.ScanFolderButton.TabIndex = 2;
            this.ScanFolderButton.Text = "Scan";
            this.ScanFolderButton.UseVisualStyleBackColor = true;
            this.ScanFolderButton.Click += new System.EventHandler(this.ScanFolderButton_Click);
            // 
            // FolderBrowseButton
            // 
            this.FolderBrowseButton.Location = new System.Drawing.Point(269, 10);
            this.FolderBrowseButton.Name = "FolderBrowseButton";
            this.FolderBrowseButton.Size = new System.Drawing.Size(27, 23);
            this.FolderBrowseButton.TabIndex = 1;
            this.FolderBrowseButton.Text = "...";
            this.FolderBrowseButton.UseVisualStyleBackColor = true;
            this.FolderBrowseButton.Click += new System.EventHandler(this.FolderBrowseButton_Click);
            // 
            // GlobalsFileNameTextBox
            // 
            this.GlobalsFileNameTextBox.Location = new System.Drawing.Point(473, 12);
            this.GlobalsFileNameTextBox.Name = "GlobalsFileNameTextBox";
            this.GlobalsFileNameTextBox.Size = new System.Drawing.Size(86, 20);
            this.GlobalsFileNameTextBox.TabIndex = 3;
            this.GlobalsFileNameTextBox.Text = "_globals.c";
            this.GlobalsFileNameTextBox.TextChanged += new System.EventHandler(this.GlobalsFileNameTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(406, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Globals file:";
            // 
            // ToolsButton
            // 
            this.ToolsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ToolsButton.Location = new System.Drawing.Point(900, 10);
            this.ToolsButton.Name = "ToolsButton";
            this.ToolsButton.Size = new System.Drawing.Size(74, 23);
            this.ToolsButton.TabIndex = 10;
            this.ToolsButton.Text = "Tools";
            this.ToolsButton.UseVisualStyleBackColor = true;
            this.ToolsButton.Click += new System.EventHandler(this.ToolsButton_Click);
            // 
            // ToolsMenu
            // 
            this.ToolsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolsMenuFindReplace,
            this.ToolsMenuFindCoordinates,
            this.ToolsMenuAutoRefactor,
            this.ToolsMenuJenkGen,
            this.ToolsMenuJenkInd,
            this.ToolsMenuSyntaxCheck});
            this.ToolsMenu.Name = "ToolsMenu";
            this.ToolsMenu.Size = new System.Drawing.Size(174, 158);
            // 
            // ToolsMenuSyntaxCheck
            // 
            this.ToolsMenuSyntaxCheck.Name = "ToolsMenuSyntaxCheck";
            this.ToolsMenuSyntaxCheck.Size = new System.Drawing.Size(173, 22);
            this.ToolsMenuSyntaxCheck.Text = "Syntax Check";
            this.ToolsMenuSyntaxCheck.Click += new System.EventHandler(this.ToolsMenuSyntaxCheck_Click);
            // 
            // ToolsMenuFindReplace
            // 
            this.ToolsMenuFindReplace.Name = "ToolsMenuFindReplace";
            this.ToolsMenuFindReplace.Size = new System.Drawing.Size(173, 22);
            this.ToolsMenuFindReplace.Text = "Find/Replace...";
            this.ToolsMenuFindReplace.Click += new System.EventHandler(this.ToolsMenuFindReplace_Click);
            // 
            // ToolsMenuAutoRefactor
            // 
            this.ToolsMenuAutoRefactor.Name = "ToolsMenuAutoRefactor";
            this.ToolsMenuAutoRefactor.Size = new System.Drawing.Size(173, 22);
            this.ToolsMenuAutoRefactor.Text = "AutoRefactor...";
            this.ToolsMenuAutoRefactor.Click += new System.EventHandler(this.ToolsMenuAutoRefactor_Click);
            // 
            // ToolsMenuJenkGen
            // 
            this.ToolsMenuJenkGen.Name = "ToolsMenuJenkGen";
            this.ToolsMenuJenkGen.Size = new System.Drawing.Size(173, 22);
            this.ToolsMenuJenkGen.Text = "JenkGen...";
            this.ToolsMenuJenkGen.Click += new System.EventHandler(this.ToolsMenuJenkGen_Click);
            // 
            // ToolsMenuJenkInd
            // 
            this.ToolsMenuJenkInd.Name = "ToolsMenuJenkInd";
            this.ToolsMenuJenkInd.Size = new System.Drawing.Size(173, 22);
            this.ToolsMenuJenkInd.Text = "JenkInd...";
            this.ToolsMenuJenkInd.Click += new System.EventHandler(this.ToolsMenuJenkInd_Click);
            // 
            // ToolsMenuFindCoordinates
            // 
            this.ToolsMenuFindCoordinates.Name = "ToolsMenuFindCoordinates";
            this.ToolsMenuFindCoordinates.Size = new System.Drawing.Size(173, 22);
            this.ToolsMenuFindCoordinates.Text = "Find Coordinates...";
            this.ToolsMenuFindCoordinates.Click += new System.EventHandler(this.ToolsMenuFindCoordinates_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 838);
            this.Controls.Add(this.ToolsButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GlobalsFileNameTextBox);
            this.Controls.Add(this.FolderBrowseButton);
            this.Controls.Add(this.ScanFolderButton);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.FolderTextBox);
            this.MinimumSize = new System.Drawing.Size(1002, 877);
            this.Name = "MainForm";
            this.Text = "GTA V Refactor by dexyfex";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.FilePanel.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.FunctionPanel.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.PerformLayout();
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            this.ToolsMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FolderTextBox;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView FilesListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button ScanFolderButton;
        private System.Windows.Forms.Label FileNameLabel;
        private System.Windows.Forms.Panel FilePanel;
        private System.Windows.Forms.ListView FunctionsListView;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label FileLinesLabel;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Label FunctionLabel;
        private System.Windows.Forms.TextBox FunctionTextBox;
        private System.Windows.Forms.Button FunctionMatchButton;
        private System.Windows.Forms.ListView FunctionDependenciesListView;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ListView FunctionMatchesListView;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.Button FolderBrowseButton;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog;
        private System.Windows.Forms.Button FunctionRefactorButton;
        private System.Windows.Forms.TextBox FunctionRefactorNameTextBox;
        private System.Windows.Forms.TextBox GlobalsFileNameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.ListView FunctionReferencesListView;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.Panel FunctionPanel;
        private System.Windows.Forms.Label FunctionStatusLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button FunctionAbortButton;
        private System.Windows.Forms.ContextMenuStrip NavContextMenu;
        private System.Windows.Forms.Button NavForwardButton;
        private System.Windows.Forms.Button NavBackButton;
        private System.Windows.Forms.Button ToolsButton;
        private System.Windows.Forms.ContextMenuStrip ToolsMenu;
        private System.Windows.Forms.ToolStripMenuItem ToolsMenuSyntaxCheck;
        private System.Windows.Forms.ToolStripMenuItem ToolsMenuAutoRefactor;
        private System.Windows.Forms.ToolStripMenuItem ToolsMenuFindReplace;
        private System.Windows.Forms.ToolStripMenuItem ToolsMenuJenkGen;
        private System.Windows.Forms.ToolStripMenuItem ToolsMenuJenkInd;
        private System.Windows.Forms.ToolStripMenuItem ToolsMenuFindCoordinates;
    }
}

