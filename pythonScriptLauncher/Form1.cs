using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pythonScriptLauncher
{
    public partial class Form1 : Form
    {
        [DllImport("Shell32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern IntPtr ShellExecute(IntPtr hwnd, string lpOperation, string lpFile, string lpParameters, string lpDirectory, int nShowCmd);

        public Form1()
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // ShellExecute(this.Handle, "open", "python", "", "", 4);
/*
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "python";
            // start.Arguments = string.Format("{0} {1}", cmd, args);
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    Console.Write(result);
                }
            }
*/
            using (Process compiler = new Process())
            {
                compiler.StartInfo.FileName = "python";
                compiler.StartInfo.Arguments = "downloadImagesMulti.py keywords.xlsx";
                compiler.StartInfo.UseShellExecute = true;
                compiler.StartInfo.RedirectStandardOutput = false;
                compiler.Start();
 /*               
                compiler.StartInfo.FileName = "python";
                compiler.StartInfo.Arguments = "downloadImagesMulti.py test1.xlsx";
                compiler.StartInfo.UseShellExecute = false;
                compiler.StartInfo.RedirectStandardOutput = true;
                compiler.Start();
                Console.WriteLine(compiler.StandardOutput.ReadToEnd());
                compiler.WaitForExit();
 */
            }
        }
    }
}
