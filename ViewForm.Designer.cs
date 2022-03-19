namespace gta5refactor
{
    partial class ViewForm
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
            this.FunctionTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.FindTextBox = new System.Windows.Forms.TextBox();
            this.FindNextButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FunctionTextBox
            // 
            this.FunctionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FunctionTextBox.HideSelection = false;
            this.FunctionTextBox.Location = new System.Drawing.Point(12, 39);
            this.FunctionTextBox.Multiline = true;
            this.FunctionTextBox.Name = "FunctionTextBox";
            this.FunctionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.FunctionTextBox.Size = new System.Drawing.Size(386, 354);
            this.FunctionTextBox.TabIndex = 0;
            this.FunctionTextBox.WordWrap = false;
            this.FunctionTextBox.Enter += new System.EventHandler(this.FunctionTextBox_Enter);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(179, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Find:";
            // 
            // FindTextBox
            // 
            this.FindTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FindTextBox.Location = new System.Drawing.Point(215, 12);
            this.FindTextBox.Name = "FindTextBox";
            this.FindTextBox.Size = new System.Drawing.Size(150, 20);
            this.FindTextBox.TabIndex = 2;
            this.FindTextBox.TextChanged += new System.EventHandler(this.FindTextBox_TextChanged);
            // 
            // FindNextButton
            // 
            this.FindNextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FindNextButton.Location = new System.Drawing.Point(371, 10);
            this.FindNextButton.Name = "FindNextButton";
            this.FindNextButton.Size = new System.Drawing.Size(27, 23);
            this.FindNextButton.TabIndex = 3;
            this.FindNextButton.Text = ">";
            this.FindNextButton.UseVisualStyleBackColor = true;
            this.FindNextButton.Click += new System.EventHandler(this.FindNextButton_Click);
            // 
            // ViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 405);
            this.Controls.Add(this.FindNextButton);
            this.Controls.Add(this.FindTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FunctionTextBox);
            this.Name = "ViewForm";
            this.Text = "GTA V Refactor by dexyfex - View Function";
            this.Load += new System.EventHandler(this.ViewForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FunctionTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox FindTextBox;
        private System.Windows.Forms.Button FindNextButton;
    }
}