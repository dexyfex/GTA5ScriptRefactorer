using gta5refactor.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gta5refactor
{
    public partial class MainForm : Form
    {

        Dictionary<string, ScriptFile> Files = new Dictionary<string, ScriptFile>();
        ScriptFile GlobalsFile = null;
        ScriptFile SelectedFile = null;
        ScriptFunction SelectedFunction = null;
        List<ScriptFunctionMatch> SelectedFunctionMatches = null;
        List<ScriptFunction> SelectedFunctionHistory = new List<ScriptFunction>();
        int CurrentHistoryIndex = 0;
        bool HistoryNavigating = false;
        bool RestoreSelection = false;
        string RestoreFileName = string.Empty;
        string RestoreFunctionName = string.Empty;
        bool MatchInProgress = false;
        bool RefactorInProgress = false;
        volatile bool AbortOperation = false;

        int FilesListViewSortColumn = -1;
        int FunctionsListViewSortColumn = -1;
        int FunctionMatchesListViewSortColumn = -1;
        int FunctionDependenciesListViewSortColumn = -1;
        int FunctionReferencesListViewSortColumn = -1;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            FunctionTextBox.SetTabStopWidth(3);

            FolderTextBox.Text = Settings.Default.ScriptFolder;
            GlobalsFileNameTextBox.Text = Settings.Default.GlobalsFile;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.Default.Save();
        }


        private void FolderTextBox_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.ScriptFolder = FolderTextBox.Text;
        }

        private void GlobalsFileNameTextBox_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.GlobalsFile = GlobalsFileNameTextBox.Text;
        }


        private void FolderBrowseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog.SelectedPath = Settings.Default.ScriptFolder;
            DialogResult res = FolderBrowserDialog.ShowDialog();
            if (res == DialogResult.OK)
            {
                FolderTextBox.Text = FolderBrowserDialog.SelectedPath;
            }
        }

        private void ScanFolderButton_Click(object sender, EventArgs e)
        {
            ScanFolder();
        }

        private void ScanFolder()
        {
            try
            {
                
                if (FilesListView.SelectedItems.Count > 0)
                {
                    ClearSelectedFile();
                }

                SelectedFunctionHistory.Clear();
                NavBackButton.Enabled = false;
                NavForwardButton.Enabled = false;

                FilesListView.Items.Clear();
                Files.Clear();
                GlobalsFile = null;

                ListViewItem restorefileitem = null;
                string gfilename = GlobalsFileNameTextBox.Text.ToLower();
                string[] files = Directory.GetFiles(FolderTextBox.Text);
                Array.Sort(files);
                foreach (string file in files)
                {
                    string filel = file.ToLower();
                    if (!(filel.EndsWith(".c") || filel.EndsWith(".c4"))) continue;


                    ScriptFile f = new ScriptFile(file);
                    Files.Add(f.Name, f);

                    if (f.Name == gfilename)
                    {
                        GlobalsFile = f;
                    }

                    var lvi = new ListViewItem(new string[] { f.Name, GetBytesReadable(f.FileSize) });
                    lvi.Tag = f;

                    FilesListView.Items.Add(lvi);

                    if (f.Name == RestoreFileName)
                    {
                        restorefileitem = lvi;
                    }
                }
                if (GlobalsFile != null)
                {
                    GlobalsFile.Load();
                }

                if (RestoreSelection && (restorefileitem != null))
                {
                    restorefileitem.Selected = true;
                    FilesListView.EnsureVisible(restorefileitem.Index);
                }
                else
                {
                    RestoreSelection = false; //if an item was selected, this will be reset in the selection event handler...
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error");
            }
        }


        private void FilesListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FilesListView.SelectedItems.Count != 1)
            {
                ClearSelectedFile();
                return;
            }

            ListViewItem lvi = FilesListView.SelectedItems[0];
            ScriptFile f = (ScriptFile)lvi.Tag;

            SelectedFile = f;
            if (f.FileLines == null)
            {
                f.Load();
            }

            FilePanel.Enabled = true;
            FileNameLabel.Text = f.Name;

            FileLinesLabel.Text = string.Format("{0} lines, {1} functions", f.FileLines.Length, f.Functions.Count);

            FunctionsListView.VirtualListSize = f.Functions.Count;

            if (RestoreSelection)
            {
                ScriptFunction resfunc;
                if (SelectedFile.FunctionMap.TryGetValue(RestoreFunctionName, out resfunc))
                {
                    for (int i = 0; i < SelectedFile.Functions.Count; i++)
                    {
                        if (SelectedFile.Functions[i] == resfunc)
                        {
                            FunctionsListView.Items[i].Selected = true;
                            FunctionsListView.EnsureVisible(i);
                            FunctionsListView.Focus();
                            break;
                        }
                    }
                }
                RestoreSelection = false;
            }
        }

        private void ClearSelectedFile()
        {
            ClearSelectedFunction();
            FunctionsListView.VirtualListSize = 0;
            SelectedFile = null;
            FileLinesLabel.Text = "Nothing selected";
            FileNameLabel.Text = "Nothing selected";
            FilePanel.Enabled = false;
        }


        private void FunctionsListView_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            ScriptFunction func = null;
            if ((SelectedFile != null) && (e.ItemIndex >= 0) && (e.ItemIndex < SelectedFile.Functions.Count))
            {
                func = SelectedFile.Functions[e.ItemIndex];
            }
            if (func != null)
            {
                ListViewItem flvi = new ListViewItem(new string[] { func.Name, func.ReturnType, func.Length.ToString() });
                flvi.Tag = func;
                e.Item = flvi;
            }
            else
            {
                e.Item = new ListViewItem(); //nothing to see here...
            }
        }

        private void FunctionsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedFile == null) return; //this shouldn't really happen
            if (FunctionsListView.SelectedIndices.Count != 1)
            {
                ClearSelectedFunction();
                return;
            }

            ScriptFunction f = SelectedFile.Functions[FunctionsListView.SelectedIndices[0]];


            SelectedFunction = f;
            //if ((SelectedFunctionHistory.Count == 0) || (SelectedFunctionHistory[CurrentHistoryIndex] != f))
            //{
                if (!HistoryNavigating)
                {
                    if ((SelectedFunctionHistory.Count == 0) || (SelectedFunctionHistory[CurrentHistoryIndex] != f))
                    {
                        if (CurrentHistoryIndex < (SelectedFunctionHistory.Count - 1))
                        {
                            int sind = CurrentHistoryIndex + 1;
                            SelectedFunctionHistory.RemoveRange(sind, SelectedFunctionHistory.Count - sind);
                        }

                        CurrentHistoryIndex = SelectedFunctionHistory.Count;
                        SelectedFunctionHistory.Add(f);
                        NavBackButton.Enabled = (SelectedFunctionHistory.Count > 1);
                        NavForwardButton.Enabled = false;
                    }
                }
                else
                {
                    NavBackButton.Enabled = (CurrentHistoryIndex > 0) && (SelectedFunctionHistory.Count > 1);
                    NavForwardButton.Enabled = (CurrentHistoryIndex < (SelectedFunctionHistory.Count - 1)) && (SelectedFunctionHistory.Count > 1);
                }
                HistoryNavigating = false;
            //}

            if (f.File.Name == GlobalsFileNameTextBox.Text)
            {
                //pre-populate global function name in the textbox
                FunctionRefactorNameTextBox.Text = f.Name;
            }
            else
            {
                //auto-generate a new name?
                FunctionRefactorNameTextBox.Text = f.Name;
            }


            StringBuilder sb = new StringBuilder();
            for (int i = f.StartLine; i <= f.EndLine; i++)
            {
                sb.AppendLine(f.File.FileLines[i]);
            }
            FunctionTextBox.Text = sb.ToString();

            FunctionDependenciesListView.Items.Clear();
            int depcount = 0;
            foreach (ScriptFunctionDependency dep in f.LocalDependencies)
            {
                ListViewItem dlvi = new ListViewItem(new string[] { dep.Name, dep.Params, dep.Line.ToString() });
                dlvi.Tag = dep;
                FunctionDependenciesListView.Items.Add(dlvi);
                depcount++;
            }
            foreach (ScriptFunctionDependency dep in f.AllDependencies)
            {
                if (!f.File.FunctionMap.ContainsKey(dep.Name))
                {
                    ListViewItem dlvi2 = new ListViewItem(new string[] { dep.Name, dep.Params, dep.Line.ToString() });
                    dlvi2.Tag = dep;
                    dlvi2.ForeColor = Color.Gray;
                    FunctionDependenciesListView.Items.Add(dlvi2);
                }
            }

            FunctionReferencesListView.Items.Clear();
            int refcount = 0;
            foreach (ScriptFunctionReference reff in f.References)
            {
                ListViewItem rlvi = new ListViewItem(new string[] { reff.Name, reff.Params, reff.Line.ToString() });
                rlvi.Tag = reff;
                FunctionReferencesListView.Items.Add(rlvi);
                refcount++;
            }


            FunctionLabel.Text = string.Format("{0} {1}   ({2} dependencies, {3} references)", f.ReturnType, f.Name, depcount, refcount);

            FunctionPanel.Enabled = true;
        }

        private void ClearSelectedFunction()
        {
            SelectedFunction = null;
            SelectedFunctionMatches = null;
            FunctionPanel.Enabled = false;
            FunctionMatchesListView.Items.Clear();
            FunctionDependenciesListView.Items.Clear();
            FunctionReferencesListView.Items.Clear();
            FunctionLabel.Text = "Nothing selected";
            FunctionTextBox.Text = "";
            FunctionStatusLabel.Text = "Tip: Double-click on matches, dependencies and references";
        }


        private void EnableFilesFunctionsUI(bool enable)
        {
            FilesListView.Enabled = enable;
            FunctionsListView.Enabled = enable;
            ScanFolderButton.Enabled = enable;
        }


        private void FunctionAbortButton_Click(object sender, EventArgs e)
        {
            AbortOperation = true;
        }


        private void FunctionMatchButton_Click(object sender, EventArgs e)
        {
            if (SelectedFunction == null) return;
            if (MatchInProgress) return; //already matching...
            if (RefactorInProgress) return; //currently refactoring.

            Cursor = Cursors.WaitCursor;
            AbortOperation = false;
            MatchInProgress = true;
            FunctionMatchButton.Enabled = false;
            FunctionRefactorButton.Enabled = false;
            EnableFilesFunctionsUI(false);

            FunctionMatchesListView.Items.Clear();


            bool isglobal = SelectedFunction.File.Name == GlobalsFileNameTextBox.Text;
            if (isglobal)
            {
                //if this is a global function, add found references to the references list...
                //so need to start with a clean slate for this process. found refs will be added later.
                FunctionReferencesListView.Items.Clear();
                foreach (ScriptFunctionReference reff in SelectedFunction.References)
                {
                    ListViewItem rlvi = new ListViewItem(new string[] { reff.Name, reff.Params, reff.Line.ToString() });
                    rlvi.Tag = reff;
                    FunctionReferencesListView.Items.Add(rlvi);
                }
            }
            string refname = SelectedFunction.Name;
            string funccallmatch = refname + "(";


            Task.Run(() =>
            {
                List<ScriptFunctionMatch> matches = new List<ScriptFunctionMatch>();
                int totalmatches = 0;
                int fullmatches = 0;
                int shownmatches = 0;
                int refcount = 0;

                foreach (ScriptFile sf in Files.Values)
                {
                    UpdateFunctionStatus(string.Format("Searching file {0}...", sf.Name));

                    bool loaded = (sf.FileLines != null);
                    if (!loaded)
                    {
                        sf.Load();
                    }
                    foreach (ScriptFunction func in sf.Functions)
                    {
                        if (AbortOperation)
                        {
                            if (!loaded)
                            {
                                sf.Unload();
                            }
                            UpdateFunctionStatus("Matching aborted");
                            UpdateFunctionMatches(matches);
                            return;
                        }

                        //match the function with the selected one.
                        if (func.Length == SelectedFunction.Length)
                        {
                            ScriptFunctionMatch match = new ScriptFunctionMatch(func, SelectedFunction);
                            if (match.Match > 90.0)
                            {
                                matches.Add(match);
                                UpdateFunctionMatch(match);
                                shownmatches++;
                                if (match.Match >= 100.0)
                                {
                                    fullmatches++;
                                }
                            }
                            totalmatches++;
                        }

                        //look for references to global functions...
                        if (isglobal)
                        {
                            for (int i = func.StartLine + 1; i < func.EndLine; i++)
                            {
                                string line = sf.FileLines[i];

                                int testind = 0;
                                int found;
                                while ((found = line.IndexOf(funccallmatch, testind)) > 0)
                                {
                                    //found a reference...

                                    int paramstart = found + funccallmatch.Length;
                                    int paramend = ScriptFunction.FindCloseBracket(paramstart-1, line);

                                    string paramstr = string.Empty;
                                    if (paramend > paramstart)
                                    {
                                        paramstr = line.Substring(paramstart, paramend - paramstart);
                                    }

                                    ScriptFunctionReference reff = new ScriptFunctionReference(func, i, found, refname, paramstr);
                                    UpdateFunctionReference(reff);
                                    refcount++;

                                    testind = paramstart; //next index to check
                                }

                                //if (line.Contains(funccallmatch))
                                //{
                                //    //found at least one reference on this line... record it for posterity
                                //    //definitely improve this - should find all refs with char indices! but meh..
                                //    ScriptFunctionReference reff = new ScriptFunctionReference(func, i, 0, string.Empty);
                                //    UpdateFunctionReference(reff);
                                //    refcount++;
                                //}
                            }

                        }

                    }
                    if (!loaded)
                    {
                        sf.Unload(); //gotta save memory...
                    }
                }

                if (isglobal)
                {
                    UpdateFunctionStatus(string.Format("Matching complete, {0} full, {1} matches shown, {2} references", fullmatches, shownmatches, refcount));
                }
                else
                {
                    UpdateFunctionStatus(string.Format("Matching complete, {0} total, {1} full, {2} matches shown", totalmatches, fullmatches, shownmatches));
                }

                UpdateFunctionMatches(matches);
            });


        }

        private void UpdateFunctionStatus(string text)
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new Action(() => { UpdateFunctionStatus(text); }));
                }
                else
                {
                    FunctionStatusLabel.Text = text;
                }
            }
            catch { }
        }

        private void UpdateFunctionReference(ScriptFunctionReference reff)
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new Action(() => { UpdateFunctionReference(reff); }));
                }
                else
                {
                    ListViewItem rlvi = new ListViewItem(new string[] { reff.Name, reff.Params, reff.Line.ToString() });
                    rlvi.Tag = reff;
                    FunctionReferencesListView.Items.Add(rlvi);
                }
            }
            catch { }
        }

        private void UpdateFunctionMatch(ScriptFunctionMatch match)
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new Action(() => { UpdateFunctionMatch(match); }));
                }
                else
                {
                    ListViewItem mlvi = new ListViewItem(new string[] { match.FileName, match.Name, match.Match.ToString() });
                    mlvi.Tag = match;
                    FunctionMatchesListView.Items.Add(mlvi);
                }
            }
            catch { }
        }

        private void UpdateFunctionMatches(List<ScriptFunctionMatch> matches)
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new Action(() => { UpdateFunctionMatches(matches); }));
                }
                else
                {
                    SelectedFunctionMatches = matches;

                    //foreach (ScriptFunctionMatch match in matches)
                    //{
                    //    ListViewItem mlvi = new ListViewItem(new string[] { match.FileName, match.Name, match.Match.ToString("0.00") });
                    //    mlvi.Tag = match;
                    //    FunctionMatchesListView.Items.Add(mlvi);
                    //}

                    Cursor = Cursors.Default;
                    MatchInProgress = false;
                    FunctionMatchButton.Enabled = true;
                    FunctionRefactorButton.Enabled = true;
                    EnableFilesFunctionsUI(true);
                }
            }
            catch { }
        }


        private void FunctionRefactorButton_Click(object sender, EventArgs e)
        {
            if (MatchInProgress) return; //currently matching...
            if (RefactorInProgress) return; //already refactoring.

            if (SelectedFunction == null)
            {
                MessageBox.Show("Please select a function.");
                return;
            }
            if (FunctionRefactorNameTextBox.Text == string.Empty)
            {
                MessageBox.Show("Please enter a name for the new global function.");
                return;
            }
            if (FunctionRefactorNameTextBox.Text == SelectedFunction.Name)
            {
                MessageBox.Show("Please enter a new name for the new global function.");
                return;
            }
            if (SelectedFunction.File.Name == GlobalsFileNameTextBox.Text)
            {
                if (MessageBox.Show("Would you like to rename this global function?", "Global function refactor - rename", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (IsGlobalFuncNameAlreadyInUse(FunctionRefactorNameTextBox.Text))
                    {
                        MessageBox.Show(string.Format("Cannot refactor - function {0} already exists in {1}.", FunctionRefactorNameTextBox.Text, GlobalsFileNameTextBox.Text));
                        return;
                    }

                    FunctionRename();
                    return;
                }
                else
                {
                    return; //global function can't be refactored like the others!
                }
            }
            if ((SelectedFunctionMatches == null) || (SelectedFunctionMatches.Count == 0))
            {
                if (MessageBox.Show("No function matches found. Please run the match function first.\nDo you wish to refactor anyway? (Could cause problems!)", "No matches", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                {
                    return;
                }
            }
            if (SelectedFunction.LocalDependencies.Count > 0)
            {
                int totdepnotself = 0; //make sure not to count recursion as a dependency.
                foreach (ScriptFunctionDependency dep in SelectedFunction.LocalDependencies)
                {
                    if (dep.Name != SelectedFunction.Name) totdepnotself++;
                }
                if (totdepnotself > 0)
                {
                    if (MessageBox.Show("Local function dependencies detected. Dependencies will not refactor correctly.\nContinue refactoring anyway?", "Dependencies detected", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    {
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Looks like you're refactoring a recursive function. Great! :D");
                }
            }

            //TODO: should also check to see if this function has references to local variables!

            List<ScriptFunctionMatch> fullmatches = new List<ScriptFunctionMatch>();
            if (SelectedFunctionMatches != null)
            {
                foreach (ScriptFunctionMatch match in SelectedFunctionMatches)
                {
                    if (match.Match >= 100.0)
                    {
                        fullmatches.Add(match);
                    }
                }
            }
            if (fullmatches.Count == 0)
            {
                MessageBox.Show("Unable to refactor, no matches found. At least the original match should have been found!");
                return;
            }


            string sf = SelectedFunction.File.Name;
            string nf = GlobalsFileNameTextBox.Text;
            string sfn = SelectedFunction.Name;
            string nfn = FunctionRefactorNameTextBox.Text;
            string fmc = fullmatches.Count.ToString();
            string txt = string.Format("Refactoring:\nSource: {0}::{1}\nDestination: {2}::{3}\nMatches: {4}\nContinue?", sf, sfn, nf, nfn, fmc);
            string gfilepath = FolderTextBox.Text + "\\" + nf;

            if (IsGlobalFuncNameAlreadyInUse(nfn))
            {
                MessageBox.Show(string.Format("Cannot refactor - function {0} already exists in {1}.", nfn, nf));
                return;
            }



            if (MessageBox.Show(txt, "Confirm Refactor", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                return;
            }


            FunctionRefactor(fullmatches);

        }

        private bool IsGlobalFuncNameAlreadyInUse(string funcname)
        {
            string nf = GlobalsFileNameTextBox.Text;
            string gfilepath = FolderTextBox.Text + "\\" + nf;

            if (File.Exists(gfilepath))
            {
                ScriptFile gsf = new ScriptFile(gfilepath);
                gsf.Load();
                if (gsf.FunctionMap.ContainsKey(funcname))
                {
                    return true;
                }
                gsf.Unload();
            }

            return false;
        }

        private void FunctionRefactor(List<ScriptFunctionMatch> fullmatches)
        {
            Cursor = Cursors.WaitCursor;
            AbortOperation = false;
            RefactorInProgress = true;
            EnableFilesFunctionsUI(false);

            string folderpath = FolderTextBox.Text + "\\";
            string sf = SelectedFunction.File.Name;
            string nf = GlobalsFileNameTextBox.Text;
            string sfn = SelectedFunction.Name;
            string nfn = FunctionRefactorNameTextBox.Text;
            string gfilepath = folderpath + nf;


            RestoreSelection = true;
            RestoreFileName = sf;
            RestoreFunctionName = string.Empty; //just select the previously selected file - function moving to globals!


            Task.Run(() =>
            {
                int filecount = 0;
                int errcount = 0;

                if (sf.ToLower() != nf.ToLower())
                {
                    //if we're not refactoring an already global function, add it to the globals file.

                    UpdateFunctionStatus("Adding " + nfn + " to " + nf + "...");

                    SelectedFile.AppendToGlobalsFile(SelectedFunction, nfn, fullmatches, gfilepath);

                    filecount++;
                }
                else
                {
                    //shouldn't be able to "refactor" a global function! rename should be used instead...
                    MessageBox.Show("Attempting to full refactor global function...\nThis shouldn't be possible - aborting!");
                    UpdateFunctionStatus("Aborting refactor due to attempting to refactor global function!");
                    UpdateRefactorComplete();
                    return;
                }



                //now step through all the match files and remove the function,
                //at the same time replacing all references with the new global function name.

                List<string> errors = new List<string>();

                foreach (ScriptFunctionMatch match in fullmatches)
                {
                    if (AbortOperation)
                    {
                        MessageBox.Show("Refactoring aborted! Scripts will now be inconsistent!\nRecommend to manually fix this or restore script from backup!");
                        UpdateFunctionStatus("Refactoring aborted! Scripts will now be inconsistent.");
                        UpdateRefactorComplete();
                        return;
                    }

                    UpdateFunctionStatus(string.Format("Refactoring {0}::{1} -> {2}::{3} ...", match.FileName, match.Name, nf, nfn));

                    try
                    {
                        ScriptFile sfile = new ScriptFile(folderpath + match.FileName);
                        sfile.Load();

                        if (sfile.RefactorFunction(match.Name, nfn))
                        {
                            filecount++;
                        }
                        else
                        {
                            errors.Add(sfile.LastError);
                            errcount++;
                        }
                    }
                    catch (Exception ex)
                    {
                        errors.Add(ex.ToString());
                        errcount++;
                    }
                }



                UpdateFunctionStatus(string.Format("Refactoring complete.\n{0} files were modified.\n{1} errors.", filecount, errcount));

                if (errors.Count > 0)
                {
                    if (errors.Count <= 10)
                    {
                        StringBuilder esb = new StringBuilder();
                        foreach (string error in errors)
                        {
                            esb.AppendLine(error);
                            esb.AppendLine();
                        }
                        MessageBox.Show("Errors encountered:\n\n" + esb.ToString());
                    }
                    else
                    {
                        MessageBox.Show("More than 10 errors were encountered. It's probably best you restore your scripts from a backup at this point...");
                    }
                }

                UpdateRefactorComplete();

            });
        }

        private void FunctionRename()
        {
            Cursor = Cursors.WaitCursor;
            AbortOperation = false;
            RefactorInProgress = true;
            EnableFilesFunctionsUI(false);

            string oldname = SelectedFunction.Name;
            string newname = FunctionRefactorNameTextBox.Text;


            RestoreSelection = true;
            RestoreFileName = SelectedFunction.File.Name;
            RestoreFunctionName = newname;


            Task.Run(() =>
            {
                int linecount = 0;
                int filecount = 0;

                foreach (ScriptFile sf in Files.Values)
                {
                    if (AbortOperation)
                    {
                        MessageBox.Show("Renaming aborted! Scripts will now be inconsistent!\nRecommend to manually fix this or restore script from backup!");
                        UpdateFunctionStatus("Renaming aborted! Scripts will now be inconsistent.");
                        UpdateRefactorComplete();
                        return;
                    }

                    UpdateFunctionStatus(string.Format("Processing file {0}...", sf.Name));

                    bool loaded = (sf.FileLines != null);
                    if (!loaded)
                    {
                        sf.Load();
                    }
                    int changes = sf.RenameGlobalFunction(oldname, newname);
                    if (changes > 0)
                    {
                        linecount += changes;
                        filecount++;
                    }
                    if (!loaded)
                    {
                        sf.Unload(); //gotta save memory...
                    }
                }

                UpdateFunctionStatus(string.Format("Rename complete, {0} total lines, {1} files affected", linecount, filecount));

                UpdateRefactorComplete();
            });
        }

        private void UpdateRefactorComplete()
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new Action(() => { UpdateRefactorComplete(); }));
                }
                else
                {
                    EnableFilesFunctionsUI(true);
                    RefactorInProgress = false;
                    Cursor = Cursors.Default;

                    //refactoring finished. need to refresh the UI...
                    ScanFolder();
                }
            }
            catch { }
        }



        private void FunctionsListView_DoubleClick(object sender, EventArgs e)
        {
            if (FunctionsListView.SelectedIndices.Count != 1) return;
            ListViewItem lvi = FunctionsListView.Items[FunctionsListView.SelectedIndices[0]];

            ShowViewForm(lvi);
        }

        private void FunctionMatchesListView_DoubleClick(object sender, EventArgs e)
        {
            if (FunctionMatchesListView.SelectedItems.Count != 1) return;
            ListViewItem lvi = FunctionMatchesListView.SelectedItems[0];

            ShowViewForm(lvi);
        }

        private void FunctionDependenciesListView_DoubleClick(object sender, EventArgs e)
        {
            if (FunctionDependenciesListView.SelectedItems.Count != 1) return;
            ListViewItem lvi = FunctionDependenciesListView.SelectedItems[0];

            ShowViewForm(lvi);
        }

        private void FunctionReferencesListView_DoubleClick(object sender, EventArgs e)
        {
            if (FunctionReferencesListView.SelectedItems.Count != 1) return;
            ListViewItem lvi = FunctionReferencesListView.SelectedItems[0];

            ShowViewForm(lvi);
        }


        private void ShowViewForm(ListViewItem lvi)
        {
            if (lvi.Tag is ScriptFunction)
            {
                ScriptFunction func = (ScriptFunction)lvi.Tag;
                ShowViewForm(func, -1);
            }
            else if (lvi.Tag is ScriptFunctionMatch)
            {
                ScriptFunctionMatch match = (ScriptFunctionMatch)lvi.Tag;

                ScriptFile file;
                if (!Files.TryGetValue(match.FileName, out file))
                {
                    file = new ScriptFile(FolderTextBox.Text + "\\" + match.FileName);
                    file.Load(); //have to parse this file as the match process let it go
                }
                else if (file.FileLines == null)
                {
                    file.Load();  //found a cached file, make sure it's loaded.
                }

                ScriptFunction func;
                if (file.FunctionMap.TryGetValue(match.Name, out func))
                {
                    ShowViewForm(func, -1);
                }
            }
            else if (lvi.Tag is ScriptFunctionDependency)
            {
                ScriptFunctionDependency dep = (ScriptFunctionDependency)lvi.Tag;

                //original version - just show the dep in the current func
                //ShowViewForm(dep.Function, dep.Line);

                ScriptFunction func; //dependency func should be in the same file...
                if (dep.Function.File.FunctionMap.TryGetValue(dep.Name, out func))
                {
                    ShowViewForm(func, -1); //don't select a line (-1)
                }
                else if ((GlobalsFile != null) && (GlobalsFile.FunctionMap.TryGetValue(dep.Name, out func)))
                {
                    ShowViewForm(func, -1); //try the globals file
                }
                else
                {
                    ShowViewForm(dep.Function, dep.Line, dep.Char, dep.Name.Length); //no match, just show the dependency
                }
            }
            else if (lvi.Tag is ScriptFunctionReference)
            {
                ScriptFunctionReference reff = (ScriptFunctionReference)lvi.Tag;

                ShowViewForm(reff.Function, reff.Line, reff.Char, reff.RefName.Length);
            }
        }

        private void ShowViewForm(ScriptFunction func, int linesel, int charsel=0, int sellen=0)
        {
            ViewForm form = new ViewForm();
            form.LoadFunction(func, linesel, charsel, sellen);
            form.Show(this);
        }


        private void FunctionMatchesListView_MouseClick(object sender, MouseEventArgs e)
        {
            //show the context menu if right-clicked on an item
            if (e.Button == MouseButtons.Right)
            {
                if (FunctionMatchesListView.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    NavContextMenu.Tag = FunctionMatchesListView.FocusedItem;
                    NavContextMenu.Show(Cursor.Position);
                }
            }
        }

        private void FunctionDependenciesListView_MouseClick(object sender, MouseEventArgs e)
        {
            //show the context menu if right-clicked on an item
            if (e.Button == MouseButtons.Right)
            {
                if (FunctionDependenciesListView.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    NavContextMenu.Tag = FunctionDependenciesListView.FocusedItem;
                    NavContextMenu.Show(Cursor.Position);
                }
            }
        }

        private void FunctionReferencesListView_MouseClick(object sender, MouseEventArgs e)
        {
            //show the context menu if right-clicked on an item
            if (e.Button == MouseButtons.Right)
            {
                if (FunctionReferencesListView.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    NavContextMenu.Tag = FunctionReferencesListView.FocusedItem;
                    NavContextMenu.Show(Cursor.Position);
                }
            }
        }

        private void NavContextMenu_Opening(object sender, CancelEventArgs e)
        {
            ListViewItem lvi = NavContextMenu.Tag as ListViewItem;
            if (lvi != null)
            {
                ListView lv = lvi.ListView;
                NavContextMenu.Items.Clear();
                NavContextMenu.Items.Add("Navigate To").Tag = lvi;
                NavContextMenu.Items.Add("View").Tag = lvi;
                e.Cancel = false;
            }
        }

        private void NavContextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ListViewItem lvi = e.ClickedItem.Tag as ListViewItem;
            if (lvi != null)
            {
                if (MatchInProgress) return; //currently matching... can't switch right now
                if (RefactorInProgress) return; //currently refactoring... can't switch right now

                switch(e.ClickedItem.Text)
                {
                    case "View":
                        ShowViewForm(lvi);
                        break;
                    case "Navigate To":
                        NavigateToSelection(lvi);
                        break;
                }
            }
        }

        private void NavigateToSelection(ListViewItem lvi)
        {

            string targetfile = string.Empty;
            string targetfunc = string.Empty;
            ListView lv = lvi.ListView;
            if (lv == FunctionMatchesListView)
            {
                ScriptFunctionMatch match = (ScriptFunctionMatch)lvi.Tag;
                targetfile = new FileInfo(match.FileName).Name;
                targetfunc = match.Name;
            }
            else if (lv == FunctionDependenciesListView)
            {
                ScriptFunctionDependency dep = (ScriptFunctionDependency)lvi.Tag;
                ScriptFunction func; //dependency func should be in the same file...
                if (dep.Function.File.FunctionMap.TryGetValue(dep.Name, out func))
                {
                    targetfile = dep.Function.File.Name;
                    targetfunc = dep.Name;
                }
                else if ((GlobalsFile != null) && (GlobalsFile.FunctionMap.TryGetValue(dep.Name, out func)))
                {
                    targetfile = GlobalsFile.Name;
                    targetfunc = dep.Name;
                }
            }
            else if (lv == FunctionReferencesListView)
            {
                ScriptFunctionReference reff = (ScriptFunctionReference)lvi.Tag;
                targetfile = reff.Function.File.Name;
                if (reff.Name.Contains("::"))
                {
                    string[] splits = reff.Name.Split(new string[] { "::" }, StringSplitOptions.RemoveEmptyEntries);
                    targetfunc = splits[splits.Length - 1];
                }
                else
                {
                    targetfunc = reff.Name;
                }
            }
            if (!string.IsNullOrEmpty(targetfile) && !string.IsNullOrEmpty(targetfunc))
            {
                NavigateTo(targetfile, targetfunc);
            }
        }

        private void NavigateTo(string targetfile, string targetfunc)
        {
            if ((SelectedFile == null) || (SelectedFile.Name != targetfile))
            {
                RestoreSelection = true;
                RestoreFileName = targetfile;
                RestoreFunctionName = targetfunc;
                FilesListView.SelectedItems.Clear();

                foreach (ListViewItem flvi in FilesListView.Items)
                {
                    ScriptFile sf = flvi.Tag as ScriptFile;
                    if ((sf != null) && (sf.Name == targetfile))
                    {
                        flvi.Selected = true;
                        FilesListView.EnsureVisible(flvi.Index);
                        break;
                    }
                }
            }
            else if ((SelectedFunction == null) || (SelectedFunction.Name != targetfunc))
            {
                FunctionsListView.SelectedIndices.Clear();

                for (int i = 0; i < SelectedFile.Functions.Count; i++)
                {
                    ScriptFunction sfunc = SelectedFile.Functions[i];
                    if (sfunc.Name == targetfunc)
                    {
                        FunctionsListView.SelectedIndices.Add(i);
                        FunctionsListView.EnsureVisible(i);
                        break;
                    }
                }
            }
        }


        private void NavBackButton_Click(object sender, EventArgs e)
        {
            if (SelectedFunctionHistory.Count > 1)
            {
                int targetind = CurrentHistoryIndex - 1;

                if ((targetind >= 0) && (targetind < SelectedFunctionHistory.Count))
                {
                    ScriptFunction target = SelectedFunctionHistory[targetind];
                    string targetfile = target.File.Name;
                    string targetfunc = target.Name;

                    HistoryNavigating = true;
                    CurrentHistoryIndex = targetind;

                    NavigateTo(targetfile, targetfunc);
                }
            }
        }

        private void NavForwardButton_Click(object sender, EventArgs e)
        {
            if (SelectedFunctionHistory.Count > 1)
            {
                int targetind = CurrentHistoryIndex + 1;

                if ((targetind >= 0) && (targetind < SelectedFunctionHistory.Count))
                {
                    ScriptFunction target = SelectedFunctionHistory[targetind];
                    string targetfile = target.File.Name;
                    string targetfunc = target.Name;

                    HistoryNavigating = true;
                    CurrentHistoryIndex = targetind;

                    NavigateTo(targetfile, targetfunc);
                }
            }
        }



        private void SyntaxCheck()
        {
            Cursor = Cursors.WaitCursor;
            AbortOperation = false;
            RefactorInProgress = true;
            EnableFilesFunctionsUI(false);


            Task.Run(() =>
            {

                int filecount = 0;
                int errorcount = 0;
                int errorfilecount = 0;
                List<ScriptFile> errorfiles = new List<ScriptFile>();

                foreach (ScriptFile sf in Files.Values)
                {
                    if (AbortOperation)
                    {
                        UpdateFunctionStatus("Syntax check aborted.");
                        UpdateRefactorComplete();
                        return;
                    }

                    UpdateFunctionStatus(string.Format("Checking syntax of {0}...", sf.Name));


                    int errors = sf.SyntaxCheck();
                    if (errors > 0)
                    {
                        errorcount += errors;
                        errorfilecount++;
                        errorfiles.Add(sf);
                    }

                    filecount++;
                }

                if (errorcount == 0)
                {
                    string okstr = string.Format("Syntax check complete, {0} files checked, 0 errors found.", filecount);

                    MessageBox.Show(okstr);

                    UpdateFunctionStatus(okstr);
                }
                else
                {
                    string errstr = string.Format("Syntax check complete, {0} files checked, {1} errors found in {2} files.", filecount, errorcount, errorfilecount);

                    UpdateFunctionStatus(errstr);

                    if (MessageBox.Show(errstr + "\nWould you like to attempt to fix the errors?", "Fix syntax errors?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        int probcount = FixSyntaxErrors(errorfiles);
                        if (AbortOperation)
                        {
                            MessageBox.Show(string.Format("Syntax error fix aborted! {0} problems were encountered...", probcount));
                            return;
                        }
                        if (probcount == 0)
                        {
                            MessageBox.Show("Syntax errors fixed? No problems were encountered during the process.");
                        }
                        else
                        {
                            MessageBox.Show(string.Format("Problems were encountered during the syntax error fixing! {0} files had issues.", probcount));
                        }
                    }
                }

                UpdateRefactorComplete();
            });

        }

        private int FixSyntaxErrors(List<ScriptFile> files)
        {
            int errorcount = 0;

            foreach (ScriptFile sf in files)
            {
                if (AbortOperation)
                {
                    UpdateFunctionStatus("Fixing syntax aborted!");
                    UpdateRefactorComplete();
                    return errorcount;
                }

                UpdateFunctionStatus(string.Format("Fixing syntax of {0}...", sf.Name));

                int errors = sf.FixSyntax();
                if (errors > 0)
                {
                    errorcount++;
                }
            }

            return errorcount;
        }





        private void FilesListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            FilesListViewSortColumn = GenericListViewSorting(FilesListView, e.Column, FilesListViewSortColumn);
        }

        private void FunctionsListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine whether the column is the same as the last column clicked.
            if (e.Column != FunctionsListViewSortColumn)
            {
                // Set the sort column to the new column.
                FunctionsListViewSortColumn = e.Column;
                // Set the sort order to ascending by default.
                FunctionsListView.Sorting = SortOrder.Ascending;
            }
            else
            {
                // Determine what the last sort order was and change it.
                FunctionsListView.Sorting = (FunctionsListView.Sorting == SortOrder.Ascending) ? SortOrder.Descending : SortOrder.Ascending;
            }


            SelectedFile.Functions.Sort(new ScriptFunctionComparer(e.Column, FunctionsListView.Sorting));

            FunctionsListView.RedrawItems(0, SelectedFile.Functions.Count - 1, false);
        }

        private void FunctionMatchesListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            FunctionMatchesListViewSortColumn = GenericListViewSorting(FunctionMatchesListView, e.Column, FunctionMatchesListViewSortColumn);
        }

        private void FunctionDependenciesListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            FunctionDependenciesListViewSortColumn = GenericListViewSorting(FunctionDependenciesListView, e.Column, FunctionDependenciesListViewSortColumn);
        }

        private void FunctionReferencesListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            FunctionReferencesListViewSortColumn = GenericListViewSorting(FunctionReferencesListView, e.Column, FunctionReferencesListViewSortColumn);
        }

        private int GenericListViewSorting(ListView lv, int col, int curcol)
        {
            // Determine whether the column is the same as the last column clicked.
            if (col != curcol)
            {
                // Set the sort column to the new column.
                curcol = col;
                // Set the sort order to ascending by default.
                lv.Sorting = SortOrder.Ascending;
            }
            else
            {
                // Determine what the last sort order was and change it.
                lv.Sorting = (lv.Sorting == SortOrder.Ascending) ? SortOrder.Descending : SortOrder.Ascending;
            }

            lv.Sort();
            lv.ListViewItemSorter = new ListViewItemComparer(col, lv.Sorting);

            return curcol;
        }



        public string GetBytesReadable(long i)
        {
            //shamelessly stolen from stackoverflow

            // Returns the human-readable file size for an arbitrary, 64-bit file size 
            // The default format is "0.### XB", e.g. "4.2 KB" or "1.434 GB"
            // Get absolute value
            long absolute_i = (i < 0 ? -i : i);
            // Determine the suffix and readable value
            string suffix;
            double readable;
            if (absolute_i >= 0x1000000000000000) // Exabyte
            {
                suffix = "EB";
                readable = (i >> 50);
            }
            else if (absolute_i >= 0x4000000000000) // Petabyte
            {
                suffix = "PB";
                readable = (i >> 40);
            }
            else if (absolute_i >= 0x10000000000) // Terabyte
            {
                suffix = "TB";
                readable = (i >> 30);
            }
            else if (absolute_i >= 0x40000000) // Gigabyte
            {
                suffix = "GB";
                readable = (i >> 20);
            }
            else if (absolute_i >= 0x100000) // Megabyte
            {
                suffix = "MB";
                readable = (i >> 10);
            }
            else if (absolute_i >= 0x400) // Kilobyte
            {
                suffix = "KB";
                readable = i;
            }
            else
            {
                return i.ToString("0 B"); // Byte
            }
            // Divide by 1024 to get fractional value
            readable = (readable / 1024);
            // Return formatted number with suffix
            return readable.ToString("0.# ") + suffix;
        }



        private void ToolsButton_Click(object sender, EventArgs e)
        {
            ToolsMenu.Show(ToolsButton, 0, ToolsButton.Height);
        }

        private void ToolsMenuFindReplace_Click(object sender, EventArgs e)
        {
            FindForm frm = new FindForm(this);
            frm.Show(this);
        }

        private void ToolsMenuFindCoordinates_Click(object sender, EventArgs e)
        {
            CoordForm frm = new CoordForm(this);
            frm.Show(this);
        }

        private void ToolsMenuAutoRefactor_Click(object sender, EventArgs e)
        {
            AutoForm frm = new AutoForm(this);
            frm.Show(this);
        }

        private void ToolsMenuJenkGen_Click(object sender, EventArgs e)
        {
            JenkGenForm frm = new JenkGenForm(this);
            frm.Show(this);
        }

        private void ToolsMenuJenkInd_Click(object sender, EventArgs e)
        {
            JenkIndForm frm = new JenkIndForm(this);
            frm.Show(this);
        }

        private void ToolsMenuSyntaxCheck_Click(object sender, EventArgs e)
        {
            if (MatchInProgress) return; //already matching...
            if (RefactorInProgress) return; //currently refactoring.

            if (Files.Count == 0)
            {
                MessageBox.Show("Please scan a valid GTA V script folder first.");
                return;
            }
            if (MessageBox.Show("Begin syntax check?", "Confirm start", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                return;
            }

            SyntaxCheck();
        }
    }








    public class ScriptFunctionComparer : IComparer<ScriptFunction>
    {
        private int col;
        private SortOrder order;
        public ScriptFunctionComparer()
        {
            col = 0;
            order = SortOrder.Ascending;
        }
        public ScriptFunctionComparer(int column, SortOrder order)
        {
            col = column;
            this.order = order;
        }

        public int Compare(ScriptFunction x, ScriptFunction y)
        {
            int returnVal = -1;

            //for sorting the functions list view.
            switch (col)
            {
                default:
                case 0: //name col, sort by string.
                    returnVal = String.Compare(x.Name, y.Name);
                    break;
                case 1: //return type col, sort by string.
                    returnVal = String.Compare(x.ReturnType, y.ReturnType);
                    break;
                case 2: //length col, sort by length.
                    returnVal = x.Length.CompareTo(y.Length);
                    break;
            }

            // Determine whether the sort order is descending.
            if (order == SortOrder.Descending)
                // Invert the value returned by String.Compare.
                returnVal *= -1;

            return returnVal;
        }
    }


    public class ListViewItemComparer : IComparer
    {
        // Implements the manual sorting of items by columns.
        private int col;
        private SortOrder order;
        public ListViewItemComparer()
        {
            col = 0;
            order = SortOrder.Ascending;
        }
        public ListViewItemComparer(int column, SortOrder order)
        {
            col = column;
            this.order = order;
        }
        public int Compare(object x, object y)
        {
            int returnVal = -1;

            ListViewItem lvix = (ListViewItem)x;
            ListViewItem lviy = (ListViewItem)y;

            if ((lvix.Tag is ScriptFile) && (lviy.Tag is ScriptFile))
            {
                ScriptFile sfx = (ScriptFile)lvix.Tag;
                ScriptFile sfy = (ScriptFile)lviy.Tag;

                //sorting the files list view.
                switch (col)
                {
                    default:
                    case 0: //filename col, sort by string.
                        returnVal = String.Compare(lvix.SubItems[col].Text, lviy.SubItems[col].Text);
                        break;
                    case 1: //file size col, sort by size.
                        returnVal = sfx.FileSize.CompareTo(sfy.FileSize);
                        break;
                }
            }
            else if ((lvix.Tag is ScriptFunctionMatch) && (lviy.Tag is ScriptFunctionMatch))
            {
                ScriptFunctionMatch fmx = (ScriptFunctionMatch)lvix.Tag;
                ScriptFunctionMatch fmy = (ScriptFunctionMatch)lviy.Tag;

                //sorting the function matches list view.
                switch (col)
                {
                    default: //string sorting.
                        returnVal = String.Compare(lvix.SubItems[col].Text, lviy.SubItems[col].Text);
                        break;
                    case 1: //match col, sort by match.
                        returnVal = fmx.Match.CompareTo(fmy.Match);
                        break;
                }
            }
            else if ((lvix.Tag is ScriptFunctionDependency) && (lviy.Tag is ScriptFunctionDependency))
            {
                ScriptFunctionDependency fdx = (ScriptFunctionDependency)lvix.Tag;
                ScriptFunctionDependency fdy = (ScriptFunctionDependency)lviy.Tag;

                //sorting the function matches list view.
                switch (col)
                {
                    default: //string sorting.
                        returnVal = String.Compare(lvix.SubItems[col].Text, lviy.SubItems[col].Text);
                        break;
                    case 1: //line col, sort by line.
                        returnVal = fdx.Line.CompareTo(fdy.Line);
                        break;
                }
            }
            else if ((lvix.Tag is ScriptFunctionReference) && (lviy.Tag is ScriptFunctionReference))
            {
                ScriptFunctionReference frx = (ScriptFunctionReference)lvix.Tag;
                ScriptFunctionReference fry = (ScriptFunctionReference)lviy.Tag;

                //sorting the function matches list view.
                switch (col)
                {
                    default: //string sorting.
                        returnVal = String.Compare(lvix.SubItems[col].Text, lviy.SubItems[col].Text);
                        break;
                    case 1: //line col, sort by line.
                        returnVal = frx.Line.CompareTo(fry.Line);
                        break;
                }
            }
            else
            {
                returnVal = String.Compare(lvix.SubItems[col].Text, lviy.SubItems[col].Text);
            }


            // Determine whether the sort order is descending.
            if (order == SortOrder.Descending)
                // Invert the value returned by String.Compare.
                returnVal *= -1;

            return returnVal;
        }
    }



    public static class TextBoxExtension
    {
        private const int EM_SETTABSTOPS = 0x00CB;

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr h, int msg, int wParam, int[] lParam);

        public static Point GetCaretPosition(this TextBox textBox)
        {
            Point point = new Point(0, 0);

            if (textBox.Focused)
            {
                point.X = textBox.SelectionStart - textBox.GetFirstCharIndexOfCurrentLine() + 1;
                point.Y = textBox.GetLineFromCharIndex(textBox.SelectionStart) + 1;
            }

            return point;
        }

        public static void SetTabStopWidth(this TextBox textbox, int width)
        {
            SendMessage(textbox.Handle, EM_SETTABSTOPS, 1, new int[] { width * 4 });
        }
    }
}
