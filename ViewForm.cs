using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gta5refactor
{
    public partial class ViewForm : Form
    {

        bool ScrollSelection = false;

        int FindCharStart = 0;

        public ViewForm()
        {
            InitializeComponent();
        }

        private void ViewForm_Load(object sender, EventArgs e)
        {
            FunctionTextBox.SetTabStopWidth(3);
        }

        public void LoadFunction(ScriptFunction func, int linesel, int charsel, int sellen)
        {
            Text = string.Format("{0}::{1}", func.File.Name, func.Name);

            bool loaded = (func.File.FileLines != null);
            if (!loaded)
            {
                func.File.Load();
            }

            int schar = 0;
            int fchar = 0;
            bool selit = false;
            StringBuilder sb = new StringBuilder();
            for (int i = func.StartLine; i <= func.EndLine; i++)
            {
                if (i == linesel)
                {
                    schar = sb.Length;
                }
                sb.AppendLine(func.File.FileLines[i]);
                if (i == linesel)
                {
                    fchar = sb.Length - 1;
                    selit = true;
                }
            }

            FunctionTextBox.Text = sb.ToString();

            if (selit)
            {
                if (sellen > 0)
                {
                    schar += charsel;
                    fchar = schar + sellen;
                }

                //FunctionTextBox.Select(schar, fchar - schar);
                FunctionTextBox.SelectionStart = schar;
                FunctionTextBox.SelectionLength = fchar - schar;
                FunctionTextBox.ScrollToCaret();
                ScrollSelection = true;
            }
            else
            {
                FunctionTextBox.SelectionStart = 0;
                FunctionTextBox.SelectionLength = 0;
            }

            if (!loaded)
            {
                func.File.Unload(); //try save some memory
            }

        }

        private void FunctionTextBox_Enter(object sender, EventArgs e)
        {
            if (ScrollSelection)
            {
                FunctionTextBox.ScrollToCaret();
                ScrollSelection = false;
            }
        }

        private void FindTextBox_TextChanged(object sender, EventArgs e)
        {
            FindCharStart = 0;
            FindNext();
        }

        private void FindNextButton_Click(object sender, EventArgs e)
        {
            FindNext();
        }

        private void FindNext()
        {
            int schar = 0;
            int fchar = 0;
            string find = FindTextBox.Text;

            if (find.Length > 0)
            {
                int found = FunctionTextBox.Text.IndexOf(find, FindCharStart, StringComparison.OrdinalIgnoreCase);
                if (found < 0) //first try missed, try again from the beginning to allow wrap-around find next
                {
                    FindCharStart = 0;
                    found = FunctionTextBox.Text.IndexOf(find, FindCharStart, StringComparison.OrdinalIgnoreCase);
                }
                if (found >= 0)
                {
                    schar = found;
                    fchar = found + find.Length;
                    FindCharStart = fchar;
                }
            }

            FunctionTextBox.SelectionStart = schar;
            FunctionTextBox.SelectionLength = fchar - schar;
            FunctionTextBox.ScrollToCaret();
        }

    }
}
