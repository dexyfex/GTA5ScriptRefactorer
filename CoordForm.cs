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
    public partial class CoordForm : Form
    {
        private MainForm OwnerForm;
        volatile bool AbortOperation = false;
        bool InProgress = false;


        public CoordForm(MainForm owner)
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

        private void FindButton_Click(object sender, EventArgs e)
        {
            if (InProgress) return;

            Find();
        }

        private void Find()
        {
            AbortOperation = false;
            InProgress = true;

            string scriptfolder = ScriptFolderTextBox.Text;

            string posstr = PositionTextBox.Text;
            double range = (double)RangeUpDown.Value;
            bool use3ddist = Use3dDistCheckBox.Checked;
            bool ignoresign = IgnoreSignCheckBox.Checked;
            double px = 0.0;
            double py = 0.0;
            double pz = 0.0;
            string[] psplit = posstr.Split(',');
            for (int i = 0; i < psplit.Length; i++)
            {
                double val;
                if (double.TryParse(psplit[i].Trim(), out val))
                {
                    switch (i)
                    {
                        case 0: px = val; break;
                        case 1: py = val; break;
                        case 2: pz = val; break;
                    }
                }
            }


            ResultTextBox.Text = string.Empty;


            Task.Run(() =>
            {

                UpdateStatus("Task beginning...");

                DateTime starttime = DateTime.Now;

                List<ScriptCoord> coords = new List<ScriptCoord>();
                Dictionary<Vec3D, List<ScriptCoord>> coorddict = new Dictionary<Vec3D, List<ScriptCoord>>();

                string[] scriptfiles = Directory.GetFiles(scriptfolder);

                foreach (string scriptfile in scriptfiles)
                {
                    if (AbortOperation)
                    {
                        UpdateStatus("Search aborted.");
                        FindComplete(coords, coorddict);
                        return;
                    }

                    string filel = scriptfile.ToLower();
                    if (!(filel.EndsWith(".c") || filel.EndsWith(".c4"))) continue;

                    UpdateStatus("Searching " + scriptfile);

                    ScriptFile sf = new ScriptFile(scriptfile);

                    List<ScriptCoord> filecoords = sf.FindCoordinates();

                    foreach (ScriptCoord coord in filecoords)
                    {
                        double dist = coord.DistanceTo(px, py, pz, use3ddist, ignoresign);
                        if (dist <= range)
                        {
                            coords.Add(coord);

                            Vec3D v3d = coord.GetVec3D();
                            List<ScriptCoord> coordlist;
                            if (!coorddict.TryGetValue(v3d, out coordlist))
                            {
                                coordlist = new List<ScriptCoord>();
                                coorddict.Add(v3d, coordlist);
                            }
                            coordlist.Add(coord);
                        }
                    }



                    //coords.AddRange(filecoords);
                }


                UpdateStatus(string.Format("Find complete. {0} possible coordinates found, {1} unique.", coords.Count, coorddict.Count));
                FindComplete(coords, coorddict);
            });
        }

        private void FindComplete(List<ScriptCoord> coords, Dictionary<Vec3D, List<ScriptCoord>> cdict)
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new Action(() => { FindComplete(coords, cdict); }));
                }
                else
                {
                    InProgress = false;

                    StringBuilder sb = new StringBuilder();

                    if (DeduplicateCheckBox.Checked)
                    {
                        foreach (KeyValuePair<Vec3D, List<ScriptCoord>> kvp in cdict)
                        {
                            int count = kvp.Value.Count;
                            ScriptCoord c = kvp.Value[0];
                            if (count == 1)
                            {
                                sb.AppendLine(c.GetOutputString());
                            }
                            else
                            {
                                sb.AppendLine(string.Format("{0} (+{1} other{2})", c.GetOutputString(), count - 1, count>2?"s":""));
                            }
                        }
                    }
                    else
                    {
                        foreach (ScriptCoord c in coords)
                        {
                            sb.AppendLine(c.GetOutputString());
                        }
                    }

                    ResultTextBox.Text = sb.ToString();

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

    }


}
