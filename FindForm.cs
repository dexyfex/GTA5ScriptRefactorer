using gta5refactor.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gta5refactor
{
    public partial class FindForm : Form
    {
        private MainForm OwnerForm;
        volatile bool AbortOperation = false;
        bool InProgress = false;

        public FindForm(MainForm owner)
        {
            InitializeComponent();

            OwnerForm = owner;
            ScriptFolderTextBox.Text = Settings.Default.ScriptFolder;
        }

        private void FolderBrowseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog.SelectedPath = ScriptFolderTextBox.Text;
            DialogResult res = FolderBrowserDialog.ShowDialog();
            if (res == DialogResult.OK)
            {
                ScriptFolderTextBox.Text = FolderBrowserDialog.SelectedPath;
            }
        }

        private void AbortButton_Click(object sender, EventArgs e)
        {
            AbortOperation = true;
        }


        private void FindButton_Click(object sender, EventArgs e)
        {
            if (InProgress)
            {
                return;
            }
            if (string.IsNullOrEmpty(FindTextBox.Text))
            {
                MessageBox.Show("Please enter a search term.");
                return;
            }

            Find();
        }

        private void ReplaceButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sorry, not yet implemented!");
        }


        private void Find()
        {
            AbortOperation = false;
            InProgress = true;

            string scriptfolder = ScriptFolderTextBox.Text;
            bool casesensitive = CaseSensitiveCheckBox.Checked;
            string searchterm = casesensitive ? FindTextBox.Text : FindTextBox.Text.ToLower();

            MatchesListView.Items.Clear();
            FunctionTextBox.Text = string.Empty;


            Task.Run(() =>
            {

                UpdateStatus("Task beginning...");

                DateTime starttime = DateTime.Now;

                List<FindMatch> matches = new List<FindMatch>();

                string[] scriptfiles = Directory.GetFiles(scriptfolder);

                foreach (string scriptfile in scriptfiles)
                {
                    if (AbortOperation)
                    {
                        UpdateStatus("Search aborted.");
                        FindComplete(matches);
                        return;
                    }

                    string filel = scriptfile.ToLower();
                    if (!(filel.EndsWith(".c") || filel.EndsWith(".c4"))) continue;

                    UpdateStatus("Searching " + scriptfile);

                    ScriptFile sf = new ScriptFile(scriptfile);
                    string[] lines = File.ReadAllLines(scriptfile);

                    for (int i = 0; i < lines.Length; i++)
                    {
                        if (AbortOperation)
                        {
                            UpdateStatus("Search aborted.");
                            FindComplete(matches);
                            return;
                        }


                        string line = lines[i];
                        string searchtext = casesensitive ? line : line.ToLower();
                        int foundindex = searchtext.IndexOf(searchterm);
                        if (foundindex >= 0)
                        {
                            //there's a match on this line. record it for posterity
                            FindMatch match = new FindMatch();
                            match.File = sf;
                            match.Line = i;
                            match.Char = foundindex;

                            matches.Add(match);

                            FoundMatch(match);
                        }
                    }


                }


                UpdateStatus(string.Format("Find complete. {0} matches found.", matches.Count));
                FindComplete(matches);
            });
        }

        private void FindComplete(List<FindMatch> matches)
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new Action(() => { FindComplete(matches); }));
                }
                else
                {
                    InProgress = false;

                }
            }
            catch { }
        }

        private void FoundMatch(FindMatch match)
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new Action(() => { FoundMatch(match); }));
                }
                else
                {
                    ListViewItem lvi = new ListViewItem(new string[] { match.File.Name, match.Line.ToString(), match.Char.ToString() });
                    lvi.Tag = match;
                    MatchesListView.Items.Add(lvi);
                }
            }
            catch { }
        }

        private void UpdateStatus(string text)
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new Action(() => { UpdateStatus(text); }));
                }
                else
                {
                    StatusLabel.Text = text;
                }
            }
            catch { }
        }

        private void MatchesListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MatchesListView.SelectedItems.Count != 1)
            {
                FunctionTextBox.Text = string.Empty;
                return;
            }

            ListViewItem selitem = MatchesListView.SelectedItems[0];
            FindMatch fm = (FindMatch)selitem.Tag;

            ScriptFunction func = fm.File.TryGetFunction(fm.Line, true);

            if (func == null)
            {
                FunctionTextBox.Text = string.Empty;
                return;
            }

            FunctionTextBox.Text = func.FunctionText;

            int lineoff = fm.Line - func.StartLine;
            int charoff = fm.Char;
            for (int i = 0; i < lineoff; i++)
            {
                charoff += fm.File.FileLines[i + func.StartLine].Length + 2;
            }

            //FunctionTextBox.Select(charoff, FindTextBox.Text.Length);
            FunctionTextBox.SelectionStart = charoff;
            FunctionTextBox.SelectionLength = FindTextBox.Text.Length;
            FunctionTextBox.ScrollToCaret();

        }
    }


    public class FindMatch
    {
        public ScriptFile File { get; set; }
        public int Line { get; set; }
        public int Char { get; set; }
    }

}
