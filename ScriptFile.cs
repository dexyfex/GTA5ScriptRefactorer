using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace gta5refactor
{


    public class ScriptFile
    {
        public string Name { get; set; }
        public string FilePath { get; set; }
        public long FileSize { get; set; }
        public string[] FileLines { get; set; }
        public List<ScriptFunction> Functions { get; set; }
        public Dictionary<string, ScriptFunction> FunctionMap { get; set; }
        public string LastError { get; set; }

        public ScriptFile(string fpath)
        {
            FileInfo fi = new FileInfo(fpath);
            Name = fi.Name;
            FilePath = fpath;
            FileSize = fi.Length;
            FileLines = null;
            Functions = null;
            FunctionMap = null;
        }

        public void Load()
        {
            FileLines = File.ReadAllLines(FilePath);
            Functions = GetScriptFunctions(FileLines);
            FunctionMap = GetFunctionMap(Functions);

            foreach (ScriptFunction func in Functions)
            {
                //make sure lists are all created before trying to populate them...!
                func.References = new List<ScriptFunctionReference>();
            }
            foreach (ScriptFunction func in Functions)
            {
                func.LoadDependenciesAndReferences();
            }

        }

        public void Unload()
        {
            FileLines = null;
            Functions = null;
            FunctionMap = null;
        }

        public void Save()
        {
            //save the file...
            string ofpath = FilePath;// + "2";
            StringBuilder osb = new StringBuilder();
            for (int i = 0; i < FileLines.Length; i++)
            {
                osb.AppendLine(FileLines[i]);
            }
            File.WriteAllText(ofpath, osb.ToString());
        }


        public void AppendToGlobalsFile(ScriptFunction func, string newname, List<ScriptFunctionMatch> fullmatches, string gfilepath)
        {
            //v1 used by main refactorer tool and v1 autorefactor (slow for multi use!)
            //convert the given function to global and append to the globals file.

            if (func == null) return;
            if (func.File != this) return;

            StringBuilder fsb = new StringBuilder();
            string funcdecl = string.Format("{0} {1}({2})", func.ReturnType, newname, func.Params);
            fsb.AppendLine();
            if (FileLines[func.StartLine].Contains('{'))
            {
                funcdecl += " {"; //listener script files have function decl's with the trailing brace.
            }
            string extrastr = string.Empty;
            if (fullmatches.Count > 1)
            {
                extrastr = string.Format("  +{0} others", fullmatches.Count - 1);
            }
            funcdecl += string.Format(" /* From {0}::{1}{2} */", Name, func.Name, extrastr);

            string recfuncd = func.Name + "("; //to allow matching recursive functions
            string newfuncd = newname + "("; //replace matches with the current function name with the new - for recursives
            fsb.AppendLine(funcdecl);
            for (int i = func.StartLine + 1; i <= func.EndLine; i++)
            {
                fsb.AppendLine(FileLines[i].Replace(recfuncd, newfuncd));
            }


            EnsureGlobalsFile(gfilepath);

            File.AppendAllText(gfilepath, fsb.ToString());

        }

        public void AppendToGlobalsFile(ScriptFunction func, string newname, List<ScriptFunction> fullmatches, string gfilepath, string funcbody)
        {
            //v2 used by v2 autorefactor (for multi use)
            //convert the given functions to global and appends them to the globals file.

            if (func == null) return;


            StringBuilder fsb = new StringBuilder();
            string funcdecl = string.Format("{0} {1}({2})", func.ReturnType, newname, func.Params);
            fsb.AppendLine();


            //find the first brace and the first non whitepace char, to determine if there's an open brace at the start of the first line
            int braceind = funcbody.IndexOf('{');
            int firstcharind = 0;
            for (int i = 0; i < funcbody.Length; i++)
            {
                if (!char.IsWhiteSpace(funcbody[i]))
                {
                    firstcharind = i;
                    break;
                }
            }
            if ((braceind < 0) || (braceind > firstcharind))
            {
                funcdecl += " {"; //listener script files have function decl's with the trailing brace.
            }

            string extrastr = string.Empty;
            if (fullmatches.Count > 1)
            {
                extrastr = string.Format("  +{0} others", fullmatches.Count - 1);
            }
            funcdecl += string.Format(" /* From {0}::{1}{2} */", Name, func.Name, extrastr);

            string recfuncd = func.Name + "("; //to allow matching recursive functions
            string newfuncd = newname + "("; //replace matches with the current function name with the new - for recursives
            fsb.AppendLine(funcdecl);

            fsb.Append(funcbody);


            EnsureGlobalsFile(gfilepath);

            File.AppendAllText(gfilepath, fsb.ToString());
        }

        public int RenameGlobalFunction(string name, string newname)
        {
            int hits = 0;

            foreach (ScriptFunction func in Functions)
            {
                if (func.Name == name)
                {
                    //probably found the global declaration for this function.. rename it!
                    func.RenameDeclaration(newname);
                    hits++;
                }

                foreach (ScriptFunctionDependency dep in func.AllDependencies)
                {
                    //update any references in dependencies in this function
                    if (dep.Name == name)
                    {
                        dep.Rename(newname);
                        hits++;
                    }
                }
            }

            if (hits > 0)
            {
                Save();
            }

            return hits;
        }

        public bool RefactorFunction(string name, string newname)
        {
            //this will strip the function with the given name from this file,
            //and replace all references with the new name.
            //saves the file at the end.

            if (FileLines == null) Load();

            ScriptFunction func;
            if (!FunctionMap.TryGetValue(name, out func))
            {
                LastError = string.Format("Function {0} not found in {1}.", name, Name);
                return false; //apparently the function doesn't exist in here?
            }


            //go through the references list and replace the function name with the new one.
            foreach (ScriptFunctionReference reff in func.References)
            {
                reff.Rename(name, newname);


                //since the ref line may have changed length, need to update any other references on this line...
                //only really care about references to the same function. so don't worry about others here.
                //(everything will only be used for this process.)
                int lendiff = newname.Length - name.Length;
                foreach (ScriptFunctionReference ref2 in func.References)
                {
                    if ((ref2.Line == reff.Line) && (ref2.Char > reff.Char))
                    {
                        ref2.Char += lendiff; //offset the char to account for it.
                    }
                }
            }


            string ofpath = FilePath;
            StringBuilder osb = new StringBuilder();
            for (int i = 0; i < FileLines.Length; i++)
            {
                if (i == func.StartLine)
                {
                    i = func.EndLine;
                }
                else
                {
                    osb.AppendLine(FileLines[i]);
                }
            }
            File.WriteAllText(ofpath, osb.ToString());

            return true;
        }

        public bool RefactorFunctions(List<ScriptFunction> oldfuncs)
        {

            LastError = string.Empty;

            List<ScriptFunction> refacfuncs = new List<ScriptFunction>();
            foreach (ScriptFunction oldfunc in oldfuncs)
            {
                ScriptFunction func;
                if (!FunctionMap.TryGetValue(oldfunc.Name, out func))
                {
                    LastError += string.Format("Function {0} not found in {1}. ", oldfunc.Name, Name);
                    continue; //this shouldn't really happen..
                }

                refacfuncs.Add(func);

                int lendiff = oldfunc.NewName.Length - func.Name.Length;

                foreach (ScriptFunctionReference reff in func.References)
                {
                    reff.Rename(func.Name, oldfunc.NewName);

                    //could have multiple refs on the same line. need to offset ones that are to the right..
                    //references to this function have been updated. But other function references might now
                    //have incorrect Char values if they were on the same line...
                    foreach (ScriptFunction tfunc in Functions)
                    {
                        foreach (ScriptFunctionReference ref3 in tfunc.References)
                        {
                            if ((ref3.Line == reff.Line) && (ref3.Char > reff.Char))
                            {
                                ref3.Char += lendiff; //offset the char to account for it.
                            }
                        }
                    }
                }
            }


            string ofpath = FilePath;
            StringBuilder osb = new StringBuilder();

            Dictionary<int, ScriptFunction> startlinedict = new Dictionary<int, ScriptFunction>();
            foreach (ScriptFunction func in refacfuncs)
            {
                if (!startlinedict.ContainsKey(func.StartLine))
                {
                    startlinedict.Add(func.StartLine, func);
                }
            }
            for (int i = 0; i < FileLines.Length; i++)
            {
                ScriptFunction stfunc;
                if (startlinedict.TryGetValue(i, out stfunc))
                {
                    i = stfunc.EndLine;
                }
                else
                {
                    osb.AppendLine(FileLines[i]);
                }
            }
            //int curline = 0;
            //foreach (ScriptFunction func in refacfuncs)
            //{
            //    for (int i = curline; i < func.StartLine; i++)
            //    {
            //        osb.AppendLine(FileLines[i]);
            //    }
            //    curline = func.EndLine + 1;
            //}

            File.WriteAllText(ofpath, osb.ToString());

            return true;
        }


        public static void EnsureGlobalsFile(string path)
        {
            if (!File.Exists(path))
            {
                StringBuilder sbmsg = new StringBuilder();
                sbmsg.AppendLine("// Globals file from GTA V Refactor by dexyfex");
                File.AppendAllText(path, sbmsg.ToString());//it's a great message, the greatest of messages
            }
        }



        public int SyntaxCheck()
        {
            //search for errors that happen in drp4lyf scripts. (missing close braces)

            bool loaded = (FileLines != null);
            FileLines = File.ReadAllLines(FilePath);

            int errors = 0;
            int bracedepth = 0;
            bool instr = false;

            for (int l = 0; l < FileLines.Length; l++)
            {
                string line = FileLines[l];
                char lc = (char)0;
                for (int i = 0; i < line.Length; i++)
                {
                    char c = line[i];
                    if ((c == '"') && (lc != '\\')) //maybe there's an escaped string somewhere?
                    {
                        instr = !instr;
                    }
                    if ((c == '/') && (lc == '/') && (!instr)) //begin single line comment, go to next line.
                    {
                        lc = c;
                        continue;
                    }
                    switch (c)
                    {
                        case '{': bracedepth++; break;
                        case '}': bracedepth--; break;
                    }

                    lc = c;
                }
            }

            errors = Math.Abs(bracedepth); //let's just check how badly all the braces line up.

            if (!loaded) FileLines = null;
            return errors;
        }

        public int FixSyntax()
        {
            //try to fix errors that happen in drp4lyf scripts. (missing close braces)

            bool loaded = (FileLines != null);
            FileLines = File.ReadAllLines(FilePath);

            int bracedepth = 0;
            bool instr = false;
            int additions = 0;
            List<int> errlines = new List<int>();
            List<int> errdepths = new List<int>();

            for (int l = 0; l < FileLines.Length; l++)
            {
                string line = FileLines[l];

                char lc = (char)0;
                for (int i = 0; i < line.Length; i++)
                {
                    char c = line[i];
                    if ((c == '"') && (lc != '\\')) //maybe there's an escaped string somewhere?
                    {
                        instr = !instr;
                    }
                    if ((c == '/') && (lc == '/') && (!instr)) //begin single line comment, go to next line.
                    {
                        lc = c;
                        continue;
                    }
                    switch (c)
                    {
                        case '{': bracedepth++; break;
                        case '}': bracedepth--; break;
                    }
                    lc = c;
                }

                //see if this line is a function declaration...
                if (instr) continue; //in a string... shouldn't happen really
                if (line.Length == 0) continue; //empty line.. no function
                char l0 = line[0];
                if (l0 == '#') continue; //ignore #region etc.
                if (l0 == ' ') continue; //ignore lines starting with a space... (most function body - listener)
                if (l0 == '\t') continue; //ignore lines starting with a tab... (most function body - drp4lyf)
                if ((l0 == '/') && (line.Length > 1) && (line[1] == '/')) continue; //line is a comment.
                if ((l0 == '{') || (l0 == '}')) continue; //it's an open/close brace line, probably no declaration here.
                if (line.IndexOf('(') == -1) continue; //no open bracket found, can't be a function declaration.

                //if we got here, it's probably a function declaration.
                //need to insert closing braces here to get the depth back to zero, if it isn't zero already..
                //but we're iterating the lines here, so save the position to insert the braces in 2nd pass.
                if (bracedepth != 0)
                {
                    errlines.Add(l);
                    errdepths.Add(bracedepth);
                    bracedepth = 0;
                    for (int i = 0; i < line.Length; i++) //there might still be braces on this line...
                    {
                        char c = line[i];
                        switch (c)
                        {
                            case '{': bracedepth++; break; //shouldn't really happen in drp4lyf scripts
                            case '}': bracedepth--; break; //this really should be considered an error case. oh well.
                        }
                    }
                }
            }




            //quick test to guess if the script is using tab or space indenting...
            bool usetab = false;
            for (int l = 0; l < 20; l++)
            {
                string line = FileLines[l];
                if (line.Length == 0) continue;
                if (line[0] == '\t')
                {
                    usetab = true;
                    break;
                }
            }


            //now insert the missing closing braces..
            int cline = 0;
            StringBuilder sb = new StringBuilder();
            for (int el = 0; el < errlines.Count; el++)
            {
                int errl = errlines[el];
                int errdepth = errdepths[el];

                //copy the lines up until this point.
                for (int i = cline; i < errl; i++)
                {
                    sb.AppendLine(FileLines[i]);
                }

                //add the closing brace lines.
                for (int i = 0; i < errdepth; i++)
                {
                    int inset = errdepth - i - 1;
                    for (int j = 0; j < inset; j++)
                    {
                        if (usetab) sb.Append('\t');
                        else sb.Append("   "); //use 3 spaces if not a tab..
                    }
                    sb.Append('}'); //close that brace!
                    sb.AppendLine(" // This line was added by GTA V Refactor."); //add a helpful message
                    if (inset == 0)
                    {
                        sb.AppendLine(); //try to keep the gap between this and the next function.
                    }
                }
                cline = errl; //keep track of where we left off!
            }
            for (int l = cline; l < FileLines.Length; l++)
            {
                sb.AppendLine(FileLines[l]); //copy any remaining lines.
            }


            File.WriteAllText(FilePath, sb.ToString()); //save the new string to the file.


            if (!loaded) FileLines = null;
            return additions;
        }


        public List<ScriptHash> FindHashes(bool findunsigned, bool findsigned, bool findhex, int minlength)
        {
            List<ScriptHash> res = new List<ScriptHash>();

            bool loaded = (FileLines != null);
            FileLines = File.ReadAllLines(FilePath);

            StringBuilder sb = new StringBuilder(); //for building found hashes.

            for (int l = 0; l < FileLines.Length; l++)
            {
                string line = FileLines[l].ToLower();

                bool innum = false;
                bool hexstart = false;
                sb.Clear(); //a new line is a new string.

                char lc = (char)0;
                for (int i = 0; i < line.Length; i++)
                {
                    char c = line[i];
                    bool match = false;
                    switch (c)
                    {
                        case '0':
                        case '1':
                        case '2':
                        case '3':
                        case '4':
                        case '5':
                        case '6':
                        case '7':
                        case '8':
                        case '9':
                            match = true;
                            break;
                        case '-':
                            match = findsigned && !innum;
                            break;
                        case 'x':
                            match = findhex && (lc == '0');
                            hexstart = match;
                            break;
                        case 'a':
                        case 'b':
                        case 'c':
                        case 'd':
                        case 'e':
                        case 'f':
                            match = findhex && hexstart;
                            break;
                    }
                    if (match)
                    {
                        sb.Append(c);
                        innum = true;
                    }
                    else
                    {
                        if (innum)
                        {
                            //anything we consider a potential match just ended. record it...
                            if (sb.Length >= minlength)
                            {
                                bool issigned = (sb[0] == '-');
                                bool ishex = findhex && hexstart;
                                bool isunsigned = !(issigned || ishex);

                                if ((isunsigned && findunsigned) || (issigned && findsigned) || (ishex && findhex))
                                {
                                    ScriptHash foundhash = new ScriptHash();
                                    foundhash.File = this;
                                    foundhash.HashStr = sb.ToString();
                                    foundhash.Line = l;
                                    foundhash.Char = i - sb.Length;
                                    res.Add(foundhash);
                                }
                            }
                        }
                        innum = false;
                        hexstart = false;
                        sb.Clear();
                    }

                    lc = c;
                }

            }



            if (!loaded) FileLines = null;
            return res;
        }

        public List<ScriptChange> ReplaceHashes(List<ScriptHash> hashes, Dictionary<string, JenkIndMatch> matches, Dictionary<string, List<JenkIndMatch>> collisions, string format, bool replace, bool insert)
        {
            //hashes are the results from FindHashes!
            //matches are what was found in the JenkIndex.
            //collisions are matches that have more than one possible value.

            bool loaded = (FileLines != null);
            FileLines = File.ReadAllLines(FilePath);

            List<ScriptChange> changes = new List<ScriptChange>();

            foreach (ScriptHash hash in hashes)
            {
                if (hash.File != this)
                {
                    continue; //ignore hashes that aren't for this file.
                }

                int l = hash.Line;
                string line = FileLines[l];
                string linel = line.ToLower();

                JenkIndMatch match;
                if (matches.TryGetValue(hash.HashStr, out match)) //make sure this hash is one we found ea match for!
                {
                    int ind = linel.IndexOf(hash.HashStr, hash.Char);

                    if (ind != -1) //make sure this hash is present in this line...
                    {
                        string newstr = string.Format(format, match.Value);
                        int diffoffset;
                        if (!char.IsWhiteSpace(line[0]))
                        {
                            line = line + " //" + newstr; //seems to be a function call line... append onto the end!
                            diffoffset = newstr.Length + 2;
                        }
                        else if (replace)
                        {
                            line = line.Replace(hash.HashStr, newstr);
                            diffoffset = newstr.Length - hash.HashStr.Length;
                        }
                        else
                        {

                            if (!insert) //insert after... do same thing as insert before, but shifted to the right
                            {
                                ind = ind + hash.HashStr.Length;
                            }
                            string s1 = (ind > 0) ? line.Substring(0, ind) : string.Empty;
                            string s2 = (ind < line.Length) ? line.Substring(ind) : string.Empty;
                            line = s1 + newstr + s2;

                            diffoffset = newstr.Length;
                        }

                        ScriptChange change = new ScriptChange();
                        change.File = this;
                        change.LineNum = l;
                        change.LineBefore = FileLines[l];
                        change.LineAfter = line;
                        changes.Add(change);

                        FileLines[l] = line;


                        foreach (ScriptHash otherhash in hashes)
                        {
                            if ((otherhash.Line == hash.Line) && (otherhash.Char > hash.Char))
                            {
                                otherhash.Char += diffoffset;
                            }
                        }

                    }
                    else
                    {
                        //this shouldn't happen?
                    }
                }
            }



            if (changes.Count > 0)
            {
                Save();
            }

            if (!loaded) FileLines = null;
            return changes;
        }

        public List<ScriptChange> ReplaceHash(ScriptHash hash, string val, string format, bool replace, bool insert)
        {
            //helper. not currently used...

            List<ScriptHash> hashes = new List<ScriptHash>();
            hashes.Add(hash);

            Dictionary<string, JenkIndMatch> matches = new Dictionary<string, JenkIndMatch>();
            JenkIndMatch match = new JenkIndMatch(hash.HashStr, val);
            matches.Add(hash.HashStr, match);

            Dictionary<string, List<JenkIndMatch>> collisions = new Dictionary<string, List<JenkIndMatch>>();

            return ReplaceHashes(hashes, matches, collisions, format, replace, insert);
        }


        public List<ScriptCoord> FindCoordinates()
        {
            List<ScriptCoord> result = new List<ScriptCoord>();

            bool loaded = (FileLines != null);
            FileLines = File.ReadAllLines(FilePath);

            StringBuilder sb = new StringBuilder(); //for building found hashes.
            List<double> vals = new List<double>();

            for (int l = 0; l < FileLines.Length; l++)
            {
                string line = FileLines[l].ToLower();

                bool innum = false;
                int commacount = 0;

                sb.Clear(); //a new line is a new string.

                for (int i = 0; i < line.Length; i++)
                {
                    char lastc = (i > 0) ? line[i - 1] : (char)0;
                    char c = line[i];
                    bool match = false;

                    if (char.IsDigit(c) || (c == '-'))
                    {
                        match = true;
                    }
                    else if (innum && ((c == '.') || (c == ',') || (c == ' ')))
                    {
                        match = true;
                        if (c == ',') commacount++;
                    }

                    if (match)
                    {
                        if (innum)
                        {
                            sb.Append(c);
                        }
                        else if (!(char.IsLetterOrDigit(lastc) || (c == '_')))
                        {
                            sb.Append(c);
                            innum = true;
                        }
                    }
                    else
                    {
                        if (innum && (commacount > 1))
                        {
                            //anything we consider a potential match just ended. record it...

                            string vecstr = sb.ToString();


                            List<ScriptCoord> linecoords = GetCoordsFromVecStr(vecstr, l, vals);

                            result.AddRange(linecoords);

                        }

                        sb.Clear();
                        innum = false;
                        commacount = 0;
                    }
                }
            }

            if (!loaded) FileLines = null;

            return result;
        }

        private List<ScriptCoord> GetCoordsFromVecStr(string vecstr, int linenum, List<double> vals)
        {
            //vals is passed in here as an optimisation. it is a temporary.
            List<ScriptCoord> result = new List<ScriptCoord>();

            string[] components = vecstr.Split(',');
            vals.Clear();

            for (int v = 0; v < components.Length; v++)
            {
                string comp = components[v].Trim();
                double val;
                double.TryParse(comp, out val);
                //bool isdec = (((val - Math.Floor(val)) > 0.0) || ((comp.Contains('.') && (comp.Length > 3))));
                components[v] = comp;
                vals.Add(val);
            }

            if (vals.Count == 3) //simple case.
            {
                //just add it to the result, filtering will be done later
                ScriptCoord coord = new ScriptCoord(this, linenum, vals);
                if (coord.Score > 0.0)
                {
                    result.Add(coord);
                }
            }
            else
            {
                List<ScriptCoord> candidates = new List<ScriptCoord>();
                ScriptCoord lastcand = null;
                int lasti = -10;
                for (int i = 0; i < vals.Count - 1; i++)
                {
                    ScriptCoord candidate = new ScriptCoord(this, linenum, vals, i);
                    if (candidate.Score > 0.0)
                    {
                        if ((lastcand == null) || ((i - lasti) > 2))
                        {
                            candidates.Add(candidate);
                            lastcand = candidate;
                            lasti = i;
                        }
                        else if (lastcand.Score < candidate.Score)
                        {
                            candidates[candidates.Count - 1] = candidate;
                            lastcand = candidate;
                            lasti = i;
                        }
                    }
                }
                if (candidates.Count > 0)
                {
                    lastcand = null;
                    foreach (ScriptCoord cand in candidates)
                    {
                        if ((lastcand != null) && (lastcand.W == cand.X))
                        {
                            lastcand.W = 0.0; //sequential 3D candidates - fixing incorrect W val for the first one
                        }
                        lastcand = cand;
                    }

                    result.AddRange(candidates);
                }

            }


            return result;
        }


        public ScriptFunction TryGetFunction(int line, bool keeploaded)
        {
            ScriptFunction rf = null;

            bool loaded = (FileLines != null);
            if (!loaded)
            {
                Load();
            }

            foreach (ScriptFunction func in Functions)
            {
                if ((func.StartLine <= line) && (func.EndLine >= line))
                {
                    rf = func;
                    break;
                }
            }

            if (!loaded && !keeploaded)
            {
                Unload();
            }
            return rf;
        }


        private List<ScriptFunction> GetScriptFunctions(string[] lines)
        {
            List<ScriptFunction> res = new List<ScriptFunction>();

            int bracedepthlast = 0;
            int bracedepth = 0;
            string functype = "";
            string funcname = "";
            string funcparams = "";
            int funcstartline = 0;
            bool instr = false;

            for (int l = 0; l < lines.Length; l++)
            {
                string line = lines[l];
                if (line.Length == 0) continue;
                char l0 = line[0];
                if (l0 == '#') continue; //ignore #region etc.
                if (l0 == ' ') continue; //ignore lines starting with a space... (most function body - listener)
                if (l0 == '\t') continue; //ignore lines starting with a tab... (most function body - drp4lyf)
                if ((l0 == '/') && (line.Length > 1) && (line[1] == '/')) continue; //line is a comment.
                bool hasspace = false;
                int spaceidx = 0;
                int linestartbracedepth = bracedepth;
                char lc = (char)0;
                for (int i = 0; i < line.Length; i++)
                {
                    char c = line[i];
                    if ((c == '"') && (lc != '\\')) //maybe there's an escaped string somewhere?
                    {
                        instr = !instr;
                    }
                    if ((c == '/') && (lc == '/') && (!instr)) //begin single line comment, go to next line.
                    {
                        lc = c;
                        continue;
                    }
                    switch (c)
                    {
                        case '{': bracedepth++; break;
                        case '}': bracedepth--; break;
                        case ' ': if (!hasspace) spaceidx = i; hasspace = true; break;
                    }
                    lc = c;
                }

                if ((linestartbracedepth == 0) && (hasspace))
                {
                    int paramstart = line.IndexOf('(', spaceidx);
                    int paramend = line.LastIndexOf(')');

                    functype = line.Substring(0, spaceidx);
                    funcname = line.Substring(spaceidx + 1, paramstart - spaceidx - 1);
                    funcparams = line.Substring(paramstart + 1, paramend - (paramstart + 1));
                    funcstartline = l;
                }

                if ((bracedepthlast == 1) && (bracedepth == 0))
                {
                    //function just ended.. record it
                    int funclength = l - funcstartline;

                    ScriptFunction fun = new ScriptFunction();
                    fun.File = this;
                    fun.StartLine = funcstartline;
                    fun.EndLine = l;
                    fun.Length = funclength;
                    fun.Name = funcname;
                    fun.ReturnType = functype;
                    fun.Params = funcparams;
                    res.Add(fun);
                }


                bracedepthlast = bracedepth;
            }


            return res;
        }

        private Dictionary<string, ScriptFunction> GetFunctionMap(List<ScriptFunction> funcs)
        {
            Dictionary<string, ScriptFunction> res = new Dictionary<string, ScriptFunction>();
            foreach (ScriptFunction func in funcs)
            {
                if (!res.ContainsKey(func.Name))
                {
                    res.Add(func.Name, func);
                }
            }
            return res;
        }
    }

    public class ScriptFunction
    {
        public ScriptFile File { get; set; }
        public int StartLine { get; set; }
        public int EndLine { get; set; }
        public int Length { get; set; }
        public string Name { get; set; }
        public string ReturnType { get; set; }
        public string Params { get; set; }
        public string NewName { get; set; }
        public List<ScriptFunctionDependency> AllDependencies { get; set; }
        public List<ScriptFunctionDependency> LocalDependencies { get; set; }
        public List<ScriptFunctionReference> References { get; set; }

        public void LoadDependenciesAndReferences()
        {
            if (File.FileLines == null) return;// File.Load();

            AllDependencies = new List<ScriptFunctionDependency>();
            LocalDependencies = new List<ScriptFunctionDependency>();

            for (int i = StartLine + 1; i <= EndLine; i++)
            {
                string line = File.FileLines[i];

                for (int ci = 0; ci < line.Length; ci++)
                {
                    char c = line[ci];

                    switch (c)
                    {
                        case '(':

                            ScriptFunctionDependency dep = new ScriptFunctionDependency();
                            int closei = FindCloseBracket(ci, line);
                            dep.Function = this;
                            dep.Name = GetFunctionName(ci, line);
                            dep.Params = (closei > (ci + 1)) ? line.Substring(ci + 1, closei - ci - 1) : "";
                            dep.Line = i;
                            dep.Char = ci - ((dep.Name != null) ? dep.Name.Length : 0);

                            string lname = dep.Name.ToLower();
                            bool nameok = true;
                            switch (lname)
                            {
                                case null:
                                case "":
                                case "if": //ignore if, switch, empty string, etc
                                case "for":
                                case "while":
                                case "switch":
                                    nameok = false;
                                    break;
                            }
                            if (nameok)
                            {
                                AllDependencies.Add(dep);



                                //this works by pushing dependencies as references to found functions in the file

                                ScriptFunction sf;
                                if (File.FunctionMap.TryGetValue(dep.Name, out sf))
                                {
                                    ScriptFunctionReference reff = new ScriptFunctionReference(this, dep);
                                    sf.References.Add(reff);

                                    LocalDependencies.Add(dep);
                                }
                            }

                            break;

                    }
                }
            }

        }

        public static int FindCloseBracket(int ci, string line)
        {
            int depth = 0;
            for (int i = ci; i < line.Length; i++)
            {
                switch (line[i])
                {
                    case '(':
                        depth++;
                        break;
                    case ')':
                        depth--;
                        if (depth == 0)
                        {
                            return i;
                        }
                        break;
                }
            }
            return ci;
        }

        public static string GetFunctionName(int ci, string line)
        {
            //ci should be the index of the open bracket

            int endindex = ci - 1;
            int startindex = 0;
            bool charfound = false;
            for (int i = endindex; i >= 0; i--)
            {
                bool breakout = false;
                char c = line[i];
                switch (c)
                {
                    case '(': //we're at the beginning of a function call.. id starts here
                    case ')': //(shouldn't really happen..)
                    case '{': //(shouldn't really happen..) but inside a scope, id starts here
                    case '}': //(shouldn't really happen..)
                    case '[': //inside an array indexer, id starts here
                    case ']': //array indexer just ended.. shouldn't really happen
                    case '~': //someone used the tilde operator...
                    case '!': //not operator, id starts here
                    case '@': //(shouldn't really happen..)
                    case '$': //(shouldn't really happen..)
                    case '%': //mod operator, id starts here
                    case '^': //hat operator? id starts here
                    case '&': //reference operator or and operator, start an id here
                    case '*': //multiplication operator, id start here
                    case '+': //addition operator, id starts here
                    case '=': //assignment operator or equality comparison, id start here
                    case '|': //or operator, id starts here
                    case '\\': //(shouldn't really happen..)
                    case ',': //comma, next parameter, id start here
                    case '.': //dot operator. probably should ignore this... for now start id here
                    case '<': //less than operator, id starts here
                    case '>': //greater than operator, id starts here
                    case '/': //divide operator, id starts here
                    case '?': //selector, id starts here
                    case ';': //end of statement, id start here
                    case '\'': //single quote, shouldn't happen
                    case '\"': //double quote, shouldn't happen
                        startindex = i + 1;
                        breakout = true;
                        break;
                    case '\t': //tab, id starts here
                    case ' ': //space, id starts here
                        if (charfound)
                        {
                            startindex = i + 1;
                            breakout = true;
                        }
                        else
                        {
                            endindex--; //avoid reading whitespace as the name...
                        }
                        break;
                    case ':':
                        if (i <= 0 || (i >= (line.Length - 1)) || ((line[i - 1] != ':') && (line[i + 1] != ':')))
                        {
                            //not a double colon, must be selector - id start here
                            startindex = i + 1;
                            breakout = true;
                        }
                        break;
                    default:
                        charfound = true;
                        break;
                }
                if (breakout)
                {
                    break;
                }
            }

            string res = "";

            if (endindex > startindex)
            {
                res = line.Substring(startindex, endindex - startindex + 1);
            }

            return res;
        }

        public void RenameDeclaration(string newname)
        {
            //just changes the function name declaration line

            if (File == null) return;
            if (File.FileLines == null) return;

            string line = File.FileLines[StartLine];

            int idx = line.IndexOf(Name);
            int endi = idx + Name.Length;

            string s1 = (idx > 0) ? line.Substring(0, idx) : string.Empty;
            string s2 = (endi < line.Length) ? line.Substring(endi) : string.Empty;

            string newline = s1 + newname + s2;

            File.FileLines[StartLine] = newline;
        }


        public override string ToString()
        {
            return (File != null) ? (File.Name + "::" + Name) : Name;
        }


        public string FunctionText
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                if ((File != null) && (File.FileLines != null))
                {
                    for (int i = StartLine; i <= EndLine; i++)
                    {
                        sb.AppendLine(File.FileLines[i]);
                    }
                }
                return sb.ToString();
            }
        }

        public string FunctionBody
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                if ((File != null) && (File.FileLines != null))
                {
                    for (int i = StartLine + 1; i <= EndLine; i++)
                    {
                        sb.AppendLine(File.FileLines[i]);
                    }
                }
                return sb.ToString();
            }
        }
    }

    public class ScriptFunctionDependency
    {
        public ScriptFunction Function { get; set; }
        public string Name { get; set; }
        public string Params { get; set; }
        public int Line { get; set; }
        public int Char { get; set; }


        public void Rename(string newname)
        {
            if (Function == null) return;
            if (Function.File == null) return;
            if (Function.File.FileLines == null) return;

            string line = Function.File.FileLines[Line];

            if (Char >= line.Length) return;

            int endi = Char + Name.Length;

            string s1 = (Char > 0) ? line.Substring(0, Char) : string.Empty;
            string s2 = (endi < line.Length) ? line.Substring(endi) : string.Empty;

            string newline = s1 + newname + s2;

            Function.File.FileLines[Line] = newline;


            //since this line may have changed length, need to update any other dependencies on this line...
            int lendiff = newname.Length - Name.Length;
            foreach (ScriptFunctionDependency dep in Function.AllDependencies)
            {
                if ((dep.Line == Line) && (dep.Char > Char))
                {
                    dep.Char += lendiff; //offset the char to account for it.
                }
            }

            Name = newname;
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public class ScriptFunctionReference
    {
        public ScriptFunction Function { get; set; }
        public string Name { get; set; } //name of the function that this reference is in
        public string RefName { get; set; } //name of the function that this reference is to
        public string Params { get; set; }
        public int Line { get; set; }
        public int Char { get; set; }

        public ScriptFunctionReference(ScriptFunction func, ScriptFunctionDependency dep)
        {
            Function = func;
            Name = func.Name;
            RefName = dep.Name;
            Params = dep.Params;
            Line = dep.Line;
            Char = dep.Char;
        }
        public ScriptFunctionReference(ScriptFunction func, int line, int charr, string refname, string paramss)
        {
            Function = func;
            Name = func.File.Name + "::" + func.Name;
            RefName = refname;
            Params = paramss;
            Line = line;
            Char = charr;
        }


        public void Rename(string name, string newname)
        {
            //almost copy of ScriptFunctionDependency.Rename

            if (Function == null) return;
            if (Function.File == null) return;
            if (Function.File.FileLines == null) return;

            string line = Function.File.FileLines[Line];

            if (Char >= line.Length) return;

            int endi = Char + name.Length;

            string s1 = (Char > 0) ? line.Substring(0, Char) : string.Empty;
            string s2 = (endi < line.Length) ? line.Substring(endi) : string.Empty;

            string newline = s1 + newname + s2;

            Function.File.FileLines[Line] = newline;

        }

        public override string ToString()
        {
            return Name + ": line " + Line.ToString() + ", char " + Char.ToString();
        }
    }


    public class ScriptFunctionMatch
    {
        public string Name { get; set; }
        public string FileName { get; set; }
        public int StartLine { get; set; }
        public int EndLine { get; set; }
        public double Match { get; set; }

        public ScriptFunctionMatch(ScriptFunction found, ScriptFunction comp)
        {
            Name = found.Name;
            FileName = found.File.Name;
            StartLine = found.StartLine;
            EndLine = found.EndLine;


            Match = 0.0;

            if (found.Length != comp.Length) return;

            if (found.File.FileLines == null)
            {
                found.File.Load(); //shouldn't really happen
            }
            if (comp.File.FileLines == null)
            {
                comp.File.Load(); //shouldn't really happen
            }


            string compfuncd = comp.Name + "("; //to allow matching recursive functions

            double matchtot = 0.0;
            for (int i = 1; i < found.Length; i++) //skip the declaration line
            {
                int foundi = found.StartLine + i;
                int compi = comp.StartLine + i;
                string foundl = found.File.FileLines[foundi].Replace(found.Name + "(", compfuncd); //match recursion...
                string compl = comp.File.FileLines[compi];

                double lmatch = StringMatch(foundl, compl);

                matchtot += lmatch;
            }

            Match = 100.0 * matchtot / ((double)(found.Length - 1));
        }


        private double StringMatch(string a, string b)
        {
            int cmatch = 0;
            int clen = Math.Min(a.Length, b.Length);
            int ctot = Math.Max(a.Length, b.Length);
            for (int i = 0; i < clen; i++)
            {
                if (a[i] == b[i]) cmatch++;
            }
            return ((double)cmatch) / ((double)ctot);
        }

    }

    public class ScriptFunctionHash
    {
        public uint Hash { get; set; }
        public int Lines { get; set; }
    }

    public class ScriptHash
    {
        public ScriptFile File { get; set; }
        public string HashStr { get; set; }
        public int Line { get; set; }
        public int Char { get; set; }
        public override string ToString()
        {
            return string.Format("{0}   ({1} : {2})", HashStr, File.Name, Line);
        }
    }

    public class ScriptChange
    {
        public ScriptFile File { get; set; }
        public int LineNum { get; set; }
        public string LineBefore { get; set; }
        public string LineAfter { get; set; }
    }

    public class ScriptCoord
    {
        public ScriptFile File { get; set; }
        public int Line { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public double W { get; set; } //could be a radius, not used in score calcs

        public double Score
        {
            get
            {
                double xy2 = X * X + Y * Y;
                double z2 = Z * Z;
                double v = xy2 - z2 * 0.01;

                double intthresh = 20.0;
                double twodthresh = 500.0;
                double negzbias = xy2 * 0.1;
                double minx = -5700.0;
                double maxx = 6700.0;
                double miny = -4000.0;
                double maxy = 8400.0;
                double minz = -500.0;
                double maxz = 2000.0;

                double xfrac = (X - Math.Floor(X));
                double yfrac = (Y - Math.Floor(Y));
                double zfrac = (Z - Math.Floor(Z));

                if ((X == 0.0) || (Y == 0.0))
                {
                    v = 0.0; //any value of exactly 0 isn't what we're after really
                }
                else if ((X < minx) || (X > maxx) || (Y < miny) || (Y > maxy) || (Z < minz) || (Z > maxz))
                {
                    v = 0.0; //coord is out of range.
                }
                else if ((Z == 0.0) && (xy2 < twodthresh))
                {
                    v = 0.0; //when z is 0, maybe we got a 2D point? otherwise not interested
                }
                else if ((v - Math.Floor(v)) == 0.0)
                {
                    v = 0.0; //ended up with an integer value... means all were integers, can't really be an interesting coord!
                }
                else if ((xfrac == 0.0) && (Math.Abs(X) < intthresh))
                {
                    v = 0.0; //small integer values are no good...
                }
                else if ((yfrac == 0.0) && (Math.Abs(Y) < intthresh))
                {
                    v = 0.0; //small integer values are no good...
                }
                else if ((zfrac == 0.0) && (Math.Abs(Z) < intthresh) && (Z != 0.0))
                {
                    v = 0.0; //small integer values are no good... (but 0 might be OK for 2D point)
                }
                else if ((xfrac == 0.0) && (yfrac == 0.0) && (zfrac == 0.0))
                {
                    v *= 0.01; //all values are integers. not a very interesting coordinate...
                }
                else if (Z < 0.0)
                {
                    v += Z * Math.Abs(Z) * negzbias; //negative Z values are generally bad. except if we're looking below sea level...
                }

                double sc = Math.Max(v, 0.0);
                return Math.Sqrt(sc);
            }
        }

        public ScriptCoord(ScriptFile file, int line, List<double> vals, int offset = 0)
        {
            File = file;
            Line = line;
            X = (vals.Count > (0 + offset)) ? vals[0 + offset] : 0.0;
            Y = (vals.Count > (1 + offset)) ? vals[1 + offset] : 0.0;
            Z = (vals.Count > (2 + offset)) ? vals[2 + offset] : 0.0;
            W = (vals.Count > (3 + offset)) ? Math.Min(Math.Max(vals[3 + offset], 0.0), 500.0) : 0.0;
            if (W == 500.0) W = 0.0;
        }


        public double DistanceTo(double px, double py, double pz, bool use3d, bool ignoresign)
        {
            double dx = X - px;
            double dy = Y - py;
            double dz = Z - pz;

            if (ignoresign)
            {
                dx = Math.Abs(X) - Math.Abs(px);
                dy = Math.Abs(Y) - Math.Abs(py);
                dz = Math.Abs(Z) - Math.Abs(pz);
            }

            if (use3d)
            {
                return Math.Sqrt(dx * dx + dy * dy + dz * dz);
            }
            else
            {
                return Math.Sqrt(dx * dx + dy * dy);
            }
        }

        public Vec3D GetVec3D()
        {
            return new Vec3D(X, Y, Z);
        }

        public string GetOutputString()
        {
            if (W > 0.0)
            {
                return string.Format("{0}, {1}, {2}, {3}:{4}  Rad:{5}", X, Y, Z, File.Name, Line + 1, W);
            }
            else
            {
                return string.Format("{0}, {1}, {2}, {3}:{4}", X, Y, Z, File.Name, Line + 1);
            }
        }

        public override string ToString()
        {
            return string.Format("{0}:{1}: {2}, {3}, {4}  [{5}]   ({6})", File.Name, Line, X, Y, Z, W, Score);
        }

    }

    public struct Vec3D
    {
        public double X;
        public double Y;
        public double Z;

        public Vec3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static bool operator ==(Vec3D left, Vec3D right)
        {
            return (left.X == right.X) && (left.Y == right.Y) && (left.Z == right.Z);
        }
        public static bool operator !=(Vec3D left, Vec3D right)
        {
            return (left.X != right.X) || (left.Y != right.Y) || (left.Z != right.Z);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Vec3D)) return false;
            return (this == ((Vec3D)obj));
        }

        public override int GetHashCode()
        {
            int hashcode = 0;
            hashcode ^= X.GetHashCode();
            hashcode ^= Y.GetHashCode();
            hashcode ^= Z.GetHashCode();
            return hashcode;
        }

    }

}