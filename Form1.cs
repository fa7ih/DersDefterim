using Microsoft.CSharp;
using Microsoft.VisualBasic;
using Microsoft.SqlServer;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DersDefterim
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Text = "";
        }

        public void OpenDlg()
        {
            OpenFileDialog of = new OpenFileDialog();
            if (fastColoredTextBox1.Language == FastColoredTextBoxNS.Language.CSharp)
                of.Filter = "C# File|*.cs|Any File|*.*";
            else if (fastColoredTextBox1.Language == FastColoredTextBoxNS.Language.VB)
                of.Filter = "VB File|*.vb|Any File|*.*";
            else if (fastColoredTextBox1.Language == FastColoredTextBoxNS.Language.HTML)
                of.Filter = "HTML File|*.html|Any File|*.*";
            else if (fastColoredTextBox1.Language == FastColoredTextBoxNS.Language.PHP)
                of.Filter = "PHP File|*.php|Any File|*.*";
            else if (fastColoredTextBox1.Language == FastColoredTextBoxNS.Language.XML)
                of.Filter = "XML File|*.xml|Any File|*.*";
            else if (fastColoredTextBox1.Language == FastColoredTextBoxNS.Language.JS)
                of.Filter = "JS File|*.js|Any File|*.*";
            else if (fastColoredTextBox1.Language == FastColoredTextBoxNS.Language.Lua)
                of.Filter = "Lua File|*.lua|Any File|*.*";
            else
                of.Filter = "Any File|*.*";
            if (of.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(of.FileName);
                fastColoredTextBox1.Text = sr.ReadToEnd();
                sr.Close();
                this.Text = of.FileName;
            }
        }

        public void SaveDlg()
        {
            SaveFileDialog of = new SaveFileDialog();
            if (fastColoredTextBox1.Language == FastColoredTextBoxNS.Language.CSharp)
                of.Filter = "C# File|*.cs|Any File|*.*";
            else if (fastColoredTextBox1.Language == FastColoredTextBoxNS.Language.VB)
                of.Filter = "VB File|*.vb|Any File|*.*";
            else if (fastColoredTextBox1.Language == FastColoredTextBoxNS.Language.HTML)
                of.Filter = "HTML File|*.html|Any File|*.*";
            else if (fastColoredTextBox1.Language == FastColoredTextBoxNS.Language.PHP)
                of.Filter = "PHP File|*.php|Any File|*.*";
            else if (fastColoredTextBox1.Language == FastColoredTextBoxNS.Language.XML)
                of.Filter = "XML File|*.xml|Any File|*.*";
            else if (fastColoredTextBox1.Language == FastColoredTextBoxNS.Language.JS)
                of.Filter = "JS File|*.js|Any File|*.*";
            else if (fastColoredTextBox1.Language == FastColoredTextBoxNS.Language.Lua)
                of.Filter = "Lua File|*.lua|Any File|*.*";
            else
                of.Filter = "Any File|*.*";
            if (of.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sr = new StreamWriter(of.FileName);
                sr.Write(fastColoredTextBox1.Text);
                sr.Close();
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Undo();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenDlg();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                StreamWriter sw = new StreamWriter(this.Text);
                sw.Write(fastColoredTextBox1.Text);
                sw.Close();
            }
            catch
            {
                SaveDlg();
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveDlg();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Paste();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Redo();
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.ShowFindDialog();
        }

        private void goToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.ShowGoToDialog();
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.ShowReplaceDialog();
        }

        private void cToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.CSharp;
        }

        private void vBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.VB;
        }

        private void hTMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.HTML;
        }

        private void pHPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.PHP;
        }

        private void jSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.JS;
        }

        private void sQLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.SQL;
        }

        private void lUAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.Lua;
        }

        private void xMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.XML;
        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fastColoredTextBox1.Language == FastColoredTextBoxNS.Language.HTML) 
            {
                HTML h = new HTML(fastColoredTextBox1.Text);
                h.Show();
            }
            else if (fastColoredTextBox1.Language == FastColoredTextBoxNS.Language.CSharp) 
            {
                SaveFileDialog sf = new SaveFileDialog();
                sf.Filter = "Executable File|*.exe";
                string OutPath = "?.exe";
                if (sf.ShowDialog() == DialogResult.OK)
                {
                    OutPath = sf.FileName;
                }
                CSharpCodeProvider codeProvider = new CSharpCodeProvider();
                CompilerParameters parameters = new CompilerParameters(new string[] { "System.dll" });
                parameters.GenerateExecutable = true;
                parameters.OutputAssembly = OutPath;
                string[] sources = { fastColoredTextBox1.Text };
                CompilerResults results = codeProvider.CompileAssemblyFromSource(parameters, sources);
                if (results.Errors.Count > 0)
                {
                    string errsText = "";
                    foreach (CompilerError CompErr in results.Errors)
                    {
                        errsText = "(" + CompErr.ErrorNumber +
                                    ")Line " + CompErr.Line +
                                    ",Column " + CompErr.Column +
                                    ":" + CompErr.ErrorText + "" +
                                    Environment.NewLine;
                    }
                    MessageBox.Show(errsText, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    System.Diagnostics.Process.Start(OutPath);
                }
            }
            else if(fastColoredTextBox1.Language == FastColoredTextBoxNS.Language.VB)
            {
                SaveFileDialog sf = new SaveFileDialog();
                sf.Filter = "Executable File|*.exe";
                string OutPath = "?.exe";
                if (sf.ShowDialog() == DialogResult.OK)
                {
                    OutPath = sf.FileName;
                }
                VBCodeProvider codeProvider = new VBCodeProvider();
                CompilerParameters parameters = new CompilerParameters(new string[] { "System.dll" });
                parameters.GenerateExecutable = true;
                parameters.OutputAssembly = OutPath;
                string[] sources = { fastColoredTextBox1.Text };
                CompilerResults results = codeProvider.CompileAssemblyFromSource(parameters, sources);
                if (results.Errors.Count > 0)
                {
                    string errsText = "";
                    foreach (CompilerError CompErr in results.Errors)
                    {
                        errsText = "(" + CompErr.ErrorNumber +
                                    ")Line " + CompErr.Line +
                                    ",Column " + CompErr.Column +
                                    ":" + CompErr.ErrorText + "" +
                                    Environment.NewLine;
                    }
                    MessageBox.Show(errsText, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    System.Diagnostics.Process.Start(OutPath);
                }
            }
            else
            {
                MessageBox.Show("Bu dosya çalıştırılamıyor");
            }
        }
    }
}
