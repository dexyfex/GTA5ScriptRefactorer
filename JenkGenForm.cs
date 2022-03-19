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
    public partial class JenkGenForm : Form
    {
        private MainForm OwnerForm;
        volatile bool AbortOperation = false;
        bool InProgress = false;
        List<ScriptHash> ScriptHashes = null;
        Dictionary<string, int> UniqueHashes = null;
        List<string> MatchedHashes = new List<string>();


        public JenkGenForm(MainForm owner)
        {
            InitializeComponent();

            OwnerForm = owner;
            ScriptFolderTextBox.Text = Settings.Default.ScriptFolder;
        }

        private void InputTextBox_TextChanged(object sender, EventArgs e)
        {
            GenerateHash();
        }

        private void UTF8RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            GenerateHash();
        }

        private void ASCIIRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            GenerateHash();
        }


        private void GenerateHash()
        {
            JenkHashInputEncoding encoding = JenkHashInputEncoding.UTF8;
            if (ASCIIRadioButton.Checked) encoding = JenkHashInputEncoding.ASCII;

            JenkHash h = new JenkHash(InputTextBox.Text, encoding);

            HashHexTextBox.Text = h.HashHex;
            HashSignedTextBox.Text = h.HashInt.ToString();
            HashUnsignedTextBox.Text = h.HashUint.ToString();

            MatchGeneratedHash();
        }





        private void ScriptFolderBrowseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog.SelectedPath = ScriptFolderTextBox.Text;
            DialogResult res = FolderBrowserDialog.ShowDialog();
            if (res == DialogResult.OK)
            {
                ScriptFolderTextBox.Text = FolderBrowserDialog.SelectedPath;
            }
        }

        private void BuildScriptIndexButton_Click(object sender, EventArgs e)
        {
            if (InProgress) return;

            BuildScriptIndex();
        }

        private void UpdateScriptsButton_Click(object sender, EventArgs e)
        {
            if (InProgress) return;

            if (MessageBox.Show("Continue updating scripts?", "Confirm", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                return;
            }

            UpdateScripts();
        }



        private void BuildScriptIndex()
        {
            AbortOperation = false;
            InProgress = true;

            string scriptfolder = ScriptFolderTextBox.Text;
            bool findunsigned = true;
            bool findsigned = true;
            bool findhex = true;
            int minlength = (int)5;

            UniqueHashesTextBox.Text = string.Empty;
            ScriptMatchesLabel.Text = "0";

            //this part is slightly redundant - same code in JenkIndForm to find all script hashes
            Task.Run(() =>
            {

                UpdateStatus("Task beginning...");

                DateTime starttime = DateTime.Now;

                string[] scriptfiles = Directory.GetFiles(scriptfolder);


                //go through all the script files and look for hashes.
                List<ScriptHash> foundhashes = new List<ScriptHash>();
                foreach (string scriptfile in scriptfiles)
                {
                    if (AbortOperation)
                    {
                        UpdateStatus("Hash search aborted.");
                        BuildScriptIndexComplete(null, null);
                        return;
                    }

                    string filel = scriptfile.ToLower();
                    if (!(filel.EndsWith(".c") || filel.EndsWith(".c4"))) continue;

                    UpdateStatus(GetTimeStr(starttime) + ": Searching " + scriptfile);

                    ScriptFile sf = new ScriptFile(scriptfile);

                    List<ScriptHash> hl = sf.FindHashes(findunsigned, findsigned, findhex, minlength);

                    foundhashes.AddRange(hl);
                }


                UpdateStatus("Compiling hashes...");

                Dictionary<string, int> uniquehashes = new Dictionary<string, int>();
                foreach (ScriptHash foundhash in foundhashes)
                {
                    if (uniquehashes.ContainsKey(foundhash.HashStr))
                    {
                        uniquehashes[foundhash.HashStr]++;
                    }
                    else
                    {
                        uniquehashes.Add(foundhash.HashStr, 1);
                    }
                }

                BuildScriptIndexComplete(foundhashes, uniquehashes);
            });
        }

        private void BuildScriptIndexComplete(List<ScriptHash> foundhashes, Dictionary<string, int> uniquehashes)
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new Action(() => { BuildScriptIndexComplete(foundhashes, uniquehashes); }));
                }
                else
                {
                    InProgress = false;

                    if (uniquehashes != null)
                    {
                        ScriptHashes = foundhashes;
                        UniqueHashes = uniquehashes;
                        ScriptHashesLabel.Text = uniquehashes.Count.ToString();

                        StringBuilder sb = new StringBuilder();
                        foreach (KeyValuePair<string, int> kvp in uniquehashes)
                        {
                            sb.AppendLine(string.Format("{0}  ({1} refs)", kvp.Key, kvp.Value));
                        }
                        UniqueHashesTextBox.Text = sb.ToString();

                        UpdateStatus("Script indexing complete");
                    }
                }
            }
            catch { }
        }


        private void UpdateScripts()
        {

            AbortOperation = false;
            InProgress = true;

            string scriptfolder = ScriptFolderTextBox.Text;
            string format = UpdateFormatComboBox.Text;
            bool replace = ReplaceRadioButton.Checked;
            bool insert = InsertBeforeRadioButton.Checked;
            string val = InputTextBox.Text;



            string hexhash = HashHexTextBox.Text.ToLower();
            string signedhash = HashSignedTextBox.Text;
            string unsignedhash = HashUnsignedTextBox.Text;


            //stuff needed for the ReplaceHashes method
            Dictionary<string, JenkIndMatch> matches = new Dictionary<string, JenkIndMatch>();
            matches.Add(hexhash, new JenkIndMatch(hexhash, val));
            matches.Add(signedhash, new JenkIndMatch(signedhash, val));
            if (unsignedhash != signedhash)
            {
                matches.Add(unsignedhash, new JenkIndMatch(unsignedhash, val));
            }
            Dictionary<string, List<JenkIndMatch>> collisions = new Dictionary<string, List<JenkIndMatch>>();


            //this part is slightly redundant - same code in JenkIndForm to find all script hashes
            Task.Run(() =>
            {

                UpdateStatus("Task beginning...");

                DateTime starttime = DateTime.Now;



                Dictionary<string, List<ScriptHash>> hashesbyfile = new Dictionary<string, List<ScriptHash>>();
                foreach (ScriptHash hash in ScriptHashes)
                {
                    if ((hash.HashStr == hexhash) || (hash.HashStr == signedhash) || (hash.HashStr == unsignedhash))
                    {
                        List<ScriptHash> hashlist;
                        if (!hashesbyfile.TryGetValue(hash.File.Name, out hashlist))
                        {
                            hashlist = new List<ScriptHash>();
                            hashesbyfile.Add(hash.File.Name, hashlist);
                        }
                        hashlist.Add(hash);
                    }
                }

                string[] scriptfiles = Directory.GetFiles(scriptfolder);

                List<ScriptChange> allchanges = new List<ScriptChange>();
                int filecount = 0;

                foreach (string scriptfile in scriptfiles)
                {
                    string filename = new FileInfo(scriptfile).Name;
                    List<ScriptHash> hashlist;
                    if (hashesbyfile.TryGetValue(filename, out hashlist))
                    {
                        if (hashlist.Count > 0)
                        {
                            UpdateStatus("Updating " + filename + "...");

                            ScriptFile file = hashlist[0].File;

                            List<ScriptChange> changes = file.ReplaceHashes(hashlist, matches, collisions, format, replace, insert);

                            allchanges.AddRange(changes);

                            if (changes.Count > 0)
                            {
                                filecount++;
                            }
                        }
                    }
                }
                
                UpdateScriptsComplete(allchanges, filecount);
            });
        }

        private void UpdateScriptsComplete(List<ScriptChange> changes, int filecount)
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new Action(() => { UpdateScriptsComplete(changes, filecount); }));
                }
                else
                {
                    InProgress = false;

                    UpdateStatus("Update scripts complete. " + filecount.ToString() + " files modified.");
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



        private void MatchGeneratedHash()
        {
            if (UniqueHashes == null) return;

            MatchedHashes.Clear();
            MatchesListView.Items.Clear();
            int totalmatches = 0;
            string[] hashes = new string[] { HashHexTextBox.Text, HashSignedTextBox.Text, HashUnsignedTextBox.Text };

            foreach (string hash in hashes)
            {
                string hashlc = hash.ToLower();
                int matches = 0;
                if (UniqueHashes.TryGetValue(hashlc, out matches))
                {
                    MatchedHashes.Add(hashlc);
                    totalmatches += matches;
                    //ScriptMatchesTextBox.AppendText(string.Format("{0}  ({1} refs)\r\n", hashlc, matches));

                    foreach (ScriptHash scripthash in ScriptHashes)
                    {
                        if (scripthash.HashStr == hashlc)
                        {
                            ListViewItem lvi = new ListViewItem(new string[] { scripthash.File.Name, scripthash.Line.ToString() });
                            lvi.Tag = scripthash;
                            MatchesListView.Items.Add(lvi);
                        }
                    }

                }
            }

            ScriptMatchesLabel.Text = totalmatches.ToString();

            UpdateScriptsGroupBox.Enabled = (totalmatches > 0);

        }

        private void MatchesListView_DoubleClick(object sender, EventArgs e)
        {
            if (MatchesListView.SelectedItems.Count != 1) return;

            ListViewItem lvi = MatchesListView.SelectedItems[0];
            ScriptHash hash = lvi.Tag as ScriptHash;

            if (hash == null) return;

            ScriptFile sfile = hash.File;

            bool loaded = (sfile.FileLines != null);
            if (!loaded) sfile.Load();

            foreach (ScriptFunction func in sfile.Functions)
            {
                if ((func.StartLine <= hash.Line) && (func.EndLine >= hash.Line))
                {
                    ShowViewForm(func, hash.Line, hash.Char, hash.HashStr.Length);
                    break;
                }
            }

            if (!loaded) sfile.Unload();
        }

        private void ShowViewForm(ScriptFunction func, int linesel, int charsel = 0, int sellen = 0)
        {
            ViewForm form = new ViewForm();
            form.LoadFunction(func, linesel, charsel, sellen);
            form.Show(this);
        }

        private string GetTimeStr(DateTime starttime)
        {
            return (DateTime.Now - starttime).ToString("h\\:mm\\:ss");
        }

    }



}
