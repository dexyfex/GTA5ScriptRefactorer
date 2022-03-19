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
    public partial class JenkIndForm : Form
    {
        private MainForm OwnerForm;
        volatile bool AbortOperation = false;
        bool InProgress = false;
        List<ScriptHash> ScriptHashes = null;
        Dictionary<string, JenkIndMatch> JenkIndUniqueMatches = null;
        Dictionary<string, List<JenkIndMatch>> JenkIndCollisions = null;
        Dictionary<string, int> JenkIndMisses = null;

        public JenkIndForm(MainForm owner)
        {
            InitializeComponent();

            OwnerForm = owner;
            ScriptFolderTextBox.Text = Settings.Default.ScriptFolder;
            JenkIndFolderTextBox.Text = Settings.Default.JenkIndFolder;
        }

        private void JenkIndFolderTextBox_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.JenkIndFolder = JenkIndFolderTextBox.Text;
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

        private void JenkIndFolderBrowseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog.SelectedPath = Settings.Default.JenkIndFolder;
            DialogResult res = FolderBrowserDialog.ShowDialog();
            if (res == DialogResult.OK)
            {
                JenkIndFolderTextBox.Text = FolderBrowserDialog.SelectedPath;
            }
        }


        private void BeginButton_Click(object sender, EventArgs e)
        {
            if (InProgress)
            {
                return;
            }
            //if (MessageBox.Show("Begin DeJenkification?\nCould take a while.\nMany script files may be modified...", "Confirm begin DeJenkify", MessageBoxButtons.OKCancel) != DialogResult.OK)
            //{
            //    return;
            //}
            if (!Directory.Exists(ScriptFolderTextBox.Text))
            {
                MessageBox.Show("Error: Folder doesn't exist: " + ScriptFolderTextBox.Text);
                return;
            }
            if (!Directory.Exists(JenkIndFolderTextBox.Text))
            {
                MessageBox.Show("Error: Folder doesn't exist: " + JenkIndFolderTextBox.Text);
                return;
            }

            JenkIndSearch();
        }

        private void AbortButton_Click(object sender, EventArgs e)
        {
            if (!InProgress)
            {
                return;
            }
            //if (MessageBox.Show("Abort DeJenkification?\nDon't want to accidentally waste your time.", "Confirm abort DeJenkify", MessageBoxButtons.OKCancel) != DialogResult.OK)
            //{
            //    return;
            //}
            AbortOperation = true;
        }

        private void UpdateScriptsButton_Click(object sender, EventArgs e)
        {
            if (InProgress)
            {
                MessageBox.Show("Operation is in progress. Please wait for it to complete.");
                return;
            }
            if (JenkIndUniqueMatches == null)
            {
                MessageBox.Show("Please run the JenkInd search first.");
                return;
            }
            if (MessageBox.Show("Are you sure you want to update the script files in " + ScriptFolderTextBox.Text + "?", "Confirm script update", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                return;
            }

            UpdateScripts();
        }




        private void JenkIndSearch()
        {
            AbortOperation = false;
            InProgress = true;

            string scriptfolder = ScriptFolderTextBox.Text;
            string jenkindfolder = JenkIndFolderTextBox.Text;
            bool findunsigned = UnsignedCheckBox.Checked;
            bool findsigned = SignedCheckBox.Checked;
            bool findhex = HexCheckBox.Checked;
            int minlength = (int)MinLengthUpDown.Value;
            double threshold = (double)ThresholdUpDown.Value;

            ScriptChangesTextBox.Text = string.Empty;
            HashCollisionsTextBox.Text = string.Empty;
            UniqueHashesTextBox.Text = string.Empty;
            HashMatchesTextBox.Text = string.Empty;
            ProblemsTextBox.Text = string.Empty;
            UniqueScriptHashesLabel.Text = "-";
            TotalScriptHashesLabel.Text = "-";
            TotalMissesLabel.Text = "-";
            HashCollisionsLabel.Text = "-";
            TotalHashMatchesLabel.Text = "-";
            UniqueHashMatchesLabel.Text = "-";
            TotalChangesLabel.Text = "-";
            FilesModifiedLabel.Text = "-";

            Task.Run(() =>
            {

                UpdateStatus("Task beginning...");

                DateTime starttime = DateTime.Now;

                string[] scriptfiles = Directory.GetFiles(scriptfolder);


                //first, go through all the script files and look for hashes.
                List<ScriptHash> foundhashes = new List<ScriptHash>();
                foreach (string scriptfile in scriptfiles)
                {
                    if (AbortOperation)
                    {
                        UpdateStatus("Hash search aborted.");
                        JenkIndSearchComplete();
                        return;
                    }

                    string filel = scriptfile.ToLower();
                    if (!(filel.EndsWith(".c") || filel.EndsWith(".c4"))) continue;

                    UpdateStatus(GetTimeStr(starttime) + ": Searching " + scriptfile);

                    ScriptFile sf = new ScriptFile(scriptfile);

                    List<ScriptHash> hl = sf.FindHashes(findunsigned, findsigned, findhex, minlength);

                    foundhashes.AddRange(hl);

                    UpdateTotalHashes(foundhashes.Count);
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

                UpdateScriptHashes(foundhashes, uniquehashes);


                List<JenkIndMatch> matches = new List<JenkIndMatch>();
                List<JenkIndProblem> problems = new List<JenkIndProblem>();
                IEnumerable<string> jenkenum = Directory.EnumerateFiles(jenkindfolder);
                foreach (string jenkfile in jenkenum)
                {
                    if (AbortOperation)
                    {
                        UpdateStatus("JenkInd search aborted!");
                        JenkIndSearchComplete();
                        return;
                    }

                    UpdateStatus(GetTimeStr(starttime) + ": JenkInd search: " + jenkfile);

                    string[] lines = File.ReadAllLines(jenkfile);

                    string curhashstr = string.Empty;
                    string curhashunsigned = string.Empty;
                    string curhashsigned = string.Empty;
                    string curhashhex = string.Empty;
                    int curstate = 0;
                    int fquote;
                    int lquote;
                    int strlen;
                    string trimline;
                    JenkIndProblem prob;
                    JenkIndMatch match;

                    for (int l = 0; l < lines.Length; l++)
                    {
                        string line = lines[l];

                        switch(curstate)
                        {
                            case 0: //looking for hashes array
                                if (line.Contains("\"Hashes\"")) curstate = 1;
                                break;
                            case 1: //looking for hash string
                                fquote = line.IndexOf('\"');
                                lquote = line.LastIndexOf('\"');
                                strlen = lquote - fquote - 1;
                                if (strlen > 0)
                                {
                                    curhashstr = line.Substring(fquote+1, strlen).Replace("\\\"", "\"");
                                    curstate = 2;
                                }
                                break;
                            case 2: //looking for unsigned version
                                trimline = line.Trim();
                                if (trimline.EndsWith(","))
                                {
                                    curhashunsigned = trimline.Substring(0, trimline.Length - 1);
                                    curstate = 3;
                                }
                                else //hmm. this shouldn't really happen!
                                {
                                    prob = new JenkIndProblem(jenkfile, "Expected unsigned number", l);
                                    problems.Add(prob);
                                    UpdateJenkIndProblem(prob);
                                }
                                break;
                            case 3: //looking for signed version
                                trimline = line.Trim();
                                if (trimline.EndsWith(",") || trimline.EndsWith("["))
                                {
                                    curhashsigned = trimline.Substring(0, trimline.Length - 1);
                                    curstate = 4;
                                }
                                else //hmm. this shouldn't really happen!
                                {
                                    prob = new JenkIndProblem(jenkfile, "Expected signed number", l);
                                    problems.Add(prob);
                                    UpdateJenkIndProblem(prob);
                                }
                                break;
                            case 4: //looking for hex version
                                fquote = line.IndexOf('\"');
                                lquote = line.LastIndexOf('\"');
                                strlen = lquote - fquote - 1;
                                if (strlen > 0)
                                {
                                    curhashhex = line.Substring(fquote + 1, strlen).Replace("\\\"", "\"");
                                    curstate = 1;

                                    //got a hash. now do the lookups!
                                    match = null;
                                    if (findunsigned && uniquehashes.ContainsKey(curhashunsigned))
                                    {
                                        match = new JenkIndMatch(curhashunsigned, curhashstr);
                                        if (match.Score >= threshold)
                                        {
                                            matches.Add(match);
                                            UpdateJenkIndMatch(match, matches.Count);
                                        }
                                    }
                                    if (findsigned && uniquehashes.ContainsKey(curhashsigned) && (curhashunsigned != curhashsigned))
                                    {
                                        match = new JenkIndMatch(curhashsigned, curhashstr);
                                        if (match.Score >= threshold)
                                        {
                                            matches.Add(match);
                                            UpdateJenkIndMatch(match, matches.Count);
                                        }
                                    }
                                    if (findhex && uniquehashes.ContainsKey(curhashhex))
                                    {
                                        match = new JenkIndMatch(curhashhex, curhashstr);
                                        if (match.Score >= threshold)
                                        {
                                            matches.Add(match);
                                            UpdateJenkIndMatch(match, matches.Count);
                                        }
                                    }

                                }
                                else //hmm. this shouldn't really happen!
                                {
                                    prob = new JenkIndProblem(jenkfile, "Expected hex string", l);
                                    problems.Add(prob);
                                    UpdateJenkIndProblem(prob);
                                }
                                break;
                        }
                    }

                }




                UpdateStatus("Looking for collisions...");

                Dictionary<string, JenkIndMatch> uniquematches = new Dictionary<string, JenkIndMatch>();
                Dictionary<string, List<JenkIndMatch>> collisions = new Dictionary<string, List<JenkIndMatch>>();
                Dictionary<string, int> misses = new Dictionary<string, int>();
                foreach (JenkIndMatch match in matches)
                {
                    JenkIndMatch unmatch;
                    if (!uniquematches.TryGetValue(match.Hash, out unmatch))
                    {
                        uniquematches.Add(match.Hash, match);
                    }
                    else if (unmatch.Value != match.Value)
                    {
                        if (collisions.ContainsKey(match.Hash))
                        {
                            List<JenkIndMatch> colllist = collisions[match.Hash];
                            bool found = false;
                            foreach (JenkIndMatch oldmatch in colllist)
                            {
                                if (oldmatch.Value == match.Value)
                                {
                                    found = true;
                                    break;
                                }
                            }
                            if (!found)
                            {
                                colllist.Add(match);
                            }
                        }
                        else
                        {
                            List<JenkIndMatch> colllist = new List<JenkIndMatch>();
                            colllist.Add(unmatch);
                            colllist.Add(match);
                            collisions.Add(match.Hash, colllist);
                        }
                    }
                }
                foreach (KeyValuePair<string, int> kvp in uniquehashes)
                {
                    if (!uniquematches.ContainsKey(kvp.Key))
                    {
                        misses.Add(kvp.Key, kvp.Value);
                    }
                }

                UpdateStatus("Resolving collisions...");

                foreach (KeyValuePair<string, List<JenkIndMatch>> kvp in collisions)
                {
                    JenkIndMatch bestmatch = null;
                    foreach (JenkIndMatch match in kvp.Value)
                    {
                        if ((bestmatch == null) || (match.Score >= bestmatch.Score))
                        {
                            if ((bestmatch != null) && (match.Score == bestmatch.Score))
                            {
                                //it's a tie. take the longest one...
                                if (match.Value.Length > bestmatch.Value.Length)
                                {
                                    bestmatch = match;
                                }
                            }
                            else
                            {
                                bestmatch = match;
                            }
                        }
                    }
                    if (bestmatch != null)
                    {
                        uniquematches[kvp.Key] = bestmatch;
                    }
                }

                UpdateJenkIndMatches(uniquematches);

                UpdateJenkIndCollisions(collisions, misses);

                UpdateStatus("JenkInd search completed at " + DateTime.Now.ToString() + ". Total duration: " + GetTimeStr(starttime));

                JenkIndSearchComplete();
            });
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

        private void UpdateTotalHashes(int totalhashes)
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new Action(() => { UpdateTotalHashes(totalhashes); }));
                }
                else
                {
                    TotalScriptHashesLabel.Text = totalhashes.ToString();
                }
            }
            catch { }
        }

        private void UpdateScriptHashes(List<ScriptHash> hashes, Dictionary<string, int> uniquehashes)
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new Action(() => { UpdateScriptHashes(hashes, uniquehashes); }));
                }
                else
                {
                    ScriptHashes = hashes;

                    StringBuilder sb = new StringBuilder();
                    foreach (KeyValuePair<string, int> kvp in uniquehashes)
                    {
                        sb.AppendLine(string.Format("{0}  ({1} refs)", kvp.Key, kvp.Value));
                    }
                    UniqueHashesTextBox.Text = sb.ToString();
                    UniqueScriptHashesLabel.Text = uniquehashes.Count.ToString();
                }
            }
            catch { }
        }

        private void UpdateJenkIndProblem(JenkIndProblem p)
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new Action(() => { UpdateJenkIndProblem(p); }));
                }
                else
                {
                    ProblemsTextBox.AppendText(p.ToString() + "\r\n");
                }
            }
            catch { }
        }

        private void UpdateJenkIndMatch(JenkIndMatch m, int totalmatches)
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new Action(() => { UpdateJenkIndMatch(m, totalmatches); }));
                }
                else
                {
                    TotalHashMatchesLabel.Text = totalmatches.ToString();
                    HashMatchesTextBox.AppendText(m.ToString() + "\r\n");
                }
            }
            catch { }
        }

        private void UpdateJenkIndMatches(Dictionary<string, JenkIndMatch> uniquematches)
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new Action(() => { UpdateJenkIndMatches(uniquematches); }));
                }
                else
                {
                    JenkIndUniqueMatches = uniquematches;

                    UniqueHashMatchesLabel.Text = uniquematches.Count.ToString();

                    StringBuilder sb = new StringBuilder();
                    foreach (KeyValuePair<string, JenkIndMatch> kvp in uniquematches)
                    {
                        sb.AppendLine(kvp.Value.ToString());
                    }

                    HashMatchesTextBox.Text = sb.ToString();

                }
            }
            catch { }
        }

        private void UpdateJenkIndCollisions(Dictionary<string, List<JenkIndMatch>> collisions, Dictionary<string, int> misses)
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new Action(() => { UpdateJenkIndCollisions(collisions, misses); }));
                }
                else
                {
                    JenkIndCollisions = collisions;
                    JenkIndMisses = misses;

                    HashCollisionsLabel.Text = collisions.Count.ToString();
                    StringBuilder sb = new StringBuilder();
                    foreach (KeyValuePair<string, List<JenkIndMatch>> kvp in collisions)
                    {
                        sb.AppendFormat("{0} : {1} collisions", kvp.Key, kvp.Value.Count);
                        sb.AppendLine();

                        foreach (JenkIndMatch m in kvp.Value)
                        {
                            sb.AppendFormat("   {0}  ({1:0.##})", m.Value, m.Score);
                            sb.AppendLine();
                        }

                        sb.AppendLine();
                    }
                    HashCollisionsTextBox.Text = sb.ToString();

                    TotalMissesLabel.Text = misses.Count.ToString();
                }
            }
            catch { }
        }

        private void JenkIndSearchComplete()
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new Action(() => { JenkIndSearchComplete(); }));
                }
                else
                {
                    InProgress = false;

                }
            }
            catch { }
        }



        private void UpdateScripts()
        {
            AbortOperation = false;
            InProgress = true;

            ScriptChangesTextBox.Text = string.Empty;
            TotalChangesLabel.Text = "-";
            FilesModifiedLabel.Text = "-";


            bool findunsigned = UnsignedCheckBox.Checked;
            bool findsigned = SignedCheckBox.Checked;
            bool findhex = HexCheckBox.Checked;
            int minlength = (int)MinLengthUpDown.Value;
            string scriptfolder = ScriptFolderTextBox.Text;
            string format = UpdateFormatComboBox.Text;
            bool replace = ReplaceRadioButton.Checked;
            bool insert = InsertBeforeRadioButton.Checked;
            int totalchanges = 0;
            int filechanges = 0;

            Task.Run(() =>
            {

                UpdateStatus("Task beginning...");

                DateTime starttime = DateTime.Now;

                string[] scriptfiles = Directory.GetFiles(scriptfolder);

                foreach (string scriptfile in scriptfiles)
                {
                    if (AbortOperation)
                    {
                        UpdateStatus("Script update aborted!");
                        UpdateScriptsComplete();
                        return;
                    }

                    string filel = scriptfile.ToLower();
                    if (!(filel.EndsWith(".c") || filel.EndsWith(".c4"))) continue;

                    UpdateStatus(GetTimeStr(starttime) + ": Updating " + scriptfile + "...");

                    ScriptFile sf = new ScriptFile(scriptfile);

                    //look for hashes again here since we could be pointing at another script folder... possibly!!
                    List<ScriptHash> hashes = sf.FindHashes(findunsigned, findsigned, findhex, minlength);

                    List<ScriptChange> changes = sf.ReplaceHashes(hashes, JenkIndUniqueMatches, JenkIndCollisions, format, replace, insert);
                    if (changes.Count > 0)
                    {
                        totalchanges += changes.Count;
                        filechanges++;

                        UpdateScriptChange(sf, changes, totalchanges, filechanges);
                    }
                }


                UpdateStatus("Script update completed at " + DateTime.Now.ToString() + ". Total duration: " + GetTimeStr(starttime));

                UpdateScriptsComplete();

            });
        }

        private void UpdateScriptChange(ScriptFile sf, List<ScriptChange> changes, int totalchanges, int filechanges)
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new Action(() => { UpdateScriptChange(sf, changes, totalchanges, filechanges); }));
                }
                else
                {
                    TotalChangesLabel.Text = totalchanges.ToString();
                    FilesModifiedLabel.Text = filechanges.ToString();

                    StringBuilder sb = new StringBuilder();
                    sb.AppendFormat("{0} : {1} changes:", sf.Name, changes.Count);
                    sb.AppendLine();

                    foreach (ScriptChange change in changes)
                    {
                        sb.AppendFormat("   {0}: {1}", change.LineNum, change.LineAfter);
                        sb.AppendLine();
                    }
                    sb.AppendLine();
                    sb.AppendLine();

                    ScriptChangesTextBox.AppendText(sb.ToString());
                }
            }
            catch { }
        }

        private void UpdateScriptsComplete()
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new Action(() => { UpdateScriptsComplete(); }));
                }
                else
                {
                    InProgress = false;

                }
            }
            catch { }
        }


        private string GetTimeStr(DateTime starttime)
        {
            return (DateTime.Now - starttime).ToString("h\\:mm\\:ss");
        }

    }


}
