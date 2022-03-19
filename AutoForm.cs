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
    public partial class AutoForm : Form
    {
        MainForm OwnerForm;
        volatile bool AbortOperation = false;
        bool InProgress = false;

        public AutoForm(MainForm owner)
        {
            InitializeComponent();

            OwnerForm = owner;
            FolderTextBox.Text = Settings.Default.ScriptFolder;
            GlobalsFileNameTextBox.Text = Settings.Default.GlobalsFile;
        }

        private void FolderBrowseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog.SelectedPath = FolderTextBox.Text;
            DialogResult res = FolderBrowserDialog.ShowDialog();
            if (res == DialogResult.OK)
            {
                FolderTextBox.Text = FolderBrowserDialog.SelectedPath;
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (InProgress) return;

            AutoRefactor2();
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            AbortOperation = true;
        }




        private void AutoRefactor()
        {
            AbortOperation = false;
            InProgress = true;

            string scriptfolder = FolderTextBox.Text;
            string globalsfile = GlobalsFileNameTextBox.Text;
            string functempl = FunctionTemplateComboBox.Text;
            int threshold = (int)ThresholdUpDown.Value;

            Task.Run(() =>
            {

                UpdateStatus("Task beginning...");

                DateTime starttime = DateTime.Now;
                string gfilepath = scriptfolder + "\\" + globalsfile;

                ScriptFile.EnsureGlobalsFile(gfilepath);

                int funcnumber = GetNextAvailableGlobalFunctionNumber(gfilepath, functempl, 1);
                int errorcount = 0; //total number of errors encountered
                int successcount = 0; //number of functions successfully refactored
                List<string> errors = new List<string>();
                int currentfuncline = 0;
                Dictionary<string, ScriptFunction> ignorefuncs = new Dictionary<string, ScriptFunction>(); //funcs that were already matched to 2 or less copies

                string[] scriptfiles = Directory.GetFiles(scriptfolder);
                
                foreach (string scriptfile in scriptfiles)
                {
                    if (AbortOperation)
                    {
                        UpdateStatus("AutoRefactor stopped at " + DateTime.Now.ToString() + ". Total duration: " + GetTimeStr(starttime));
                        AutoRefactorComplete();
                        return;
                    }

                    ignorefuncs.Clear();

                    ScriptFile file = new ScriptFile(scriptfile);

                    if (file.Name.ToLower() == globalsfile.ToLower()) continue; //don't autorefactor the globals file!

                    UpdateStatus(GetTimeStr(starttime) + ": AutoRefactoring " + scriptfile + "...");

                    file.Load();

                    ScriptFunction func = GetFirstRefactorableFunction(file, currentfuncline);

                    while (func != null)
                    {

                        string newname = string.Format(functempl, funcnumber);

                        string refacstrpart = file.Name + "::" + func.Name + " -> " + newname;
                        string refacstr = ": AutoRefactoring " + refacstrpart;

                        UpdateStatus(GetTimeStr(starttime) + refacstr + "...");


                        int cfile = 1;

                        //first step: find 100% function matches, this is basically the same as find matches function in MainForm
                        List<ScriptFunctionMatch> matches = new List<ScriptFunctionMatch>();
                        foreach (string matchfilep in scriptfiles)
                        {
                            if (AbortOperation)
                            {
                                UpdateStatus("AutoRefactor stopped at " + DateTime.Now.ToString() + ". Total duration: " + GetTimeStr(starttime));
                                AutoRefactorComplete();
                                return;
                            }

                            UpdateStatus(GetTimeStr(starttime) + refacstr + " : matching (" + cfile.ToString() + "/" + scriptfiles.Length.ToString() + ")...");

                            ScriptFile matchfile = new ScriptFile(matchfilep);
                            matchfile.Load();

                            foreach (ScriptFunction matchfunc in matchfile.Functions)
                            {
                                if (matchfunc.Length == func.Length)
                                {
                                    ScriptFunctionMatch match = new ScriptFunctionMatch(matchfunc, func);
                                    if (match.Match >= 100.0)
                                    {
                                        matches.Add(match);
                                    }
                                }
                            }

                            matchfile.Unload(); //must save memory :(

                            cfile++;
                        }


                        //only autorefactor this if more matches than the threshold are found
                        if (matches.Count >= threshold)
                        {

                            UpdateStatus(GetTimeStr(starttime) + refacstr + " : Appending new globals function...");

                            file.AppendToGlobalsFile(func, newname, matches, gfilepath);


                            int cmatch = 1;
                            int initialerrcount = errorcount;
                            foreach (ScriptFunctionMatch match in matches)
                            {

                                if (AbortOperation)
                                {
                                    //don't stop just now, wait until the current function is dealt with.
                                    UpdateStatus("AutoRefactor stopping...");
                                }
                                else
                                {
                                    UpdateStatus(GetTimeStr(starttime) + refacstr + " : refactoring (" + cmatch.ToString() + "/" + matches.Count.ToString() + ")...");
                                }

                                try
                                {
                                    ScriptFile sfile = new ScriptFile(scriptfolder + "\\" + match.FileName);
                                    sfile.Load();

                                    if (sfile.RefactorFunction(match.Name, newname))
                                    {
                                    }
                                    else
                                    {
                                        UpdateRefactorProgress("Error refactoring " + refacstrpart + ": " + sfile.LastError);
                                        errors.Add(sfile.LastError);
                                        errorcount++;
                                    }

                                }
                                catch (Exception ex)
                                {
                                    UpdateRefactorProgress("Error refactoring " + refacstrpart + ": " + ex.ToString());
                                    errors.Add(ex.ToString());
                                    errorcount++;
                                }

                                cmatch++;
                            }

                            if (initialerrcount == errorcount)
                            {
                                //no errors recorded here, count the success
                                successcount++;

                                int linecount = func.EndLine - func.StartLine;
                                UpdateRefactorProgress(refacstrpart + "   (" + linecount.ToString() + " lines, " + matches.Count.ToString() + " matches)");
                            }

                            currentfuncline = 0; //start searching at the beginning of the file again since earlier funcs may now be refactorable!

                            //funcnumber++;
                            funcnumber = GetNextAvailableGlobalFunctionNumber(gfilepath, functempl, 1);
                        }
                        else
                        {
                            currentfuncline = func.EndLine;
                            if (!ignorefuncs.ContainsKey(func.Name))
                            {
                                ignorefuncs.Add(func.Name, func);
                            }
                            UpdateRefactorProgress("Skipped " + refacstrpart + " due to only " + matches.Count.ToString() + " matches.");
                        }


                        file = new ScriptFile(scriptfile);
                        file.Load();
                        func = GetFirstRefactorableFunction(file, currentfuncline);

                        while ((func != null) && ignorefuncs.ContainsKey(func.Name))
                        {
                            func = GetFirstRefactorableFunction(file, func.EndLine);
                        }
                    }


                    currentfuncline = 0; //reset search start for next file!
                }


                UpdateStatus("AutoRefactor completed at " + DateTime.Now.ToString() + ". Total duration: " + GetTimeStr(starttime));

                AutoRefactorComplete();
            });
        }

        private void AutoRefactor2()
        {
            AbortOperation = false;
            InProgress = true;

            string scriptfolder = FolderTextBox.Text;
            string globalsfile = GlobalsFileNameTextBox.Text;
            string functempl = FunctionTemplateComboBox.Text;
            int threshold = Math.Max((int)ThresholdUpDown.Value, 1);

            Task.Run(() =>
            {

                UpdateStatus("Task beginning...");

                DateTime starttime = DateTime.Now;
                string gfilepath = scriptfolder + "\\" + globalsfile;


                string[] scriptfiles = Directory.GetFiles(scriptfolder);

                string recursivefuncname = "XXXXXXXX__RECURSIVEFUNCTION__XXXXXXXX(";


                int pass = 1;
                while (true)
                {
                    //stage 0: make sure the globals file is there
                    ScriptFile.EnsureGlobalsFile(gfilepath);
                    ScriptFile gfile = new ScriptFile(gfilepath);
                    gfile.Load();

                    //stage 1: find all currently refactorable functions in all files and smash them into a dictionary...
                    Dictionary<string, List<ScriptFunction>> foundfuncs = new Dictionary<string, List<ScriptFunction>>();

                    foreach (string scriptfile in scriptfiles)
                    {
                        if (AbortOperation)
                        {
                            UpdateStatus("AutoRefactor stopped at " + DateTime.Now.ToString() + ". Total duration: " + GetTimeStr(starttime));
                            AutoRefactorComplete();
                            return;
                        }

                        ScriptFile file = new ScriptFile(scriptfile);

                        if (file.Name.ToLower() == globalsfile) continue; //don't look in the globals file

                        UpdateStatus(GetTimeStr(starttime) + " : Searching " + file.Name + "...");

                        file.Load();

                        ScriptFunction func = null;
                        int currentline = 0;

                        //find all currently refactorable functions in this file, and add them to the dict
                        while ((func = GetFirstRefactorableFunction(file, currentline)) != null)
                        {
                            string funcstr = func.FunctionBody.Replace(func.Name + "(", recursivefuncname);
                            //uint funchash = JenkHash.GenHash(funcstr, JenkHashInputEncoding.UTF8);

                            List<ScriptFunction> hitlist = null;
                            if (!foundfuncs.TryGetValue(funcstr, out hitlist))
                            {
                                hitlist = new List<ScriptFunction>();
                                foundfuncs.Add(funcstr, hitlist);
                            }

                            hitlist.Add(func);

                            currentline = func.EndLine;
                        }

                        file.Unload();
                    }

                    GC.Collect(); //try keep the memory flowing


                    //stage 2: organise the found functions by the filename. allocate new global func names
                    Dictionary<string, List<ScriptFunction>> filefuncs = new Dictionary<string, List<ScriptFunction>>();
                    int curfuncnum = 1;
                    int foundfunccount = 0;
                    foreach (KeyValuePair<string, List<ScriptFunction>> kvp in foundfuncs)
                    {
                        if (kvp.Value.Count < threshold) continue; //skip this if below the threshold

                        foundfunccount++;

                        curfuncnum = GetNextAvailableGlobalFunctionNumber(gfile, functempl, curfuncnum);
                        string newname = string.Format(functempl, curfuncnum);

                        UpdateStatus(GetTimeStr(starttime) + " : Adding " + newname + " to " + gfile.Name + "...");

                        foreach (ScriptFunction func in kvp.Value)
                        {
                            List<ScriptFunction> flist;
                            if (!filefuncs.TryGetValue(func.File.Name, out flist))
                            {
                                flist = new List<ScriptFunction>();
                                filefuncs.Add(func.File.Name, flist);
                            }
                            func.NewName = newname;
                            flist.Add(func);
                        }

                        ScriptFunction usefunc = kvp.Value[0]; //use the first found func as the template for the globals.

                        string funcbody = kvp.Key.Replace(recursivefuncname, newname + "(");

                        //might be faster to use a stringbuilder to get the filewrite out of the loop..
                        usefunc.File.AppendToGlobalsFile(usefunc, newname, kvp.Value, gfilepath, funcbody);

                        string refacstrpart = "Added " + newname + " to " + gfile.Name;
                        int linecount = usefunc.EndLine - usefunc.StartLine;
                        UpdateRefactorProgress(refacstrpart + "   (" + linecount.ToString() + " lines, " + kvp.Value.Count.ToString() + " matches)");

                        curfuncnum++;
                    }

                    foundfuncs.Clear();


                    //stage 3: go through all the files and refactor all found funcs in the file.
                    int grandtotfuncs = 0;
                    int grandtotlines = 0;
                    foreach (string scriptfile in scriptfiles)
                    {
                        ScriptFile file = new ScriptFile(scriptfile);

                        if (file.Name.ToLower() == globalsfile) continue; //don't refactor the globals file

                        List<ScriptFunction> ffuncs;
                        if (!filefuncs.TryGetValue(file.Name, out ffuncs)) continue; //no matches found for funcs in this file...

                        UpdateStatus(GetTimeStr(starttime) + " : Refactoring " + file.Name + "...");

                        file.Load();

                        file.RefactorFunctions(ffuncs);

                        file.Unload();


                        string refacstrpart = "Refactored " + ffuncs.Count.ToString() + " funcs in " + file.Name;
                        int totlines = 0;
                        foreach (ScriptFunction ffunc in ffuncs)
                        {
                            totlines += (ffunc.EndLine - ffunc.StartLine);
                        }
                        UpdateRefactorProgress(refacstrpart + "   (" + totlines.ToString() + " total lines)");

                        grandtotfuncs += ffuncs.Count;
                        grandtotlines += totlines;
                    }



                    UpdateRefactorProgress("Pass " + pass.ToString() + " complete. " + grandtotfuncs.ToString() + " total functions refactored into "+foundfunccount+" global functions, " + grandtotlines + " total lines.");
                    pass++;


                    //try to keep the GC not confused...
                    foreach (KeyValuePair<string, List<ScriptFunction>> kvp in foundfuncs)
                    {
                        kvp.Value.Clear();
                    }
                    foreach (KeyValuePair<string, List<ScriptFunction>> kvp in filefuncs)
                    {
                        kvp.Value.Clear();
                    }
                    foundfuncs.Clear();
                    filefuncs.Clear();
                    GC.Collect(); //try keep the memory flowing



                    if (grandtotfuncs == 0)
                    {
                        break;
                    }
                }

                UpdateStatus("AutoRefactor completed at " + DateTime.Now.ToString() + ". Total duration: " + GetTimeStr(starttime));
                UpdateRefactorProgress("AutoRefactor process complete.");

                AutoRefactorComplete();
            });
        }


        private void AutoRefactorComplete()
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new Action(() => { AutoRefactorComplete(); }));
                }
                else
                {
                    InProgress = false;
                }
            }
            catch { }
        }

        private void UpdateRefactorProgress(string text)
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new Action(() => { UpdateRefactorProgress(text); }));
                }
                else
                {
                    LogTextBox.AppendText(text + "\r\n");
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


        private int GetNextAvailableGlobalFunctionNumber(string globalsfile, string functemplate, int start)
        {

            ScriptFile gf = new ScriptFile(globalsfile);
            gf.Load();

            return GetNextAvailableGlobalFunctionNumber(gf, functemplate, start);
        }

        private int GetNextAvailableGlobalFunctionNumber(ScriptFile gf, string functemplate, int start)
        {
            int num = start - 1;
            string name;
            bool found = true;
            while (found)
            {
                num++;
                name = string.Format(functemplate, num);
                found = gf.FunctionMap.ContainsKey(name);
            }

            return num;
        }

        private ScriptFunction GetFirstRefactorableFunction(ScriptFile file, int startline)
        {
            string[] exclstarts = { "l_", "Local_", "iLocal_", "uLocal_", "fLocal_", "vLocal_", "sLocal_", "cLocal_" };

            foreach (ScriptFunction func in file.Functions)
            {
                if (func.StartLine < startline) continue; //don't look at functions before the given line.
                if (func.Name == "main") continue; //don't refactor main funcs...

                //first test - does the function have no local dependencies?
                bool haslocaldeps = false;
                foreach (ScriptFunctionDependency funcdep in func.LocalDependencies)
                {
                    if (funcdep.Name != func.Name)
                    {
                        haslocaldeps = true;
                        break;
                    }
                }
                if (haslocaldeps) continue;


                //second test - does the function contain any references to local variables?
                bool localfound = false;
                for (int l = func.StartLine + 1; l <= func.EndLine; l++)
                {
                    string line = file.FileLines[l];

                    int wordstart = 0;
                    bool inword = false;
                    for (int i = 0; i < line.Length; i++)
                    {
                        char c = line[i];
                        if ((!inword) && (char.IsLetter(c) || (c=='_')))
                        {
                            inword = true;
                            wordstart = i;
                        }
                        else if (!(char.IsLetter(c) || char.IsNumber(c) || (c == '_')))
                        {
                            if (inword)
                            {
                                string word = line.Substring(wordstart, i - wordstart);

                                foreach (string exclstart in exclstarts)
                                {
                                    if (word.StartsWith(exclstart))
                                    {
                                        localfound = true;
                                        break;
                                    }
                                }
                                if (localfound) break;
                            }
                            inword = false;
                        }
                    }
                    if (localfound) break;
                }

                if (!localfound)
                {
                    return func;
                }
            }

            return null;
        }


        private string GetTimeStr(DateTime starttime)
        {
            return (DateTime.Now - starttime).ToString("h\\:mm\\:ss");
        }
    }


}
